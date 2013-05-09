//
//  XFElement.m
//  XForms
//
//  Form Element Model Class
//  XFForm contains 1..n XFPage instances which contains 0..n XFElement instances
//
//  Created by Nolan Whitaker on 11/12/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import "XFElement.h"

@interface XFElement (PrivateAPI)
	static void *bindingIdentifier = (void *)@"elementDict";
@end

@implementation XFElement

- (id)initWithDictionary:(NSMutableDictionary *)dict
{
	self = [super init];
	
	elementDict = [[NSMutableDictionary alloc] initWithDictionary:dict];
	bounds.origin.x = [[elementDict valueForKeyPath:@"viewFrame.origin.x"] floatValue];
	bounds.origin.y	= [[elementDict valueForKeyPath:@"viewFrame.origin.y"] floatValue];
	bounds.size.height	= [[elementDict valueForKeyPath:@"viewFrame.size.height"] floatValue];
	bounds.size.width = [[elementDict valueForKeyPath:@"viewFrame.size.width"] floatValue];
	elementId = [elementDict valueForKey:@"elementId"];
	selected = [[elementDict valueForKey:@"selected"] boolValue];
	
	return self;
}

- (id)initWithCoder:(NSCoder *)coder
{
	NSAssert( [coder allowsKeyedCoding], @"Unable to unarchive using keyed encoding!");
	
	elementId = [coder decodeObjectForKey:@"elementId"];
	elementDict = [[NSMutableDictionary alloc] initWithDictionary:
											[coder decodeObjectForKey:@"elementDict"]];
	bounds = [coder decodeRectForKey:@"viewFrame"];
	selected = [coder decodeBoolForKey:@"selected"];
	
	return self;
}

- (void)encodeWithCoder:(NSCoder *)coder
{
	NSAssert( [coder allowsKeyedCoding], @"Unable to archive using keyed encoding!");
	
	[coder encodeObject:elementId forKey:@"elementId"];
	[coder encodeObject:elementDict forKey:@"elementDict"];
	[coder encodeRect:bounds forKey:@"bounds"];
	[coder encodeBool:selected forKey:@"selected"];
}

/*	
- (NSRect)bounds
{
	NSLog(@"XFElement -bounds XXXX DEPRECATED METHOD XXXXXXX    use viewFrame instead!");
	return bounds;
}
*/
- (BOOL)selected
{
	return selected;
}

- (NSMutableDictionary *)elementDict
{
	return elementDict;
}

- (NSString *)elementId 
{
	return elementId;
}

- (void)dealloc
{
	[elementDict release];
}


// Methods to support data export to HTML and XML

- (NSString *)dataAsHTML
{
	NSString		*imageName;
	NSString		*key;
	NSEnumerator	*keyEnumerator;
	NSMutableString *htmlString;
	NSString		*className;
	
	htmlString = [[NSMutableString alloc] initWithCapacity:1000];
	imageName = [elementDict valueForKeyPath:@"elementTypeDict.imageName"];
	className = [elementDict valueForKeyPath:@"elementTypeDict.className"];
	NSLog(@"XFElement dataAsHTML for elementId:%@ imageName='%@'", elementId, imageName);
	
	if( [imageName isEqual:@"Button"] ) {
		[htmlString appendString:@"<INPUT type='submit' name='"];
//		[htmlString appendString:[elementId copy]];
		[htmlString appendString:@"'>"];
//		[htmlString appendString:[elementDict 
//					valueForKeyPath:@"elementTypeDict.xfMutableProperties.title"]];
		[htmlString appendString:@"</INPUT>\n"];
	}
	
	if( [className isEqual:@"NSImageView"] ) {
		[htmlString appendString:@"<IMG src='"];
		[htmlString appendString:[elementDict 
					valueForKeyPath:@"elementTypeDict.imageName"]];
		[htmlString appendString:@"'></IMG>\n"];
	}
	
	if( [imageName isEqual:@"CheckBox"] ) {
		[htmlString appendString:@"<INPUT type='checkbox' name='"];
	//	[htmlString appendString:[elementId copy]];
		[htmlString appendString:@">"];
		[htmlString appendString:[elementDict 
					valueForKeyPath:@"elementTypeDict.xfMutableProperties.title"]];
		[htmlString appendString:@"'</INPUT>\n"];
	}
	
	if( [imageName isEqual:@"RadioButton"] ) {
		[htmlString appendString:@"<INPUT type='radio' name='"];
	//	[htmlString appendString:[elementId copy]];
		[htmlString appendString:@"'>"];
		[htmlString appendString:[elementDict 
					valueForKeyPath:@"elementTypeDict.xfMutableProperties.title"]];
		[htmlString appendString:@"</INPUT>\n"];
	}
	
	if( [imageName isEqual:@"TextField"] ) {
		[htmlString appendString:@"<INPUT type='text' name='"];
	//	[htmlString appendString:[elementId copy]];
		[htmlString appendString:@"' value='"];
		[htmlString appendString:[elementDict 
					valueForKeyPath:@"elementTypeDict.xfMutableProperties.stringValue"]];
		[htmlString appendString:@"'></INPUT>\n"];
	}
	
	if( [imageName isEqual:@"TextLabel"] ) {
		[htmlString appendString:@""];
		[htmlString appendString:[elementDict 
					valueForKeyPath:@"elementTypeDict.xfMutableProperties.stringValue"]];
		[htmlString appendString:@"\n"];
	}
	
	NSLog(@"XFElement HTML string='%@'", htmlString);

	[htmlString autorelease];
	return [NSString stringWithString:htmlString];
}


@end
