Imports System.Data.Odbc
Public Class TamuInHouse

    Sub NamaTamu()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM tamu WHERE status = 1", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "nama_depan_tamu"
        ComboBox1.ValueMember = "id_Tamu"
        ComboBox1.Text = "Pilih Nama Tamu"
    End Sub

    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM tamu WHERE status = 1", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tamu")
        DataGridView1.DataSource = Ds.Tables("tamu")
    End Sub
    Private Sub TamuInHouse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call NamaTamu()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Koneksi()
        Dim id_tamu As Integer
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        CMD = New OdbcCommand("SELECT ps.tipe_kamar, t.id_tamu, k.id_kamar, k.nomor_kamar, ps.id_kamar, ps.id_tamu FROM pesan_kamar as ps INNER JOIN tamu as t ON ps.id_tamu=t.id_tamu INNER JOIN kamar as k ON ps.id_kamar=k.id_kamar WHERE status_pesan=0 AND ps.id_tamu='" & id_tamu & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Label3.Text = Rd.Item("tipe_kamar")
            Label5.Text = Rd.Item("nomor_kamar")
        Else
            MsgBox("Data Tidak Ada")
        End If
    End Sub
End Class