//
//  XFToolView.h
//  XForms
//
//  Created by Nolan Whitaker on 10/31/05.
//  Copyright 2005 Nolan Whitaker. All rights reserved.
//

#import <Cocoa/Cocoa.h>


@interface XFToolView : NSView {
	
@public
	NSDictionary	*xfToolList;

	// Default values for forms tool panel
	float	xfToolImageHeight;
	float	xfToolImageWidth;
	float	xfToolWindowHeight;
	float	xfToolWindowWidth;
	float	xfToolViewHeight;
	float	xfToolViewWidth;
	float	xfToolViewX;
	float	xfToolViewY;
	
@private
	NSDictionary	*toolPanelDefaults;
	NSString		*dragImageName;
		
}

@end
