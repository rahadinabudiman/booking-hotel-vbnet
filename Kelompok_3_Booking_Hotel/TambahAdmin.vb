Imports System.Data.Odbc
Public Class TambahAdmin
    Sub NonAktif()
        TextBox1.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        ComboBox1.Enabled = False
    End Sub
    Sub Aktif()
        TextBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
    End Sub
    Sub KondisiAwal()
        Call Koneksi()
        TextBox1.Text = ""
        ComboBox1.Text = "Pilih Tipe Administrator"
        TextBox3.Text = ""
        TextBox4.Text = ""
        Da = New OdbcDataAdapter("SELECT * FROM login", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "login")
        DataGridView1.DataSource = Ds.Tables("login")
        Button1.Text = "Input"
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button4.Text = "Close"
        Call NonAktif()
    End Sub

    Private Sub TambahAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Label5.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Batal" Then
            Call KondisiAwal()
        Else
            Me.Close()
            Login.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Input" Then
            Button1.Text = "Simpan"
            Button4.Text = "Batal"
            Button2.Enabled = False
            Button3.Enabled = False
            Call Aktif()
        Else
                Call Koneksi()
                CMD = New OdbcCommand("SELECT username FROM login WHERE username = '" & TextBox3.Text & "'", Conn)
                Da = New OdbcDataAdapter(CMD)
                Dt = New DataTable
                Da.Fill(Dt)

                If Dt.Rows.Count > 0 Then
                    MsgBox("Username Sudah Ada")
            Else
                If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "Pilih Tipe Administrator" Then
                    MsgBox("Data tidak boleh kosong")
                Else
                    Dim InputData As String
                    InputData = "INSERT INTO login (username,password,nama_admin,tipe_administrator) VALUES ('" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "')"
                    CMD = New OdbcCommand(InputData, Conn)
                    CMD.ExecuteNonQuery()
                    MsgBox("Berhasil input Data")
                    Call KondisiAwal()
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Label5.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(1).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox1.Text = DataGridView1.CurrentRow.Cells(3).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value
        TextBox3.ReadOnly = True
        Call Aktif()
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "Pilih Tipe Administrator" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim HapusData As String
            HapusData = "DELETE FROM login WHERE id_login = '" & Label5.Text & "'"
            CMD = New OdbcCommand(HapusData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Hapus Data")
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "Pilih Tipe Administrator" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Dim UpdateData As String
            UpdateData = "UPDATE login SET password='" & TextBox4.Text & "', nama_admin='" & TextBox1.Text & "' , tipe_administrator='" & ComboBox1.Text & "' WHERE id_login = '" & Label5.Text & "'"
            CMD = New OdbcCommand(UpdateData, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil Ubah Data")
            Call KondisiAwal()
        End If
    End Sub
End Class