<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class splashscreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(splashscreen))
        Me.lblSplLoad = New Bunifu.UI.WinForms.BunifuLabel()
        Me.timSplStart = New System.Windows.Forms.Timer(Me.components)
        Me.pbxSplImg = New Bunifu.UI.WinForms.BunifuPictureBox()
        CType(Me.pbxSplImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSplLoad
        '
        Me.lblSplLoad.AutoEllipsis = False
        Me.lblSplLoad.CursorType = Nothing
        Me.lblSplLoad.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblSplLoad.ForeColor = System.Drawing.Color.White
        Me.lblSplLoad.Location = New System.Drawing.Point(20, 560)
        Me.lblSplLoad.Name = "lblSplLoad"
        Me.lblSplLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSplLoad.Size = New System.Drawing.Size(78, 23)
        Me.lblSplLoad.TabIndex = 1
        Me.lblSplLoad.Text = "Loading..."
        Me.lblSplLoad.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblSplLoad.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        Me.lblSplLoad.Visible = False
        '
        'timSplStart
        '
        '
        'pbxSplImg
        '
        Me.pbxSplImg.AllowFocused = False
        Me.pbxSplImg.BackColor = System.Drawing.Color.Transparent
        Me.pbxSplImg.BorderRadius = 50
        Me.pbxSplImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbxSplImg.Image = Global.asgmt_khayalan_re.My.Resources.Resources.splashscreen
        Me.pbxSplImg.IsCircle = False
        Me.pbxSplImg.Location = New System.Drawing.Point(0, 0)
        Me.pbxSplImg.Name = "pbxSplImg"
        Me.pbxSplImg.Size = New System.Drawing.Size(600, 600)
        Me.pbxSplImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxSplImg.TabIndex = 0
        Me.pbxSplImg.TabStop = False
        Me.pbxSplImg.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square
        '
        'splashscreen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(600, 600)
        Me.Controls.Add(Me.lblSplLoad)
        Me.Controls.Add(Me.pbxSplImg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "splashscreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.pbxSplImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbxSplImg As Bunifu.UI.WinForms.BunifuPictureBox
    Friend WithEvents lblSplLoad As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents timSplStart As Timer
End Class
