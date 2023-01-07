Imports System.Data.Odbc
Public Class CheckOut
    Sub ResetAll()
        Button1.Enabled = False
        Button2.Enabled = False
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label24.Text = ""
        Label15.Text = 0
        Label17.Text = 0
        Label22.Text = 0
        Label27.Text = 0
        TextBox1.Enabled = False
    End Sub
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
    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Close()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Close()
        TamuInHouse.Show()
    End Sub
    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesan_kamar WHERE status_pesan = 0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesan_kamar")
        DataGridView1.DataSource = Ds.Tables("pesan_kamar")
        DataGridView2.Visible = False
        ListView1.Items.Clear()
        Call NamaTamu()
        Call ListBoxMakanan()
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
    Sub ListBoxMakanan()
        ListView1.Columns.Add("Nama Layanan", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Jumlah", 60, HorizontalAlignment.Center)
        ListView1.Columns.Add("Total Harga", 80, HorizontalAlignment.Right)

        ListView1.View = View.Details
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
    End Sub
    Sub NampilkanDataMakanan()
        Dim id_tamu As Integer
        Call Koneksi()
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Da = New OdbcDataAdapter("SELECT nama_layanan, banyak_pesanan, total_harga FROM pesanan WHERE id_tamu ='" & id_tamu & "' AND status_pesanan = '0'", Conn)
        Dt = New DataTable
        Da.Fill(Dt)
            For Each Drow As DataRow In Dt.Rows
                ListView1.Items.Add(Drow(0).ToString())
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Drow(1).ToString())
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Drow(2).ToString())
            Next
    End Sub
    Private Sub CheckOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call NamaTamu()
        Call KondisiAwal()
        Call ListBoxMakanan()
        Call ResetAll()
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
        DateTimePicker2.Visible = False
        Label32.Visible = False
        Label34.Visible = False
        Label35.Visible = False
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
    Sub HargaAkhir()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Enabled = True
        Button2.Enabled = True
        Call TotalPesanan()
        Dim id_tamu As Integer
        Dim Panggil_Pesan_Kamar, TglSaya As String
        Call Koneksi()
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Panggil_Pesan_Kamar = "SELECT id_pesan_kamar FROM pesan_kamar WHERE id_tamu ='" & id_tamu & "'"
        CMD = New OdbcCommand("SELECT ps.lama_pesan, ps.tanggal_masuk, ps.jam_masuk, ps.jumlah_deposit, ps.id_pesan_kamar, ps.harga_awal, ps.tipe_kamar, t.id_tamu, t.nama_depan_tamu, k.id_kamar, k.nomor_kamar, ps.id_kamar, ps.id_tamu FROM pesan_kamar as ps INNER JOIN tamu as t ON ps.id_tamu=t.id_tamu INNER JOIN kamar as k ON ps.id_kamar=k.id_kamar WHERE status_pesan=0 AND ps.id_tamu='" & id_tamu & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            DateTimePicker2.Text = Rd.Item("tanggal_masuk")
            Label11.Text = Format(Rd.Item("tanggal_masuk"), "dd/MM/yyyy")
            Label29.Text = Format(Rd.Item("tanggal_masuk"), "dd/MM/yyyy")
            Label31.Text = Rd.Item("lama_pesan")
            Label12.Text = Rd.Item("jam_masuk").ToString
            Label9.Text = Rd.Item("tipe_kamar")
            Label10.Text = Rd.Item("nomor_kamar")
            Label13.Text = Rd.Item("harga_awal")
            Label18.Text = Rd.Item("id_pesan_kamar")
            Label19.Text = Rd.Item("id_kamar")
            Label20.Text = Rd.Item("id_tamu")
            Label14.Text = Rd.Item("jumlah_deposit")
        Else
            MsgBox("Data Tidak Ada")
        End If
        Label24.Text = Val(Label13.Text) - Val(Label14.Text)
        CMD = New OdbcCommand("SELECT harga_kamar FROM kategori_kamar WHERE tipe_kamar='" & Label9.Text & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        Label33.DataBindings.Add("Text", Dt, "harga_kamar")

        Call KondisiAwal()
        Call NampilkanDataMakanan()
        Label28.Text = Format(Now, "dd/MM/yyyy")
        Dim TanggalAwal As DateTime = Label29.Text
        Dim TanggalAkhir As DateTime = Label28.Text
        Label30.Text = (TanggalAkhir - TanggalAwal).Days
        If Val(Label30.Text) > Val(Label31.Text) Then
            Label32.Visible = True
            Label34.Visible = True
            Label35.Visible = True
            Label32.Text = Val(Label30.Text) - Val(Label31.Text)
            Label15.Text = Val(Label33.Text) * Val(Label32.Text)
        Else
            Label32.Visible = True
            Label34.Visible = True
            Label35.Visible = True
            Label32.Text = "Tidak lewat"
        End If
        Label17.Text = Val(Label22.Text) + Val(Label15.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text < Label17.Text Then
            MsgBox("Harap bayar dengan jumlah yang sudah ditentukan")
        Else
            Call Koneksi()
            Dim InputData, CheckData, TglSaya, ganti_status_kamar, ganti_status_tamu, ganti_Status_pesanan As String
            Dim status_pesan, jumlah_deposit, status_tamu As Integer
            status_pesan = 1
            jumlah_deposit = 0
            status_tamu = 0
            TglSaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            InputData = "UPDATE pesan_kamar SET tanggal_keluar='" & TglSaya & "', jam_keluar='" & Now.ToLongTimeString & "', denda='" & Label15.Text & "', harga_akhir='" & Label17.Text & "' , status_pesan='" & status_pesan & "' , jumlah_deposit='" & jumlah_deposit & "', denda='" & Label15.Text & "' , harga_akhir='" & Label17.Text & "' WHERE id_pesan_kamar = '" & Label18.Text & "'"
            ganti_status_kamar = "UPDATE kamar SET status=2 WHERE id_kamar ='" & Label19.Text & "'"
            ganti_status_tamu = "UPDATE tamu SET status=0 WHERE id_tamu ='" & Label20.Text & "'"
            ganti_Status_pesanan = "UPDATE pesanan SET status_pesanan='1', tanggal_bayar ='" & TglSaya & "', waktu_bayar ='" & Now.ToLongTimeString & "' WHERE id_pesan_kamar = '" & Label18.Text & "' AND id_tamu ='" & Label20.Text & "'"
            CMD = New OdbcCommand(ganti_Status_pesanan, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(ganti_status_tamu, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(ganti_status_kamar, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(InputData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Checkout Berhasil")
            Call KondisiAwal()
            Call ResetAll()
        End If
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        MsgBox("Anda sudah berada di menu yang dipilih")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Label27.Text = Val(TextBox1.Text) - Val(Label17.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button1.Enabled = True
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Close()
        Food.Show()
    End Sub

    Private Sub MenuUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUtamaToolStripMenuItem.Click
        Me.Close()
        MenuUtama.Show()
    End Sub
End Class