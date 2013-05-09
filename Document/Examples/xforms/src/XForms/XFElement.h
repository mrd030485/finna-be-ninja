//
//  XFElement.h
//  XForms
//
//  Form Element Model Class
//  XFForm contains 1..n XFPage instances which contains 0..n XFElement instances
//
//  Created by Nolan Whitaker on 11/12/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "DeepCopy.h"

@interface XFElement : NSObject <NSCoding>
{
	NSString				*elementId;
	NSMutableDictionary		*elementDict;
	NSRect					bounds;
	BOOL					selected;
}

- initWithDictionary:(NSMutableDictionary *)dict;

//- (NSRect)bounds;

- (BOOL)selected;

- (NSMutableDictionary *)elementDict;

- (NSString *)elementId;

- (NSString *)dataAsHTML;

- (NSString *)dataAsXML;

@end
