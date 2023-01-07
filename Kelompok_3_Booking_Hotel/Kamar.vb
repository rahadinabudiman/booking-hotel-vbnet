Imports System.Data.Odbc
Public Class Kamar
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Logout Berhasil")
        Me.Close()
        Login.Show()
        Login.TextBox1.Text = ""
        Login.TextBox2.Text = ""
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Login.Close()
    End Sub

    Private Sub BukuTamuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Tamu.Show()
        Me.Close()
    End Sub

    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Kategori_Kamar.Show()
    End Sub
    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        CheckIn.Show()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        CheckOut.Show()
    End Sub
    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Close()
        TamuInHouse.Show()
    End Sub
    Sub KondisiAwal()
        Label7.Visible = False
        TextBox1.Enabled = False
        ComboBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox3.Text = ""
        Button1.Text = "Input"
        Button4.Text = "Close"
        Button2.Enabled = True
        Button4.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM kamar WHERE status=0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kamar")
        DataGridView1.DataSource = Ds.Tables("kamar")
        Label6.Visible = False
    End Sub

    Sub FieldAktif()
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call FieldAktif()
        Else
            Call Koneksi()
            CMD = New OdbcCommand("SELECT nomor_kamar FROM kamar WHERE nomor_kamar = '" & TextBox1.Text & "'", Conn)
            Da = New OdbcDataAdapter(CMD)
            Dt = New DataTable
            Da.Fill(Dt)

            If Dt.Rows.Count > 0 Then
                MsgBox("Nomor Kamar Sudah Ada")
            Else
                If TextBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                    MsgBox("Data tidak boleh kosong")
                Else
                    Dim Status As Integer
                    Status = 0
                    Call Koneksi()
                    Dim InputData As String
                    InputData = "INSERT INTO kamar (nomor_kamar,tipe_kamar,kapasitas,status) VALUES ('" & TextBox1.Text & "', '" & ComboBox1.Text & "', '" & TextBox3.Text & "','status')"
                    CMD = New OdbcCommand(InputData, Conn)
                    CMD.ExecuteNonQuery()
                    MsgBox("Berhasil input Data")
                    Call KondisiAwal()
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Batal" Then
            Call KondisiAwal()
        Else
            Me.Close()
            Login.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Label5.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        Label7.Text = DataGridView1.CurrentRow.Cells(1).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value
        Call FieldAktif()
        Button1.Enabled = False
        Label5.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Koneksi()
        CMD = New OdbcCommand("SELECT nomor_kamar FROM kamar WHERE nomor_kamar = '" & TextBox1.Text & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)

        If TextBox1.Text = Label7.Text Then
            Dim UpdateData As String
            UpdateData = "UPDATE kamar SET tipe_kamar='" & ComboBox1.Text & "' , kapasitas='" & TextBox3.Text & "' WHERE id_kamar = '" & Label5.Text & "'"
            CMD = New OdbcCommand(UpdateData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Ubah Data")
            Call KondisiAwal()
        Else
            If Dt.Rows.Count > 0 Then
                MsgBox("Nomor Kamar Sudah Ada")
            Else
                If TextBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
                    MsgBox("Data tidak boleh kosong")
                Else
                    Dim UpdateData As String
                    UpdateData = "UPDATE kamar SET nomor_kamar='" & TextBox1.Text & "', tipe_kamar='" & ComboBox1.Text & "' , kapasitas='" & TextBox3.Text & "' WHERE id_kamar = '" & Label5.Text & "'"
                    CMD = New OdbcCommand(UpdateData, Conn)
                    CMD.ExecuteNonQuery()
                    MsgBox("Berhasil Ubah Data")
                    Call KondisiAwal()
                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim HapusData, CheckData As String
            HapusData = "DELETE FROM kamar WHERE id_kamar = '" & Label5.Text & "'"
            CMD = New OdbcCommand(HapusData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Hapus Data")
            Call KondisiAwal()
        End If
    End Sub
    Sub Tipe_Kamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT tipe_kamar,harga_kamar, kapasitas FROM kategori_kamar", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        ComboBox1.DataSource = Dt
        ComboBox1.DisplayMember = "tipe_kamar"
        ComboBox1.ValueMember = "harga_kamar"
        ComboBox1.Text = "Pilih Tipe Kamar"
        Label6.Text = "0"
        TextBox3.DataBindings.Add("Text", Dt, "kapasitas")
    End Sub

    Private Sub Kamar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call Tipe_Kamar()
        TextBox3.ReadOnly = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        CMD = New OdbcCommand("SELECT harga_kamar FROM kategori_kamar WHERE tipe_kamar ='" & ComboBox1.Text, Conn)
        Label6.Text = ComboBox1.GetItemText(ComboBox1.SelectedValue)
    End Sub

    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarToolStripMenuItem.Click
        MsgBox("Anda sudah berada di menu yang dipilih")
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        Me.Close()
        MenuUtama.Show()
    End Sub
End Class