﻿Imports System.Data.Odbc
Public Class MenuUtama

    Private Property BindingSource1 As Object

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
        Tamu.Show()
        Me.Hide()
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

    Private Sub LayananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayananToolStripMenuItem.Click
        Me.Hide()
        Layanan.Show()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FoodToolStripMenuItem.Click
        Me.Hide()
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
    End Sub
End Class