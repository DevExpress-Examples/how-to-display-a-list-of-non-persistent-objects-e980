Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.DC

Namespace UnboundListView.Module
	<DomainComponent> _
	Public Class Duplicate
		<Key, Browsable(False)> _
		Public Id As Integer
		Private privateTitle As String
		Public Property Title() As String
			Get
				Return privateTitle
			End Get
			Set(ByVal value As String)
				privateTitle = value
			End Set
		End Property
		Private privateCount As Integer
		Public Property Count() As Integer
			Get
				Return privateCount
			End Get
			Set(ByVal value As Integer)
				privateCount = value
			End Set
		End Property
	End Class
	<DomainComponent> _
	Public Class DuplicatesList
		Private duplicates_Renamed As BindingList(Of Duplicate)
		Public Sub New()
			duplicates_Renamed = New BindingList(Of Duplicate)()
		End Sub
		Public ReadOnly Property Duplicates() As BindingList(Of Duplicate)
			Get
				Return duplicates_Renamed
			End Get
		End Property
	End Class
End Namespace
