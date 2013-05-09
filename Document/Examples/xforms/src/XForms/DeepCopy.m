//
//  DeepCopy.m
//  XForms
//
//  Created by Nolan Whitaker on 11/19/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "DeepCopy.h"

@implementation DeepCopy

+ (NSDictionary *)copyOfDictionary:(NSDictionary *)sourceDict
{
	id					obj;
	NSString			*key;
	NSEnumerator		*keyEnum;
	NSMutableDictionary	*targetDict;
	
	targetDict = [[NSMutableDictionary alloc] init];
	
	//	NSLog(@"NSDictionary category:: -mutableDeepCopy");
	
	keyEnum = [sourceDict keyEnumerator];
	while( (key = [keyEnum nextObject]) ) {
		obj = [sourceDict valueForKey:key];
		//		NSLog(@" key = '%@' \tclassName = '%@'", key, [obj className]);
		if( [[obj className] compare:@"NSCFDictionary"] == NSOrderedSame ||
			[[obj className] compare:@"NSCFMutableDictionary"] == NSOrderedSame	) {
			[targetDict setValue:[self mutableCopyOfDictionary:obj]
						  forKey:key];
		} else {
			if( [[obj className] compare:@"NSCFArray"] == NSOrderedSame ||
				[[obj className] compare:@"NSCFMutableArray"] == NSOrderedSame ) {					
				// deep copy for NSArray and NSMutableArray types not implemented
				//NSAssert( NO, @" deepCopy of NSArray in NSDictionary not supported!");

				NSLog(@"WARNING: deep copy of NSArray/NSMutableArray not supported!");
				NSLog(@".performing shallow copy of array instead");
				[targetDict setValue:[obj mutableCopy] 
							  forKey:key];
				
			} else {
				// All non-container classes
				if( [obj respondsToSelector:@selector(mutableCopyWithZone:)] ) {
					[targetDict setValue:[obj copy] 
								  forKey:key];
				}
			}
		}		
	}
	
	return [NSDictionary dictionaryWithDictionary:[targetDict autorelease]];
}

+ (NSMutableDictionary *)mutableCopyOfDictionary:(NSDictionary *)sourceDict
{
	id					obj;
	NSString			*key;
	NSEnumerator		*keyEnum;
	NSMutableDictionary	*targetDict;
	
	targetDict = [[NSMutableDictionary alloc] init];
	
//	NSLog(@"NSDictionary category:: -mutableDeepCopy");
	
	keyEnum = [sourceDict keyEnumerator];
	while( (key = [keyEnum nextObject]) ) {
		obj = [sourceDict valueForKey:key];
//		NSLog(@" key = '%@' \tclassName = '%@'", key, [obj className]);
		
		// Handle container classes: Dictionaries and Arrays
		if( [[obj className] compare:@"NSCFDictionary"] == NSOrderedSame ||
			[[obj className] compare:@"NSCFMutableDictionary"] == NSOrderedSame	) {
			[targetDict setValue:[self mutableCopyOfDictionary:obj]
						  forKey:key];
		} else {
			if( [[obj className] compare:@"NSCFArray"] == NSOrderedSame ||
				[[obj className] compare:@"NSCFMutableArray"] == NSOrderedSame ) {					
				
				//NSAssert( NO, @" deepCopy of NSArray in NSDictionary not supported!");
				NSLog(@"WARNING: deep copy of NSArray/NSMutableArray not supported!");
				NSLog(@".performing shallow copy of array instead");
				[targetDict setValue:[obj mutableCopy] 
							  forKey:key];
			} else {
				// All non-container classes
			
				// make a mutable or nonmutable copy of object as appropriate, opting
				// for mutable by default if available
				if( [obj respondsToSelector:@selector(mutableCopyWithZone:)] ) {
					[targetDict setValue:[obj mutableCopy]
								  forKey:key];
				} else {
					[targetDict setValue:[obj copy] 
								  forKey:key];
				}
			}
		}
	}
	
	return [targetDict autorelease];
}


@end
