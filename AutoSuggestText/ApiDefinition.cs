using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace AutoSuggestText
{
	// @protocol ARAutocompleteDataSource <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ARAutocompleteDataSource
	{
		// @required -(NSString *)textView:(ARAutocompleteTextView *)textView completionForPrefix:(NSString *)prefix ignoreCase:(BOOL)ignoreCase;
		[Abstract]
		[Export("textView:completionForPrefix:ignoreCase:")]
		string CompletionForPrefix(ARAutocompleteTextView textView, string prefix, bool ignoreCase);
	}

	// @protocol ARAutocompleteTextViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ARAutocompleteTextViewDelegate
	{
		// @optional -(void)autoCompleteTextViewDidAutoComplete:(ARAutocompleteTextView *)autoCompleteField;
		[Export("autoCompleteTextViewDidAutoComplete:")]
		void AutoCompleteTextViewDidAutoComplete(ARAutocompleteTextView autoCompleteField);

		// @optional -(void)autoCompleteTextView:(ARAutocompleteTextView *)autocompleteTextView didChangeAutocompleteText:(NSString *)autocompleteText;
		[Export("autoCompleteTextView:didChangeAutocompleteText:")]
		void AutoCompleteTextView(ARAutocompleteTextView autocompleteTextView, string autocompleteText);
	}

	// @interface ARAutocompleteTextView : UITextView <UITextViewDelegate>
	[BaseType(typeof(UITextView))]
	interface ARAutocompleteTextView : IUITextViewDelegate
	{
		// -(id)initWithFrame:(CGRect)frame;
		[Export("initWithFrame:")]
		IntPtr Constructor(CGRect frame);

		// @property (assign, nonatomic) NSUInteger autocompleteType;
		[Export("autocompleteType")]
		nuint AutocompleteType { get; set; }

		// @property (assign, nonatomic) BOOL autocompleteDisabled;
		[Export("autocompleteDisabled")]
		bool AutocompleteDisabled { get; set; }

		// @property (assign, nonatomic) BOOL ignoreCase;
		[Export("ignoreCase")]
		bool IgnoreCase { get; set; }

		[Wrap("WeakAutoCompleteTextViewDelegate")]
		ARAutocompleteTextViewDelegate AutoCompleteTextViewDelegate { get; set; }

		// @property (assign, nonatomic) id<ARAutocompleteTextViewDelegate> autoCompleteTextViewDelegate;
		[NullAllowed, Export("autoCompleteTextViewDelegate", ArgumentSemantic.Assign)]
		NSObject WeakAutoCompleteTextViewDelegate { get; set; }

		[Wrap("WeakInnerTextViewDelegate")]
		UITextViewDelegate InnerTextViewDelegate { get; set; }

		// @property (assign, nonatomic) id<UITextViewDelegate> innerTextViewDelegate;
		[NullAllowed, Export("innerTextViewDelegate", ArgumentSemantic.Assign)]
		NSObject WeakInnerTextViewDelegate { get; set; }

		// @property (nonatomic, strong) UILabel * autocompleteLabel;
		[Export("autocompleteLabel", ArgumentSemantic.Strong)]
		UILabel AutocompleteLabel { get; set; }

		// -(void)setFont:(UIFont *)font;
		[Export("setFont:")]
		void SetFont(UIFont font);

		// @property (assign, nonatomic) CGPoint autocompleteTextOffset;
		[Export("autocompleteTextOffset", ArgumentSemantic.Assign)]
		CGPoint AutocompleteTextOffset { get; set; }

		// @property (assign, nonatomic) id<ARAutocompleteDataSource> autocompleteDataSource;
		[Export("autocompleteDataSource", ArgumentSemantic.Assign)]
		ARAutocompleteDataSource AutocompleteDataSource { get; set; }

		// +(void)setDefaultAutocompleteDataSource:(id<ARAutocompleteDataSource>)dataSource;
		[Static]
		[Export("setDefaultAutocompleteDataSource:")]
		void SetDefaultAutocompleteDataSource(ARAutocompleteDataSource source);

		// -(CGRect)autocompleteRectForBounds:(CGRect)bounds;
		[Export("autocompleteRectForBounds:")]
		CGRect AutocompleteRectForBounds(CGRect bounds);

		// -(void)setupAutocompleteTextView;
		[Export("setupAutocompleteTextView")]
		void SetupAutocompleteTextView();

		// -(void)forceRefreshAutocompleteText;
		[Export("forceRefreshAutocompleteText")]
		void ForceRefreshAutocompleteText();
	}

	// @interface AREmailAutocompleteTextView : ARAutocompleteTextView <ARAutocompleteDataSource>
	[BaseType(typeof(ARAutocompleteTextView))]
	interface AREmailAutocompleteTextView : ARAutocompleteDataSource
	{
		// @property (copy, nonatomic) NSArray * emailDomains;
		[Export("emailDomains", ArgumentSemantic.Copy)]
		NSObject[] EmailDomains { get; set; }
	}

	// @interface ARTwitterAutocompleteTextView : ARAutocompleteTextView <ARAutocompleteDataSource>
	[BaseType(typeof(ARAutocompleteTextView))]
	interface ARTwitterAutocompleteTextView : ARAutocompleteDataSource
	{
		// @property (copy, nonatomic) NSArray * autocomplete;
		[Export("autocomplete", ArgumentSemantic.Copy)]
		NSObject[] Autocomplete { get; set; }
	}
}
