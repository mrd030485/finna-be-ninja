//
//  XFPageView.h
//  XForms
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 __MyCompanyName__. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface XFPageView : NSScrollView {
	@public
	NSString		*dragImageName;
	NSMutableArray	*pageElements;
	
	@private
	NSDictionary	*elementTypeDict;
	NSDictionary	*elementInfoDict;
	id				formDocument;
	id				selectedElementView;
}

- (void)setElementInfoDict:(NSDictionary *)dict;

- (void)setElementTypeDict:(NSDictionary *)dict;

- (void)deselectAllElements;

- (void)selectAllElements;

- (int)selectElementsAtPoint:(NSPoint)target;

- (NSArray *)elementsAtPoint:(NSPoint)target;

- (void)setFormDocument:(id)doc;

- (NSMutableArray *)pageElements;

@end
