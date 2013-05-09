//
//  XFNumValueTransformer.m
//  XForms
//
//  Created by Nolan Whitaker on 11/23/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFCBValueTransformer.h"


@implementation XFCBValueTransformer

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

- (void)printLookupTable
{
	int idx;
	for(idx=0; idx < [lookupTable count]; idx++ ) {
		NSLog(@"%i: %@", idx, [lookupTable objectAtIndex:idx]);
	}
}

- (id)transformedValue:(id)value 
{
	NSString *stringValue;
	
	NSLog(@" -transformedValue   value= %@", value );
	stringValue = [lookupTable objectAtIndex:[value intValue]];
	NSLog(@" -- returning stringValue:%@", stringValue);
//	[self printLookupTable];
	return stringValue;
}

- (id)reverseTransformedValue:(id)value 
{
	int index;
	int count;
	NSLog(@" -reverseTransformedValue   [value className] = %@", [value className]);
	count = [lookupTable count];
	for( index=0; index < count; index++ ) {
		if( [[lookupTable objectAtIndex:index] isEqual:value] ) {
			return [NSNumber numberWithInt:index];
		}
	}
	return [NSNumber numberWithInt:0];
}

- (void)dealloc
{
	[lookupTable release];
}

@end
