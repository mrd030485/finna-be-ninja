//
//  XFForm.h
//  XForms
//
//  Primary Model Class
//  XFForm contains 1..n XFPage instances which contains 0..n XFElement instances
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "XFElement.h"
#import "DeepCopy.h"

@interface XFForm : NSObject <NSCoding> {
@public
	NSString			*appVersion;
	NSString			*formName;
	NSString			*formVersion;
	BOOL				openUntitledDocument;
	float				originOffset;
	int					pageCount;
	float				pageHeight;
	float				pageWidth;
	NSMutableArray		*elementList;
	NSMutableString		*pageSizeUnit;
	float				rotationAngle;
	int					elementCount;
	
	NSDictionary 			*documentDict;
	NSDictionary			*elementTypeDict;
	NSDictionary			*elementInfoDict;
	NSDictionary			*pageInfoDict;
	NSDictionary			*formInfoDict;

}

// NSCoding protocol methods
- (id)initWithCoder:(NSCoder *)coder;
- (void)encodeWithCoder:(NSCoder *)coder;

// Add form element to array list
- (void)addXFElement:(XFElement *)newElement;

// Add a new page to the document dictionary
- (int)addPage;

- (NSMutableArray *)elementList;

- (NSString *)dataAsHTML;

- (NSString *)dataAsXML;

@end
