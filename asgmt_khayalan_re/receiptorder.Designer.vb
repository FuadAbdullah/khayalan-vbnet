<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receiptorder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(receiptorder))
        Dim BorderEdges1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges()
        Dim StateProperties1 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties2 As Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties = New Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties()
        Dim StateProperties3 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties4 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties5 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim StateProperties6 As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panROIStep = New System.Windows.Forms.Panel()
        Me.btnROIComplete = New Bunifu.UI.WinForms.BunifuButton.BunifuButton()
        Me.panROIHeader = New System.Windows.Forms.Panel()
        Me.lblROIHeader = New Bunifu.UI.WinForms.BunifuLabel()
        Me.panROIBack = New System.Windows.Forms.Panel()
        Me.lblROIChange = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIPaid = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROITax = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIPayable = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIDate = New Bunifu.UI.WinForms.BunifuLabel()
        Me.txtROIRemarks = New Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox()
        Me.lblROISID = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIOID = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROISIDTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIOIDTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIChangeTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIPaidTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROITaxTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIPayableTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIDateTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROICNameTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROICIDTitle = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROICName = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROICID = New Bunifu.UI.WinForms.BunifuLabel()
        Me.lblROIOrdDet = New Bunifu.UI.WinForms.BunifuLabel()
        Me.sprROIBottom = New Bunifu.Framework.UI.BunifuSeparator()
        Me.sprROITop = New Bunifu.Framework.UI.BunifuSeparator()
        Me.panROISummary = New System.Windows.Forms.Panel()
        Me.dgvROIFinal = New Bunifu.UI.WinForms.BunifuDataGridView()
        Me.vsbROIMain = New Bunifu.UI.WinForms.BunifuVScrollBar()
        Me.panROIStep.SuspendLayout()
        Me.panROIHeader.SuspendLayout()
        Me.panROIBack.SuspendLayout()
        Me.panROISummary.SuspendLayout()
        CType(Me.dgvROIFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panROIStep
        '
        Me.panROIStep.Controls.Add(Me.btnROIComplete)
        Me.panROIStep.Controls.Add(Me.panROIHeader)
        Me.panROIStep.Location = New System.Drawing.Point(22, 10)
        Me.panROIStep.Name = "panROIStep"
        Me.panROIStep.Size = New System.Drawing.Size(760, 40)
        Me.panROIStep.TabIndex = 14
        '
        'btnROIComplete
        '
        Me.btnROIComplete.AllowToggling = False
        Me.btnROIComplete.AnimationSpeed = 200
        Me.btnROIComplete.AutoGenerateColors = False
        Me.btnROIComplete.BackColor = System.Drawing.Color.Transparent
        Me.btnROIComplete.BackColor1 = System.Drawing.Color.WhiteSmoke
        Me.btnROIComplete.BackgroundImage = CType(resources.GetObject("btnROIComplete.BackgroundImage"), System.Drawing.Image)
        Me.btnROIComplete.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        Me.btnROIComplete.ButtonText = "Complete"
        Me.btnROIComplete.ButtonTextMarginLeft = 0
        Me.btnROIComplete.ColorContrastOnClick = 45
        Me.btnROIComplete.ColorContrastOnHover = 45
        Me.btnROIComplete.Cursor = System.Windows.Forms.Cursors.Hand
        BorderEdges1.BottomLeft = True
        BorderEdges1.BottomRight = True
        BorderEdges1.TopLeft = True
        BorderEdges1.TopRight = True
        Me.btnROIComplete.CustomizableEdges = BorderEdges1
        Me.btnROIComplete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnROIComplete.DisabledBorderColor = System.Drawing.Color.Empty
        Me.btnROIComplete.DisabledFillColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnROIComplete.DisabledForecolor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.btnROIComplete.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed
        Me.btnROIComplete.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnROIComplete.ForeColor = System.Drawing.Color.Black
        Me.btnROIComplete.IconLeftCursor = System.Windows.Forms.Cursors.Hand
        Me.btnROIComplete.IconMarginLeft = 11
        Me.btnROIComplete.IconPadding = 10
        Me.btnROIComplete.IconRightCursor = System.Windows.Forms.Cursors.Hand
        Me.btnROIComplete.IdleBorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnROIComplete.IdleBorderRadius = 30
        Me.btnROIComplete.IdleBorderThickness = 1
        Me.btnROIComplete.IdleFillColor = System.Drawing.Color.WhiteSmoke
        Me.btnROIComplete.IdleIconLeftImage = Nothing
        Me.btnROIComplete.IdleIconRightImage = Nothing
        Me.btnROIComplete.IndicateFocus = False
        Me.btnROIComplete.Location = New System.Drawing.Point(582, 5)
        Me.btnROIComplete.Name = "btnROIComplete"
        StateProperties1.BorderColor = System.Drawing.Color.DarkSlateGray
        StateProperties1.BorderRadius = 30
        StateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties1.BorderThickness = 1
        StateProperties1.FillColor = System.Drawing.Color.DarkSlateGray
        StateProperties1.ForeColor = System.Drawing.Color.White
        StateProperties1.IconLeftImage = Nothing
        StateProperties1.IconRightImage = Nothing
        Me.btnROIComplete.onHoverState = StateProperties1
        StateProperties2.BorderColor = System.Drawing.Color.DarkSlateGray
        StateProperties2.BorderRadius = 30
        StateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid
        StateProperties2.BorderThickness = 1
        StateProperties2.FillColor = System.Drawing.Color.DarkSlateGray
        StateProperties2.ForeColor = System.Drawing.Color.White
        StateProperties2.IconLeftImage = Nothing
        StateProperties2.IconRightImage = Nothing
        Me.btnROIComplete.OnPressedState = StateProperties2
        Me.btnROIComplete.Size = New System.Drawing.Size(175, 30)
        Me.btnROIComplete.TabIndex = 6
        Me.btnROIComplete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnROIComplete.TextMarginLeft = 0
        Me.btnROIComplete.UseDefaultRadiusAndThickness = True
        '
        'panROIHeader
        '
        Me.panROIHeader.BackColor = System.Drawing.Color.Crimson
        Me.panROIHeader.Controls.Add(Me.lblROIHeader)
        Me.panROIHeader.Location = New System.Drawing.Point(230, -15)
        Me.panROIHeader.Name = "panROIHeader"
        Me.panROIHeader.Size = New System.Drawing.Size(300, 45)
        Me.panROIHeader.TabIndex = 5
        '
        'lblROIHeader
        '
        Me.lblROIHeader.AutoEllipsis = False
        Me.lblROIHeader.AutoSize = False
        Me.lblROIHeader.CursorType = Nothing
        Me.lblROIHeader.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIHeader.ForeColor = System.Drawing.Color.White
        Me.lblROIHeader.Location = New System.Drawing.Point(31, 15)
        Me.lblROIHeader.Name = "lblROIHeader"
        Me.lblROIHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIHeader.Size = New System.Drawing.Size(238, 30)
        Me.lblROIHeader.TabIndex = 1
        Me.lblROIHeader.Text = "Customer Receipt"
        Me.lblROIHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblROIHeader.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'panROIBack
        '
        Me.panROIBack.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panROIBack.Controls.Add(Me.lblROIChange)
        Me.panROIBack.Controls.Add(Me.lblROIPaid)
        Me.panROIBack.Controls.Add(Me.lblROITax)
        Me.panROIBack.Controls.Add(Me.lblROIPayable)
        Me.panROIBack.Controls.Add(Me.lblROIDate)
        Me.panROIBack.Controls.Add(Me.txtROIRemarks)
        Me.panROIBack.Controls.Add(Me.lblROISID)
        Me.panROIBack.Controls.Add(Me.lblROIOID)
        Me.panROIBack.Controls.Add(Me.lblROISIDTitle)
        Me.panROIBack.Controls.Add(Me.lblROIOIDTitle)
        Me.panROIBack.Controls.Add(Me.lblROIChangeTitle)
        Me.panROIBack.Controls.Add(Me.lblROIPaidTitle)
        Me.panROIBack.Controls.Add(Me.lblROITaxTitle)
        Me.panROIBack.Controls.Add(Me.lblROIPayableTitle)
        Me.panROIBack.Controls.Add(Me.lblROIDateTitle)
        Me.panROIBack.Controls.Add(Me.lblROICNameTitle)
        Me.panROIBack.Controls.Add(Me.lblROICIDTitle)
        Me.panROIBack.Controls.Add(Me.lblROICName)
        Me.panROIBack.Controls.Add(Me.lblROICID)
        Me.panROIBack.Controls.Add(Me.lblROIOrdDet)
        Me.panROIBack.Controls.Add(Me.sprROIBottom)
        Me.panROIBack.Controls.Add(Me.sprROITop)
        Me.panROIBack.Location = New System.Drawing.Point(22, 64)
        Me.panROIBack.Name = "panROIBack"
        Me.panROIBack.Size = New System.Drawing.Size(760, 230)
        Me.panROIBack.TabIndex = 15
        '
        'lblROIChange
        '
        Me.lblROIChange.AutoEllipsis = False
        Me.lblROIChange.AutoSize = False
        Me.lblROIChange.CursorType = Nothing
        Me.lblROIChange.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIChange.ForeColor = System.Drawing.Color.Black
        Me.lblROIChange.Location = New System.Drawing.Point(143, 187)
        Me.lblROIChange.Name = "lblROIChange"
        Me.lblROIChange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIChange.Size = New System.Drawing.Size(131, 30)
        Me.lblROIChange.TabIndex = 11
        Me.lblROIChange.Text = "RM0.00"
        Me.lblROIChange.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROIChange.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIPaid
        '
        Me.lblROIPaid.AutoEllipsis = False
        Me.lblROIPaid.AutoSize = False
        Me.lblROIPaid.CursorType = Nothing
        Me.lblROIPaid.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIPaid.ForeColor = System.Drawing.Color.Black
        Me.lblROIPaid.Location = New System.Drawing.Point(143, 151)
        Me.lblROIPaid.Name = "lblROIPaid"
        Me.lblROIPaid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIPaid.Size = New System.Drawing.Size(131, 30)
        Me.lblROIPaid.TabIndex = 11
        Me.lblROIPaid.Text = "RM0.00"
        Me.lblROIPaid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROIPaid.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROITax
        '
        Me.lblROITax.AutoEllipsis = False
        Me.lblROITax.AutoSize = False
        Me.lblROITax.CursorType = Nothing
        Me.lblROITax.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROITax.ForeColor = System.Drawing.Color.Black
        Me.lblROITax.Location = New System.Drawing.Point(143, 115)
        Me.lblROITax.Name = "lblROITax"
        Me.lblROITax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROITax.Size = New System.Drawing.Size(131, 30)
        Me.lblROITax.TabIndex = 11
        Me.lblROITax.Text = "RM0.00"
        Me.lblROITax.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROITax.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIPayable
        '
        Me.lblROIPayable.AutoEllipsis = False
        Me.lblROIPayable.AutoSize = False
        Me.lblROIPayable.CursorType = Nothing
        Me.lblROIPayable.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIPayable.ForeColor = System.Drawing.Color.Black
        Me.lblROIPayable.Location = New System.Drawing.Point(143, 79)
        Me.lblROIPayable.Name = "lblROIPayable"
        Me.lblROIPayable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIPayable.Size = New System.Drawing.Size(131, 30)
        Me.lblROIPayable.TabIndex = 11
        Me.lblROIPayable.Text = "RM0.00"
        Me.lblROIPayable.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROIPayable.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIDate
        '
        Me.lblROIDate.AutoEllipsis = False
        Me.lblROIDate.AutoSize = False
        Me.lblROIDate.CursorType = Nothing
        Me.lblROIDate.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIDate.ForeColor = System.Drawing.Color.Black
        Me.lblROIDate.Location = New System.Drawing.Point(81, 41)
        Me.lblROIDate.Name = "lblROIDate"
        Me.lblROIDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIDate.Size = New System.Drawing.Size(209, 30)
        Me.lblROIDate.TabIndex = 11
        Me.lblROIDate.Text = "dd/MM/yyyy, HH:mm:ss"
        Me.lblROIDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROIDate.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'txtROIRemarks
        '
        Me.txtROIRemarks.AcceptsReturn = False
        Me.txtROIRemarks.AcceptsTab = False
        Me.txtROIRemarks.AnimationSpeed = 200
        Me.txtROIRemarks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.txtROIRemarks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None
        Me.txtROIRemarks.BackColor = System.Drawing.Color.Transparent
        Me.txtROIRemarks.BackgroundImage = CType(resources.GetObject("txtROIRemarks.BackgroundImage"), System.Drawing.Image)
        Me.txtROIRemarks.BorderColorActive = System.Drawing.Color.Crimson
        Me.txtROIRemarks.BorderColorDisabled = System.Drawing.Color.Gray
        Me.txtROIRemarks.BorderColorHover = System.Drawing.Color.Crimson
        Me.txtROIRemarks.BorderColorIdle = System.Drawing.Color.Crimson
        Me.txtROIRemarks.BorderRadius = 20
        Me.txtROIRemarks.BorderThickness = 2
        Me.txtROIRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.txtROIRemarks.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtROIRemarks.DefaultFont = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.txtROIRemarks.DefaultText = ""
        Me.txtROIRemarks.FillColor = System.Drawing.Color.WhiteSmoke
        Me.txtROIRemarks.HideSelection = True
        Me.txtROIRemarks.IconLeft = Nothing
        Me.txtROIRemarks.IconLeftCursor = System.Windows.Forms.Cursors.IBeam
        Me.txtROIRemarks.IconPadding = 10
        Me.txtROIRemarks.IconRight = Nothing
        Me.txtROIRemarks.IconRightCursor = System.Windows.Forms.Cursors.IBeam
        Me.txtROIRemarks.Lines = New String(-1) {}
        Me.txtROIRemarks.Location = New System.Drawing.Point(280, 88)
        Me.txtROIRemarks.MaxLength = 32767
        Me.txtROIRemarks.MinimumSize = New System.Drawing.Size(100, 35)
        Me.txtROIRemarks.Modified = False
        Me.txtROIRemarks.Multiline = True
        Me.txtROIRemarks.Name = "txtROIRemarks"
        StateProperties3.BorderColor = System.Drawing.Color.Crimson
        StateProperties3.FillColor = System.Drawing.Color.Empty
        StateProperties3.ForeColor = System.Drawing.Color.Empty
        StateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtROIRemarks.OnActiveState = StateProperties3
        StateProperties4.BorderColor = System.Drawing.Color.Gray
        StateProperties4.FillColor = System.Drawing.Color.White
        StateProperties4.ForeColor = System.Drawing.Color.Empty
        StateProperties4.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtROIRemarks.OnDisabledState = StateProperties4
        StateProperties5.BorderColor = System.Drawing.Color.Crimson
        StateProperties5.FillColor = System.Drawing.Color.Empty
        StateProperties5.ForeColor = System.Drawing.Color.Empty
        StateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtROIRemarks.OnHoverState = StateProperties5
        StateProperties6.BorderColor = System.Drawing.Color.Crimson
        StateProperties6.FillColor = System.Drawing.Color.WhiteSmoke
        StateProperties6.ForeColor = System.Drawing.Color.Empty
        StateProperties6.PlaceholderForeColor = System.Drawing.Color.Empty
        Me.txtROIRemarks.OnIdleState = StateProperties6
        Me.txtROIRemarks.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtROIRemarks.PlaceholderForeColor = System.Drawing.Color.Silver
        Me.txtROIRemarks.PlaceholderText = "A description"
        Me.txtROIRemarks.ReadOnly = True
        Me.txtROIRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtROIRemarks.SelectedText = ""
        Me.txtROIRemarks.SelectionLength = 0
        Me.txtROIRemarks.SelectionStart = 0
        Me.txtROIRemarks.ShortcutsEnabled = True
        Me.txtROIRemarks.Size = New System.Drawing.Size(460, 129)
        Me.txtROIRemarks.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu
        Me.txtROIRemarks.TabIndex = 10
        Me.txtROIRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtROIRemarks.TextMarginBottom = 0
        Me.txtROIRemarks.TextMarginLeft = 5
        Me.txtROIRemarks.TextMarginTop = 0
        Me.txtROIRemarks.TextPlaceholder = "A description"
        Me.txtROIRemarks.UseSystemPasswordChar = False
        Me.txtROIRemarks.WordWrap = True
        '
        'lblROISID
        '
        Me.lblROISID.AutoEllipsis = False
        Me.lblROISID.AutoSize = False
        Me.lblROISID.CursorType = Nothing
        Me.lblROISID.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROISID.ForeColor = System.Drawing.Color.Black
        Me.lblROISID.Location = New System.Drawing.Point(660, 5)
        Me.lblROISID.Name = "lblROISID"
        Me.lblROISID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROISID.Size = New System.Drawing.Size(70, 30)
        Me.lblROISID.TabIndex = 9
        Me.lblROISID.Text = "S000"
        Me.lblROISID.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblROISID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIOID
        '
        Me.lblROIOID.AutoEllipsis = False
        Me.lblROIOID.AutoSize = False
        Me.lblROIOID.CursorType = Nothing
        Me.lblROIOID.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIOID.ForeColor = System.Drawing.Color.Black
        Me.lblROIOID.Location = New System.Drawing.Point(466, 5)
        Me.lblROIOID.Name = "lblROIOID"
        Me.lblROIOID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIOID.Size = New System.Drawing.Size(114, 30)
        Me.lblROIOID.TabIndex = 9
        Me.lblROIOID.Text = "O00000"
        Me.lblROIOID.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblROIOID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROISIDTitle
        '
        Me.lblROISIDTitle.AutoEllipsis = False
        Me.lblROISIDTitle.AutoSize = False
        Me.lblROISIDTitle.CursorType = Nothing
        Me.lblROISIDTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROISIDTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROISIDTitle.Location = New System.Drawing.Point(586, 5)
        Me.lblROISIDTitle.Name = "lblROISIDTitle"
        Me.lblROISIDTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROISIDTitle.Size = New System.Drawing.Size(68, 30)
        Me.lblROISIDTitle.TabIndex = 9
        Me.lblROISIDTitle.Text = "Staff ID:"
        Me.lblROISIDTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROISIDTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIOIDTitle
        '
        Me.lblROIOIDTitle.AutoEllipsis = False
        Me.lblROIOIDTitle.AutoSize = False
        Me.lblROIOIDTitle.CursorType = Nothing
        Me.lblROIOIDTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIOIDTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROIOIDTitle.Location = New System.Drawing.Point(380, 5)
        Me.lblROIOIDTitle.Name = "lblROIOIDTitle"
        Me.lblROIOIDTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIOIDTitle.Size = New System.Drawing.Size(80, 30)
        Me.lblROIOIDTitle.TabIndex = 9
        Me.lblROIOIDTitle.Text = "Order ID:"
        Me.lblROIOIDTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIOIDTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIChangeTitle
        '
        Me.lblROIChangeTitle.AutoEllipsis = False
        Me.lblROIChangeTitle.AutoSize = False
        Me.lblROIChangeTitle.CursorType = Nothing
        Me.lblROIChangeTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIChangeTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROIChangeTitle.Location = New System.Drawing.Point(3, 187)
        Me.lblROIChangeTitle.Name = "lblROIChangeTitle"
        Me.lblROIChangeTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIChangeTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblROIChangeTitle.TabIndex = 9
        Me.lblROIChangeTitle.Text = "Change:"
        Me.lblROIChangeTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIChangeTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIPaidTitle
        '
        Me.lblROIPaidTitle.AutoEllipsis = False
        Me.lblROIPaidTitle.AutoSize = False
        Me.lblROIPaidTitle.CursorType = Nothing
        Me.lblROIPaidTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIPaidTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROIPaidTitle.Location = New System.Drawing.Point(3, 151)
        Me.lblROIPaidTitle.Name = "lblROIPaidTitle"
        Me.lblROIPaidTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIPaidTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblROIPaidTitle.TabIndex = 9
        Me.lblROIPaidTitle.Text = "Total Paid:"
        Me.lblROIPaidTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIPaidTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROITaxTitle
        '
        Me.lblROITaxTitle.AutoEllipsis = False
        Me.lblROITaxTitle.AutoSize = False
        Me.lblROITaxTitle.CursorType = Nothing
        Me.lblROITaxTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROITaxTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROITaxTitle.Location = New System.Drawing.Point(3, 115)
        Me.lblROITaxTitle.Name = "lblROITaxTitle"
        Me.lblROITaxTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROITaxTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblROITaxTitle.TabIndex = 9
        Me.lblROITaxTitle.Text = "Taxation (6%):"
        Me.lblROITaxTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROITaxTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIPayableTitle
        '
        Me.lblROIPayableTitle.AutoEllipsis = False
        Me.lblROIPayableTitle.AutoSize = False
        Me.lblROIPayableTitle.CursorType = Nothing
        Me.lblROIPayableTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIPayableTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROIPayableTitle.Location = New System.Drawing.Point(3, 79)
        Me.lblROIPayableTitle.Name = "lblROIPayableTitle"
        Me.lblROIPayableTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIPayableTitle.Size = New System.Drawing.Size(134, 30)
        Me.lblROIPayableTitle.TabIndex = 9
        Me.lblROIPayableTitle.Text = "Total Payable:"
        Me.lblROIPayableTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIPayableTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIDateTitle
        '
        Me.lblROIDateTitle.AutoEllipsis = False
        Me.lblROIDateTitle.AutoSize = False
        Me.lblROIDateTitle.CursorType = Nothing
        Me.lblROIDateTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROIDateTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROIDateTitle.Location = New System.Drawing.Point(3, 41)
        Me.lblROIDateTitle.Name = "lblROIDateTitle"
        Me.lblROIDateTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIDateTitle.Size = New System.Drawing.Size(68, 30)
        Me.lblROIDateTitle.TabIndex = 9
        Me.lblROIDateTitle.Text = "Date:"
        Me.lblROIDateTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIDateTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROICNameTitle
        '
        Me.lblROICNameTitle.AutoEllipsis = False
        Me.lblROICNameTitle.AutoSize = False
        Me.lblROICNameTitle.CursorType = Nothing
        Me.lblROICNameTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROICNameTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROICNameTitle.Location = New System.Drawing.Point(277, 41)
        Me.lblROICNameTitle.Name = "lblROICNameTitle"
        Me.lblROICNameTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROICNameTitle.Size = New System.Drawing.Size(68, 30)
        Me.lblROICNameTitle.TabIndex = 9
        Me.lblROICNameTitle.Text = "Name:"
        Me.lblROICNameTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROICNameTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROICIDTitle
        '
        Me.lblROICIDTitle.AutoEllipsis = False
        Me.lblROICIDTitle.AutoSize = False
        Me.lblROICIDTitle.CursorType = Nothing
        Me.lblROICIDTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROICIDTitle.ForeColor = System.Drawing.Color.Black
        Me.lblROICIDTitle.Location = New System.Drawing.Point(161, 5)
        Me.lblROICIDTitle.Name = "lblROICIDTitle"
        Me.lblROICIDTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROICIDTitle.Size = New System.Drawing.Size(113, 30)
        Me.lblROICIDTitle.TabIndex = 9
        Me.lblROICIDTitle.Text = "Customer ID:"
        Me.lblROICIDTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROICIDTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROICName
        '
        Me.lblROICName.AutoEllipsis = False
        Me.lblROICName.AutoSize = False
        Me.lblROICName.CursorType = Nothing
        Me.lblROICName.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblROICName.ForeColor = System.Drawing.Color.Black
        Me.lblROICName.Location = New System.Drawing.Point(351, 41)
        Me.lblROICName.Name = "lblROICName"
        Me.lblROICName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROICName.Size = New System.Drawing.Size(398, 30)
        Me.lblROICName.TabIndex = 9
        Me.lblROICName.Text = "John Doe"
        Me.lblROICName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblROICName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROICID
        '
        Me.lblROICID.AutoEllipsis = False
        Me.lblROICID.AutoSize = False
        Me.lblROICID.CursorType = Nothing
        Me.lblROICID.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROICID.ForeColor = System.Drawing.Color.Black
        Me.lblROICID.Location = New System.Drawing.Point(277, 5)
        Me.lblROICID.Name = "lblROICID"
        Me.lblROICID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROICID.Size = New System.Drawing.Size(114, 30)
        Me.lblROICID.TabIndex = 9
        Me.lblROICID.Text = "C00000"
        Me.lblROICID.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblROICID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'lblROIOrdDet
        '
        Me.lblROIOrdDet.AutoEllipsis = False
        Me.lblROIOrdDet.AutoSize = False
        Me.lblROIOrdDet.CursorType = Nothing
        Me.lblROIOrdDet.Font = New System.Drawing.Font("Century Gothic", 16.0!)
        Me.lblROIOrdDet.ForeColor = System.Drawing.Color.Black
        Me.lblROIOrdDet.Location = New System.Drawing.Point(3, 5)
        Me.lblROIOrdDet.Name = "lblROIOrdDet"
        Me.lblROIOrdDet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblROIOrdDet.Size = New System.Drawing.Size(152, 30)
        Me.lblROIOrdDet.TabIndex = 9
        Me.lblROIOrdDet.Text = "Order Details:"
        Me.lblROIOrdDet.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblROIOrdDet.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.[Default]
        '
        'sprROIBottom
        '
        Me.sprROIBottom.BackColor = System.Drawing.Color.Transparent
        Me.sprROIBottom.LineColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.sprROIBottom.LineThickness = 1
        Me.sprROIBottom.Location = New System.Drawing.Point(20, 61)
        Me.sprROIBottom.Name = "sprROIBottom"
        Me.sprROIBottom.Size = New System.Drawing.Size(720, 35)
        Me.sprROIBottom.TabIndex = 8
        Me.sprROIBottom.Transparency = 255
        Me.sprROIBottom.Vertical = False
        '
        'sprROITop
        '
        Me.sprROITop.BackColor = System.Drawing.Color.Transparent
        Me.sprROITop.LineColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.sprROITop.LineThickness = 1
        Me.sprROITop.Location = New System.Drawing.Point(0, 20)
        Me.sprROITop.Name = "sprROITop"
        Me.sprROITop.Size = New System.Drawing.Size(761, 35)
        Me.sprROITop.TabIndex = 8
        Me.sprROITop.Transparency = 255
        Me.sprROITop.Vertical = False
        '
        'panROISummary
        '
        Me.panROISummary.BackColor = System.Drawing.Color.LightGray
        Me.panROISummary.Controls.Add(Me.dgvROIFinal)
        Me.panROISummary.Location = New System.Drawing.Point(22, 300)
        Me.panROISummary.Name = "panROISummary"
        Me.panROISummary.Size = New System.Drawing.Size(728, 240)
        Me.panROISummary.TabIndex = 16
        '
        'dgvROIFinal
        '
        Me.dgvROIFinal.AllowCustomTheming = True
        Me.dgvROIFinal.AllowUserToAddRows = False
        Me.dgvROIFinal.AllowUserToDeleteRows = False
        Me.dgvROIFinal.AllowUserToResizeColumns = False
        Me.dgvROIFinal.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(206, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvROIFinal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvROIFinal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvROIFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvROIFinal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvROIFinal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Crimson
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvROIFinal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvROIFinal.ColumnHeadersHeight = 40
        Me.dgvROIFinal.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.dgvROIFinal.CurrentTheme.AlternatingRowsStyle.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.dgvROIFinal.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvROIFinal.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvROIFinal.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgvROIFinal.CurrentTheme.BackColor = System.Drawing.Color.Crimson
        Me.dgvROIFinal.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvROIFinal.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Crimson
        Me.dgvROIFinal.CurrentTheme.HeaderStyle.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.dgvROIFinal.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvROIFinal.CurrentTheme.Name = Nothing
        Me.dgvROIFinal.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.dgvROIFinal.CurrentTheme.RowsStyle.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.dgvROIFinal.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvROIFinal.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvROIFinal.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(216, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(138, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvROIFinal.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvROIFinal.EnableHeadersVisualStyles = False
        Me.dgvROIFinal.GridColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvROIFinal.HeaderBackColor = System.Drawing.Color.Crimson
        Me.dgvROIFinal.HeaderBgColor = System.Drawing.Color.Empty
        Me.dgvROIFinal.HeaderForeColor = System.Drawing.Color.White
        Me.dgvROIFinal.Location = New System.Drawing.Point(0, 0)
        Me.dgvROIFinal.Name = "dgvROIFinal"
        Me.dgvROIFinal.ReadOnly = True
        Me.dgvROIFinal.RowHeadersVisible = False
        Me.dgvROIFinal.RowTemplate.Height = 40
        Me.dgvROIFinal.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvROIFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvROIFinal.Size = New System.Drawing.Size(728, 240)
        Me.dgvROIFinal.TabIndex = 2
        Me.dgvROIFinal.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Crimson
        '
        'vsbROIMain
        '
        Me.vsbROIMain.AllowCursorChanges = True
        Me.vsbROIMain.AllowHomeEndKeysDetection = False
        Me.vsbROIMain.AllowIncrementalClickMoves = True
        Me.vsbROIMain.AllowMouseDownEffects = True
        Me.vsbROIMain.AllowMouseHoverEffects = True
        Me.vsbROIMain.AllowScrollingAnimations = True
        Me.vsbROIMain.AllowScrollKeysDetection = True
        Me.vsbROIMain.AllowScrollOptionsMenu = True
        Me.vsbROIMain.AllowShrinkingOnFocusLost = True
        Me.vsbROIMain.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.vsbROIMain.BackgroundImage = CType(resources.GetObject("vsbROIMain.BackgroundImage"), System.Drawing.Image)
        Me.vsbROIMain.BindingContainer = Me.dgvROIFinal
        Me.vsbROIMain.BorderColor = System.Drawing.Color.Silver
        Me.vsbROIMain.BorderRadius = 1
        Me.vsbROIMain.BorderThickness = 1
        Me.vsbROIMain.DurationBeforeShrink = 2000
        Me.vsbROIMain.LargeChange = 10
        Me.vsbROIMain.Location = New System.Drawing.Point(756, 300)
        Me.vsbROIMain.Maximum = 100
        Me.vsbROIMain.Minimum = 0
        Me.vsbROIMain.MinimumThumbLength = 18
        Me.vsbROIMain.Name = "vsbROIMain"
        Me.vsbROIMain.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver
        Me.vsbROIMain.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent
        Me.vsbROIMain.OnDisable.ThumbColor = System.Drawing.Color.Silver
        Me.vsbROIMain.ScrollBarBorderColor = System.Drawing.Color.Silver
        Me.vsbROIMain.ScrollBarColor = System.Drawing.Color.Gainsboro
        Me.vsbROIMain.ShrinkSizeLimit = 3
        Me.vsbROIMain.Size = New System.Drawing.Size(15, 240)
        Me.vsbROIMain.SmallChange = 25
        Me.vsbROIMain.TabIndex = 17
        Me.vsbROIMain.ThumbColor = System.Drawing.Color.Crimson
        Me.vsbROIMain.ThumbLength = 23
        Me.vsbROIMain.ThumbMargin = 0
        Me.vsbROIMain.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Proportional
        Me.vsbROIMain.Value = 0
        '
        'receiptorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(808, 570)
        Me.Controls.Add(Me.vsbROIMain)
        Me.Controls.Add(Me.panROISummary)
        Me.Controls.Add(Me.panROIBack)
        Me.Controls.Add(Me.panROIStep)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "receiptorder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "receiptorder"
        Me.panROIStep.ResumeLayout(False)
        Me.panROIHeader.ResumeLayout(False)
        Me.panROIBack.ResumeLayout(False)
        Me.panROISummary.ResumeLayout(False)
        CType(Me.dgvROIFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panROIStep As Panel
    Friend WithEvents panROIHeader As Panel
    Friend WithEvents lblROIHeader As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents panROIBack As Panel
    Friend WithEvents sprROITop As Bunifu.Framework.UI.BunifuSeparator
    Friend WithEvents lblROISID As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIOID As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROICID As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIOrdDet As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROISIDTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIOIDTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROICIDTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents txtROIRemarks As Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox
    Friend WithEvents lblROIDate As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIDateTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents panROISummary As Panel
    Friend WithEvents lblROIChange As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIPaid As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROITax As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIPayable As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIChangeTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIPaidTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROITaxTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROIPayableTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROICNameTitle As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents lblROICName As Bunifu.UI.WinForms.BunifuLabel
    Friend WithEvents vsbROIMain As Bunifu.UI.WinForms.BunifuVScrollBar
    Friend WithEvents btnROIComplete As Bunifu.UI.WinForms.BunifuButton.BunifuButton
    Friend WithEvents sprROIBottom As Bunifu.Framework.UI.BunifuSeparator
    Friend WithEvents dgvROIFinal As Bunifu.UI.WinForms.BunifuDataGridView
End Class
