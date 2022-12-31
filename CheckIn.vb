Imports System.Data.Odbc
Public Class CheckIn
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
    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        Me.Hide()
        CheckOut.Show()
    End Sub

    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Hide()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Hide()
        TamuInHouse.Show()
    End Sub
    Sub DisabledAll()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
    End Sub
    Sub EnabledAll()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
    End Sub
    Sub KondisiAwal()
        Call DisabledAll()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Label13.Text = "0"
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button3.Text = "Close"
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesan_kamar WHERE status_pesan = 0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesan_kamar")
        DataGridView1.DataSource = Ds.Tables("pesan_kamar")
        Button1.Text = "Input"
    End Sub
    Sub NamaTamu()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT id_tamu, nama_depan_tamu FROM tamu WHERE status=0", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "nama_depan_tamu"
        ComboBox1.ValueMember = "id_Tamu"
        ComboBox1.Text = "Pilih Nama Tamu"
    End Sub
    Sub KategoriKamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT tipe_kamar, harga_kamar FROM kategori_kamar", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox2.DataSource = Dt
        ComboBox2.DisplayMember = "tipe_kamar"
        ComboBox2.ValueMember = "harga_kamar"
        ComboBox2.Text = "Pilih Tipe Kamar"
        Label13.Text = "0"
    End Sub
    Sub NomorKamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT nomor_kamar, id_kamar, kapasitas, tipe_kamar FROM kamar WHERE status= 0 AND tipe_kamar='" & ComboBox2.Text & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox3.DataSource = Dt
        ComboBox3.DisplayMember = "nomor_kamar"
        ComboBox3.ValueMember = "id_kamar"
        ComboBox3.Text = "Pilih Nomor Kamar"
    End Sub
    Private Sub CheckIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call NamaTamu()
        Call KategoriKamar()
        TextBox3.Text = 150000
        Label15.Visible = False
        Label16.Visible = False
        Label17.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Text = "Batal"
            Call EnabledAll()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
                MsgBox("Data tidak boleh kosong")
            Else
                Call Koneksi()
                Dim InputData, CheckData, GantiStatusKamar, GantiStatusTamu As String
                Dim id_tamu, id_kamar, status_pesan, status_kamar, status_tamu As Integer
                id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
                id_kamar = ComboBox3.GetItemText(ComboBox3.SelectedValue)
                status_pesan = 0
                status_kamar = 1
                status_tamu = 1
                Dim TglSaya As String
                TglSaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
                Dim nilai As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
                Dim hasil As String = ""
                Dim Count = 0
                Dim Random As New Random
                Dim strpos = ""
                While Count < 5
                    strpos = Random.Next(0, nilai.Length)
                    hasil = hasil & nilai(strpos)
                    Count = Count + 1
                End While
                InputData = "INSERT INTO pesan_kamar (invoice,tipe_kamar,id_tamu,jumlah_tamu,id_kamar,harga_awal,lama_pesan,jumlah_deposit,tanggal_masuk,jam_masuk,status_pesan) VALUES ('" & hasil & "','" & ComboBox2.Text & "','" & id_tamu & "', '" & TextBox1.Text & "','" & id_kamar & "', '" & TextBox5.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TglSaya & "','" & Now.ToLongTimeString & "','status_pesan')"
                GantiStatusKamar = "UPDATE kamar SET status='" & status_kamar & "' WHERE id_kamar='" & id_kamar & "'"
                GantiStatusTamu = "UPDATE tamu SET status='" & status_tamu & "' WHERE id_tamu='" & id_tamu & "'"
                CMD = New OdbcCommand(GantiStatusTamu, Conn)
                CMD.ExecuteNonQuery()
                CMD = New OdbcCommand(GantiStatusKamar, Conn)
                CMD.ExecuteNonQuery()
                CMD = New OdbcCommand(InputData, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("Berhasil input Data")
                Call KondisiAwal()
            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "Batal" Then
            Call KondisiAwal()
        Else
            Me.Close()
            Login.Close()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call NomorKamar()
        Label13.Text = ComboBox2.GetItemText(ComboBox2.SelectedValue)
        Dim TotalHarga, LamaMenginap As Integer
        LamaMenginap = Val(TextBox2.Text)
        TotalHarga = (Val(Label13.Text) * LamaMenginap) + Val(TextBox3.Text)
        TextBox5.Text = TotalHarga
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim TotalHarga, LamaMenginap As Integer
        LamaMenginap = Val(TextBox2.Text)
        TotalHarga = (Val(Label13.Text) * LamaMenginap) + Val(TextBox3.Text)
        TextBox5.Text = TotalHarga
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Dim Kembalian, TotalBayar As Integer
        TotalBayar = Val(TextBox6.Text)
        Kembalian = TotalBayar - Val(TextBox5.Text)
        TextBox7.Text = Kembalian
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim HapusData, CheckData, GantiStatusKamar, GantiStatusTamu As String
            Dim id_tamu, id_kamar, status_kamar, status_tamu, id_pesan_kamar As Integer
            status_kamar = 0
            status_tamu = 0
            id_pesan_kamar = Label15.Text
            id_tamu = Label16.Text
            id_kamar = Label17.Text
            GantiStatusKamar = "UPDATE kamar SET status='" & status_kamar & "' WHERE id_kamar='" & id_kamar & "'"
            GantiStatusTamu = "UPDATE tamu SET status='" & status_tamu & "' WHERE id_tamu='" & id_tamu & "'"
            HapusData = "DELETE FROM pesan_kamar WHERE id_pesan_kamar = '" & id_pesan_kamar & "'"
            CMD = New OdbcCommand(GantiStatusKamar, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(GantiStatusTamu, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(HapusData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Hapus Data")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call Koneksi()
        Call KategoriKamar()
        Call NomorKamar()
        Dim id_tamu As Integer
        ComboBox1.Enabled = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        id_tamu = DataGridView1.CurrentRow.Cells(2).Value
        CMD = New OdbcCommand("SELECT nama_depan_tamu FROM tamu WHERE id_tamu='" & id_tamu & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            ComboBox1.DataSource = Dt
            ComboBox1.DisplayMember = "nama_depan_tamu"
            ComboBox1.ValueMember = "id_Tamu"
        End If
        TextBox1.Text = DataGridView1.CurrentRow.Cells(3).Value
        ComboBox2.Text = DataGridView1.CurrentRow.Cells(5).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(9).Value
        Label15.Text = DataGridView1.CurrentRow.Cells(0).Value
        Label16.Text = DataGridView1.CurrentRow.Cells(2).Value
        Label17.Text = DataGridView1.CurrentRow.Cells(4).Value
        Button1.Enabled = False
        Button3.Text = "Batal"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim EditData, EditStatusKamar, EditKamarTerpakai As String
            Dim status_kamar, status_tamu, id_pesan_kamar, id_kamar, kamar_tidak_terpakai, kamar_terpakai As Integer
            status_kamar = 0
            status_tamu = 0
            kamar_tidak_terpakai = 0
            kamar_terpakai = 1
            id_pesan_kamar = Label15.Text
            If ComboBox3.Text = "Pilih Nomor Kamar" Then
                id_kamar = Label17.Text
            Else
                id_kamar = ComboBox3.GetItemText(ComboBox3.SelectedValue)
                EditKamarTerpakai = "UPDATE kamar SET status = '" & kamar_terpakai & "' WHERE id_kamar ='" & id_kamar & "'"
                CMD = New OdbcCommand(EditKamarTerpakai, Conn)
                CMD.ExecuteNonQuery()
            End If

            Dim TglSaya As String
            TglSaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            EditData = "UPDATE pesan_kamar SET jumlah_tamu = '" & TextBox1.Text & "', tipe_kamar ='" & ComboBox2.Text & "', id_kamar ='" & id_kamar & "', lama_pesan ='" & TextBox2.Text & "' , tanggal_masuk ='" & TglSaya & "' , jam_masuk ='" & Now.ToLongTimeString & "' WHERE id_pesan_kamar = '" & id_pesan_kamar & "'"
            EditStatusKamar = "UPDATE kamar SET status ='" & kamar_tidak_terpakai & "' WHERE id_kamar = '" & Label17.Text & "'"
            CMD = New OdbcCommand(EditStatusKamar, Conn)
            CMD.ExecuteNonQuery()
            CMD = New OdbcCommand(EditData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Edit Data")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click
        MsgBox("Anda sudah berada di menu yang dipilih")
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Hide()
        Food.Show()
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        Me.Hide()
        MenuUtama.Show()
    End Sub
End Class