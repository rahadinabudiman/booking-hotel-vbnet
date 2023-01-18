<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TampilLaporan
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
        Me.CrystalReportViewer2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.LaporanHotel1 = New Kelompok_3_Booking_Hotel.LaporanHotel()
        Me.SuspendLayout()
        '
        'CrystalReportViewer2
        '
        Me.CrystalReportViewer2.ActiveViewIndex = 0
        Me.CrystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer2.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer2.Name = "CrystalReportViewer2"
        Me.CrystalReportViewer2.ReportSource = Me.LaporanHotel1
        Me.CrystalReportViewer2.Size = New System.Drawing.Size(472, 597)
        Me.CrystalReportViewer2.TabIndex = 0
        '
        'TampilLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 597)
        Me.Controls.Add(Me.CrystalReportViewer2)
        Me.Name = "TampilLaporan"
        Me.Text = "TampilLaporan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents LaporanHotel1 As Kelompok_3_Booking_Hotel.LaporanHotel
End Class
