Imports System.Data.Odbc
Public Class RoomServices
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        MsgBox("Logout Berhasil")
        Me.Close()
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
        Me.Close()
    End Sub

    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KategoriKamarToolStripMenuItem.Click
        Me.Close()
        Kategori_Kamar.Show()
    End Sub

    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarToolStripMenuItem.Click
        Me.Close()
        Kamar.Show()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click
        Me.Close()
        CheckIn.Show()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        Me.Close()
        CheckOut.Show()
    End Sub

    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Close()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Close()
        TamuInHouse.Show()
    End Sub

    Private Sub LayananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayananToolStripMenuItem.Click
        Me.Close()
        Layanan.Show()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Close()
        Food.Show()
    End Sub
    Sub NamaTamu()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT ps.id_pesan_kamar, t.nama_depan_tamu, t.id_tamu FROM tamu as t INNER JOIN pesan_kamar as ps ON t.id_tamu=ps.id_tamu WHERE t.status=1 AND ps.status_pesan=0;", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "nama_depan_tamu"
        ComboBox1.ValueMember = "id_pesan_kamar"
        ComboBox1.Text = "Pilih Nama Tamu"
    End Sub
    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesanan WHERE status_pesanan=0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesanan")
        DataGridView1.DataSource = Ds.Tables("pesanan")
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        DateTimePicker1.Visible = False
    End Sub
    Sub Disable()
        ComboBox1.Enabled = False
        TextBox1.Enabled = False
    End Sub
    Sub NamaMakanan()
        CMD = New OdbcCommand("SELECT * from layanan WHERE kategori='Room'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox2.DataSource = Dt
        ComboBox2.DisplayMember = "nama_layanan"
        ComboBox2.ValueMember = "id_layanan"
        ComboBox2.Text = "Pilih Layanan"
    End Sub
    Private Sub Food_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call NamaTamu()
        Call Disable()
        Call NamaMakanan()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Enabled = True
        TextBox1.Enabled = True
        Label9.Text = ComboBox2.GetItemText(ComboBox2.SelectedValue)
        CMD = New OdbcCommand("SELECT harga from layanan WHERE id_layanan='" & Label9.Text & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Label6.Text = Rd.Item("harga")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim Jumlah As Integer
        Jumlah = Val(Label6.Text) * Val(TextBox1.Text)
        Label7.Text = Jumlah
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TambahPesanan, TglSaya As String
        Dim StatusPesanan As Integer
        StatusPesanan = 0
        TglSaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        TambahPesanan = "INSERT INTO pesanan (id_pesan_kamar,id_tamu,id_layanan,nama_layanan,banyak_pesanan,total_harga,status_pesanan,tanggal_pesan,waktu_pesan) VALUES ('" & Label8.Text & "','" & Label10.Text & "', '" & Label9.Text & "', '" & ComboBox2.Text & "', '" & TextBox1.Text & "', '" & Label7.Text & "', '" & StatusPesanan & "', '" & TglSaya & "', '" & Now.ToLongTimeString & "')"
        CMD = New OdbcCommand(TambahPesanan, Conn)
        CMD.ExecuteNonQuery()
        MsgBox("Pesanan ditambahkan")
        Call KondisiAwal()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label8.Text = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        CMD = New OdbcCommand("SELECT id_tamu from tamu WHERE nama_depan_tamu='" & ComboBox1.Text & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Label10.Text = Rd.Item("id_tamu")
        End If
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        Me.Close()
        MenuUtama.Show()
    End Sub
End Class