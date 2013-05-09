//
//  XFCBValueTransformer.m
//  XForms
//
//  Created by Nolan Whitaker on 11/23/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFNumValueTransformer.h"


@implementation XFNumValueTransformer

+ (Class)transformedValueClass
{ 
	return [NSString class]; 
}

+ (BOOL)allowsReverseTransformation 
{ 
	return YES; 
}

- (NSArray *)lookupTable
{
	return lookupTable;
}

- (void)setLookupTable:(NSArray *)anArray
{
	lookupTable = [anArray retain];
}

- (id)transformedValue:(id)value 
{
	NSLog(@" -transformedValue   [value className] = %@", [value className] );
	return [value stringValue];
}

- (id)reverseTransformedValue:(id)value 
{
	float	numValue;
	NSLog(@" -reverseTransformedValue   [value className] = %@", [value className]);
	
	[[NSScanner scannerWithString:value] scanFloat:&numValue];
	return [NSNumber numberWithFloat:numValue];
}

- (void)dealloc
{
	[lookupTable release];
}

@end
