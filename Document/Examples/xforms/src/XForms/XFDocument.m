//
//  XFDocument.m
//  XForms
//
//  Primary Controller Class
//
//  Created by Nolan Whitaker on 11/12/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFDocument.h"

@interface XFDocument (PrivateAPI)
	NSString *XFDocumentPlist = @"../plists/XFDocument.plist";
@end

@implementation XFDocument

- (id)init
{
	NSDictionary	*defaultDict;
	NSString		*key;
	NSEnumerator	*keyEnum;
	
    self = [super init];
    if (self) {
		
		NSLog(@"XFDocument -init");
        // Add your subclass-specific initialization here.
        // If an error occurs here, send a [self release] message and return nil.
		defaultDict = [NSDictionary dictionaryWithContentsOfFile:XFDocumentPlist];
		if( defaultDict == nil ) {
			NSLog( @"ERROR: Unable to load property list:'%@'", XFDocumentPlist );
			[self release];
			return nil;
		}
		
		// initialize default value and lookup dictionaries
		documentDict = [[NSDictionary alloc] initWithDictionary:defaultDict
													  copyItems:NO];
		
		elementTypeDict = [[NSDictionary alloc] 
				initWithDictionary:[defaultDict valueForKey:@"ElementTypes"]
						 copyItems:NO];

		elementInfoDict = [[NSDictionary alloc] 
				initWithDictionary:[defaultDict valueForKey:@"ElementInfo"]
						 copyItems:NO];
		
		pageInfoDict = [[NSDictionary alloc] 
				initWithDictionary:[defaultDict valueForKey:@"PageInfo"] 
						 copyItems:NO];
		
		formInfoDict = [[NSDictionary alloc] 
				initWithDictionary:[defaultDict valueForKey:@"FormInfo"] 
						 copyItems:NO];
		
		if( elementTypeDict == nil || elementInfoDict == nil || 
			pageInfoDict == nil || formInfoDict == nil) {
			NSLog( @" Unable to initialize default value and lookup dictionaries!");
			[self release];
			return nil;
		}

		formData = [[XFForm alloc] initWithDictionary:[DeepCopy 
												mutableCopyOfDictionary:defaultDict]];
		NSAssert( formData, @" - Unable to allocate instance of XFForm");
		
		// post notification of initialization to notification center
//		[[NSNotificationCenter defaultCenter] 
//									postNotificationName:XFNOTICEDocumentInitialized 
//												  object:self];
	}
	NSLog(@".XFDocument initialization complete.");
    return self;
}

- (void)awakeFromNib
{
	int			idx;
	int			count;
	id			printMenuItem;
	NSString	*itemTitle;
	NSArray		*docMenuItems;
	
	NSAssert( pageView != nil, @" handle to XFPageView instance is invalid!" );
	[pageView setElementInfoDict:elementInfoDict];
	[pageView setElementTypeDict:elementTypeDict];
	[pageView setFormDocument:self];
	[propertyController setFormDocument:self];
	[propertyController setDocumentDictionary:documentDict];
	
	// set main menu targets to XFDocument
	docMenuItems = [[[[[NSApplication sharedApplication] mainMenu] 
										itemWithTitle:@"File"] submenu] itemArray];
	count = [docMenuItems count];
	for(idx=0; idx < count; idx++) {
		itemTitle = [[docMenuItems objectAtIndex:idx] title];
		if( [itemTitle length] > 5 && 
			[[itemTitle substringToIndex:5] isEqual:@"Print"]		) {
			printMenuItem = [docMenuItems objectAtIndex:idx];			
		}
		
		if( [itemTitle isEqual:@"Export HTML"] ) {
			[[docMenuItems objectAtIndex:idx] setTarget:self];
			[[docMenuItems objectAtIndex:idx] setAction:@selector(exportHTML:)];
		}
		
		if( [itemTitle isEqual:@"Export XML"] ) {
			[[docMenuItems objectAtIndex:idx] setTarget:self];
			[[docMenuItems objectAtIndex:idx] setAction:@selector(exportXML:)];
		}
		
		if( [itemTitle isEqual:@"Export PDF"] ) {
			[[docMenuItems objectAtIndex:idx] setTarget:self];
			[[docMenuItems objectAtIndex:idx] setAction:@selector(exportPDF:)];
		}
	}	
	[printMenuItem setTarget:self];
	
}

// Print Document
- (IBAction)print:(id)sender
{
	NSView				*viewToPrint;
	NSPrintInfo			*printInfo;
	NSPrintOperation	*printOp;
	
	NSRect r;
	r = [[pageView contentView] rectForPage:1];
	NSLog(@"page 1 x=%f, y=%f, height=%f, width=%f", r.origin.x, r.origin.y,
		  r.size.height, r.size.width);
	
	NSLog(@"###################################");
	int i;
	NSArray *views = [pageView subviews];
	for(i=0;i<[views count]; i++){
		NSLog(@"%i: %@", i, [views objectAtIndex:i]);
	}
	
	printInfo = [NSPrintInfo sharedPrintInfo];
	viewToPrint = [pageView contentView];
	printOp = [NSPrintOperation printOperationWithView:viewToPrint 
											 printInfo:printInfo];
	[printOp setShowPanels:YES];
	[printOp runOperation];
}

// PDF Generation
- (void)exportPDF:(id)sender
{
	NSSavePanel *savePanel;
	
	// bring up a save file panel
	savePanel = [NSSavePanel savePanel];
	[savePanel setRequiredFileType:@"PDF"];
	[savePanel beginSheetForDirectory:nil 
								 file:nil 
					   modalForWindow:[pageView window] 
						modalDelegate:self 
					   didEndSelector:@selector(savePDF:returnCode:contextInfo:) 
						  contextInfo:NULL];	
}

- (void)savePDF:(NSSavePanel *)sheet
	 returnCode:(int)code
	contextInfo:(id)contextInfo
{
	NSRect r;
	NSData *data;
	
	if( code==NSOKButton ) {
		r = [[pageView contentView] bounds];
		data = [[pageView contentView] dataWithPDFInsideRect:r];
		[data writeToFile:[sheet filename] atomically:YES];
	}
}	

// XML Generation
- (void)exportXML:(id)sender
{
	NSSavePanel *savePanel;
	
	// bring up a save file panel
	savePanel = [NSSavePanel savePanel];
	[savePanel setRequiredFileType:@"XML"];
	[savePanel beginSheetForDirectory:nil 
								 file:nil 
					   modalForWindow:[pageView window] 
						modalDelegate:self 
					   didEndSelector:@selector(saveXML:returnCode:contextInfo:) 
						  contextInfo:NULL];	
}

- (void)saveXML:(NSSavePanel *)sheet
	  returnCode:(int)code
	 contextInfo:(id)contextInfo
{
	int count;
	int idx;
	NSArray *elementList;
	NSMutableDictionary *xml;
	NSMutableString *elementId;
	NSMutableString *keyPath;
	
	// capture form attributes
	xml = [[NSMutableDictionary alloc] init];
	[xml setValue:[formData valueForKeyPath:@"documentDict"] 
	   forKeyPath:@"FormInfo"];
	
	
	// add each form element
	elementList = [formData elementList];
	count = [elementList count];
	for(idx=0; idx<count; idx++) {
		elementId = [NSMutableString stringWithString:@"Element"];
		[elementId appendString:[[NSNumber numberWithInt:idx] stringValue]];
		[xml setValue:[[elementList objectAtIndex:idx] elementDict]
		   forKeyPath:elementId];
	}
	
	[xml writeToFile:[sheet filename]
		  atomically:YES];
	
}
	

// HTML Generation
- (void)exportHTML:(id)sender
{
	NSSavePanel *savePanel;
	
	// bring up a save file panel
	savePanel = [NSSavePanel savePanel];
	[savePanel setRequiredFileType:@"HTML"];
	[savePanel beginSheetForDirectory:nil 
								 file:nil 
					   modalForWindow:[pageView window] 
						modalDelegate:self 
					   didEndSelector:@selector(saveHTML:returnCode:contextInfo:) 
						  contextInfo:NULL];
	 
}

// generate HTML after getting filename
- (void)saveHTML:(NSSavePanel *)sheet
	  returnCode:(int)code
	 contextInfo:(id)contextInfo
{
	
	int				idx;
	int				elementCount;
	float			yPos;
	float			pageHeight;
	NSArray			*elementList;
	XFElement		*element;
	NSMutableString *htmlPage;
	

	NSLog(@"XFDocument -didEnd");
	
	if( code == NSOKButton ) {
		// create HTML page
		htmlPage = [[NSMutableString alloc] init];
		[htmlPage appendString:@"<HTML>\n"];
		[htmlPage appendString:@"\t<BODY bgcolor=gray><P>\n"];
		[htmlPage appendString:@"\t\t<FORM>\n"];
		
		pageHeight = [[formData valueForKeyPath:@"pageWidth"] floatValue];
		
		// create a white box to mark page boundaries
		[htmlPage appendString:@"<DIV style='position: absolute; top:10px; left: 10px; width: "];
		[htmlPage appendString:[[formData valueForKeyPath:@"pageWidth"] stringValue]];
		[htmlPage appendString:@"px; height: "];
		[htmlPage appendString:[[formData valueForKeyPath:@"pageHeight"] stringValue]];
		[htmlPage appendString:@"px; background-color: white'></DIV>\n"];
		
		elementList = [formData elementList];
		elementCount = [elementList count];
		for( idx=0; idx < elementCount; idx++ ) {
			element = [elementList objectAtIndex:idx];	
			
			[htmlPage appendString:@"<DIV style='position: absolute; top: "];
			
			yPos = [[element valueForKeyPath:@"elementDict.viewFrame.origin.y"] floatValue];
			yPos = pageHeight - yPos - 135.0;		// translate coordinates and subtract rulers
			[htmlPage appendString:[[NSNumber numberWithFloat:yPos] stringValue]];
			[htmlPage appendString:@"px; left: "];
			[htmlPage appendString:[[element 
				valueForKeyPath:@"elementDict.viewFrame.origin.x"] stringValue]];
			[htmlPage appendString:@"px; width: "];
			[htmlPage appendString:[[element 
				valueForKeyPath:@"elementDict.viewFrame.size.width"] stringValue]];
			[htmlPage appendString:@"px; height: "];
			[htmlPage appendString:[[element 
				valueForKeyPath:@"elementDict.viewFrame.size.height"] stringValue]];
			[htmlPage appendString:@"px;'> "];
			
			[htmlPage appendString:[element dataAsHTML]];
			
			[htmlPage appendString:@"</DIV>\n"];
			
		}
				
		[htmlPage appendString:@"\t</BODY></P>\n"];
		[htmlPage appendString:@"</HTML>\n"];
		
//		NSLog(@"HTML\n=========================================\n%@", htmlPage);

		[htmlPage writeToFile:[sheet filename] 
				   atomically:YES];
		[htmlPage release];
	}
	NSLog(@".end of didEnd method");
	
}

// Intercept method call to parent class and grab document file name
//		saveToFile:	is called after the user is presented a file dialog box
//					but before data is archived
- (void)saveToFile:fileName
	 saveOperation:(NSSaveOperationType)saveOperation
		  delegate:(id)delegate
   didSaveSelector:(SEL)aSelector
	   contextInfo:(void *)contextInfo
{
	
	// set NSDocument fileName (fileName includes an absolute path)
	[self setFileName:fileName];
	
	// set formName in XFForm to fileName less path information
	[formData setValue:[self lastComponentOfFileName]
				forKey:@"formName"];

	// pass call on to the parent's method unaltered
	[super saveToFile:fileName
		saveOperation:saveOperation
			 delegate:delegate
	  didSaveSelector:aSelector
		  contextInfo:contextInfo];
}

- (NSString *)windowNibName
{
    // Override returning the nib file name of the document
    // If you need to use a subclass of NSWindowController or if your document supports 
	// multiple NSWindowControllers, you should remove this method and override 
	// -makeWindowControllers instead.
	
    return @"XFDocument";
}

- (void)windowControllerDidLoadNib:(NSWindowController *) aController
{
	int			idx;
	int			count;
	XFElement	*element;	
    
	[super windowControllerDidLoadNib:aController];
    // Add any code here that needs to be executed once the windowController has loaded 
	// the document's window.

	// update pageView to display form elements
	count = [[formData elementList] count];
	for(idx=0; idx < count; idx++ ) {
		element = [[[formData elementList] objectAtIndex:idx] retain];
		[self unarchiveElement:element
						toView:pageView];
	}
	
	// initialize property window
//	[propertyController setDocumentDictionary:[DeepCopy copyOfDictionary:documentDict]];
	[propertyController setForm:formData];
	
}

- (NSData *)dataRepresentationOfType:(NSString *)aType
{
    // Insert code here to write your document from the given data.  You can also choose 
	// to override -fileWrapperRepresentationOfType: or -writeToFile:ofType: instead.
    NSLog(@" -dataRepresentationOfType");
	return [NSKeyedArchiver archivedDataWithRootObject:formData];
}

- (BOOL)loadDataRepresentation:(NSData *)data ofType:(NSString *)aType
{
    // Insert code here to read your document from the given data.  You can also choose 
	// to override -loadFileWrapperRepresentation:ofType: or -readFromFile:ofType: 
	// instead.
	int			count;
	int			idx;
	XFElement	*element;
	
	// load data object representations of XFForm and XFElement
	formData = [[NSKeyedUnarchiver unarchiveObjectWithData:data] retain];
	
	// check for valid unarchive
	if(formData == nil) {
		return NO;
	}
	
    return YES;
}

// create XFElementView instance from an unarchived XFElement and add to subview
- (id)unarchiveElement:(XFElement *)element
				toView:(NSView *)view
{
	NSDictionary	*dict;
	XFElementView	*newElementView;

	NSLog(@"XFDocument unarchiveElement:");
		// get XFElement dictionary for control with given image name
	dict = [element elementDict];
	NSAssert(dict, @"Unable to find dictionary for XFElement in plist!");
	
	// create an XFElementView instance from dictionary
	newElementView = [[XFElementView alloc] initWithDictionary:dict];
	NSAssert( newElementView, @" Unable to instantiate XFElementView from archive!");
	
	// add to subview in XFPageView
	[newElementView setDataElement:element];
	[[pageView contentView] addSubview:newElementView];
	[[pageView pageElements] addObject:newElementView];
	
	[view setNeedsDisplay:YES];

	return newElementView;
}


- (XFElementView *)addElementWithImageName:(NSString *)imageName
									toView:(NSView *)view
								   atPoint:(NSPoint)point
{
	NSRect			bounds;
	NSEnumerator	*keyEnum;
	NSDictionary	*dict;
	NSString		*key;
	NSString		*dictImageName;
	XFElement		*newElement;
	XFElementView	*newElementView;
	NSMutableDictionary	*newElementDict;
	
	NSLog(@"XFDocument addElementWithImageName:%@", imageName);
	
	// get XFElement dictionary for control with given image name
	newElementDict = [[NSMutableDictionary alloc] 
				initWithDictionary:[DeepCopy mutableCopyOfDictionary:elementInfoDict]];
	
	keyEnum = [elementTypeDict keyEnumerator];
	while( (key=[keyEnum nextObject]) ) {
		dict = [elementTypeDict valueForKey:key];	// dictionary for a form element
		dictImageName = [dict valueForKey:@"imageName"];
		if( [dictImageName compare:imageName] == NSOrderedSame ) {
			[newElementDict setValue:[DeepCopy mutableCopyOfDictionary:dict]
							  forKey:@"elementTypeDict"];
			break;
		}
	}
	NSAssert(newElementDict, @"Unable to find dictionary for dragImage in plist!");

	// update origin coordinate in the new element's dictionary
	[newElementDict setValue:[NSNumber numberWithFloat:point.x]
				  forKeyPath:@"viewFrame.origin.x"];
	[newElementDict setValue:[NSNumber numberWithFloat:point.y] 
					 forKeyPath:@"viewFrame.origin.y"];
		
	// create a new XFElement instance
	newElement = [[XFElement alloc] initWithDictionary:newElementDict];
	[formData addXFElement:newElement];
	

	// create a new XFElementView instance using the XFElement created above
	newElementView = [[XFElementView alloc] initWithXFElement:newElement];
		
	// add to subview in XFPageView
	[view addSubview:newElementView];

	// update properties panel
	[propertyController setSelectedElementView:newElementView];
//	[propertyController setSelectedElement:newElement];
	
	return newElementView;
}

- (XFPropertyController *)propertyController
{
	return propertyController;
}

// Add a new page to the document dictionary
- (void)addPage
{
	NSNotificationCenter	*nc;
	NSDictionary			*pageDict;
	
	// 1. increment page count 
	// 2. add a mutable copy of the pageInfoDict to the page list in formDocumentDict
	// 3. send notification of page addition to the notification center
	// 4, return page count
	
	[nc postNotificationName:XFNoticeDocumentAddedPage 
					  object:self 
					userInfo:pageDict];
	
}

- (void)dealloc
{
	[elementTypeDict release];
	[elementInfoDict release];
	[pageInfoDict release];
	[formInfoDict release];
		
	[super dealloc];
}
@end
