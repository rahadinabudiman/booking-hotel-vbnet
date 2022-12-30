Imports System.Data.Odbc
Public Class CheckOut
    Sub KondisiAwal()
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesan_kamar WHERE status_pesan = 0", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "pesan_kamar")
        DataGridView1.DataSource = Ds.Tables("pesan_kamar")
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim id_tamu As Integer
        Dim Panggil_Pesan_Kamar As String
        id_tamu = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        Panggil_Pesan_Kamar = "SELECT id_pesan_kamar FROM pesan_kamar WHERE id_tamu ='" & id_tamu & "'"
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM pesan_kamar INNER JOIN tamu ON pesan_kamar.id_tamu = tamu.id_tamu WHERE pesan_kamar.id_tamu = '" & id_tamu & "'", Conn)
        Rd = CMD.ExecuteReader
        Rd.Read()

        Dim dtdd As DateTime
        If Rd.HasRows Then
            Label9.Text = Rd.Item("tipe_kamar")
            Label10.Text = Rd.Item("nama_belakang_tamu")
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
End Class