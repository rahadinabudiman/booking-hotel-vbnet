Imports System.Data.Odbc
Public Class Layanan
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
    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KategoriKamarToolStripMenuItem.Click
        Me.Hide()
        Kategori_Kamar.Show()
    End Sub

    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarToolStripMenuItem.Click
        Me.Hide()
        Kamar.Show()
    End Sub
    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Hide()
        PembersihanKamar.Show()
    End Sub
    Private Sub LayananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayananToolStripMenuItem.Click
         MsgBox("Anda sudah berada pada menu yang dipilih")
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Hide()
        Food.Show()
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        Me.Hide()
        MenuUtama.Show()
    End Sub
    Sub KondisiAwal()
        ComboBox1.Text = "Pilih Kategori"
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM layanan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "layanan")
        DataGridView1.DataSource = Ds.Tables("layanan")
    End Sub
    Private Sub Layanan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "Pilih Kategori" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            CMD = New OdbcCommand("INSERT INTO layanan (nama_layanan,kategori,harga) VALUES ('" & TextBox1.Text & "','" & ComboBox1.Text & "', '" & TextBox3.Text & "')", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil input Data")
            Call KondisiAwal()
        End If
    End Sub
End Class