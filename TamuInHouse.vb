Imports System.Data.Odbc
Public Class TamuInHouse
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        MsgBox("Logout Berhasil")
        Me.Hide()
        Login.Show()
        Login.TextBox1.Text = ""
        Login.TextBox2.Text = ""
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        Me.Close()
        Login.Close()
    End Sub

    Private Sub BukuTamuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BukuTamuToolStripMenuItem.Click
        Tamu.Show()
        Me.Hide()
    End Sub

    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KategoriKamarToolStripMenuItem.Click
        Me.Hide()
        Kategori_Kamar.Show()
    End Sub

    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarToolStripMenuItem.Click
        Me.Hide()
        Kamar.Show()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click
        Me.Hide()
        CheckIn.Show()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        Me.Hide()
        CheckOut.Show()
    End Sub

    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Hide()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        MsgBox("Anda sudah berada pada menu yang dipilih")
    End Sub

    Private Sub LayananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayananToolStripMenuItem.Click
        Me.Hide()
        Layanan.Show()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Hide()
        Food.Show()
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        Me.Hide()
        MenuUtama.Show()
    End Sub
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