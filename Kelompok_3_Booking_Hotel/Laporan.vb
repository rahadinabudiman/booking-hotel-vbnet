Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic
Public Class Laporan

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Lap As New ReportDocument
        Lap.Load("LaporanHotel.rpt")

        TampilLaporan.CrystalReportViewer2.SelectionFormula = "{pesan_kamar1.tanggal_masuk}=date(" & Year(DateTimePicker1.Value) & "," & Month(DateTimePicker1.Value) & "," & Day(DateTimePicker1.Value) & ")"
        TampilLaporan.CrystalReportViewer2.RefreshReport()
        TampilLaporan.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Lap As New ReportDocument
        Lap.Load("LaporanHotel.rpt")

        TampilLaporan.CrystalReportViewer2.SelectionFormula = "YEAR({pesan_kamar1.tanggal_masuk})=" & Year(DateTimePicker2.Value) & ""
        TampilLaporan.CrystalReportViewer2.RefreshReport()
        TampilLaporan.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Lap As New ReportDocument
        Lap.Load("LaporanHotel.rpt")

        TampilLaporan.CrystalReportViewer2.SelectionFormula = "MONTH({pesan_kamar1.tanggal_masuk})=" & Month(DateTimePicker3.Value) & " AND YEAR({pesan_kamar1.tanggal_masuk})=" & Format(DateTimePicker3.Value, "yyyy") & ""
        TampilLaporan.CrystalReportViewer2.RefreshReport()
        TampilLaporan.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Lap As New ReportDocument
        Lap.Load("LaporanHotel.rpt")

        TampilLaporan.CrystalReportViewer2.SelectionFormula = "{pesan_kamar1.tanggal_masuk}>=date(" & Year(DateTimePicker4.Value) & "," & Month(DateTimePicker4.Value) & "," & Day(DateTimePicker4.Value) & ") AND  {pesan_kamar1.tanggal_masuk}<=date(" & Year(DateTimePicker5.Value) & "," & Month(DateTimePicker5.Value) & "," & Day(DateTimePicker5.Value) & ")"
        TampilLaporan.CrystalReportViewer2.RefreshReport()
        TampilLaporan.ShowDialog()
    End Sub
End Class