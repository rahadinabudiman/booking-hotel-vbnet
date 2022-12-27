Imports System.Data.Odbc
Public Class CheckIn
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
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Label13.Text = "0"
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        Button2.Enabled = True
        Button4.Enabled = True
        Button3.Text = "Close"
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM pesan_kamar", Conn)
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
End Class