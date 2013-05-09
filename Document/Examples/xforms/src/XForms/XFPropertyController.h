/* XFPropertyController */

#import <Cocoa/Cocoa.h>
#import "DeepCopy.h"
#import "XFElementView.h"
#import "XFForm.h"
#import "XFCBValueTransformer.h"
#import "XFNumValueTransformer.h"

@interface XFPropertyController : NSObject
{

@public
    IBOutlet NSScrollView	*elementPropertyView;
    IBOutlet NSTextField	*pageHeight;
    IBOutlet NSTextField	*formName;
    IBOutlet NSWindow		*propertyWindow;
    IBOutlet NSComboBox		*units;
    IBOutlet NSTextField	*formVersion;
    IBOutlet NSTextField	*pageWidth;
	
	IBOutlet NSBox			*elementBox;
	IBOutlet NSTextField	*elementId;
	IBOutlet NSTextField	*elementIdLabel;
	IBOutlet NSTextField	*elementHeight;
	IBOutlet NSTextField	*elementHeightLabel;
	IBOutlet NSTextField	*elementWidth;
	IBOutlet NSTextField	*elementWidthLabel;
	IBOutlet NSTextField	*elementX;
	IBOutlet NSTextField	*elementXLabel;
	IBOutlet NSTextField	*elementY;
	IBOutlet NSTextField	*elementYLabel;
	
	int						rows;
	NSMutableArray			*propertyList;
	NSMutableArray			*viewPropertyList;
	
@private
	NSMutableArray			*valueTransformers;
	NSMutableArray			*valueTransformerNames;
	XFForm					*formData;
	NSDictionary			*documentDict;
	XFElement				*selectedElement;
	XFElementView			*selectedElementView;
	id						formDocument;
}

- (void)setDocumentDictionary:(NSDictionary *)dict;

- (void)setForm:(XFForm *)form;

- (void)setSelectedElement:(XFElement *)element;

- (void)setSelectedElementView:(XFElementView *)elementView;

- (void)setFormDocument:(id)newDocument;

// Properties panel control action methods
- (void)switchButtonAction:(id)sender;

- (void)stringAction:(NSNotification *)aNotification;

- (void)comboBoxSelection:(NSNotification *)aNotification;

- (void)numberAction:(NSNotification *)aNotification;

- (NSString *)keyPathFromTag:(int)tag;

@end