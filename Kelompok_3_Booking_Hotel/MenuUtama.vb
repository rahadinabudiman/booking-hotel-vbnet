Imports System.Data.Odbc
Public Class MenuUtama

    Private Property BindingSource1 As Object

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        MsgBox("Logout Berhasil")
        Me.Close()
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
        Me.Close()
    End Sub

    Private Sub KategoriKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KategoriKamarToolStripMenuItem.Click
        Me.Close()
        Kategori_Kamar.Show()
    End Sub

    Private Sub KamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KamarToolStripMenuItem.Click
        Me.Close()
        Kamar.Show()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click
        Me.Close()
        CheckIn.Show()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        Me.Close()
        CheckOut.Show()
    End Sub

    Private Sub PembersihanKamarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembersihanKamarToolStripMenuItem.Click
        Me.Close()
        PembersihanKamar.Show()
    End Sub

    Private Sub TamuInHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TamuInHouseToolStripMenuItem.Click
        Me.Close()
        TamuInHouse.Show()
    End Sub

    Private Sub LayananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayananToolStripMenuItem.Click
        Me.Close()
        Layanan.Show()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Close()
        Food.Show()
    End Sub

    Private Sub HalamanUtamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalamanUtamaToolStripMenuItem.Click
        MsgBox("Anda sudah berada pada menu yang dipilih")
    End Sub
    Sub JumlahData()
        Dim JumlahData
        JumlahData = DataGridView1.RowCount
        Label4.Text = JumlahData - 1
    End Sub
    Sub AmbilIdKamar()
        Call Koneksi()
        Dim BindingSource1 As New BindingSource
        CMD = New OdbcCommand("SELECT id_pesan_kamar, id_kamar FROM pesan_kamar WHERE status_pesan=0 ORDER BY id_pesan_kamar DESC LIMIT 1;", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        Label6.DataBindings.Add("Text", Dt, "id_kamar")
        Label6.Visible = False
    End Sub
    Sub AmbilLastReservation()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT ps.id_pesan_kamar, ps.id_kamar, ps.tipe_kamar, k.id_kamar, k.nomor_kamar FROM pesan_kamar as ps INNER JOIN kamar as k ON ps.id_kamar=k.id_kamar WHERE ps.id_kamar='" & Label6.Text & "' ORDER BY ps.id_pesan_kamar DESC LIMIT 1", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        Label3.DataBindings.Add("Text", Dt, "tipe_kamar")
        Label5.DataBindings.Add("Text", Dt, "nomor_kamar")
    End Sub
    Sub Tekunci()
        KamarToolStripMenuItem.Enabled = False
        LayananToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        KategoriKamarToolStripMenuItem.Enabled = False
        AdministrasiHotelToolStripMenuItem.Enabled = False
    End Sub
    Sub Terbuka()
        If Login.Label6.Text = "Super Administrator" Then
            KamarToolStripMenuItem.Enabled = True
            LayananToolStripMenuItem.Enabled = True
            LaporanToolStripMenuItem.Enabled = True
            KategoriKamarToolStripMenuItem.Enabled = True
            AdministrasiHotelToolStripMenuItem.Enabled = True
        Else
            KamarToolStripMenuItem.Enabled = False
            LayananToolStripMenuItem.Enabled = False
            LaporanToolStripMenuItem.Enabled = False
            KategoriKamarToolStripMenuItem.Enabled = False
            AdministrasiHotelToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub MenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Visible = False
        Call Koneksi()
        Da = New OdbcDataAdapter("SELECT * FROM tamu WHERE status = 1", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tamu")
        DataGridView1.DataSource = Ds.Tables("tamu")
        Call JumlahData()
        Call AmbilIdKamar()
        Call AmbilLastReservation()
        Call Tekunci()
        Call Terbuka()
        Label9.Text = Today
        Timer1.Enabled = True
        Label7.Visible = False
        Call StatusKotorKamar()
        Label2.Text = Login.Label5.Text
        Call KamarKosong()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label11.Text = TimeOfDay
    End Sub

    Private Sub TambahAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahAdminToolStripMenuItem.Click
        TambahAdmin.Show()
        Me.Close()
    End Sub

    Private Sub RoomServicesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomServicesToolStripMenuItem1.Click
        Me.Close()
        RoomServices.Show()
    End Sub
    Sub StatusKotorKamar()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM kamar WHERE status=2", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            Label12.Text = "Ada Kamar Kotor (Checkout)"
        Else
            Label12.Text = "Tidak Ada Kamar Kotor (Checkout)"
        End If
    End Sub
    Sub KamarKosong()
        Call Koneksi()
        CMD = New OdbcCommand("SELECT * FROM kamar WHERE status = 0", Conn)
        Da = New OdbcDataAdapter(CMD)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            Label15.Text = "Tersedia Kamar Kosong"
        Else
            Label15.Text = "Tidak Ada Kamar Kosong (Full)"
        End If
    End Sub

    Private Sub DrinkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrinkToolStripMenuItem.Click
        Me.Close()
        Drink.Show()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanToolStripMenuItem.Click
        Laporan.Show()
        Me.Close()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub LaundryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryToolStripMenuItem.Click
        Me.Close()
        Laundry.Show()
    End Sub

    Private Sub CetakStrukToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakStrukToolStripMenuItem.Click
        CetakStruk.Show()
        Me.Close()
    End Sub
End Class