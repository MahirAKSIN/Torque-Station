Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing
Imports System.IO

Public Class MSSqlTools

    Public sqlStr As SqlString
    Public dr As SqlDataReader = Nothing
    Public CNBuilder As New SqlConnectionStringBuilder
    Public cmd As SqlCommand = Nothing
    'Dim adp As SqlDataAdapter

    Public Sub New(ByRef DataSourceName As String, ByVal IP As String, ByVal User As String, ByVal Pass As String)

        'CNBuilder.PersistSecurityInfo = False
        CNBuilder.InitialCatalog = DataSourceName
        CNBuilder.DataSource = IP
        CNBuilder.UserID = User
        CNBuilder.Password = Pass

    End Sub

    Function PopulateGrid(ByRef s As SqlString, ByRef parameter As String) As DataSet

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Dim ds As DataSet = Nothing

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                Dim adp As SqlDataAdapter
                adp = New SqlDataAdapter(sqlStr, CN)
                adp.SelectCommand.CommandTimeout = 600
                ds = New DataSet
                adp.Fill(ds, parameter)
                adp.Dispose()
            End If
            CN.Dispose()
        End Try

        Return ds

    End Function

    Public Sub ExecuteNonQuery(ByRef s As SqlString)

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                cmd.ExecuteNonQuery()
            End If
            CN.Dispose()
        End Try

    End Sub

    Function isAvaliable(ByRef s As SqlString) As Boolean

        Dim dummy As Boolean = False

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                dr = cmd.ExecuteReader()
                dr.Read()
                If dr.HasRows() Then
                    dummy = False
                Else
                    dummy = True
                End If
                dr.Close()
                cmd.Dispose()
                sqlStr = Nothing
            End If
            CN.Dispose()
        End Try

        Return dummy

    End Function

    Function isThere(ByRef s As SqlString) As Boolean

        Dim dummy As Boolean = False

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                dr = cmd.ExecuteReader()
                dr.Read()

                If dr.HasRows() Then
                    dummy = True
                Else
                    dummy = False
                End If

                dr.Close()
                cmd.Dispose()
                sqlStr = Nothing
            End If
            CN.Dispose()
        End Try
        Return dummy

    End Function

    Function IsThereDB(ByRef s As SqlString) As Boolean

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Dim result As Integer

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                result = cmd.ExecuteScalar()
            End If
            CN.Dispose()
        End Try

        Return result

    End Function

    Function GetImage(ByRef s As SqlString) As Image

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Dim i As Image

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                Dim imageData As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    i = Image.FromStream(ms, True)
                End Using
            End If
            CN.Dispose()
        End Try

        Return i

    End Function

    Public Sub SetImage(ByRef s As SqlString, ByRef parameter As String, ByRef i As Image)

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                Dim ms As New MemoryStream()
                i.Save(ms, i.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter(parameter, SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
            End If
            CN.Dispose()
        End Try

    End Sub

    Function PopulateComboBox(ByVal s As SqlString, ByRef paramater As String) As List(Of String)

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Dim DummyList As List(Of String) = Nothing

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                dr = cmd.ExecuteReader()
                DummyList = New List(Of String)()
                While dr.Read()
                    DummyList.Add(dr(paramater))
                End While
                dr.Close()
            End If
            CN.Dispose()
        End Try

        Return DummyList

    End Function

    Function GetSingleValue(ByRef s As SqlString, ByRef val As String) As String

        Dim dummy As String = String.Empty

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
        Finally
            If CN.State = ConnectionState.Open Then
                sqlStr = s
                cmd = New SqlCommand(sqlStr, CN)
                dr = cmd.ExecuteReader()
                dr.Read()

                dummy = dr(val)

                dr.Close()
                cmd.Dispose()
                sqlStr = Nothing
            End If
            CN.Dispose()
        End Try

        Return dummy

    End Function

    ' 23.08.2019
    Public Function ConnectionControl() As Boolean

        Dim CN As New SqlConnection(CNBuilder.ConnectionString)
        Dim status As Boolean = True

        Try
            CN.Open()
        Catch ex As Exception
            CN.Dispose()
            status = False
        Finally
            If CN.State = ConnectionState.Open Then
                CN.Dispose()
                status = True
            End If
        End Try

        Return status

    End Function






End Class
