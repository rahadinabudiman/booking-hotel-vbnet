Imports System.Data.Odbc
Public Class PembersihanKamar
    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM kamar WHERE status = 2", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "kamar")
        DataGridView1.DataSource = Ds.Tables("kamar")
    End Sub
    Sub LoadKamarKotor()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM kamar WHERE status=2 AND tipe_kamar = '" & ComboBox1.Text & "'", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            ComboBox2.DataSource = Dt
            ComboBox2.DisplayMember = "nomor_kamar"
            ComboBox2.ValueMember = "id_kamar"
            ComboBox2.Text = "Pilih Nomor Kamar"
            ComboBox2.Enabled = True
            Button1.Enabled = True
        Else
            ComboBox2.Text = "Tidak Ada Kamar Kotor"
            ComboBox2.Enabled = False
            Button1.Enabled = False
        End If
    End Sub
    Sub KategoriKamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT tipe_kamar FROM kategori_kamar", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            ComboBox1.DataSource = Dt
            ComboBox1.DisplayMember = "tipe_kamar"
            ComboBox1.ValueMember = "tipe_kamar"
            ComboBox1.Text = "Pilih Tipe Kamar"
        Else
            ComboBox1.Text = "Tidak Ada Kamar Kotor"
            ComboBox1.Enabled = False
        End If

    End Sub
    Private Sub PembersihanKamar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call KategoriKamar()
        Call StatusKotorKamar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Or ComboBox1.Text = "Pilih Tipe Kamar" Or ComboBox2.Text = "Pilih Nomor Kamar" Then
            MsgBox("Data tidak boleh kosong")
        Else
            Call Koneksi()
            Dim GantiStatusKamar As String
            GantiStatusKamar = "UPDATE kamar SET status = 0 WHERE id_kamar ='" & ComboBox2.GetItemText(ComboBox2.SelectedValue) & "'"
            CMD = New OdbcCommand(GantiStatusKamar, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Kamar sudah dibersihkan")
            Call KondisiAwal()
        End If
    End Sub
    Sub StatusKotorKamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM kamar WHERE status=2", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            Label1.Text = "Ada Kamar Kotor (Checkout)"
        Else
            Label1.Text = "Tidak Ada Kamar Kotor (Checkout)"
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call LoadKamarKotor()
    End Sub
End Class