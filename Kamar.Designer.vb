﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kamar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrasiHotelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KamarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayananToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KategoriKamarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProsesHotelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TamuInHouseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BukuTamuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HalamanUtamaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nomor Kamar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipe Kamar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kapasitas"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(115, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 3
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(115, 106)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(47, 20)
        Me.TextBox3.TabIndex = 5
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(8, 235)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(264, 112)
        Me.DataGridView1.TabIndex = 13
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(168, 197)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Close"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(34, 197)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Hapus"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(168, 154)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Edit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(34, 154)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Simpan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(168, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Orang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 15
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(115, 68)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(103, 21)
        Me.ComboBox1.TabIndex = 16
        Me.ComboBox1.Text = "Pilih Tipe Kamar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(112, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 18
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AdministrasiHotelToolStripMenuItem, Me.ProsesHotelToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HalamanUtamaToolStripMenuItem, Me.ToolStripSeparator1, Me.LogoutToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'AdministrasiHotelToolStripMenuItem
        '
        Me.AdministrasiHotelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KamarToolStripMenuItem, Me.LayananToolStripMenuItem, Me.ToolStripSeparator2, Me.LaporanToolStripMenuItem, Me.KategoriKamarToolStripMenuItem})
        Me.AdministrasiHotelToolStripMenuItem.Name = "AdministrasiHotelToolStripMenuItem"
        Me.AdministrasiHotelToolStripMenuItem.Size = New System.Drawing.Size(117, 20)
        Me.AdministrasiHotelToolStripMenuItem.Text = "Administrasi Hotel"
        '
        'KamarToolStripMenuItem
        '
        Me.KamarToolStripMenuItem.Name = "KamarToolStripMenuItem"
        Me.KamarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.KamarToolStripMenuItem.Text = "Kamar"
        '
        'LayananToolStripMenuItem
        '
        Me.LayananToolStripMenuItem.Name = "LayananToolStripMenuItem"
        Me.LayananToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LayananToolStripMenuItem.Text = "Layanan"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(152, 6)
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'KategoriKamarToolStripMenuItem
        '
        Me.KategoriKamarToolStripMenuItem.Name = "KategoriKamarToolStripMenuItem"
        Me.KategoriKamarToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.KategoriKamarToolStripMenuItem.Text = "Kategori Kamar"
        '
        'ProsesHotelToolStripMenuItem
        '
        Me.ProsesHotelToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckInToolStripMenuItem, Me.CheckOutToolStripMenuItem, Me.TamuInHouseToolStripMenuItem, Me.ToolStripSeparator4, Me.BukuTamuToolStripMenuItem})
        Me.ProsesHotelToolStripMenuItem.Name = "ProsesHotelToolStripMenuItem"
        Me.ProsesHotelToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.ProsesHotelToolStripMenuItem.Text = "Proses Hotel"
        '
        'CheckInToolStripMenuItem
        '
        Me.CheckInToolStripMenuItem.Name = "CheckInToolStripMenuItem"
        Me.CheckInToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CheckInToolStripMenuItem.Text = "Check In"
        '
        'CheckOutToolStripMenuItem
        '
        Me.CheckOutToolStripMenuItem.Name = "CheckOutToolStripMenuItem"
        Me.CheckOutToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CheckOutToolStripMenuItem.Text = "Check Out"
        '
        'TamuInHouseToolStripMenuItem
        '
        Me.TamuInHouseToolStripMenuItem.Name = "TamuInHouseToolStripMenuItem"
        Me.TamuInHouseToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.TamuInHouseToolStripMenuItem.Text = "Tamu In House"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(150, 6)
        '
        'BukuTamuToolStripMenuItem
        '
        Me.BukuTamuToolStripMenuItem.Name = "BukuTamuToolStripMenuItem"
        Me.BukuTamuToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.BukuTamuToolStripMenuItem.Text = "Buku Tamu"
        '
        'HalamanUtamaToolStripMenuItem
        '
        Me.HalamanUtamaToolStripMenuItem.Name = "HalamanUtamaToolStripMenuItem"
        Me.HalamanUtamaToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.HalamanUtamaToolStripMenuItem.Text = "Halaman Utama"
        '
        'Kamar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 369)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Kamar"
        Me.Text = "Kamar"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrasiHotelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KamarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayananToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KategoriKamarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProsesHotelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TamuInHouseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BukuTamuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HalamanUtamaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
