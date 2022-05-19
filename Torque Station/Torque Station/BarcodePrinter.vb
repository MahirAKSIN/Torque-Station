Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient

Public Class BarcodePrinter
    Dim LocalDB As New SQLiteTools("TorqueStation")
    'Dim strPrinterName As String = LocalDB.GetSingleValue("Select * from INI where [Key] = 'PRN' ", "Value")
   Dim strPrinterName As String = LocalDB.GetSingleValue("SELECT * FROM INI WHERE Key = 'Printer' ", "Value")
    'Dim strPrinterName As String="ZDesigner"
    Public Sub CreateBarcode(ByVal OrderNumber As String, ByVal StationId As String, ByVal OpId As String, ByVal DateTime As String)
      Dim strFile As String = "barcode_small.txt"
     'Dim strFile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\ELOPAR\" & Application.ProductName + "\" & "barcode_small.txt"
        Dim sw As IO.StreamWriter

        If IO.File.Exists(strFile) = False Then
            sw = IO.File.CreateText(strFile)
        Else
            IO.File.Delete(strFile)
            sw = IO.File.CreateText(strFile)
        End If
        sw.WriteLine("N")

        ' Part number
        Dim partNo As String = "Part Nr :" & OrderNumber
        sw.WriteLine("A50,5,0,3,1,1,N,""" & partNo & """")

        ' Station id
        StationId = "Station :" & StationId
        sw.WriteLine("A50,30,0,3,1,1,N,""" & StationId & """")

        ' Operator Id
        OpId = "Operator:" & OpId
        sw.WriteLine("A50,55,0,3,1,1,N,""" & OpId & """")

        ' Datetime
        sw.WriteLine("A50,80,0,3,1,1,N,""" & DateTime & """")

        ' Barcode
        sw.WriteLine("B50,105,0,1,2,5,100,B,""" & OrderNumber & """")

        sw.WriteLine("P1")
        sw.Close()
    End Sub

    ' Print Barcode
    Public Sub PrintBarcode(ByVal printerName As String)
        Dim proc As New System.Diagnostics.Process
        With proc.StartInfo
            .UseShellExecute = True
            .FileName = "cmd.exe"
            .Arguments = "/C copy barcode_small.txt ""\\127.0.0.1\" & printerName & ""
            .WindowStyle = ProcessWindowStyle.Hidden
        End With
        proc.Start()
        Do
        Loop While Not proc.WaitForExit(100)
    End Sub


    Public Sub Clear()
        txt_order.Text = String.Empty
        txt_sta.Text=String.Empty
        txt_op.Text=String.Empty
        txt_date.Text = String.Empty

    End Sub

    Public Sub EnableText()
        txt_order.Enabled = False
        txt_date.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' CreateBarcode(txt_barcode1.Text, txt_barcode2.Text, txt_product.Text, txt_date.Text)
        ' Print barcode
         CreateBarcode(txt_order.Text.ToString,txt_sta.Text.ToString,txt_op.Text.ToString, txt_date.Text.ToString)
        PrintBarcode(strPrinterName)
        Clear()
    End Sub

  
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub

End Class