<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128611270/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T399401)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Rich Text Editor for WinForms: How to Show a ToolTip With Information About the Document Element Located Under the Cursor Position

This example demonstrates how to use the [HitTestManager](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.HitTestManager) class to obtain document layout elements located under the specific point and show this information in the ToolTip.

Use the [HitTestManager.HitTest](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.HitTestManager.HitTest.overloads) method to get the [RichEditHitTestResult](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.RichEditHitTestResult) object with information about a specific document element which is located under the test point. Retrieve the layout element by the [RichEditHitTestResult.LayoutElement](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.RichEditHitTestResult.LayoutElement) property. The [RichEditHitTestResult.Nex](https://docs.devexpress.com/OfficeFileAPI/DevExpress.XtraRichEdit.RichEditHitTestResult.Next) property allows you to obtain the hit information about the element positioned next to the current hit element. After that, display the required information about the document layout element in the tooltip.

## Files to Review

* [Form1.cs](./CS/ToolTip/Form1.cs) (VB: [Form1.vb](./VB/ToolTip/Form1.vb))
* [Program.cs](./CS/ToolTip/Program.cs) (VB: [Program.vb](./VB/ToolTip/Program.vb))

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=richedit-winforms-layout-element-under-cursor&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=richedit-winforms-layout-element-under-cursor&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
