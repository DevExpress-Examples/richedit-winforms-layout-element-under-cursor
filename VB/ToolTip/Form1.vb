Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Layout
Imports System.Drawing
Imports DevExpress.Utils

Namespace ToolTip

    Public Partial Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm

        Public Sub New()
            InitializeComponent()
            richEditControl1.LoadDocument("../../Resources/HitTest.docx")
            toolTipController1.AddClientControl(richEditControl1)
            AddHandler toolTipController1.GetActiveObjectInfo, AddressOf ToolTipController_GetActiveObjectInfo
        End Sub

        Private Sub ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As ToolTipControllerGetActiveObjectInfoEventArgs)
#Region "#HitTest"
            If Not e.SelectedControl.Equals(richEditControl1) Then Return
            'Obtain the mouse cursor's layout position on the page and the current page index:
            Dim pageLayoutPosition As PageLayoutPosition = richEditControl1.ActiveView.GetDocumentLayoutPosition(e.ControlMousePosition)
            If pageLayoutPosition Is Nothing Then Return
            Dim point As Point = pageLayoutPosition.Position
            Dim pageIndex As Integer = pageLayoutPosition.PageIndex
            Dim layoutPage As LayoutPage = richEditControl1.DocumentLayout.GetPage(pageIndex)
            'Create a HitTestManager instance: 
            Dim hitTest As HitTestManager = New HitTestManager(richEditControl1.DocumentLayout)
            'Perform the hit test and pass the result to the RichEditHitTestResult object:
            Dim result As RichEditHitTestResult = hitTest.HitTest(layoutPage, point)
            If result IsNot Nothing Then
                'Retrieve the current layout element type:
                Dim element As LayoutElement = result.LayoutElement
                Dim text As String = element.Type.ToString()
                'Obtain the the text character and its bounds under the mouse position              
                If element.Type = LayoutType.CharacterBox Then
                    text += String.Format(" : ""{0}""", TryCast(element, CharacterBox).Text)
                    text += GetBounds(element)
                    If element.Parent.Type = LayoutType.PlainTextBox Then
                        text += String.Format(Microsoft.VisualBasic.Constants.vbCrLf & "PlainTextBox : ""{0}""", TryCast(element.Parent, PlainTextBox).Text)
                        text += GetBounds(element.Parent)
                    End If
                Else
                    'Get the hovered element's bounds:
                    text += GetBounds(element)
                End If

                'Get the element's location:
                Dim title As String = GetLocation(element)
                'Display all retrieved information in the tooltip:
                e.Info = New ToolTipControlInfo(element.Bounds, text, title, ToolTipIconType.Information)
            End If
#End Region  ' #HitTest
        End Sub

        Private Function GetBounds(ByVal element As LayoutElement) As String
            Return String.Format(Microsoft.VisualBasic.Constants.vbCrLf & "Bounds : {0}", element.Bounds)
        End Function

        Private Function GetLocation(ByVal element As LayoutElement) As String
            While element IsNot Nothing
                Select Case element.Type
                    Case LayoutType.CommentsArea
                        Return "Comments Area Location"
                    Case LayoutType.Header
                        Return "Header Location"
                    Case LayoutType.Footer
                        Return "Footer Location"
                End Select

                element = element.Parent
            End While

            Return "Page Location"
        End Function
    End Class
End Namespace
