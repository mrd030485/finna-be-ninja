//
//  XFElementView.h
//  XForms
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "XFElement.h"

@interface XFElementView : NSView {

@public
	id			control;
	NSRect		controlFrame;
	NSRect		viewFrame;
	NSString	*elementName;
	BOOL		selected;
	NSColor		*selectedBorderColor;
	NSColor		*normalBorderColor;
	NSImage		*ctrlImage;
	XFElement	*dataElement;
	
@private
	NSString *dropImageName;
	NSString *dragImageName;
//	NSMutableArray	*xfElementList;	
	
	NSDictionary	*defaultValueDict;
	float			borderWidth;
	float			matteWidth;
	BOOL			initializedWithDictionary;
	NSColor			*selectedColor;
	NSColor			*normalColor;	
}

- (id)initWithDictionary:(NSMutableDictionary *)dict;

- (id)initWithXFElement:(XFElement *)element;

- (void)updateControlPropertiesWithDictionary:(NSMutableDictionary *)dict;

- (BOOL)selected;

- (id)control;

- (void)setSelected:(BOOL)newValue;

- (NSRect)bounds;

- (void)setBounds:(NSRect)newFrame;

- (NSRect)viewFrame;

- (void)setViewFrame:(NSRect)newFrame;

- (void)setDataElement:(XFElement *)element;

- (XFElement *)dataElement;

@end
