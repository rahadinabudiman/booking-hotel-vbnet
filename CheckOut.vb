Imports System.Data.Odbc
Public Class CheckOut
    Sub NamaTamu()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT id_tamu, nama_depan_tamu FROM tamu WHERE status=1", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "nama_depan_tamu"
        ComboBox1.ValueMember = "id_Tamu"
        ComboBox1.Text = "Pilih Nama Tamu"
    End Sub
    Private Sub CheckOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call NamaTamu()
        Call Koneksi()
        Dim id_tamu As Integer
        Dim Panggil_Pesan_Kamar As String
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Panggil_Pesan_Kamar = "SELECT id_pesan_kamar FROM pesan_kamar WHERE id_tamu ='" & id_tamu & "'"
        CMD = New OdbcCommand("SELECT tipe_kamar FROM tamu WHERE status=1 AND ", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
    End Sub
End Class