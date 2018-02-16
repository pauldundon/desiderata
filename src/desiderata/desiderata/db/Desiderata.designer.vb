﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="Desiderata")>  _
Partial Public Class DesiderataDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertCollection(instance As Collection)
    End Sub
  Partial Private Sub UpdateCollection(instance As Collection)
    End Sub
  Partial Private Sub DeleteCollection(instance As Collection)
    End Sub
  Partial Private Sub InsertDesideratum(instance As Desideratum)
    End Sub
  Partial Private Sub UpdateDesideratum(instance As Desideratum)
    End Sub
  Partial Private Sub DeleteDesideratum(instance As Desideratum)
    End Sub
  Partial Private Sub InsertSchema(instance As Schema)
    End Sub
  Partial Private Sub UpdateSchema(instance As Schema)
    End Sub
  Partial Private Sub DeleteSchema(instance As Schema)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.desiderata.My.MySettings.Default.DesiderataConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property Collections() As System.Data.Linq.Table(Of Collection)
		Get
			Return Me.GetTable(Of Collection)
		End Get
	End Property
	
	Public ReadOnly Property Desideratums() As System.Data.Linq.Table(Of Desideratum)
		Get
			Return Me.GetTable(Of Desideratum)
		End Get
	End Property
	
	Public ReadOnly Property Schemas() As System.Data.Linq.Table(Of Schema)
		Get
			Return Me.GetTable(Of Schema)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Collection")>  _
Partial Public Class Collection
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _CollectionID As Integer
	
	Private _Path As String
	
	Private _DefaultSchemaID As Integer
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnCollectionIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnCollectionIDChanged()
    End Sub
    Partial Private Sub OnPathChanging(value As String)
    End Sub
    Partial Private Sub OnPathChanged()
    End Sub
    Partial Private Sub OnDefaultSchemaIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnDefaultSchemaIDChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CollectionID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property CollectionID() As Integer
		Get
			Return Me._CollectionID
		End Get
		Set
			If ((Me._CollectionID = value)  _
						= false) Then
				Me.OnCollectionIDChanging(value)
				Me.SendPropertyChanging
				Me._CollectionID = value
				Me.SendPropertyChanged("CollectionID")
				Me.OnCollectionIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Path", DbType:="VarChar(256) NOT NULL", CanBeNull:=false)>  _
	Public Property Path() As String
		Get
			Return Me._Path
		End Get
		Set
			If (String.Equals(Me._Path, value) = false) Then
				Me.OnPathChanging(value)
				Me.SendPropertyChanging
				Me._Path = value
				Me.SendPropertyChanged("Path")
				Me.OnPathChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DefaultSchemaID", DbType:="Int NOT NULL")>  _
	Public Property DefaultSchemaID() As Integer
		Get
			Return Me._DefaultSchemaID
		End Get
		Set
			If ((Me._DefaultSchemaID = value)  _
						= false) Then
				Me.OnDefaultSchemaIDChanging(value)
				Me.SendPropertyChanging
				Me._DefaultSchemaID = value
				Me.SendPropertyChanged("DefaultSchemaID")
				Me.OnDefaultSchemaIDChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Desideratum")>  _
Partial Public Class Desideratum
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _DesideratumID As Integer
	
	Private _MediaType As String
	
	Private _Content As String
	
	Private _Path As String
	
	Private _CollectionID As Integer
	
	Private _SchemaID As Integer
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnDesideratumIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnDesideratumIDChanged()
    End Sub
    Partial Private Sub OnMediaTypeChanging(value As String)
    End Sub
    Partial Private Sub OnMediaTypeChanged()
    End Sub
    Partial Private Sub OnContentChanging(value As String)
    End Sub
    Partial Private Sub OnContentChanged()
    End Sub
    Partial Private Sub OnPathChanging(value As String)
    End Sub
    Partial Private Sub OnPathChanged()
    End Sub
    Partial Private Sub OnCollectionIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnCollectionIDChanged()
    End Sub
    Partial Private Sub OnSchemaIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnSchemaIDChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DesideratumID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property DesideratumID() As Integer
		Get
			Return Me._DesideratumID
		End Get
		Set
			If ((Me._DesideratumID = value)  _
						= false) Then
				Me.OnDesideratumIDChanging(value)
				Me.SendPropertyChanging
				Me._DesideratumID = value
				Me.SendPropertyChanged("DesideratumID")
				Me.OnDesideratumIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MediaType", DbType:="VarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property MediaType() As String
		Get
			Return Me._MediaType
		End Get
		Set
			If (String.Equals(Me._MediaType, value) = false) Then
				Me.OnMediaTypeChanging(value)
				Me.SendPropertyChanging
				Me._MediaType = value
				Me.SendPropertyChanged("MediaType")
				Me.OnMediaTypeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Content", DbType:="NText NOT NULL", CanBeNull:=false, UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Content() As String
		Get
			Return Me._Content
		End Get
		Set
			If (String.Equals(Me._Content, value) = false) Then
				Me.OnContentChanging(value)
				Me.SendPropertyChanging
				Me._Content = value
				Me.SendPropertyChanged("Content")
				Me.OnContentChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Path", DbType:="VarChar(265) NOT NULL", CanBeNull:=false)>  _
	Public Property Path() As String
		Get
			Return Me._Path
		End Get
		Set
			If (String.Equals(Me._Path, value) = false) Then
				Me.OnPathChanging(value)
				Me.SendPropertyChanging
				Me._Path = value
				Me.SendPropertyChanged("Path")
				Me.OnPathChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CollectionID", DbType:="Int NOT NULL")>  _
	Public Property CollectionID() As Integer
		Get
			Return Me._CollectionID
		End Get
		Set
			If ((Me._CollectionID = value)  _
						= false) Then
				Me.OnCollectionIDChanging(value)
				Me.SendPropertyChanging
				Me._CollectionID = value
				Me.SendPropertyChanged("CollectionID")
				Me.OnCollectionIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SchemaID", DbType:="Int NOT NULL")>  _
	Public Property SchemaID() As Integer
		Get
			Return Me._SchemaID
		End Get
		Set
			If ((Me._SchemaID = value)  _
						= false) Then
				Me.OnSchemaIDChanging(value)
				Me.SendPropertyChanging
				Me._SchemaID = value
				Me.SendPropertyChanged("SchemaID")
				Me.OnSchemaIDChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.[Schema]")>  _
Partial Public Class Schema
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _SchemaID As Integer
	
	Private _Content As String
	
	Private _IsInferred As Byte
	
	Private _Path As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnSchemaIDChanging(value As Integer)
    End Sub
    Partial Private Sub OnSchemaIDChanged()
    End Sub
    Partial Private Sub OnContentChanging(value As String)
    End Sub
    Partial Private Sub OnContentChanged()
    End Sub
    Partial Private Sub OnIsInferredChanging(value As Byte)
    End Sub
    Partial Private Sub OnIsInferredChanged()
    End Sub
    Partial Private Sub OnPathChanging(value As String)
    End Sub
    Partial Private Sub OnPathChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SchemaID", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property SchemaID() As Integer
		Get
			Return Me._SchemaID
		End Get
		Set
			If ((Me._SchemaID = value)  _
						= false) Then
				Me.OnSchemaIDChanging(value)
				Me.SendPropertyChanging
				Me._SchemaID = value
				Me.SendPropertyChanged("SchemaID")
				Me.OnSchemaIDChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Content", DbType:="NText NOT NULL", CanBeNull:=false, UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Content() As String
		Get
			Return Me._Content
		End Get
		Set
			If (String.Equals(Me._Content, value) = false) Then
				Me.OnContentChanging(value)
				Me.SendPropertyChanging
				Me._Content = value
				Me.SendPropertyChanged("Content")
				Me.OnContentChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IsInferred", DbType:="TinyInt NOT NULL")>  _
	Public Property IsInferred() As Byte
		Get
			Return Me._IsInferred
		End Get
		Set
			If ((Me._IsInferred = value)  _
						= false) Then
				Me.OnIsInferredChanging(value)
				Me.SendPropertyChanging
				Me._IsInferred = value
				Me.SendPropertyChanged("IsInferred")
				Me.OnIsInferredChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Path", DbType:="VarChar(256) NOT NULL", CanBeNull:=false)>  _
	Public Property Path() As String
		Get
			Return Me._Path
		End Get
		Set
			If (String.Equals(Me._Path, value) = false) Then
				Me.OnPathChanging(value)
				Me.SendPropertyChanging
				Me._Path = value
				Me.SendPropertyChanged("Path")
				Me.OnPathChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
