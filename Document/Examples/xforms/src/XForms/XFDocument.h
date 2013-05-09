//
//  XFDocument.h
//  XForms
//
//  Primary Controller Class
//
//  Created by Nolan Whitaker on 11/12/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "XFPageView.h"
#import "XFElement.h"
#import "XFElementView.h"
#import "XFPropertyController.h"
#import "XFForm.h"
#import "DeepCopy.h"
#import "XFNotices.h"

@interface XFDocument : NSDocument {

	@public
		// InterfaceBuilder Outlet instance variables
		IBOutlet XFPageView		*pageView;
		IBOutlet NSScrollView	*scrollView;
		IBOutlet NSWindow		*formWindow;
		IBOutlet NSPanel		*propertyWindow;
		IBOutlet XFPropertyController *propertyController;
	
		IBOutlet NSMenuItem		*exportHTML;
		IBOutlet NSMenuItem		*exportPDF;
		IBOutlet NSMenuItem		*exportXML;
		
		// Instance Variables
		XFForm					*formData;
	
	@private
		NSDictionary			*documentDict;
		NSDictionary			*elementTypeDict;
		NSDictionary			*elementInfoDict;
		NSDictionary			*pageInfoDict;
		NSDictionary			*formInfoDict;
}

- (XFElementView *)addElementWithImageName:(NSString *)imageName
									toView:(NSView *)view
								   atPoint:(NSPoint)point;

- (id)unarchiveElement:(XFElement *)element
				toView:(NSView *)view;

- (XFPropertyController *)propertyController;

@end
