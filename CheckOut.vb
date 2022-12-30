Imports System.Data.Odbc
Public Class CheckOut
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
    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Hide()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Hide()
        TamuInHouse.Show()
    End Sub
    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesan_kamar WHERE status_pesan = 0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesan_kamar")
        DataGridView1.DataSource = Ds.Tables("pesan_kamar")
        DataGridView2.Visible = False
    End Sub
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
        Call KondisiAwal()
        DateTimePicker1.CustomFormat = "HH:mm tt"
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
    End Sub
    Sub TotalPesanan()
        Dim id_tamu, totalharga As Integer
        Call Koneksi()
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Da = New OdbcDataAdapter("SELECT total_harga FROM pesanan WHERE status_pesanan = 0 AND id_tamu ='" & id_tamu & "'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesanan")
        DataGridView2.DataSource = Ds.Tables("pesanan")

        totalharga = 0

        For i As Integer = 0 To DataGridView2.RowCount - 1
            totalharga += DataGridView2.Rows(i).Cells(0).Value
        Next
        Label22.Text = totalharga
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call TotalPesanan()
        Dim id_tamu As Integer
        Dim Panggil_Pesan_Kamar As String
        Call Koneksi()
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Panggil_Pesan_Kamar = "SELECT id_pesan_kamar FROM pesan_kamar WHERE id_tamu ='" & id_tamu & "'"
        CMD = New OdbcCommand("SELECT ps.id_pesan_kamar, ps.harga_awal, ps.tipe_kamar, t.id_tamu, t.nama_depan_tamu, k.id_kamar, k.nomor_kamar, ps.id_kamar, ps.id_tamu FROM pesan_kamar as ps INNER JOIN tamu as t ON ps.id_tamu=t.id_tamu INNER JOIN kamar as k ON ps.id_kamar=k.id_kamar WHERE status_pesan=0 AND ps.id_tamu='" & id_tamu & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Label9.Text = Rd.Item("tipe_kamar")
            Label10.Text = Rd.Item("nomor_kamar")
            Label13.Text = Rd.Item("harga_awal")
            Label18.Text = Rd.Item("id_pesan_kamar")
            Label19.Text = Rd.Item("id_kamar")
            Label20.Text = Rd.Item("id_tamu")
        Else
            MsgBox("Data Tidak Ada")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Koneksi()
        Dim InputData, CheckData, TglSaya, ganti_status_kamar, ganti_status_tamu As String
        Dim status_pesan, jumlah_deposit, status_tamu As Integer
        status_pesan = 1
        jumlah_deposit = 0
        status_tamu = 0
        TglSaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        InputData = "UPDATE pesan_kamar SET tanggal_keluar='" & TglSaya & "', jam_keluar='" & Now.ToLongTimeString & "', denda='" & Label15.Text & "', harga_akhir='" & Label17.Text & "' , status_pesan='" & status_pesan & "' , jumlah_deposit='" & jumlah_deposit & "' WHERE id_pesan_kamar = '" & Label18.Text & "'"
        ganti_status_kamar = "UPDATE kamar SET status=2 WHERE id_kamar ='" & Label19.Text & "'"
        ganti_status_tamu = "UPDATE tamu SET status=0 WHERE id_tamu ='" & Label20.Text & "'"
        CMD = New OdbcCommand(ganti_status_tamu, Conn)
        CMD.ExecuteNonQuery()
        CMD = New OdbcCommand(ganti_status_kamar, Conn)
        CMD.ExecuteNonQuery()
        CMD = New OdbcCommand(InputData, Conn)
        CMD.ExecuteNonQuery()
        MsgBox("Berhasil input Data")
        Call KondisiAwal()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        MsgBox("Anda sudah berada di menu yang dipilih")
    End Sub
End Class