Imports System.Data.Odbc
Public Class Kategori_Kamar
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Logout Berhasil")
        Me.Hide()
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
        Me.Hide()
    End Sub
    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Kamar.Show()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        CheckIn.Show()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        CheckOut.Show()
    End Sub
    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Hide()
        TamuInHouse.Show()
    End Sub
    Sub KondisiAwal()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button1.Text = "Input"
        Button4.Text = "Close"
        Button2.Enabled = True
        Button4.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM kategori_kamar", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kategori_kamar")
        DataGridView1.DataSource = Ds.Tables("kategori_kamar")
    End Sub

    Sub FieldAktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Private Sub Kategori_Kamar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "Batal"
            Call FieldAktif()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Data tidak boleh kosong")
            Else
                Call Koneksi()
                Dim InputData, CheckData As String
                InputData = "INSERT INTO kategori_kamar (tipe_kamar,harga_kamar) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "')"
                CMD = New OdbcCommand(InputData, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("Berhasil input Data")
                Call KondisiAwal()
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
        Label3.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value
        Call FieldAktif()
        Button1.Enabled = False
        Label3.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim UpdateData, CheckData As String
            UpdateData = "UPDATE kategori_kamar SET  tipe_kamar='" & TextBox1.Text & "', harga_kamar='" & TextBox2.Text & "' WHERE id_kategori_kamar = '" & Label3.Text & "'"
            CMD = New OdbcCommand(UpdateData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Ubah Data")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim HapusData, CheckData As String
            HapusData = "DELETE FROM kategori_kamar WHERE id_kategori_kamar = '" & Label3.Text & "'"
            CMD = New OdbcCommand(HapusData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Hapus Data")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KategoriKamarToolStripMenuItem.Click
        MsgBox("Anda sudah berada di menu yang dipilih")
    End Sub
End Class