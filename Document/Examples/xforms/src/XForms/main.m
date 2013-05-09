//
//  main.m
//  XForms
//
//  Created by Nolan Whitaker on 11/12/05.
//  Copyright __MyCompanyName__ 2005 . All rights reserved.
//

#import <Cocoa/Cocoa.h>

NSString *XFNoticePageViewAddedElement = @"XFPageView:Add_Element";
NSString *XFNoticeDocumentAddedPage = @"XFNOTICE:XFDocument_Added_Page";
NSString *XFNoticeDocumentRemovedPage = @"XFNOTICE:XFDocument_Removed_Page";
NSString *XFNOTICEDocumentInitialized = @"XFNOTICE:XFDocument_Initializied";

int main(int argc, char *argv[])
{
    return NSApplicationMain(argc, (const char **) argv);
}
