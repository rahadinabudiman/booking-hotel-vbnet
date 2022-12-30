Imports System.Data.Odbc
Public Class Layanan

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