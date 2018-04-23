Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo

Namespace UnboundListView.Module
	Partial Public Class ShowDuplicateBooksController
		Inherits ViewController
		Public Sub New()
			Dim showDuplicatesAction As New PopupWindowShowAction(Me, "Show Duplicate Books", "View")
			AddHandler showDuplicatesAction.CustomizePopupWindowParams, AddressOf showDuplicatesAction_CustomizePopupWindowParams
			TargetViewType = ViewType.ListView
			TargetObjectType = GetType(Book)
		End Sub

		Private Sub showDuplicatesAction_CustomizePopupWindowParams(ByVal sender As Object, ByVal e As CustomizePopupWindowParamsEventArgs)
			Dim dictionary As New Dictionary(Of String, Integer)()
            For Each book As Book In (CType(Me.View, ListView)).CollectionSource.Collection
                If (Not String.IsNullOrEmpty(book.Title)) Then
                    If dictionary.ContainsKey(book.Title) Then
                        dictionary(book.Title) += 1
                    Else
                        dictionary.Add(book.Title, 1)
                    End If
                End If
            Next book
			Dim objectSpace As ObjectSpace = Application.CreateObjectSpace()
			Dim collectionSource As New CollectionSource(objectSpace, GetType(Duplicate))
			If (TryCast(collectionSource.Collection, XPBaseCollection)) IsNot Nothing Then
				CType(collectionSource.Collection, XPBaseCollection).LoadingEnabled = False
			End If
			For Each duplicateRecord As KeyValuePair(Of String, Integer) In dictionary
				If duplicateRecord.Value > 1 Then
					Dim duplicate As New Duplicate(objectSpace.Session)
					duplicate.Title = duplicateRecord.Key
					duplicate.Count = duplicateRecord.Value
					collectionSource.Collection.Add(duplicate)
				End If
			Next duplicateRecord
			Dim view As View = Application.CreateListView(Application.GetListViewId(GetType(Duplicate)), collectionSource, False)
			CType(view, ListView).Editor.AllowEdit = False
			e.View = view
			e.DialogController.SaveOnAccept = False
		End Sub
	End Class
End Namespace
