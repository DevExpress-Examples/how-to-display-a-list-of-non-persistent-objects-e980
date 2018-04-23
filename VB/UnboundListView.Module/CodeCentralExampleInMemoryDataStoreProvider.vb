Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports DevExpress.Xpo.DB

Namespace UnboundListView.Module
	Public Class CodeCentralExampleInMemoryDataStoreProvider
		Private Shared ReadOnly fConnectionString As String
		Private Shared ReadOnly fdataSet As DataSet
		Public Shared ReadOnly Property ConnectionString() As String
			Get
				Return fConnectionString
			End Get
		End Property
		Shared Sub New()
			Dim providerKey As String = Guid.NewGuid().ToString()
			fConnectionString = "XpoProvider=" & providerKey
			fdataSet = New DataSet()
			DataStoreBase.RegisterDataStoreProvider(providerKey, AddressOf CreateProviderFromString)
		End Sub
		Public Shared Function CreateProviderFromString(ByVal connectionString As String, ByVal autoCreateOption As AutoCreateOption, <System.Runtime.InteropServices.Out()> ByRef objectsToDisposeOnDisconnect() As IDisposable) As IDataStore
            Dim result As New DataSetDataStore(fdataSet, autoCreateOption)
			objectsToDisposeOnDisconnect = New IDisposable() { }
			Return result
		End Function
	End Class
End Namespace
