//
//  XFElementView.m
//  XForms
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 Nolan W. Whitaker. All rights reserved.
//

#import "XFElementView.h"

@implementation XFElementView

- (id)initWithFrame:(NSRect)frame {
    self = [super initWithFrame:frame];
    if (self) {
        selectedBorderColor = [NSColor blueColor];
		[selectedBorderColor retain];
		normalBorderColor = [NSColor lightGrayColor];
		[normalBorderColor retain];
    }
    return self;
}

- (id)initWithXFElement:(XFElement *)element
{
	self = [self initWithDictionary:[element elementDict]];
	NSLog(@"XFElementView initWithXFElement");
	dataElement = [element retain];
	
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.size.height] 
							 forKeyPath:@"viewFrame.size.height"];
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.size.width] 
							 forKeyPath:@"viewFrame.size.width"];
//	[self updateControlPropertiesWithDictionary:[dataElement elementDict]];
	return self;
}

- (id)initWithDictionary:(NSMutableDictionary *)dict
{
	NSDictionary	*propertyDict;
	NSDictionary	*controlPropDict;
	NSEnumerator	*propEnum;
	NSString		*key;
	NSString		*className;
	float			red, green, blue, alpha;
	
	viewFrame.origin = NSMakePoint(
			[[dict valueForKeyPath:@"viewFrame.origin.x"] floatValue],
			[[dict valueForKeyPath:@"viewFrame.origin.y"] floatValue] );

	viewFrame.size = NSMakeSize(
			[[dict valueForKeyPath:@"viewFrame.size.width"] floatValue],
			[[dict valueForKeyPath:@"viewFrame.size.height"] floatValue] );
	
	
	NSPoint loc = viewFrame.origin;
	NSLog(@"XFElementView initWithDictionary atPoint(%f,%f)", loc.x, loc.y);

				
	// initialize instance variables from dictionary
	borderWidth = [[dict valueForKey:@"borderWidth"] floatValue];
	matteWidth = [[dict valueForKey:@"matteWidth"] floatValue];
	selected = [[dict valueForKey:@"selected"] boolValue];
	
	// build color information from dict components
	red = [[dict valueForKeyPath:@"selectedBorderColor.red"] floatValue];
	green = [[dict valueForKeyPath:@"selectedBorderColor.green"] floatValue];
	blue = [[dict valueForKeyPath:@"selectedBorderColor.blue"] floatValue];
	alpha = [[dict valueForKeyPath:@"selectedBorderColor.alpha"] floatValue];
	selectedBorderColor = [[NSColor colorWithCalibratedRed:red
													 green:green  
													  blue:blue  
													 alpha:alpha] retain];
	
	red = [[dict valueForKeyPath:@"normalBorderColor.red"] floatValue];
	green = [[dict valueForKeyPath:@"normalBorderColor.green"] floatValue];
	blue = [[dict valueForKeyPath:@"normalBorderColor.blue"] floatValue];
	alpha = [[dict valueForKeyPath:@"normalBorderColor.alpha"] floatValue];	
	normalBorderColor =[[NSColor colorWithCalibratedRed:red
												  green:green  
												   blue:blue  
												  alpha:alpha] retain];
	
	// get control property defaults from dictionary
	propertyDict = [dict valueForKey:@"elementTypeDict"];
	className = [[propertyDict valueForKey:@"className"] retain];
	controlFrame.size.height = viewFrame.size.height - matteWidth - borderWidth;
	controlFrame.size.width = viewFrame.size.width - matteWidth - borderWidth;
	if( controlFrame.size.height <= 2.0 ) {
		controlFrame.size.height = [[propertyDict valueForKey:@"height"] floatValue];
		controlFrame.size.width = [[propertyDict valueForKey:@"width"] floatValue];	
	}
	if( viewFrame.size.height <= 2.0 ) {
		viewFrame.size.height = controlFrame.size.height + matteWidth + borderWidth;
		viewFrame.size.width = controlFrame.size.width + matteWidth + borderWidth;	
	}
	controlFrame.origin.x	= (viewFrame.size.width - controlFrame.size.width) / 2.0;
	controlFrame.origin.y	= (viewFrame.size.height - controlFrame.size.height) / 2.0;
	
	// continue with normal initialization
	[self initWithFrame:viewFrame];
	
	// create control
	NSLog(@" className = %@", className);
	control = [[NSClassFromString(className) alloc] initWithFrame:controlFrame];
	
	// set non-mutable property values for control
	controlPropDict = [propertyDict valueForKey:@"xfNonMutableProperties"];
	propEnum = [controlPropDict keyEnumerator];
	while( (key = [propEnum nextObject]) ) {
		//	NSLog(@" key = '%@' \t value = %@", key, [controlPropDict valueForKey:key]);
		if( [key compare:@"image"] == NSOrderedSame ) {
			ctrlImage = [NSImage imageNamed:[controlPropDict valueForKey:key]];
			[control setValue:ctrlImage forKey:key];
		} else {
			[control setValue:[controlPropDict valueForKey:key] forKey:key];
		}
	}

	// set mutable property values for control
	[self updateControlPropertiesWithDictionary:
							[propertyDict valueForKey:@"xfMutableProperties"]];
	
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.size.height] 
							 forKeyPath:@"viewFrame.size.height"];
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.size.width] 
							 forKeyPath:@"viewFrame.size.width"];
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.origin.x] 
							 forKeyPath:@"viewFrame.origin.x"];
	[[dataElement elementDict] setValue:[NSNumber numberWithFloat:viewFrame.origin.y] 
							 forKeyPath:@"viewFrame.origin.y"];
	
	// change action target to point here to capture mouseDown events
	[control setTarget:self];
	[control setAction:@selector(controlAction:)];
	
	[control setNeedsDisplay:YES];
	[self addSubview:control];
	[self setNeedsDisplay:YES];

	NSLog(@"XFElementView created at(%f,%f) h=%f, w=%f", viewFrame.origin.x, 
		  viewFrame.origin.y, viewFrame.size.height, viewFrame.size.width);
	
	return self;
}

- (void)awakeFromNib
{
	NSRect			bounds;
	NSDictionary	*dict;
	
	[super awakeFromNib];
	NSLog(@"XFElementView -awakeFromNib");
	
	NSAssert( control, @"INSTANCE VARIABLE:'control' IS INVALID!");
	if( [[control className] compare:@"NSTextField"] == NSOrderedSame ) {
		[control setDelegate:self];
	} else {
		[control setAction:@selector(controlAction:)];
		[control setTarget:self];
	}
	
	dict = [dataElement elementDict];
	bounds.origin.x = [[dict valueForKeyPath:@"viewFrame.origin.x"] floatValue];
	bounds.origin.y = [[dict valueForKeyPath:@"viewFrame.origin.y"] floatValue];
	bounds.size.height = [[dict valueForKeyPath:@"viewFrame.size.height"] floatValue];
	bounds.size.width = [[dict valueForKeyPath:@"viewFrame.size.width"] floatValue];
	[self setViewFrame:bounds];
}

// intercept action of control
- (void)controlAction:(id)sender
{
	NSLog(@"XFElementView -controlAction");
	// forward actions to the XFPageView object
	[[self superview] mouseDown:self];
}

// forward location of control action to XFPageView
- (NSPoint)locationInWindow;
{
	NSPoint loc;
	
	loc = viewFrame.origin;
	loc.x += viewFrame.size.width / 2.0;
	loc.y += viewFrame.size.height / 2.0;
	loc = [self convertPoint:loc  fromView:[self superview]];
	
	return loc;
}

// set mutable property values for control
- (void)updateControlPropertiesWithDictionary:(NSMutableDictionary *)dict
{
	NSString		*key;
	NSEnumerator	*keyEnum;
	
	NSLog(@"-updateControlProperties");
	
	// set mutable property values for control
	keyEnum = [dict keyEnumerator];
	while( (key = [keyEnum nextObject]) ) {
			NSLog(@" key = '%@' \t value = %@", key, [dict valueForKey:key]);
		if( [key compare:@"image"] == NSOrderedSame ) {
			ctrlImage = [NSImage imageNamed:[dict valueForKey:key]];
			if( !ctrlImage ) {
				ctrlImage = [[[NSImage alloc] 
							initByReferencingFile:[dict valueForKey:key]] autorelease];
			}
			[control setValue:ctrlImage forKey:key];
		} else {
			[control setValue:[dict valueForKey:key] forKey:key];
		}
	}
	
	[control setNeedsDisplay:YES];
	[self setNeedsDisplay:YES];
}

- (void)drawRect:(NSRect)rect {

	[super drawRect:rect];
	
	if( selected ) {
		[selectedBorderColor set];
	} else {
		[normalBorderColor set];
	}	
	
	// do not draw XFElementView border if printing
	//   border is a design cue only
	if( [[NSGraphicsContext currentContext] isDrawingToScreen] ) {
		[NSBezierPath setLineWidth:1.5];
		[NSBezierPath strokeRect:rect];			
	}
	
}

- (id)control
{
	return control;
}

- (NSRect)viewFrame;
{
	return viewFrame;
}

- (void)setViewFrame:(NSRect)newFrame
{
	NSSize change;
	NSRect ctrlFrame;
	NSRect currentFrame;
		
	NSLog(@"...setViewFrame");
	// frame of underlying control is not the same as frame of XFElementView
	// alter size and origin of control frame pixel for pixel
	currentFrame = viewFrame;
	ctrlFrame = [control frame];
	
	// calculate change 
	change.height	= newFrame.size.height - viewFrame.size.height;
	change.width	= newFrame.size.width - viewFrame.size.width; 

	// update control with change
	// note that origin of control within view frame does not change
	ctrlFrame.size.width	+= change.width;
	ctrlFrame.size.height	+= change.height;
	
	
	// update views
	[control setFrame:ctrlFrame];
	viewFrame = newFrame;

	// redraw
	[self setFrame:viewFrame];
	[self setNeedsDisplay:YES];
	[[self superview] setNeedsDisplay:YES];
}

- (NSRect)bounds
{
	NSLog(@"...setBounds XXXXXXXX  deprecated method --- use viewFrame: instead!");
	return viewFrame;
}

- (void)setBounds:(NSRect)newFrame
{
	NSLog(@"...setBounds XXXXXXXX  deprecated method --- use setViewFrame: instead!");
	[self setViewFrame:newFrame];
}

- (BOOL)selected
{
	return selected;
}

- (void)setSelected:(BOOL)newValue
{
	selected = newValue;
	[self setNeedsDisplay:YES];
}

- (void)setDataElement:(XFElement *)element
{
//	[dataElement release];
	dataElement = element;
	[dataElement retain];
	[self updateControlPropertiesWithDictionary:[[element elementDict] 
		valueForKeyPath:@"elementTypeDict.xfMutableProperties"]];
}

- (XFElement *)dataElement
{
	return dataElement;
}


- (void)dealloc
{
	[dataElement release];
}


@end
