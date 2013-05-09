//
//  XFForm.m
//  XForms
//
//  Primary Model Class
//  XFForm contains 1..n XFPage instances which contains 0..n XFElement instances
//
//  Created by Nolan Whitaker on 11/13/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFForm.h"
#include "XFNotices.h"

@implementation XFForm 

- (id)init
{
	NSString				*key;
	NSEnumerator			*keyEnum;
	NSNotificationCenter	*nc;

    self = [super init];
    if (self) {
        // Add your subclass-specific initialization here.	
		NSLog(@"XFForm -init");
		if( documentDict == nil || [documentDict count] < 1 ) {
			NSLog(@" -initWithDictionary not called!");
			[super dealloc];
			return nil;
		}
		
		// initialize default value and lookup dictionaries
		elementTypeDict = [[NSDictionary alloc] initWithDictionary:
										[documentDict valueForKey:@"ElementTypes"]];
		elementInfoDict = [[NSDictionary alloc] initWithDictionary:
										[documentDict valueForKey:@"ElementInfo"]];
		pageInfoDict = [[NSDictionary alloc] initWithDictionary:
										[documentDict valueForKey:@"PageInfo"]];
		formInfoDict = [[NSDictionary alloc] initWithDictionary:
										[documentDict valueForKey:@"FormInfo"]];
		[formInfoDict retain];
		
		if( formInfoDict == nil ) {
			NSLog( @" Unable to initialize default value and lookup dictionaries.");
			[self release];
			return nil;
		}

		// initialize form instance variables from the dictionaries above
		keyEnum = [formInfoDict keyEnumerator];
		while( (key = [keyEnum nextObject]) ) {
				[self setValue:[formInfoDict valueForKey:key] forKey:key];
		}		
		elementCount = 0;
		elementList = [[NSMutableArray alloc] initWithCapacity:10];
		
		// register with notification center to receive the following messages:	
		//	1.	XFNoticePageViewAddedElement
		nc = [NSNotificationCenter defaultCenter];
		[nc addObserver:self 
			   selector:@selector(handleAddElement:) 
				   name:XFNoticePageViewAddedElement 
				 object:nil];
		
		// post notification of initialization to notification center
//		[[NSNotificationCenter defaultCenter] 
//									postNotificationName:XFNOTICEDocumentInitialized 
//												  object:self];
	}
	NSLog(@" .XFForm initialization complete.");
    return self;
}

- (id)initWithDictionary:(NSDictionary *)initDict
{	
	documentDict = [[[NSDictionary alloc] initWithDictionary:[initDict copy]] retain];
	
	return [self init];
}

- (id)initWithCoder:(NSCoder *)coder
{
	NSAssert( [coder allowsKeyedCoding], @"Unable to unarchive using keyed encoding!");
	
	self = [super init];	// super class does not implement NSCoding protocol
	if( self ) {
		appVersion			= [[coder decodeObjectForKey:@"appVersion"] retain];
		formName			= [[coder decodeObjectForKey:@"formName"] retain];
		formVersion			= [[coder decodeObjectForKey:@"formVersion"] retain];
		pageCount			= [coder decodeIntForKey:@"pageCount"];
		pageHeight			= [coder decodeFloatForKey:@"pageHeight"];
		pageWidth			= [coder decodeFloatForKey:@"pageWidth"];
		pageSizeUnit		= [[coder decodeObjectForKey:@"pageSizeUnit"] retain];
		elementList			= [[coder decodeObjectForKey:@"elementList"] retain];		
	}
	return self;
}

- (void)encodeWithCoder:(NSCoder *)coder
{
	NSAssert( [coder allowsKeyedCoding], @"Unable to unarchive using keyed encoding!");

	NSLog(@"encoding XFForm for SaveOeration");
		
	[coder encodeObject:appVersion forKey:@"appVersion"];
	[coder encodeObject:formName forKey:@"formName"];
	[coder encodeObject:formVersion forKey:@"formVersion"];
	[coder encodeInt:pageCount forKey:@"pageCount"];
	[coder encodeFloat:pageHeight forKey:@"pageHeight"];
	[coder encodeFloat:pageWidth forKey:@"pageWidth"];
	[coder encodeObject:pageSizeUnit forKey:@"pageSizeUnit"];
	[coder encodeObject:elementList forKey:@"elementList"];
}


- (void)addXFElement:(XFElement *)newElement
{
	[elementList addObject:newElement];
}


// Add a new page to the Buttonform
- (int)addPage
{
	NSNotificationCenter	*nc;
	NSDictionary			*pageDict;
	
	// 1. increment page count 
	// 2. add a mutable copy of the pageInfoDict to the page list in formDocumentDict
	// 3, return page count

	return pageCount;
}


// intercept calls to Key-Value coding set method and inform observers of change
// --- don't have to do this!
- (void)setValue:(id)value
		  forKey:(NSString *)key
{
//	NSLog(@"XFForm setValue: forKey:%@", key);
	[super setValue:value forKey:key];
}

- (NSMutableArray *)elementList
{
	return elementList;
}

@end
