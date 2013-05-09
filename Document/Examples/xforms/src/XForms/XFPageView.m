//
//  XFPageView.m
//  XForms
//
//  Primary View Class
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFPageView.h"
#import "XFElementView.h"
#import "XFNotices.h"
#import "XFDocument.h"

@implementation XFPageView

- (id)initWithFrame:(NSRect)frame {
	NSDictionary	*docDict;
		
    self = [super initWithFrame:frame];
    if (self) {
		// Register drag and drop type(s)
		[self registerForDraggedTypes: 
			[NSArray arrayWithObject:NSStringPboardType] ];

		// Initialize handles to application dictionaries to nil
		elementTypeDict = nil;
		elementInfoDict = nil;
		selectedElementView = nil;
		formDocument = nil;
		
		// initialize array to hold handles to all XFElement instances on page
		pageElements = [[NSMutableArray alloc] initWithCapacity:50];
		
	}
    return self;
}

- (void)awakeFromNib
{
	NSRect contentBounds;
	
	NSLog(@"XFPageView -awakeFromNib");
	
	// Setup horizontal and vertical rulers
	[self setHasHorizontalRuler:YES];
	[self setHasVerticalRuler:YES];
	[self setRulersVisible:YES];
	
	// setup vertical and horizontal scrollers
	[self setHasVerticalScroller:YES];
	[self setHasHorizontalScroller:YES];
	[self setAutohidesScrollers:YES];
	
	// subtract ruler sizes from view origin
	contentBounds = [[self contentView] bounds];
	contentBounds.origin.x += 38.0;
	contentBounds.origin.y += 49.0;
	[[self contentView] setBounds:contentBounds];
	
	[self setNeedsDisplay:YES];	
}
/*
- (BOOL)knowsPageRange:(NSRange *)rptr
{
	NSLog(@" -knowsPageRange");
	return YES;
}

- (NSRect)rectForPage:(int)pageNum
{
	NSLog(@" -rectForPage:%i",pageNum);
	NSRect r;
	
	r = [[self contentView] bounds];
	
	return r;
}
*/
- (void)drawRect:(NSRect)rect {
	// Drawing code here.
	[super drawRect:rect];
}

- (void)setFormDocument:(id)doc
{
	[formDocument release];
	formDocument = doc;
	[formDocument retain];
}


- (NSMutableArray *)pageElements
{
	return pageElements;
}

- (void)setElementInfoDict:(NSDictionary *)dict
{
	NSLog(@" setElementInfoDict");
	elementInfoDict = [[[NSDictionary alloc] initWithDictionary:[dict copy]] retain];
}

- (void)setElementTypeDict:(NSDictionary *)dict
{
	NSLog(@" setElementTypeDict");
	elementTypeDict = [[[NSDictionary alloc] initWithDictionary:[dict copy]] retain];


}

/************************************************************************************
*
*	XFElement Selection Methods
*
************************************************************************************/
- (void)deselectAllElements
{
	int			count;
	int			idx;
	
	count = [pageElements count];
	for( idx=0; idx<count; idx++ ) {
		[[pageElements objectAtIndex:idx] setSelected:NO];
	}
}

- (void)selectAllElements
{
	int			count;
	int			idx;
		
	count = [pageElements count];
	for( idx=0; idx<count; idx++ ) {
		[[pageElements objectAtIndex:idx] setSelected:YES];
	}	
}

- (int)selectElementsAtPoint:(NSPoint)target
{
	int				count;
	int				idx;
	NSArray			*elementList;
	XFElementView	*elementView;
	
	
	elementList = [self elementsAtPoint:target];
	count = [elementList count];
	for( idx=0; idx<count; idx++ ) {
		// get XFElementView handle from array and send selection message
		elementView = [elementList objectAtIndex:idx];
		[elementView setSelected:YES];
		selectedElementView = elementView;
		
		// send properties panel controller a message to display the selected
		// XFElementView's attributes that are mutable at form design time
		[[formDocument propertyController] setSelectedElementView:elementView];
	}
	[self setNeedsDisplay:YES];
}

- (NSArray *)elementsAtPoint:(NSPoint)target
{
	int				count;
	int				idx;
	NSRect			r;
	XFElementView	*elementView;
	NSMutableArray	*elementsAtPoint;

	elementsAtPoint = [[[NSMutableArray alloc] initWithCapacity:10] autorelease];
	count = [pageElements count];
	for(idx=0; idx < count; idx++) {
		elementView = [pageElements objectAtIndex:idx];
		r = [elementView bounds];
		if(		(target.x >= r.origin.x && target.x <= (r.origin.x + r.size.width)) &&
				(target.y <= r.origin.y && target.y >= r.origin.y - r.size.height) ) {
			[elementsAtPoint addObject:elementView];
		}
	}
	return [NSArray arrayWithArray:elementsAtPoint];
}

/************************************************************************************
*
*		Drag and Drop Registration / Misc Methods
*
************************************************************************************/

- (BOOL)readImageNameFromPasteboard:(NSPasteboard *)pb
{
	NSString	*type;
	
	// Is there a string on the pasteboard
	type = [pb availableTypeFromArray:
		[NSArray arrayWithObject:NSStringPboardType]];
	if( type ) {
		dragImageName = [pb stringForType:NSStringPboardType];
		if( !dragImageName ) {
			dragImageName = @"";
		}
		return YES;
	}
	return NO;
}

- (BOOL)isPoint:(NSPoint)aPoint 
		 inRect:(NSRect)bounds
{
	if( aPoint.x >= bounds.origin.x && 
		aPoint.x <= bounds.origin.x + bounds.size.width &&
		aPoint.y >= bounds.origin.y &&
		aPoint.y <= bounds.origin.y + bounds.size.height   ) {
		
		return YES;
	}
	return NO;
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


/************************************************************************************
 *
 *	Drag Source Methods
 *
 ************************************************************************************/
- (unsigned int)draggingSourceOperationMaskForLocal:(BOOL)isLocal
{	
	// Register as a drag source For Copy, Move, and Delete
	return ( NSDragOperationCopy | NSDragOperationMove | NSDragOperationDelete );
}


- (void)mouseDown:(NSEvent *)event
{
	NSPoint loc;
	
	loc = [self convertPoint:[event locationInWindow] toView:self];
	NSLog(@"XFPageView -mouseDown at:(%f, %f)", loc.x, loc.y);

	// Select XFElement(s) at point
	[self deselectAllElements];
	[self selectElementsAtPoint:loc];
}


/************************************************************************************
*
*	Drag / Drop Destination Methods
*
************************************************************************************/
- (unsigned int)draggingEntered:(id <NSDraggingInfo>)sender
{
	NSLog(@"XFPageView -draggingEntered");

	if( [sender draggingSource] == self ) {
		// dragging within an XFFormView
		NSLog(@"XFPageView -draggingSource");
		return NSDragOperationMove;

	} else {
		NSPasteboard *pb = [sender draggingPasteboard];
		NSString *type = [pb availableTypeFromArray:
			[NSArray arrayWithObject:NSStringPboardType]];
		if(type != nil) {
			[self setNeedsDisplay:YES];
			NSLog(@" NSDragOperationCopy");
			return NSDragOperationCopy;
		}
		
	}
	NSLog(@" NSDragOperationNone");
	return NSDragOperationNone;
}

- (void)draggingExited:(id <NSDraggingInfo>)sender
{
	NSLog(@"XFPageView draggingExited");
	[self setNeedsDisplay:YES];
}

- (BOOL)prepareForDragOperation:(id <NSDraggingInfo>)sender
{
	NSLog(@"XFPageView prepareForDragOperation");
	return YES;
}

- (BOOL)performDragOperation:(id <NSDraggingInfo>)sender
{
	NSLog(@"XFPageView performDragOperation");
	NSPasteboard *pb = [sender draggingPasteboard];
	if( ![self readImageNameFromPasteboard:pb] ) {
		return NO;
	}
	return YES;
}

- (void)concludeDragOperation:(id <NSDraggingInfo>)sender
{
	NSPoint			loc;
	XFElementView	*formElementView;
	
	// Get location of drag operation
	loc = [self convertPoint:[sender draggingLocation] 
					  toView:self];
	NSLog(@"-concludeDragOperation atPoint:(%f,%f)",loc.x, loc.y );

	if( [[sender draggingSource] isEqual:self] ) {
		// Drop Operation from within XFFormView (ie: move/reposition control)
		// Load form element dictionary
		NSLog(@" -concludeDragOperation atPoint:(%f,%f)",loc.x, loc.y );
		
	} else {
		// Conclude drop operation (add 
		formElementView = [formDocument addElementWithImageName:dragImageName 
														 toView:[self contentView]
														atPoint:loc];		
		[pageElements addObject:formElementView];
	}
	
	[self setNeedsDisplay:YES];
}


- (void)dealloc
{
	[formDocument release];
}
@end
