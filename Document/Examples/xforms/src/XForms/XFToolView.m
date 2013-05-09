//
//  XFToolView.m
//  XForms
//
//  Created by Nolan Whitaker on 10/31/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFToolView.h"

@interface XFToolView (PrivateAPI)
	NSString *XFToolPanelPlist = @"../plists/XFToolPanel.plist";
@end

@implementation XFToolView

- (id)initWithFrame:(NSRect)frame {
	NSEnumerator	*plistEntry, *toolDictEnum, *toolLocDictEnum;
	NSDictionary	*toolDict, *toolLocDict;
	NSString		*key, *key2, *key3;
	NSString		*imageName;
	NSString		*toolName;
	NSImageView		*newToolImageView;
	NSImage			*toolImage;
	NSPoint			imageLocation;
	NSSize			imageSize;
	NSRect			toolImageBounds;
	id				keyValue;
	
    self = [super initWithFrame:frame];
    if (self) {
		// Retrieve tool list and defaults from plist
		toolPanelDefaults = [NSDictionary 
				dictionaryWithContentsOfFile:XFToolPanelPlist];
		NSAssert(toolPanelDefaults != nil, 
				 @"Unable to load XFToolPallet default property list!");

		// Initialize instance variables and constants		
		plistEntry = [toolPanelDefaults keyEnumerator];
		while( (key = [plistEntry nextObject]) ) {
			// set default instance variables (prefix = "xf")
			if( [key rangeOfString:@"xf"].length > 0 ) {
				keyValue = [toolPanelDefaults valueForKey:key];
				[self setValue:keyValue forKey:key];
			}
		}		
	}
	
	// Resize parent window and XFFormView
//	[self setBounds:NSMakeRect(xfToolViewX,xfToolViewY,xfToolViewHeight,xfToolViewWidth)];
//	[[[self window] contentView] setSize:NSMakeSize(xfToolWindowHeight,xfToolWindowWidth)];

	// Draw tools enumerated in the Tool Pallet plist under the key xfToolList
	plistEntry = [xfToolList keyEnumerator];
	while( (key = [plistEntry nextObject]) ) {
		toolDict = [xfToolList valueForKey:key];
		toolDictEnum = [toolDict keyEnumerator];
		while( (key2 = [toolDictEnum nextObject]) ) {
			//if( [key2 compare:@"imageLocation"] == NSOrderedSame ) {
			//	toolLocDict = [toolDict valueForKey:key2];
			//	toolLocDictEnum = [toolLocDict keyEnumerator];
			//	while( (key3 = [toolLocDictEnum nextObject]) ) {				
			//		if( [key3 compare:@"x"] == NSOrderedSame ) {
			//			keyValue	 = [toolLocDict valueForKey:key3];
			//			imageLocation .x = [keyValue floatValue];
			//		} else	{
			//			keyValue	 = [toolLocDict valueForKey:key3];
			//			imageLocation.y = [keyValue floatValue];
			//		}
			if( [key2 compare:@"imageX"] == NSOrderedSame ) {
				imageLocation.x = [[toolDict valueForKey:key2] floatValue];
			}
			
			if( [key2 compare:@"imageY"] == NSOrderedSame ) {
				imageLocation.y = [[toolDict valueForKey:key2] floatValue];
			}
			
			if( [key2 compare:@"imageWidth"] == NSOrderedSame ) {
				imageSize.width = [[toolDict valueForKey:key2] floatValue];
			}
			
			if( [key2 compare:@"imageHeight"] == NSOrderedSame ) {
				imageSize.height = [[toolDict valueForKey:key2] floatValue];
			}
			
			if( [key2 compare:@"imageName"] == NSOrderedSame ) {
				keyValue = [toolDict valueForKey:key2];
				imageName = keyValue;
			}
		}
		
		// add image view for tool 
		toolImageBounds.origin	= imageLocation;
		toolImageBounds.size	= NSMakeSize( xfToolImageHeight, xfToolImageWidth);
		newToolImageView = [[NSImageView alloc] initWithFrame:toolImageBounds];
		toolImage = [NSImage imageNamed:imageName];
			
		[newToolImageView setImage:toolImage];
		[newToolImageView setImageFrameStyle:NSImageFramePhoto];
		[newToolImageView setImageScaling:NSScaleProportionally];
		if( [imageName compare:@"Pointer"] == NSOrderedSame ) {
			[newToolImageView setEnabled:YES];			
		} else {
			[newToolImageView setEnabled:NO];
		}

	
		[self addSubview:newToolImageView];
		
		[toolImage release];
		[newToolImageView release];
	}
	[self setNeedsDisplay:YES];

    return self;
}

- (void)awakeFromNib
{
	
}

- (void)drawRect:(NSRect)rect {
	[super drawRect:rect];
}

// Register XFToolView as a drag/drop source
- (unsigned int)draggingSourceOperationMaskForLocal:(BOOL)isLocal
{
	return NSDragOperationCopy;
}

- (void)mouseDown:(NSEvent *)event
{
	NSPoint loc;
	int column = -1;
	int row = -1;
	
	// determine which control is selected using event coordinates
	loc = [self convertPoint:[event locationInWindow] 
					fromView:nil];
	NSLog(@"Mouse Down Event at location (%f,%f).", loc.x, loc.y);
	
	// Column 0 has x coordinate range: 2..49
	if(loc.x >=2 && loc.x <=49) column = 0;
	
	// Column 1 has x coordinate range: 51..98
	if(loc.x >=51 && loc.x <=98) column = 1;
	
	// First control starts at y=4 and ends at y=39, spacing = 2
	row = loc.y - 4;
	row = row / 38;
	if( loc.y - (row + 1) * 38  >= 36 ) row = -1;
	
	if( column == 0) {
		switch(row) {
			case 0:
				dragImageName = @"Button";
				break;
			case 1:
				dragImageName = @"RadioButton";
				break;
			case 2:
				dragImageName = @"CheckBox";
				break;
			case 3:
				dragImageName = @"TextField";
				break;
			case 4:
				dragImageName = @"Pointer";
				break;
			default:
				dragImageName = @"";
		}
	} 
	
	if( column == 1) {
		switch(row) {
			case 0:
				dragImageName = @"Table";
				break;
			case 1:
				dragImageName = @"Pikachu";
				break;
			case 2:
				dragImageName = @"Email";
				break;
			case 3:
				dragImageName = @"Web";
				break;
			case 4:
				dragImageName = @"TextLabel";
				break;
			default:
				dragImageName = @"";
		}
	}
}

- (void)writeImageName:(NSString *)imageName
		  toPasteboard:(NSPasteboard *)pb
{
	// Declare pasteboard types
	[pb declareTypes:[NSArray arrayWithObject:NSStringPboardType] 
			   owner:self];
	
	// Copy data to the pasteboard
	[pb setString:imageName forType:NSStringPboardType];
}


- (void)mouseDragged:(NSEvent *)event
{
	NSRect imageBounds;
	NSPasteboard *pb;
	NSImage *controlImage;
	NSPoint loc;
	
	// determine which control is selected using event coordinates
	loc = [self convertPoint:[event locationInWindow] 
					fromView:nil];
	
	NSLog(@"Mouse Dragged Event at location (%f,%f).", loc.x, loc.y);
	
	// Create an image of the control to be dragged
	controlImage = [NSImage imageNamed:dragImageName];
	
	imageBounds.origin = NSMakePoint(0,0);
	imageBounds.size = [controlImage size];
	
//	// draw the control image
//	[controlImage compositeToPoint:imageBounds.origin
//						 operation:NSCompositeCopy];
	
	// drag from tip of the pointer
	loc.y = loc.y - imageBounds.size.height;
	
	// get the pasteboard
	pb = [NSPasteboard pasteboardWithName:NSDragPboard];
	
	// copy image to pasteboard
	[self writeImageName:dragImageName 
			toPasteboard:pb];
	
	// start the drag
	[self dragImage:controlImage 
				 at:loc 
			 offset:NSMakeSize(0,0) 
			  event:event 
		 pasteboard:pb 
			 source:self 
		  slideBack:YES];
	
	[controlImage release];
}


@end
