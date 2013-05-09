//
//  DeepCopy.h
//  XForms
//
//  Created by Nolan Whitaker on 11/19/05.
//  Copyright 2005 __MyCompanyName__. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface DeepCopy : NSObject {
	
}

+ (NSDictionary *)copyOfDictionary:(NSDictionary *)sourceDict;

+ (NSMutableDictionary *)mutableCopyOfDictionary:(NSDictionary *)sourceDict;

@end
