Imports System.Data.Odbc
Public Class Tamu
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
       MsgBox("Anda sudah berada di menu yang dipilih")
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
        Me.Hide()
        TamuInHouse.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Button3.Text = "Close" Then
            Me.Close()
            Login.Close()
        Else
            Call KondisiAwal()
        End If


    End Sub

    Private Sub Tamu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox1.Enabled = False
        TextBox1.ReadOnly = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = True
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button3.Enabled = True
        Button1.Text = "Input"
        Button3.Text = "Close"
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM tamu WHERE status = 0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tamu")
        DataGridView1.DataSource = Ds.Tables("tamu")
    End Sub

    Sub FieldAktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button4.Enabled = False
            Button3.Text = "Batal"
            Call FieldAktif()
        Else
            Dim status As Integer
            status = 0

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
                MsgBox("Data tidak boleh kosong")
            Else
                Call Koneksi()
                Dim InputData, CheckData As String
                CheckData = "SELECT * FROM tamu WHERE nomor_identitas = '" & TextBox1.Text & "'"
                InputData = "INSERT INTO tamu (nama_depan_tamu,nama_belakang_tamu,panggilan_tamu,identitas_tamu,nomor_identitas,warga_negara,alamat_tinggal,kota,provinsi,nomor_hp,email,status) VALUES ('" & TextBox2.Text & "', '" & TextBox3.Text & "','" & ComboBox1.Text & "', '" & ComboBox2.Text & "', '" & TextBox1.Text & "', '" & ComboBox3.Text & "', '" & TextBox6.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & status & "')"
                CMD = New OdbcCommand(InputData, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("Berhasil input Data")
                Call KondisiAwal()
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim EditData As String
            EditData = "UPDATE tamu SET nama_depan_tamu='" & TextBox2.Text & "', nama_belakang_tamu='" & TextBox3.Text & "',panggilan_tamu='" & ComboBox1.Text & "', identitas_tamu='" & ComboBox2.Text & "', nomor_identitas='" & TextBox1.Text & "', warga_negara='" & ComboBox3.Text & "', alamat_tinggal='" & TextBox6.Text & "', kota='" & TextBox7.Text & "', provinsi='" & TextBox8.Text & "', nomor_hp='" & TextBox4.Text & "', email='" & TextBox5.Text & "'"
            CMD = New OdbcCommand(EditData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Edit Data Behasil")
            Call KondisiAwal()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Isi data sebelum dihapus")
        Else
            Call Koneksi()
            Dim HapusData As String
            HapusData = "DELETE FROM tamu WHERE nomor_identitas = '" & TextBox1.Text & "'"
            CMD = New OdbcCommand(HapusData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Hapus Data Behasil")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
            Button1.Text = "Simpan"
            Button2.Enabled = True
            Button4.Enabled = True
        Button3.Text = "Batal"
        Button1.Enabled = False
            Call FieldAktif()
            Call Koneksi()
            CMD = New OdbcCommand("SELECT * FROM tamu WHERE nomor_identitas = '" & TextBox9.Text & "'", Conn)
            Rd = CMD.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox1.Text = Rd.Item("nomor_identitas")
                TextBox1.ReadOnly = True
                TextBox2.Text = Rd.Item("nama_depan_tamu")
                TextBox3.Text = Rd.Item("nama_belakang_tamu")
                TextBox4.Text = Rd.Item("nomor_hp")
                TextBox5.Text = Rd.Item("email")
                TextBox6.Text = Rd.Item("alamat_tinggal")
                TextBox7.Text = Rd.Item("kota")
                TextBox8.Text = Rd.Item("provinsi")
                ComboBox1.Text = Rd.Item("panggilan_tamu")
                ComboBox2.Text = Rd.Item("identitas_tamu")
                ComboBox3.Text = Rd.Item("warga_negara")
            Else
                MsgBox("Data Tidak Ada")
            End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(5).Value
        TextBox1.ReadOnly = True
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(10).Value
        TextBox5.Text = DataGridView1.CurrentRow.Cells(11).Value
        TextBox6.Text = DataGridView1.CurrentRow.Cells(7).Value
        TextBox7.Text = DataGridView1.CurrentRow.Cells(8).Value
        TextBox8.Text = DataGridView1.CurrentRow.Cells(9).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(3).Value
        ComboBox2.Text = DataGridView1.CurrentRow.Cells(4).Value
        ComboBox3.Text = DataGridView1.CurrentRow.Cells(6).Value
        Call FieldAktif()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
    End Sub
End Class