//
//  XFCBValueTransformer.h
//  XForms
//
//  Created by Nolan Whitaker on 11/23/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>


@interface XFCBValueTransformer : NSValueTransformer {
	NSArray		*lookupTable;
}

- (void)setLookupTable:(NSArray *)anArray;

- (NSArray *)lookupTable;

@end
