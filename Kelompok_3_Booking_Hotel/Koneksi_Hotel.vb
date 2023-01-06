Imports System.Data.Odbc
Module Koneksi_Hotel
    Public Conn As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Dt As DataTable
    Public CMD As OdbcCommand
    Public Rd As OdbcDataReader
    Public MyDB As String

    Public Sub Koneksi()
        MyDB = "Driver={MySQL ODBC 3.51 Driver};Database=bookinghotel_kel3;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
End Module
