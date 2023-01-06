Imports System.Data.Odbc
Public Class Login
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username atau Password tidak boleh kosong")
        Else
            CMD = New OdbcCommand("SELECT * FROM login WHERE username='" & TextBox1.Text & "' AND PASSWORD='" & TextBox2.Text & "'", Conn)
            Rd = CMD.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                MenuUtama.Show()
                Me.Hide()
                MenuUtama.Label2.Text = Rd.Item("nama_admin")
                MenuUtama.Label7.Text = Rd.Item("tipe_administrator")
                If MenuUtama.Label7.Text = "Super Administrator" Then
                    MenuUtama.KamarToolStripMenuItem.Enabled = True
                    MenuUtama.LayananToolStripMenuItem.Enabled = True
                    MenuUtama.LaporanToolStripMenuItem.Enabled = True
                    MenuUtama.KategoriKamarToolStripMenuItem.Enabled = True
                    MenuUtama.AdministrasiHotelToolStripMenuItem.Enabled = True
                Else
                    MenuUtama.KamarToolStripMenuItem.Enabled = False
                    MenuUtama.LayananToolStripMenuItem.Enabled = False
                    MenuUtama.LaporanToolStripMenuItem.Enabled = False
                    MenuUtama.KategoriKamarToolStripMenuItem.Enabled = False
                    MenuUtama.AdministrasiHotelToolStripMenuItem.Enabled = False
                End If
            Else
                MsgBox("Username atau Password Salah")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"
        Call Koneksi()
        If Conn.State = ConnectionState.Open Then
            Label4.Text = "Connect"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class