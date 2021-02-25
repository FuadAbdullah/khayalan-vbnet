<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class staffmenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(staffmenu))
        Dim BorderEdges1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties2 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim BorderEdges2 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties3 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties4 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim Animation1 As Bunifu.UI.WinForms.BunifuAnimatorNS.Animation = New Bunifu.UI.WinForms.BunifuAnimatorNS.Animation()
        Dim Animation2 As Bunifu.UI.WinForms.BunifuAnimatorNS.Animation = New Bunifu.UI.WinForms.BunifuAnimatorNS.Animation()
        Me.panSMIBack = New System.Windows.Forms.Panel()
        Me.panSMICust = New System.Windows.Forms.Panel()
        Me.gpanSMICust = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.btnSMICustC = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMIRCust = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMIPCust = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.panSMIOrd = New System.Windows.Forms.Panel()
        Me.gpanSMIOrd = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.btnSMITkOrd = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMIOrdC = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.panSMIMisc = New System.Windows.Forms.Panel()
        Me.gpanSMIMisc = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.btnSMIMiscC = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMISOMisc = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.panSMIFrmCtr = New System.Windows.Forms.Panel()
        Me.panSMIBtnCtr = New System.Windows.Forms.Panel()
        Me.gpanSMIHeader = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.gpanSMIBtnCtr = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.btnSMIMisc = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMIOrd = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSMICust = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.lblSMIStaID = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblSMIClock = New Bunifu.UI.WinForms.BunifuLabel()
        Me.pbxSMIPic = New Bunifu.UI.WinForms.BunifuPictureBox()
        Me.panSMIOrdForm = New System.Windows.Forms.Panel()
        Me.timSMIIntro = New System.Windows.Forms.Timer(Me.components)
        Me.dcSMI = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.gpanSMIBor = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.btnSMIMin = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.btnSMIClose = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.timSMIStart = New System.Windows.Forms.Timer(Me.components)
        Me.timSMIClock = New System.Windows.Forms.Timer(Me.components)
        Me.trSMITrans = New Bunifu.UI.WinForms.BunifuTransition(Me.components)
        Me.trSMIVertS = New Bunifu.UI.WinForms.BunifuTransition(Me.components)
        Me.panSMIBack.SuspendLayout()
        Me.panSMICust.SuspendLayout()
        Me.gpanSMICust.SuspendLayout()
        Me.panSMIOrd.SuspendLayout()
        Me.gpanSMIOrd.SuspendLayout()
        Me.panSMIMisc.SuspendLayout()
        Me.gpanSMIMisc.SuspendLayout()
        Me.panSMIBtnCtr.SuspendLayout()
        Me.gpanSMIHeader.SuspendLayout()
        Me.gpanSMIBtnCtr.SuspendLayout()
        CType(Me.pbxSMIPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpanSMIBor.SuspendLayout()
        Me.SuspendLayout()
        '
        'panSMIBack
        '
        Me.panSMIBack.Controls.Add(Me.panSMICust)
        Me.panSMIBack.Controls.Add(Me.panSMIOrd)
        Me.panSMIBack.Controls.Add(Me.panSMIMisc)
        Me.panSMIBack.Controls.Add(Me.panSMIFrmCtr)
        Me.panSMIBack.Controls.Add(Me.panSMIBtnCtr)
        Me.trSMIVertS.SetDecoration(Me.panSMIBack, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIBack, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIBack.Location = New System.Drawing.Point(0, 30)
        Me.panSMIBack.Name = "panSMIBack"
        Me.panSMIBack.Size = New System.Drawing.Size(805, 570)
        Me.panSMIBack.TabIndex = 7
        '
        'panSMICust
        '
        Me.panSMICust.BackColor = System.Drawing.Color.Silver
        Me.panSMICust.Controls.Add(Me.gpanSMICust)
        Me.trSMIVertS.SetDecoration(Me.panSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMICust.Location = New System.Drawing.Point(328, 150)
        Me.panSMICust.Name = "panSMICust"
        Me.panSMICust.Size = New System.Drawing.Size(150, 150)
        Me.panSMICust.TabIndex = 10
        Me.panSMICust.Visible = False
        '
        'gpanSMICust
        '
        Me.gpanSMICust.BackgroundImage = CType(resources.GetObject("gpanSMICust.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMICust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMICust.Controls.Add(Me.btnSMICustC)
        Me.gpanSMICust.Controls.Add(Me.btnSMIRCust)
        Me.gpanSMICust.Controls.Add(Me.btnSMIPCust)
        Me.trSMIVertS.SetDecoration(Me.gpanSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMICust.GradientBottomLeft = System.Drawing.Color.Crimson
        Me.gpanSMICust.GradientBottomRight = System.Drawing.Color.DarkSlateGray
        Me.gpanSMICust.GradientTopLeft = System.Drawing.Color.LightGray
        Me.gpanSMICust.GradientTopRight = System.Drawing.Color.LightGray
        Me.gpanSMICust.Location = New System.Drawing.Point(0, 0)
        Me.gpanSMICust.Name = "gpanSMICust"
        Me.gpanSMICust.Quality = 10
        Me.gpanSMICust.Size = New System.Drawing.Size(150, 150)
        Me.gpanSMICust.TabIndex = 3
        '
        'btnSMICustC
        '
        Me.btnSMICustC.Active = False
        Me.btnSMICustC.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMICustC.BackColor = System.Drawing.Color.Transparent
        Me.btnSMICustC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMICustC.BorderRadius = 0
        Me.btnSMICustC.ButtonText = "Close"
        Me.btnSMICustC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMICustC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMICustC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMICustC.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMICustC.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMICustC.Iconimage = Nothing
        Me.btnSMICustC.Iconimage_right = Nothing
        Me.btnSMICustC.Iconimage_right_Selected = Nothing
        Me.btnSMICustC.Iconimage_Selected = Nothing
        Me.btnSMICustC.IconMarginLeft = 0
        Me.btnSMICustC.IconMarginRight = 0
        Me.btnSMICustC.IconRightVisible = True
        Me.btnSMICustC.IconRightZoom = 0R
        Me.btnSMICustC.IconVisible = True
        Me.btnSMICustC.IconZoom = 90.0R
        Me.btnSMICustC.IsTab = False
        Me.btnSMICustC.Location = New System.Drawing.Point(0, 100)
        Me.btnSMICustC.Name = "btnSMICustC"
        Me.btnSMICustC.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMICustC.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMICustC.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMICustC.selected = False
        Me.btnSMICustC.Size = New System.Drawing.Size(150, 50)
        Me.btnSMICustC.TabIndex = 2
        Me.btnSMICustC.Text = "Close"
        Me.btnSMICustC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMICustC.Textcolor = System.Drawing.Color.White
        Me.btnSMICustC.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMIRCust
        '
        Me.btnSMIRCust.Active = False
        Me.btnSMIRCust.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIRCust.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIRCust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIRCust.BorderRadius = 0
        Me.btnSMIRCust.ButtonText = "Register"
        Me.btnSMIRCust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIRCust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIRCust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIRCust.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMIRCust.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIRCust.Iconimage = Nothing
        Me.btnSMIRCust.Iconimage_right = Nothing
        Me.btnSMIRCust.Iconimage_right_Selected = Nothing
        Me.btnSMIRCust.Iconimage_Selected = Nothing
        Me.btnSMIRCust.IconMarginLeft = 0
        Me.btnSMIRCust.IconMarginRight = 0
        Me.btnSMIRCust.IconRightVisible = True
        Me.btnSMIRCust.IconRightZoom = 0R
        Me.btnSMIRCust.IconVisible = True
        Me.btnSMIRCust.IconZoom = 90.0R
        Me.btnSMIRCust.IsTab = False
        Me.btnSMIRCust.Location = New System.Drawing.Point(0, 50)
        Me.btnSMIRCust.Name = "btnSMIRCust"
        Me.btnSMIRCust.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIRCust.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIRCust.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIRCust.selected = False
        Me.btnSMIRCust.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIRCust.TabIndex = 2
        Me.btnSMIRCust.Text = "Register"
        Me.btnSMIRCust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIRCust.Textcolor = System.Drawing.Color.White
        Me.btnSMIRCust.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMIPCust
        '
        Me.btnSMIPCust.Active = False
        Me.btnSMIPCust.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIPCust.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIPCust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIPCust.BorderRadius = 0
        Me.btnSMIPCust.ButtonText = "Profile"
        Me.btnSMIPCust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIPCust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIPCust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIPCust.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMIPCust.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIPCust.Iconimage = Nothing
        Me.btnSMIPCust.Iconimage_right = Nothing
        Me.btnSMIPCust.Iconimage_right_Selected = Nothing
        Me.btnSMIPCust.Iconimage_Selected = Nothing
        Me.btnSMIPCust.IconMarginLeft = 0
        Me.btnSMIPCust.IconMarginRight = 0
        Me.btnSMIPCust.IconRightVisible = True
        Me.btnSMIPCust.IconRightZoom = 0R
        Me.btnSMIPCust.IconVisible = True
        Me.btnSMIPCust.IconZoom = 90.0R
        Me.btnSMIPCust.IsTab = False
        Me.btnSMIPCust.Location = New System.Drawing.Point(0, 0)
        Me.btnSMIPCust.Name = "btnSMIPCust"
        Me.btnSMIPCust.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIPCust.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIPCust.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIPCust.selected = False
        Me.btnSMIPCust.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIPCust.TabIndex = 2
        Me.btnSMIPCust.Text = "Profile"
        Me.btnSMIPCust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIPCust.Textcolor = System.Drawing.Color.White
        Me.btnSMIPCust.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'panSMIOrd
        '
        Me.panSMIOrd.BackColor = System.Drawing.Color.Silver
        Me.panSMIOrd.Controls.Add(Me.gpanSMIOrd)
        Me.trSMIVertS.SetDecoration(Me.panSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIOrd.Location = New System.Drawing.Point(178, 150)
        Me.panSMIOrd.Name = "panSMIOrd"
        Me.panSMIOrd.Size = New System.Drawing.Size(150, 100)
        Me.panSMIOrd.TabIndex = 8
        Me.panSMIOrd.Visible = False
        '
        'gpanSMIOrd
        '
        Me.gpanSMIOrd.BackgroundImage = CType(resources.GetObject("gpanSMIOrd.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMIOrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMIOrd.Controls.Add(Me.btnSMITkOrd)
        Me.gpanSMIOrd.Controls.Add(Me.btnSMIOrdC)
        Me.trSMIVertS.SetDecoration(Me.gpanSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMIOrd.GradientBottomLeft = System.Drawing.Color.DarkSlateGray
        Me.gpanSMIOrd.GradientBottomRight = System.Drawing.Color.Crimson
        Me.gpanSMIOrd.GradientTopLeft = System.Drawing.Color.LightGray
        Me.gpanSMIOrd.GradientTopRight = System.Drawing.Color.LightGray
        Me.gpanSMIOrd.Location = New System.Drawing.Point(0, 0)
        Me.gpanSMIOrd.Name = "gpanSMIOrd"
        Me.gpanSMIOrd.Quality = 10
        Me.gpanSMIOrd.Size = New System.Drawing.Size(150, 100)
        Me.gpanSMIOrd.TabIndex = 3
        '
        'btnSMITkOrd
        '
        Me.btnSMITkOrd.Active = False
        Me.btnSMITkOrd.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMITkOrd.BackColor = System.Drawing.Color.Transparent
        Me.btnSMITkOrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMITkOrd.BorderRadius = 0
        Me.btnSMITkOrd.ButtonText = "Take Order"
        Me.btnSMITkOrd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMITkOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMITkOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMITkOrd.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMITkOrd.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMITkOrd.Iconimage = Nothing
        Me.btnSMITkOrd.Iconimage_right = Nothing
        Me.btnSMITkOrd.Iconimage_right_Selected = Nothing
        Me.btnSMITkOrd.Iconimage_Selected = Nothing
        Me.btnSMITkOrd.IconMarginLeft = 0
        Me.btnSMITkOrd.IconMarginRight = 0
        Me.btnSMITkOrd.IconRightVisible = True
        Me.btnSMITkOrd.IconRightZoom = 0R
        Me.btnSMITkOrd.IconVisible = True
        Me.btnSMITkOrd.IconZoom = 90.0R
        Me.btnSMITkOrd.IsTab = False
        Me.btnSMITkOrd.Location = New System.Drawing.Point(0, 0)
        Me.btnSMITkOrd.Name = "btnSMITkOrd"
        Me.btnSMITkOrd.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMITkOrd.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMITkOrd.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMITkOrd.selected = False
        Me.btnSMITkOrd.Size = New System.Drawing.Size(150, 50)
        Me.btnSMITkOrd.TabIndex = 2
        Me.btnSMITkOrd.Text = "Take Order"
        Me.btnSMITkOrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMITkOrd.Textcolor = System.Drawing.Color.White
        Me.btnSMITkOrd.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMIOrdC
        '
        Me.btnSMIOrdC.Active = False
        Me.btnSMIOrdC.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIOrdC.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIOrdC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIOrdC.BorderRadius = 0
        Me.btnSMIOrdC.ButtonText = "Close"
        Me.btnSMIOrdC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIOrdC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIOrdC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIOrdC.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMIOrdC.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIOrdC.Iconimage = Nothing
        Me.btnSMIOrdC.Iconimage_right = Nothing
        Me.btnSMIOrdC.Iconimage_right_Selected = Nothing
        Me.btnSMIOrdC.Iconimage_Selected = Nothing
        Me.btnSMIOrdC.IconMarginLeft = 0
        Me.btnSMIOrdC.IconMarginRight = 0
        Me.btnSMIOrdC.IconRightVisible = True
        Me.btnSMIOrdC.IconRightZoom = 0R
        Me.btnSMIOrdC.IconVisible = True
        Me.btnSMIOrdC.IconZoom = 90.0R
        Me.btnSMIOrdC.IsTab = False
        Me.btnSMIOrdC.Location = New System.Drawing.Point(0, 50)
        Me.btnSMIOrdC.Name = "btnSMIOrdC"
        Me.btnSMIOrdC.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIOrdC.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIOrdC.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIOrdC.selected = False
        Me.btnSMIOrdC.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIOrdC.TabIndex = 2
        Me.btnSMIOrdC.Text = "Close"
        Me.btnSMIOrdC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIOrdC.Textcolor = System.Drawing.Color.White
        Me.btnSMIOrdC.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'panSMIMisc
        '
        Me.panSMIMisc.BackColor = System.Drawing.Color.Silver
        Me.panSMIMisc.Controls.Add(Me.gpanSMIMisc)
        Me.trSMIVertS.SetDecoration(Me.panSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIMisc.Location = New System.Drawing.Point(477, 150)
        Me.panSMIMisc.Name = "panSMIMisc"
        Me.panSMIMisc.Size = New System.Drawing.Size(150, 100)
        Me.panSMIMisc.TabIndex = 12
        Me.panSMIMisc.Visible = False
        '
        'gpanSMIMisc
        '
        Me.gpanSMIMisc.BackgroundImage = CType(resources.GetObject("gpanSMIMisc.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMIMisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMIMisc.Controls.Add(Me.btnSMIMiscC)
        Me.gpanSMIMisc.Controls.Add(Me.btnSMISOMisc)
        Me.trSMIVertS.SetDecoration(Me.gpanSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMIMisc.GradientBottomLeft = System.Drawing.Color.LightGray
        Me.gpanSMIMisc.GradientBottomRight = System.Drawing.Color.LightGray
        Me.gpanSMIMisc.GradientTopLeft = System.Drawing.Color.DarkSlateGray
        Me.gpanSMIMisc.GradientTopRight = System.Drawing.Color.Crimson
        Me.gpanSMIMisc.Location = New System.Drawing.Point(0, 0)
        Me.gpanSMIMisc.Name = "gpanSMIMisc"
        Me.gpanSMIMisc.Quality = 10
        Me.gpanSMIMisc.Size = New System.Drawing.Size(150, 100)
        Me.gpanSMIMisc.TabIndex = 3
        '
        'btnSMIMiscC
        '
        Me.btnSMIMiscC.Active = False
        Me.btnSMIMiscC.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIMiscC.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIMiscC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIMiscC.BorderRadius = 0
        Me.btnSMIMiscC.ButtonText = "Close"
        Me.btnSMIMiscC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIMiscC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIMiscC, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIMiscC.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMIMiscC.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIMiscC.Iconimage = Nothing
        Me.btnSMIMiscC.Iconimage_right = Nothing
        Me.btnSMIMiscC.Iconimage_right_Selected = Nothing
        Me.btnSMIMiscC.Iconimage_Selected = Nothing
        Me.btnSMIMiscC.IconMarginLeft = 0
        Me.btnSMIMiscC.IconMarginRight = 0
        Me.btnSMIMiscC.IconRightVisible = True
        Me.btnSMIMiscC.IconRightZoom = 0R
        Me.btnSMIMiscC.IconVisible = True
        Me.btnSMIMiscC.IconZoom = 90.0R
        Me.btnSMIMiscC.IsTab = False
        Me.btnSMIMiscC.Location = New System.Drawing.Point(0, 50)
        Me.btnSMIMiscC.Name = "btnSMIMiscC"
        Me.btnSMIMiscC.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIMiscC.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIMiscC.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIMiscC.selected = False
        Me.btnSMIMiscC.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIMiscC.TabIndex = 2
        Me.btnSMIMiscC.Text = "Close"
        Me.btnSMIMiscC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIMiscC.Textcolor = System.Drawing.Color.White
        Me.btnSMIMiscC.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMISOMisc
        '
        Me.btnSMISOMisc.Active = False
        Me.btnSMISOMisc.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMISOMisc.BackColor = System.Drawing.Color.Transparent
        Me.btnSMISOMisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMISOMisc.BorderRadius = 0
        Me.btnSMISOMisc.ButtonText = "Sign out"
        Me.btnSMISOMisc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMISOMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMISOMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMISOMisc.DisabledColor = System.Drawing.Color.Maroon
        Me.btnSMISOMisc.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMISOMisc.Iconimage = Nothing
        Me.btnSMISOMisc.Iconimage_right = Nothing
        Me.btnSMISOMisc.Iconimage_right_Selected = Nothing
        Me.btnSMISOMisc.Iconimage_Selected = Nothing
        Me.btnSMISOMisc.IconMarginLeft = 0
        Me.btnSMISOMisc.IconMarginRight = 0
        Me.btnSMISOMisc.IconRightVisible = True
        Me.btnSMISOMisc.IconRightZoom = 0R
        Me.btnSMISOMisc.IconVisible = True
        Me.btnSMISOMisc.IconZoom = 90.0R
        Me.btnSMISOMisc.IsTab = False
        Me.btnSMISOMisc.Location = New System.Drawing.Point(0, 0)
        Me.btnSMISOMisc.Name = "btnSMISOMisc"
        Me.btnSMISOMisc.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMISOMisc.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMISOMisc.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMISOMisc.selected = False
        Me.btnSMISOMisc.Size = New System.Drawing.Size(150, 50)
        Me.btnSMISOMisc.TabIndex = 2
        Me.btnSMISOMisc.Text = "Sign out"
        Me.btnSMISOMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMISOMisc.Textcolor = System.Drawing.Color.White
        Me.btnSMISOMisc.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'panSMIFrmCtr
        '
        Me.panSMIFrmCtr.BackColor = System.Drawing.Color.LightGray
        Me.trSMIVertS.SetDecoration(Me.panSMIFrmCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIFrmCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIFrmCtr.Location = New System.Drawing.Point(10, 180)
        Me.panSMIFrmCtr.Name = "panSMIFrmCtr"
        Me.panSMIFrmCtr.Size = New System.Drawing.Size(780, 360)
        Me.panSMIFrmCtr.TabIndex = 9
        '
        'panSMIBtnCtr
        '
        Me.panSMIBtnCtr.BackColor = System.Drawing.Color.DarkSlateGray
        Me.panSMIBtnCtr.Controls.Add(Me.gpanSMIHeader)
        Me.trSMIVertS.SetDecoration(Me.panSMIBtnCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIBtnCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIBtnCtr.Location = New System.Drawing.Point(0, 0)
        Me.panSMIBtnCtr.Name = "panSMIBtnCtr"
        Me.panSMIBtnCtr.Size = New System.Drawing.Size(808, 150)
        Me.panSMIBtnCtr.TabIndex = 7
        '
        'gpanSMIHeader
        '
        Me.gpanSMIHeader.BackgroundImage = CType(resources.GetObject("gpanSMIHeader.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMIHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMIHeader.Controls.Add(Me.gpanSMIBtnCtr)
        Me.gpanSMIHeader.Controls.Add(Me.lblSMIStaID)
        Me.gpanSMIHeader.Controls.Add(Me.lblSMIClock)
        Me.gpanSMIHeader.Controls.Add(Me.pbxSMIPic)
        Me.trSMIVertS.SetDecoration(Me.gpanSMIHeader, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMIHeader, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMIHeader.GradientBottomLeft = System.Drawing.Color.LightGray
        Me.gpanSMIHeader.GradientBottomRight = System.Drawing.Color.DarkGray
        Me.gpanSMIHeader.GradientTopLeft = System.Drawing.Color.LightGray
        Me.gpanSMIHeader.GradientTopRight = System.Drawing.Color.LightGray
        Me.gpanSMIHeader.Location = New System.Drawing.Point(0, 0)
        Me.gpanSMIHeader.Name = "gpanSMIHeader"
        Me.gpanSMIHeader.Quality = 10
        Me.gpanSMIHeader.Size = New System.Drawing.Size(808, 150)
        Me.gpanSMIHeader.TabIndex = 3
        '
        'gpanSMIBtnCtr
        '
        Me.gpanSMIBtnCtr.BackgroundImage = CType(resources.GetObject("gpanSMIBtnCtr.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMIBtnCtr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMIBtnCtr.Controls.Add(Me.btnSMIMisc)
        Me.gpanSMIBtnCtr.Controls.Add(Me.btnSMIOrd)
        Me.gpanSMIBtnCtr.Controls.Add(Me.btnSMICust)
        Me.trSMIVertS.SetDecoration(Me.gpanSMIBtnCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMIBtnCtr, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMIBtnCtr.GradientBottomLeft = System.Drawing.Color.DarkSlateGray
        Me.gpanSMIBtnCtr.GradientBottomRight = System.Drawing.Color.Crimson
        Me.gpanSMIBtnCtr.GradientTopLeft = System.Drawing.Color.LightGray
        Me.gpanSMIBtnCtr.GradientTopRight = System.Drawing.Color.DimGray
        Me.gpanSMIBtnCtr.Location = New System.Drawing.Point(177, 100)
        Me.gpanSMIBtnCtr.Name = "gpanSMIBtnCtr"
        Me.gpanSMIBtnCtr.Quality = 10
        Me.gpanSMIBtnCtr.Size = New System.Drawing.Size(450, 50)
        Me.gpanSMIBtnCtr.TabIndex = 3
        '
        'btnSMIMisc
        '
        Me.btnSMIMisc.Active = False
        Me.btnSMIMisc.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIMisc.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIMisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIMisc.BorderRadius = 0
        Me.btnSMIMisc.ButtonText = "Miscellaneous"
        Me.btnSMIMisc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIMisc, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIMisc.DisabledColor = System.Drawing.Color.Transparent
        Me.btnSMIMisc.Enabled = False
        Me.btnSMIMisc.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIMisc.Iconimage = Nothing
        Me.btnSMIMisc.Iconimage_right = Nothing
        Me.btnSMIMisc.Iconimage_right_Selected = Nothing
        Me.btnSMIMisc.Iconimage_Selected = Nothing
        Me.btnSMIMisc.IconMarginLeft = 0
        Me.btnSMIMisc.IconMarginRight = 0
        Me.btnSMIMisc.IconRightVisible = True
        Me.btnSMIMisc.IconRightZoom = 0R
        Me.btnSMIMisc.IconVisible = True
        Me.btnSMIMisc.IconZoom = 90.0R
        Me.btnSMIMisc.IsTab = False
        Me.btnSMIMisc.Location = New System.Drawing.Point(300, 0)
        Me.btnSMIMisc.Name = "btnSMIMisc"
        Me.btnSMIMisc.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIMisc.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIMisc.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIMisc.selected = False
        Me.btnSMIMisc.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIMisc.TabIndex = 2
        Me.btnSMIMisc.Text = "Miscellaneous"
        Me.btnSMIMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIMisc.Textcolor = System.Drawing.Color.White
        Me.btnSMIMisc.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMIOrd
        '
        Me.btnSMIOrd.Active = False
        Me.btnSMIOrd.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMIOrd.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIOrd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMIOrd.BorderRadius = 0
        Me.btnSMIOrd.ButtonText = "Order"
        Me.btnSMIOrd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMIOrd, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIOrd.DisabledColor = System.Drawing.Color.Transparent
        Me.btnSMIOrd.Enabled = False
        Me.btnSMIOrd.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMIOrd.Iconimage = Nothing
        Me.btnSMIOrd.Iconimage_right = Nothing
        Me.btnSMIOrd.Iconimage_right_Selected = Nothing
        Me.btnSMIOrd.Iconimage_Selected = Nothing
        Me.btnSMIOrd.IconMarginLeft = 0
        Me.btnSMIOrd.IconMarginRight = 0
        Me.btnSMIOrd.IconRightVisible = True
        Me.btnSMIOrd.IconRightZoom = 0R
        Me.btnSMIOrd.IconVisible = True
        Me.btnSMIOrd.IconZoom = 90.0R
        Me.btnSMIOrd.IsTab = False
        Me.btnSMIOrd.Location = New System.Drawing.Point(0, 0)
        Me.btnSMIOrd.Name = "btnSMIOrd"
        Me.btnSMIOrd.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMIOrd.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMIOrd.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMIOrd.selected = False
        Me.btnSMIOrd.Size = New System.Drawing.Size(150, 50)
        Me.btnSMIOrd.TabIndex = 2
        Me.btnSMIOrd.Text = "Order"
        Me.btnSMIOrd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIOrd.Textcolor = System.Drawing.Color.White
        Me.btnSMIOrd.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'btnSMICust
        '
        Me.btnSMICust.Active = False
        Me.btnSMICust.Activecolor = System.Drawing.Color.Transparent
        Me.btnSMICust.BackColor = System.Drawing.Color.Transparent
        Me.btnSMICust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSMICust.BorderRadius = 0
        Me.btnSMICust.ButtonText = "Customer"
        Me.btnSMICust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trSMITrans.SetDecoration(Me.btnSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMIVertS.SetDecoration(Me.btnSMICust, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMICust.DisabledColor = System.Drawing.Color.Transparent
        Me.btnSMICust.Enabled = False
        Me.btnSMICust.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSMICust.Iconimage = Nothing
        Me.btnSMICust.Iconimage_right = Nothing
        Me.btnSMICust.Iconimage_right_Selected = Nothing
        Me.btnSMICust.Iconimage_Selected = Nothing
        Me.btnSMICust.IconMarginLeft = 0
        Me.btnSMICust.IconMarginRight = 0
        Me.btnSMICust.IconRightVisible = True
        Me.btnSMICust.IconRightZoom = 0R
        Me.btnSMICust.IconVisible = True
        Me.btnSMICust.IconZoom = 90.0R
        Me.btnSMICust.IsTab = False
        Me.btnSMICust.Location = New System.Drawing.Point(150, 0)
        Me.btnSMICust.Name = "btnSMICust"
        Me.btnSMICust.Normalcolor = System.Drawing.Color.Transparent
        Me.btnSMICust.OnHovercolor = System.Drawing.Color.Crimson
        Me.btnSMICust.OnHoverTextColor = System.Drawing.Color.White
        Me.btnSMICust.selected = False
        Me.btnSMICust.Size = New System.Drawing.Size(150, 50)
        Me.btnSMICust.TabIndex = 2
        Me.btnSMICust.Text = "Customer"
        Me.btnSMICust.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMICust.Textcolor = System.Drawing.Color.White
        Me.btnSMICust.TextFont = New System.Drawing.Font("Century Gothic", 14.0!)
        '
        'lblSMIStaID
        '
        Me.lblSMIStaID.AutoEllipsis = False
        Me.lblSMIStaID.AutoSize = False
        Me.lblSMIStaID.CursorType = Nothing
        Me.trSMIVertS.SetDecoration(Me.lblSMIStaID, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.lblSMIStaID, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.lblSMIStaID.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.lblSMIStaID.Location = New System.Drawing.Point(718, 82)
        Me.lblSMIStaID.Name = "lblSMIStaID"
        Me.lblSMIStaID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSMIStaID.Size = New System.Drawing.Size(70, 30)
        Me.lblSMIStaID.TabIndex = 9
        Me.lblSMIStaID.Text = "S000"
        Me.lblSMIStaID.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSMIStaID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblSMIClock
        '
        Me.lblSMIClock.AutoEllipsis = False
        Me.lblSMIClock.AutoSize = False
        Me.lblSMIClock.CursorType = Nothing
        Me.trSMIVertS.SetDecoration(Me.lblSMIClock, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.lblSMIClock, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.lblSMIClock.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.lblSMIClock.Location = New System.Drawing.Point(268, 6)
        Me.lblSMIClock.Name = "lblSMIClock"
        Me.lblSMIClock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSMIClock.Size = New System.Drawing.Size(272, 18)
        Me.lblSMIClock.TabIndex = 9
        Me.lblSMIClock.Text = "Monday, 23/07/2001, 00:00:00"
        Me.lblSMIClock.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSMIClock.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'pbxSMIPic
        '
        Me.pbxSMIPic.AllowFocused = False
        Me.pbxSMIPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxSMIPic.BackColor = System.Drawing.Color.Transparent
        Me.pbxSMIPic.BorderRadius = 35
        Me.trSMIVertS.SetDecoration(Me.pbxSMIPic, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.pbxSMIPic, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.pbxSMIPic.Image = Global.asgmt_khayalan_re.My.Resources.Resources.profile_user_coloured
        Me.pbxSMIPic.IsCircle = False
        Me.pbxSMIPic.Location = New System.Drawing.Point(718, 6)
        Me.pbxSMIPic.Name = "pbxSMIPic"
        Me.pbxSMIPic.Size = New System.Drawing.Size(70, 70)
        Me.pbxSMIPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxSMIPic.TabIndex = 8
        Me.pbxSMIPic.TabStop = False
        Me.pbxSMIPic.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square
        '
        'panSMIOrdForm
        '
        Me.panSMIOrdForm.BackColor = System.Drawing.Color.LightGray
        Me.trSMIVertS.SetDecoration(Me.panSMIOrdForm, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.panSMIOrdForm, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.panSMIOrdForm.Location = New System.Drawing.Point(0, 30)
        Me.panSMIOrdForm.Name = "panSMIOrdForm"
        Me.panSMIOrdForm.Size = New System.Drawing.Size(808, 570)
        Me.panSMIOrdForm.TabIndex = 9
        Me.panSMIOrdForm.Visible = False
        '
        'dcSMI
        '
        Me.dcSMI.Fixed = True
        Me.dcSMI.Horizontal = True
        Me.dcSMI.TargetControl = Me.gpanSMIBor
        Me.dcSMI.Vertical = True
        '
        'gpanSMIBor
        '
        Me.gpanSMIBor.BackgroundImage = CType(resources.GetObject("gpanSMIBor.BackgroundImage"), System.Drawing.Image)
        Me.gpanSMIBor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gpanSMIBor.Controls.Add(Me.btnSMIMin)
        Me.gpanSMIBor.Controls.Add(Me.btnSMIClose)
        Me.trSMIVertS.SetDecoration(Me.gpanSMIBor, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.gpanSMIBor, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.gpanSMIBor.GradientBottomLeft = System.Drawing.Color.Crimson
        Me.gpanSMIBor.GradientBottomRight = System.Drawing.Color.DarkSlateGray
        Me.gpanSMIBor.GradientTopLeft = System.Drawing.Color.LightGray
        Me.gpanSMIBor.GradientTopRight = System.Drawing.Color.Crimson
        Me.gpanSMIBor.Location = New System.Drawing.Point(0, 0)
        Me.gpanSMIBor.Name = "gpanSMIBor"
        Me.gpanSMIBor.Quality = 100
        Me.gpanSMIBor.Size = New System.Drawing.Size(808, 30)
        Me.gpanSMIBor.TabIndex = 1
        '
        'btnSMIMin
        '
        Me.btnSMIMin.AllowToggling = False
        Me.btnSMIMin.AnimationSpeed = 200
        Me.btnSMIMin.AutoGenerateColors = False
        Me.btnSMIMin.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIMin.BackColor1 = System.Drawing.Color.Orange
        Me.btnSMIMin.BackgroundImage = CType(resources.GetObject("btnSMIMin.BackgroundImage"), System.Drawing.Image)
        Me.btnSMIMin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnSMIMin.ButtonText = ""
        Me.btnSMIMin.ButtonTextMarginLeft = 0
        Me.btnSMIMin.ColorContrastOnClick = 45
        Me.btnSMIMin.ColorContrastOnHover = 45
        Me.btnSMIMin.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges1.BottomLeft = True
        BorderEdges1.BottomRight = True
        BorderEdges1.TopLeft = True
        BorderEdges1.TopRight = True
        Me.btnSMIMin.CustomizableEdges = BorderEdges1
        Me.trSMIVertS.SetDecoration(Me.btnSMIMin, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.btnSMIMin, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIMin.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSMIMin.DisabledBorderColor = System.Drawing.Color.Empty
        Me.btnSMIMin.DisabledFillColor = System.Drawing.Color.Maroon
        Me.btnSMIMin.DisabledForecolor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnSMIMin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnSMIMin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnSMIMin.ForeColor = System.Drawing.Color.White
        Me.btnSMIMin.IconLeftCursor = System.Windows.Forms.Cursors.Hand
        Me.btnSMIMin.IconMarginLeft = 0
        Me.btnSMIMin.IconPadding = 0
        Me.btnSMIMin.IconRightCursor = System.Windows.Forms.Cursors.Hand
        Me.btnSMIMin.IdleBorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnSMIMin.IdleBorderRadius = 15
        Me.btnSMIMin.IdleBorderThickness = 1
        Me.btnSMIMin.IdleFillColor = System.Drawing.Color.Orange
        Me.btnSMIMin.IdleIconLeftImage = Nothing
        Me.btnSMIMin.IdleIconRightImage = Nothing
        Me.btnSMIMin.IndicateFocus = False
        Me.btnSMIMin.Location = New System.Drawing.Point(745, 5)
        Me.btnSMIMin.Name = "btnSMIMin"
        StateProperties1.BorderColor = System.Drawing.Color.Gold
        StateProperties1.BorderRadius = 15
        StateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties1.BorderThickness = 1
        StateProperties1.FillColor = System.Drawing.Color.Yellow
        StateProperties1.ForeColor = System.Drawing.Color.White
        StateProperties1.IconLeftImage = Nothing
        StateProperties1.IconRightImage = Nothing
        Me.btnSMIMin.onHoverState = StateProperties1
        StateProperties2.BorderColor = System.Drawing.Color.DarkSlateGray
        StateProperties2.BorderRadius = 15
        StateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties2.BorderThickness = 1
        StateProperties2.FillColor = System.Drawing.Color.Orange
        StateProperties2.ForeColor = System.Drawing.Color.White
        StateProperties2.IconLeftImage = Nothing
        StateProperties2.IconRightImage = Nothing
        Me.btnSMIMin.OnPressedState = StateProperties2
        Me.btnSMIMin.Size = New System.Drawing.Size(20, 20)
        Me.btnSMIMin.TabIndex = 0
        Me.btnSMIMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIMin.TextMarginLeft = 0
        Me.btnSMIMin.UseDefaultRadiusAndThickness = True
        '
        'btnSMIClose
        '
        Me.btnSMIClose.AllowToggling = False
        Me.btnSMIClose.AnimationSpeed = 200
        Me.btnSMIClose.AutoGenerateColors = False
        Me.btnSMIClose.BackColor = System.Drawing.Color.Transparent
        Me.btnSMIClose.BackColor1 = System.Drawing.Color.Crimson
        Me.btnSMIClose.BackgroundImage = CType(resources.GetObject("btnSMIClose.BackgroundImage"), System.Drawing.Image)
        Me.btnSMIClose.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnSMIClose.ButtonText = ""
        Me.btnSMIClose.ButtonTextMarginLeft = 0
        Me.btnSMIClose.ColorContrastOnClick = 45
        Me.btnSMIClose.ColorContrastOnHover = 45
        Me.btnSMIClose.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges2.BottomLeft = True
        BorderEdges2.BottomRight = True
        BorderEdges2.TopLeft = True
        BorderEdges2.TopRight = True
        Me.btnSMIClose.CustomizableEdges = BorderEdges2
        Me.trSMIVertS.SetDecoration(Me.btnSMIClose, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me.btnSMIClose, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.btnSMIClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSMIClose.DisabledBorderColor = System.Drawing.Color.Empty
        Me.btnSMIClose.DisabledFillColor = System.Drawing.Color.Maroon
        Me.btnSMIClose.DisabledForecolor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnSMIClose.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnSMIClose.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!)
        Me.btnSMIClose.ForeColor = System.Drawing.Color.White
        Me.btnSMIClose.IconLeftCursor = System.Windows.Forms.Cursors.Hand
        Me.btnSMIClose.IconMarginLeft = 0
        Me.btnSMIClose.IconPadding = 0
        Me.btnSMIClose.IconRightCursor = System.Windows.Forms.Cursors.Hand
        Me.btnSMIClose.IdleBorderColor = System.Drawing.Color.DarkSlateGray
        Me.btnSMIClose.IdleBorderRadius = 15
        Me.btnSMIClose.IdleBorderThickness = 1
        Me.btnSMIClose.IdleFillColor = System.Drawing.Color.Crimson
        Me.btnSMIClose.IdleIconLeftImage = Nothing
        Me.btnSMIClose.IdleIconRightImage = Nothing
        Me.btnSMIClose.IndicateFocus = False
        Me.btnSMIClose.Location = New System.Drawing.Point(770, 5)
        Me.btnSMIClose.Name = "btnSMIClose"
        StateProperties3.BorderColor = System.Drawing.Color.IndianRed
        StateProperties3.BorderRadius = 15
        StateProperties3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties3.BorderThickness = 1
        StateProperties3.FillColor = System.Drawing.Color.Red
        StateProperties3.ForeColor = System.Drawing.Color.White
        StateProperties3.IconLeftImage = Nothing
        StateProperties3.IconRightImage = Nothing
        Me.btnSMIClose.onHoverState = StateProperties3
        StateProperties4.BorderColor = System.Drawing.Color.DarkSlateGray
        StateProperties4.BorderRadius = 15
        StateProperties4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties4.BorderThickness = 1
        StateProperties4.FillColor = System.Drawing.Color.Crimson
        StateProperties4.ForeColor = System.Drawing.Color.White
        StateProperties4.IconLeftImage = Nothing
        StateProperties4.IconRightImage = Nothing
        Me.btnSMIClose.OnPressedState = StateProperties4
        Me.btnSMIClose.Size = New System.Drawing.Size(20, 20)
        Me.btnSMIClose.TabIndex = 0
        Me.btnSMIClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSMIClose.TextMarginLeft = 0
        Me.btnSMIClose.UseDefaultRadiusAndThickness = True
        '
        'timSMIStart
        '
        '
        'timSMIClock
        '
        '
        'trSMITrans
        '
        Me.trSMITrans.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Transparent
        Me.trSMITrans.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 0
        Animation1.Padding = New System.Windows.Forms.Padding(0)
        Animation1.RotateCoeff = 0!
        Animation1.RotateLimit = 0!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 0!
        Animation1.TransparencyCoeff = 1.0!
        Me.trSMITrans.DefaultAnimation = Animation1
        Me.trSMITrans.MaxAnimationTime = 2000
        '
        'trSMIVertS
        '
        Me.trSMIVertS.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.VertSlide
        Me.trSMIVertS.Cursor = Nothing
        Animation2.AnimateOnlyDifferences = True
        Animation2.BlindCoeff = CType(resources.GetObject("Animation2.BlindCoeff"), System.Drawing.PointF)
        Animation2.LeafCoeff = 0!
        Animation2.MaxTime = 1.0!
        Animation2.MinTime = 0!
        Animation2.MosaicCoeff = CType(resources.GetObject("Animation2.MosaicCoeff"), System.Drawing.PointF)
        Animation2.MosaicShift = CType(resources.GetObject("Animation2.MosaicShift"), System.Drawing.PointF)
        Animation2.MosaicSize = 0
        Animation2.Padding = New System.Windows.Forms.Padding(0)
        Animation2.RotateCoeff = 0!
        Animation2.RotateLimit = 0!
        Animation2.ScaleCoeff = CType(resources.GetObject("Animation2.ScaleCoeff"), System.Drawing.PointF)
        Animation2.SlideCoeff = CType(resources.GetObject("Animation2.SlideCoeff"), System.Drawing.PointF)
        Animation2.TimeCoeff = 0!
        Animation2.TransparencyCoeff = 0!
        Me.trSMIVertS.DefaultAnimation = Animation2
        '
        'staffmenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.gpanSMIBor)
        Me.Controls.Add(Me.panSMIBack)
        Me.Controls.Add(Me.panSMIOrdForm)
        Me.trSMIVertS.SetDecoration(Me, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.trSMITrans.SetDecoration(Me, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "staffmenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "staffmenu"
        Me.panSMIBack.ResumeLayout(False)
        Me.panSMICust.ResumeLayout(False)
        Me.gpanSMICust.ResumeLayout(False)
        Me.panSMIOrd.ResumeLayout(False)
        Me.gpanSMIOrd.ResumeLayout(False)
        Me.panSMIMisc.ResumeLayout(False)
        Me.gpanSMIMisc.ResumeLayout(False)
        Me.panSMIBtnCtr.ResumeLayout(False)
        Me.gpanSMIHeader.ResumeLayout(False)
        Me.gpanSMIBtnCtr.ResumeLayout(False)
        CType(Me.pbxSMIPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpanSMIBor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpanSMIBor As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents btnSMIMin As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Friend WithEvents btnSMIClose As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Friend WithEvents panSMIBack As Panel
    Friend WithEvents panSMIBtnCtr As Panel
    Friend WithEvents gpanSMIBtnCtr As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents btnSMIMisc As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMIOrd As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMICust As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents gpanSMIHeader As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents panSMIOrd As Panel
    Friend WithEvents gpanSMIOrd As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents btnSMITkOrd As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMIOrdC As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents panSMIMisc As Panel
    Friend WithEvents gpanSMIMisc As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents btnSMIMiscC As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMISOMisc As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents panSMICust As Panel
    Friend WithEvents gpanSMICust As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents btnSMICustC As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMIRCust As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnSMIPCust As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents panSMIFrmCtr As Panel
    Friend WithEvents timSMIIntro As Timer
    Friend WithEvents dcSMI As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents timSMIStart As Timer
    Friend WithEvents timSMIClock As Timer
    Friend WithEvents trSMITrans As Bunifu.UI.WinForms.BunifuTransition
    Friend WithEvents pbxSMIPic As Bunifu.UI.WinForms.BunifuPictureBox
    Friend WithEvents panSMIOrdForm As Panel
    Friend WithEvents trSMIVertS As Bunifu.UI.WinForms.BunifuTransition
    Friend WithEvents lblSMIClock As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblSMIStaID As Bunifu.UI.WinForms.BunifuLabel
End Class
