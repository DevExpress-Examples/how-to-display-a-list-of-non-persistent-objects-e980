Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace UnboundListView.Module
	<NonPersistent> _
	Public Class Duplicate
		Inherits XPObject
		Private Shared myOid As Integer = 0

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
			myOid += 1
			Oid = myOid
		End Sub
		Public Property Title() As String
			Get
				Return GetPropertyValue(Of String)("Title")
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Title", value)
			End Set
		End Property
		Public Property Count() As Integer
			Get
				Return GetPropertyValue(Of Integer)("Count")
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("Count", value)
			End Set
		End Property
	End Class
End Namespace
