//
//  XFPropertyController.m
//  XForms
//
//  Created by Nolan Whitaker on 11/15/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFPropertyController.h"

@interface XFPropertyController (PrivateAPI)
	float XF_CONTROL_HEIGHT				= 18.0;
	float XF_COMBOBOX_HEIGHT			= 22.0;
	float XF_CONTROL_LABEL_ORIGIN_X		=  5.0;
	float XF_CONTROL_VALUE_ORIGIN_X		= 90.0;
	float XF_CONTROL_VALUE_WIDTH		= 90.0;
	float XF_COMBOBOX_WIDTH 			= 95.0;
	float XF_CONTROL_LABEL_WIDTH		= 90.0;
	float XF_CONTROL_VERTICAL_SPACING	=  2.0;
	float XF_FONT_SIZE					= 9.0;
	float XF_CONTROL_ORIGIN_Y			= 50;
	#define XF_TAG_ORIGIN_X		2
	#define XF_TAG_ORIGIN_Y		4
	#define XF_TAG_SIZE_WIDTH	6
	#define XF_TAG_SIZE_HEIGHT	8
	#define XF_TAG_PROPERTIES	9
@end



@implementation XFPropertyController

- (id)init
{
	self = [super init];
	if( self ) {
		propertyList = [[NSMutableArray alloc] init];
		viewPropertyList = [[NSMutableArray alloc] init];		
	}
	return self;
}

- (void)setFormDocument:(id)newFormDocument
{	
	formDocument = [newFormDocument retain];	
}

- (void)awakeFromNib
{
	[elementBox setHidden:YES];
}

- (void)setDocumentDictionary:(NSDictionary *)dict
{
	NSString		*key;
	NSEnumerator	*keyEnum;
	NSDictionary	*comboBoxLookups;
	id				valueTransformer;

	NSLog(@"XFPropertyController -setDocumentDictionary ");
	documentDict = [dict retain];

	// set up value transformers
	valueTransformers = [[NSMutableArray alloc] init];
	valueTransformerNames = [[NSMutableArray alloc] init];
	
	// NSNumber (float) to NSString value transformer
	valueTransformer = [[[XFNumValueTransformer alloc] init] autorelease];
	[NSValueTransformer setValueTransformer:valueTransformer 
									forName:@"XFNumValueTransformer"];
	[valueTransformerNames addObject:@"XFNumValueTransformer"];
	[valueTransformers addObject:valueTransformer];
	
	// value transformers for combo boxes
	comboBoxLookups = [documentDict valueForKey:@"ComboBoxLookups"];
	keyEnum = [comboBoxLookups keyEnumerator];
	
	while( key = [keyEnum nextObject] ) {
		[valueTransformerNames addObject:key];
		valueTransformer = [[[XFCBValueTransformer alloc] init] autorelease];
		[valueTransformer setLookupTable:[comboBoxLookups valueForKey:key]];
		NSLog(@"value Transformer key=%@", key);
		[NSValueTransformer setValueTransformer:valueTransformer
										forName:key];
		[valueTransformers addObject:valueTransformer];
	}
}

- (void)setForm:(XFForm *)form
{
	NSSize			size;
	NSString		*key;
	NSEnumerator	*keyEnum;
	NSDictionary	*sizeUnitDict;
	
	NSLog(@"XFPropertyController -setForm ");
	// set handle to XFForm instance
	formData = [form retain];
	
	// update Properties Panel with values from dictionary
    size = NSMakeSize( [[form valueForKey:@"pageWidth"] floatValue],
					   [[form valueForKey:@"pageHeight"] floatValue] );
	[pageHeight setStringValue:[NSString stringWithFormat:@"%f", size.height]];
    [pageWidth setStringValue:[NSString stringWithFormat:@"%f", size.width]];
	
	[formName setStringValue:[form valueForKey:@"formName"]];
    [formVersion setStringValue:[form valueForKey:@"formVersion"]];
	
	// add rows to Units combo box for allowed values & select row with current value
	if( documentDict ) {
		[units setUsesDataSource:NO];
		sizeUnitDict = [documentDict valueForKey:@"UnitConversionToPoints"];
		keyEnum = [sizeUnitDict keyEnumerator];
		while( key=[keyEnum nextObject] ) {
			[units addItemWithObjectValue:key];
		}
	} else {
		// documentDict was not initialized, so add default value
		[units addItemWithObjectValue:@"points (pt)"];
	}
	[units selectItemWithObjectValue:[form valueForKey:@"pageSizeUnit"]];
	[units scrollItemAtIndexToVisible:[units indexOfSelectedItem]];

}

- (void)setSelectedElementView:(XFElementView *)elementView
{
	[selectedElementView release];
	selectedElementView = [elementView retain];
	[self setSelectedElement:[elementView dataElement]];
}

- (NSTextField *)createLabelWithText:(NSString *)labelText
							  inRect:(NSRect)bounds
{
	id		control;
	
	// create text label for control
	control = [[NSTextField alloc] initWithFrame:bounds];
	[control setEnabled:YES];
	[control setEditable:NO];
	[control setBordered:NO];
	[control setHidden:NO];
	[control setStringValue:labelText];
	
	[control setBackgroundColor:[NSColor windowBackgroundColor]];
	
	return control;
}


- (id)createPropertyNamed:(NSString *)key
					 ofType:(NSString *)className
					 inRect:(NSRect)bounds
{
	id					control;
	int					count;
	int					idx;
	int					valueTransformerIndex;
	NSArray				*lookupValues;
	NSMutableString		*bindKeyPath;
	NSDictionary		*bindOptions;
		
	//NSLog(@".creating %@ property control ofType:%@", key, className);		
	
	// create text label for control
	bounds.origin.x = XF_CONTROL_LABEL_ORIGIN_X;
	control = [self createLabelWithText:key 
								 inRect:bounds];
	[control setFont:[NSFont systemFontOfSize:XF_FONT_SIZE]];
	[elementPropertyView addSubview:control];
	[control setTag:[propertyList count] + XF_TAG_PROPERTIES ];
	[propertyList addObject:control];
	
	// set bindings to update elementPropertyView when an underlying XFElement 
	// data field changes value
	bindKeyPath = [[NSMutableString alloc] init];
	[bindKeyPath appendString:@"elementDict.elementTypeDict.xfMutableProperties."];
	[bindKeyPath appendString:key];	
	
	//NSLog(@" bindKeyPath='%@'", bindKeyPath);
	
	if( [className compare:@"NSCFBoolean"] == NSOrderedSame ) {		
		
		bounds.size = NSMakeSize(XF_CONTROL_VALUE_WIDTH, XF_CONTROL_HEIGHT);
		bounds.origin.x = XF_CONTROL_VALUE_ORIGIN_X;
		control = [[NSButton alloc] initWithFrame:bounds];
		[control setButtonType:NSSwitchButton];
		[control setImagePosition:NSImageLeft];
		[control setTitle:@""];
		[control setBordered:NO];		

		[control bind:@"state"
			 toObject:selectedElement
		  withKeyPath:[NSString stringWithString:bindKeyPath]
			  options:NULL];

		// setup target action of control to inform XFPropertyController of any changes
		// to the control's value
		// -- send updates to the XFElement directly since NSDictionary does not support
		//    Cocoa bindings 
		[bindKeyPath release];
		[control setTarget:self];
		[control setAction:@selector(switchButtonAction:)];
	}

	if( [className compare:@"NSCFNumber"] == NSOrderedSame ) {
		// assume this property is a lookup table index -- saves time if correct
		bounds.size = NSMakeSize(XF_COMBOBOX_WIDTH, XF_COMBOBOX_HEIGHT);
		bounds.origin.x = XF_CONTROL_VALUE_ORIGIN_X;
		bounds.origin.y -= 3.0;
		control = [[NSComboBox alloc] initWithFrame:bounds];
		[control setUsesDataSource:NO];

		// check document dictionary to see if key is to a lookup
		lookupValues = nil;
		count = [valueTransformerNames count];
		for( idx=0; idx < count; idx++ ){
			if( [[valueTransformerNames objectAtIndex:idx] isEqual:key] ) {
				valueTransformerIndex = idx;
				lookupValues = [[valueTransformers objectAtIndex:idx] lookupTable];
				break;
			}
		}
		if( lookupValues ) {
			// get list of properties where value is the index of a combo box rather
			// than an actual number value
			count = [lookupValues count];
			for( idx=0; idx < count; idx++ ) {
				[control addItemWithObjectValue:[lookupValues objectAtIndex:idx]];
			}

			// bind control (combo box) to XFElement instance using a value transformer
			bindOptions = [NSDictionary dictionaryWithObject:key 
													  forKey:@"NSValueTransformerName"];
			[control bind:@"stringValue" 
				 toObject:selectedElement 
			  withKeyPath:bindKeyPath
				  options:bindOptions];
			[control selectItemAtIndex:
							[[selectedElement valueForKeyPath:bindKeyPath] intValue]];
			[control setEditable:NO];
			
			// setup target action of control to inform XFPropertyController of any changes
			// to the control's value
			// -- send updates to the XFElement directly since NSDictionary does not support
			//    Cocoa bindings 
			[[NSNotificationCenter defaultCenter] 
					addObserver:self
					   selector:@selector(comboBoxSelection:) 
						   name:NSComboBoxSelectionDidChangeNotification
						 object:control];
			
			NSLog(@".bindings set");
		} else {
			// property value is just a number (wrong assumption so release and re-alloc)
			[control release];
			bounds.size = NSMakeSize(XF_CONTROL_VALUE_WIDTH, XF_CONTROL_HEIGHT);
			bounds.origin.y += 3.0;
			control = [[NSTextField alloc] initWithFrame:bounds];
			[control setBordered:YES];
			[control setEditable:YES];
			[control setBezelStyle:NSTextFieldRoundedBezel];
			
			[control bind:@"floatValue" 
				 toObject:selectedElement 
			  withKeyPath:bindKeyPath
				  options:NULL];
			
			// setup target action of control to inform XFPropertyController of any changes
			// to the control's value
			// -- send updates to the XFElement directly since NSDictionary does not support
			//    Cocoa bindings 
			[[NSNotificationCenter defaultCenter] 
					addObserver:self
					   selector:@selector(numberAction:) 
						   name:NSControlTextDidChangeNotification
						 object:control];			
		}
				
		
	}
	if( [className compare:@"NSCFString"] == NSOrderedSame ) {
		bounds.size = NSMakeSize(XF_CONTROL_VALUE_WIDTH, XF_CONTROL_HEIGHT);
		bounds.origin.x = XF_CONTROL_VALUE_ORIGIN_X;
		
		// create control and set desired properties for properties panel
		control = [[NSTextField alloc] initWithFrame:bounds];
		[control setBordered:YES];
		[control setEditable:YES];
		[control setBezelStyle:NSTextFieldRoundedBezel];
		
		// bind control to XFElement dictionary element
		[control bind:@"stringValue"
			 toObject:selectedElement
		  withKeyPath:[NSString stringWithString:bindKeyPath]
			  options:NULL];
		
		// setup target action of control to inform XFPropertyController of any changes
		// to the control's value
		// -- send updates to the XFElement directly since NSDictionary does not support
		//    Cocoa bindings 
		[[NSNotificationCenter defaultCenter] 
					addObserver:self
					   selector:@selector(stringAction:) 
						   name:NSControlTextDidChangeNotification
						 object:control];

	}
	
	// set common properties
	if( control ) {
		[control setEnabled:YES];
		[control setHidden:NO];
		[control setFont:[NSFont systemFontOfSize:XF_FONT_SIZE]];
		[control setTag:[propertyList count] + XF_TAG_PROPERTIES ];
		[propertyList addObject:control];
		[elementPropertyView addSubview:control];
		[elementPropertyView setNeedsDisplay:YES];
	}
	
	return control;
}

- (void)bindIBOutletsToElementFrame
{
	NSString *bindKeyPath;
	NSDictionary *bindOptions;
	
	// origin x component
	bindKeyPath = [self keyPathFromTag:[elementX tag]];
	[elementX setFloatValue:[[selectedElement valueForKeyPath:bindKeyPath] floatValue]];
	
	// bind model to view
//	[elementX bind:@"floatValue" 
//		  toObject:selectedElement 
//	   withKeyPath:bindKeyPath
//		   options:NULL];
	
	// set method to update model when view changes
	[[NSNotificationCenter defaultCenter] addObserver:self
											 selector:@selector(stringAction:) 
												 name:NSControlTextDidChangeNotification
											   object:elementX];

	// origin y component
	bindKeyPath = [self keyPathFromTag:[elementY tag]];
	[elementY setFloatValue:[[selectedElement 
			valueForKeyPath:bindKeyPath] floatValue]];
	
	// bind model to view
//	[elementY bind:@"floatValue" 
//		  toObject:selectedElement 
//	   withKeyPath:bindKeyPath
//		   options:NULL];
	
	// set method to update model when view changes
	[[NSNotificationCenter defaultCenter] addObserver:self
											 selector:@selector(stringAction:) 
												 name:NSControlTextDidChangeNotification
											   object:elementY];
	
	// Size Width component
	bindKeyPath = [self keyPathFromTag:[elementWidth tag]];
	[elementWidth setFloatValue:[[selectedElement 
									valueForKeyPath:bindKeyPath] floatValue]];
	
	// bind model to view
//	[elementWidth bind:@"floatValue" 
//			  toObject:selectedElement 
//		   withKeyPath:bindKeyPath
//			   options:NULL];
	
	// set method to update model when view changes
	[[NSNotificationCenter defaultCenter] addObserver:self
											 selector:@selector(stringAction:) 
												 name:NSControlTextDidChangeNotification
											   object:elementWidth];

	// Size Height component
	bindKeyPath = [self keyPathFromTag:[elementHeight tag]];
	[elementHeight setFloatValue:[[selectedElement 
									valueForKeyPath:bindKeyPath] floatValue]];
	
	// bind model to view
//	[elementHeight bind:@"floatValue" 
//			   toObject:selectedElement 
//			withKeyPath:bindKeyPath
//				options:NULL];
	
	// set method to update model when view changes
	[[NSNotificationCenter defaultCenter] addObserver:self
											 selector:@selector(stringAction:) 
												 name:NSControlTextDidChangeNotification
											   object:elementHeight];
	
}

- (void)setSelectedElement:(XFElement *)element
{
	NSRect			bounds;
	NSDictionary	*dict;
	NSEnumerator	*keyEnum;
	NSString		*key;
	NSString		*className;
	id				obj;
	
	NSLog(@"XFPropertyController -setSelectedElement");
	
	// remove all controls from elementPropertyView & elementList
	keyEnum = [propertyList objectEnumerator];
	while(obj = [keyEnum nextObject] ) {
		[obj removeFromSuperview];
	}
	[propertyList removeAllObjects];
	[selectedElement release];
	
	selectedElement = [element retain];
	[elementBox setHidden:NO];
	dict = [selectedElement valueForKeyPath:@"elementDict.elementTypeDict.xfMutableProperties"];
	NSAssert( dict, @"Unable to retrieve mutable properties from XFElement");
	
	bounds.origin = NSMakePoint( XF_CONTROL_LABEL_ORIGIN_X, 2.0);
	bounds.size = NSMakeSize( XF_CONTROL_LABEL_WIDTH, XF_CONTROL_HEIGHT );
	[elementPropertyView setBackgroundColor:[NSColor windowBackgroundColor]];
	
	// set actions and bindings for elementView frame IBOutlets
	[self bindIBOutletsToElementFrame];
	
	// iterate through each mutable property and add control to elementPropertyView
	bounds.origin.y = XF_CONTROL_ORIGIN_Y;
	
	keyEnum = [dict keyEnumerator];
	while( key = [keyEnum nextObject] ) {
		obj = [dict valueForKey:key];
		className = [obj className];

		[self createPropertyNamed:[key copy]
						   ofType:[className copy]
						   inRect:bounds];
		bounds.origin.y += bounds.size.height + XF_CONTROL_VERTICAL_SPACING;
	}
	
	NSLog(@" end of setPropertiesForElement");
}

// Properties panel control action and notification methods
// These methods are used to update the model class when values are changed via the 
// properties panel.  NSDictionary does not implement Cocoa Bindings.  
//
// Note that if a value in the model changes, the property panel Controls are updated 
// automatically via Cocoa Bindings.

- (NSString *)keyPathFromTag:(int)tag
{
	NSMutableString *keyPath;
	
	// build XFElement field key
	keyPath = [[NSMutableString alloc] init];	
	// height and width of element are stored in a subdictionary at a higher level
	// in XFElement elementDict
	if( tag < XF_TAG_PROPERTIES ) {
		[keyPath appendString:@"elementDict.viewFrame."];
		switch( tag ) {
			case XF_TAG_ORIGIN_X:
				[keyPath appendString:@"origin.x"];
				break;

			case XF_TAG_ORIGIN_Y:
				[keyPath appendString:@"origin.y"];
				break;

			case XF_TAG_SIZE_HEIGHT:
				[keyPath appendString:@"size.height"];
				break;

			case XF_TAG_SIZE_WIDTH:
				[keyPath appendString:@"size.width"];
				break;
		}
	} else {
		// textfield with name of XFElement property is at index tag-2 in propertyList
		// tag is 1..N, index 0..N-1, and label is the prior control
		if( [[[propertyList objectAtIndex:tag] stringValue] isEqual:@"imageName"] ) {
			[keyPath appendString:@"elementDict.elementTypeDict."];
		} else {
			tag = tag - 1 - XF_TAG_PROPERTIES;
			[keyPath appendString:@"elementDict.elementTypeDict.xfMutableProperties."];
		}
		[keyPath appendString:[[propertyList objectAtIndex:tag] stringValue]];
		
	}
	
	//NSLog(@" keyPath = '%@'", keyPath);
	return [NSString stringWithString:[keyPath autorelease]];
}


/****************************************************************************
 * 
 * Property Panel Control Action Methods
 *	- view changed, so update model
 *
 ****************************************************************************/
- (void)switchButtonAction:(id)sender
{
	int tag;
	
	// build XFElement switch button field key
	tag = [sender tag];
	
	// update value in XFElement
	NSNumber *state = [[NSNumber alloc] initWithBool:[sender state]];
	[selectedElement setValue:[state autorelease]
				   forKeyPath:[self keyPathFromTag:tag]];
	[selectedElementView updateControlPropertiesWithDictionary:[[selectedElement 
		elementDict] valueForKeyPath:@"elementTypeDict.xfMutableProperties"]];
}

- (void)comboBoxSelection:(NSNotification *)aNotification
{
	int		tag;
	id		object;		
	
	object = [aNotification object];
	tag = [object tag];		// tag = index in propertyList
	[selectedElement setValue:[NSNumber numberWithInt:[object indexOfSelectedItem]] 
				   forKeyPath:[self keyPathFromTag:tag]];
	[selectedElementView updateControlPropertiesWithDictionary:[[selectedElement 
				elementDict] valueForKeyPath:@"elementTypeDict.xfMutableProperties"]];
}

- (void)numberAction:(NSNotification *)aNotification
{
	int		tag;
	id		obj;
	float	myFloat;
	NSString *keyPath;
	NSNumber *myNumber;
	NSRect	newFrame;
	
	NSLog(@"numberAction sender = %@", [aNotification object]);
	obj = [aNotification object];
	tag = [obj tag];		// tag = index in propertyList
	keyPath = [self keyPathFromTag:tag];
	
	NSLog(@"numberAction tag = %i, keyPath = '%@', stringValue='%@'",
		  tag, keyPath, [obj stringValue] );

	[[NSScanner scannerWithString:[obj stringValue]] scanFloat:&myFloat];
	
	NSLog(@" myFloat = %f", myFloat);
	myNumber = [[NSNumber alloc] initWithFloat:myFloat];
	NSLog(@" myNumber retainCount = %i, floatValue = %f", 
			[myNumber retainCount], [myNumber floatValue]);
	[selectedElement setValue:[myNumber autorelease]
				   forKeyPath:keyPath];
	
	// update control properties
	[selectedElementView updateControlPropertiesWithDictionary:[[selectedElement 
		elementDict] valueForKeyPath:@"elementTypeDict.xfMutableProperties"]];
}

- (void)stringAction:(NSNotification *)aNotification
{
	int					tag;
	float				fValue;
	NSNumber			*newValue;
	NSRect				newFrame;
	NSSize				ctrlSize;
	NSString			*keyPath;
	NSMutableDictionary *elementDict;
	
	NSLog(@"stringAction sender = %@", [aNotification object]);	
	tag = [[aNotification object] tag];		// tag = index in propertyList
	keyPath = [self keyPathFromTag:tag];
	
	if( tag >= XF_TAG_PROPERTIES ) {		
		[selectedElement setValue:[[aNotification object] stringValue]
					   forKeyPath:keyPath];
		[selectedElementView updateControlPropertiesWithDictionary:[[selectedElement 
			elementDict] valueForKeyPath:@"elementTypeDict.xfMutableProperties"]];
	} else {

		fValue = [[aNotification object] floatValue];
		newValue = [[NSNumber alloc] initWithFloat:fValue];
		[selectedElement setValue:[newValue autorelease]
					   forKeyPath:keyPath];

		// update viewFrame
		newFrame = NSMakeRect( 
			[[selectedElement valueForKeyPath:[self keyPathFromTag:[elementX tag]]] floatValue],
			[[selectedElement valueForKeyPath:[self keyPathFromTag:[elementY tag]]] floatValue],
			[[selectedElement valueForKeyPath:[self keyPathFromTag:[elementWidth tag]]] floatValue],
			[[selectedElement valueForKeyPath:[self keyPathFromTag:[elementHeight tag]]] floatValue] );
				
		// apparently get/set messages sent via Key-Value encoding aren't serialized
		// requesting current values from viewFrame.* gives dirty results
		switch( tag ) {
			case XF_TAG_ORIGIN_X:
				newFrame.origin.x = fValue;
				break;
			case XF_TAG_ORIGIN_Y:
				newFrame.origin.y = fValue;
				break;
			case XF_TAG_SIZE_HEIGHT:
				newFrame.size.height = fValue;
				break;
			case XF_TAG_SIZE_WIDTH:
				newFrame.size.width = fValue;
				break;
			default:
				NSAssert( 1==0, @"Unable to determine tag value of control!");
				break;
		}
		[selectedElementView setViewFrame:newFrame];
		
		// now update the model
		// viewFrame for XFElementView
		[selectedElement setValue:[NSNumber numberWithFloat:newFrame.origin.x] 
					   forKeyPath:@"elementDict.viewFrame.origin.x"];
		[selectedElement setValue:[NSNumber numberWithFloat:newFrame.origin.y] 
					   forKeyPath:@"elementDict.viewFrame.origin.y"];
		[selectedElement setValue:[NSNumber numberWithFloat:newFrame.size.width] 
					   forKeyPath:@"elementDict.viewFrame.size.width"];
		[selectedElement setValue:[NSNumber numberWithFloat:newFrame.size.height] 
					   forKeyPath:@"elementDict.viewFrame.size.height"];
		
		// size for control inside XFElementView
		ctrlSize = [[selectedElementView control] frame].size;
		[selectedElement setValue:[NSNumber numberWithFloat:ctrlSize.width]
					   forKeyPath:@"elementDict.width"];
		[selectedElement setValue:[NSNumber numberWithFloat:ctrlSize.height]
					   forKeyPath:@"elementDict.height"];
		
	}


}
	
- (void)dealloc
{
	[valueTransformerNames removeAllObjects];
	[valueTransformers removeAllObjects];
	[propertyList release];
	[viewPropertyList release];
	[selectedElementView release];
	[selectedElement release];
	[formDocument release];
	[documentDict release];
	[formData release];
	[super dealloc];
}

@end
