Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic
Public Class CetakStruk
    Sub NamaTamu()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT t.nama_depan_tamu, t.id_tamu FROM tamu AS t WHERE t.status=1", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "nama_depan_tamu"
        ComboBox1.ValueMember = "id_tamu"
        ComboBox1.Text = "Pilih Nama Tamu"
    End Sub

    Private Sub CetakStruk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call NamaTamu()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim id_tamu As Integer
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM pesanan WHERE status_pesanan=0 AND id_tamu ='" & id_tamu & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            Dim Lap As New ReportDocument
            Lap.Load("LaporanHotel.rpt")

            TampilStruk.CrystalReportViewer1.SelectionFormula = "{pesanan1.id_tamu}=" & id_tamu & " AND {pesanan1.status_pesanan}=0"
            TampilStruk.CrystalReportViewer1.RefreshReport()
            TampilStruk.ShowDialog()
        Else
            MsgBox("Tidak ada pesanan")
        End If
    End Sub
End Class