Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

Namespace UnboundListView.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal session As Session, ByVal currentDBVersion As Version)
			MyBase.New(session, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()

			Dim bookOne As New Book(Session)
			bookOne.Title = "A Visitor For Bear"
			bookOne.Save()

			Dim bookTwo As New Book(Session)
			bookTwo.Title = "Dirt on My Shirt"
			bookTwo.Save()

			Dim bookThree As New Book(Session)
			bookThree.Title = "Bats at the Library"
			bookThree.Save()

			Dim bookFour As New Book(Session)
			bookFour.Title = "Fancy Nancy at the Museum"
			bookFour.Save()

			Dim bookFive As New Book(Session)
			bookFive.Title = "Fancy Nancy at the Museum"
			bookFive.Save()

			Dim bookSix As New Book(Session)
			bookSix.Title = "Bats at the Library"
			bookSix.Save()

			Dim bookSeven As New Book(Session)
			bookSeven.Title = "Bats at the Library"
			bookSeven.Save()
		End Sub
	End Class
End Namespace
