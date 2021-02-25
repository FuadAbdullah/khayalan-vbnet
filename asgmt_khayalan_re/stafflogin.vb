Imports System.Data.OleDb

Public Class stafflogin

    '##_Note_##
    'kcdbCString - Connection String
    'kcdbDataSet - Dataset

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_START
    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_LOCAL_VARIABLE
    '##################################################################################################################################################################################################

    Dim lsec As Integer
    Dim lblSLIIO As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel

    'For database connection use
    Dim slCon As New OleDb.OleDbConnection      'Establish staff login connection to database
    Dim dbProvider, dbSource, Sql As String     'Declaring database retrieval keywords
    Dim ds As New DataSet                       'Create a new data container for fetched data
    Dim da As OleDb.OleDbDataAdapter            'Act as bridge between database and dataset
    'Dim n As Integer
    'Dim ispressed As Boolean = False
    '---------------------------

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_CORE
    '##################################################################################################################################################################################################

    Private Sub Staff_Login_Interface_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        Staff_Login_Interface_Focus()
        Staff_Login_Interface_Disable_Controls()
        Staff_Login_Interface_Startup_Timer_Start()
        Staff_Login_Interface_Initialise_Clock()
        Staff_Login_Interface_Intro_Transition_Set()
        Staff_Login_Interface_Elipse_Set()
        Staff_Login_Interface_Add_Controls()
        Staff_Login_Interface_Database_Initial_Load()
    End Sub

    Sub Staff_Login_Interface_Startup_Timer_Start()
        timSLIStart.Interval = 1000
        timSLIStart.Start()
    End Sub

    Sub Staff_Login_Interface_Initialise_Clock()
        timSLIClock.Interval = 1000
        timSLIClock.Start()
    End Sub

    Private Sub Staff_Login_Interface_Startup_Timer_Set(sender As Object, e As EventArgs) Handles timSLIStart.Tick
        lsec += 1
        If lsec = 2 Then
            Staff_Login_Interface_Controls_Load()
            Staff_Login_Interface_Enable_Controls()
            lsec = 0
            timSLIStart.Stop()
        End If
    End Sub

    Private Sub Staff_Login_Interface_Initialise_Clock_Set(sender As Object, e As EventArgs) Handles timSLIClock.Tick
        Dim day As String
        day = DateTime.Now.DayOfWeek.ToString()
        lblSLIClock.Text = day & DateTime.Now.ToString(", dd/MM/yyyy, hh:mm:ss tt")
    End Sub

    Sub Staff_Login_Interface_Intro_Transition_Set()
        Dim ftrSLIForm As New Bunifu.Framework.UI.BunifuFormFadeTransition
        ftrSLIForm.ShowAsyc(Me)
    End Sub

    'Sub Staff_Login_Interface_Drag_Control_Set()
    '    dcSLI.TargetControl = gpanSLIBor
    '    dcSLI.Horizontal = True
    '    dcSLI.Vertical = True
    '    dcSLI.Fixed = True
    'End Sub

    Sub Staff_Login_Interface_Elipse_Set()
        Dim elSLI As New Bunifu.Framework.UI.BunifuElipse
        elSLI.ApplyElipse(Me, 20)
        elSLI.ApplyElipse(panSLIBack, 20)
        elSLI.ApplyElipse(panSLIInp, 20)
    End Sub

    Sub Staff_Login_Interface_Add_Controls()
        lblSLIIO.Visible = False
        Controls.Add(lblSLIIO)
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_CONTROL_SET
    '##################################################################################################################################################################################################

    Private Sub Staff_Login_Interface_Login_Button_Vertical_Text(sender As Object, e As PaintEventArgs) Handles btnSLILogin.Paint
        Dim btnSLILoginT As New Font("Century Gothic", 12)
        Dim btnSLILoginB As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
        e.Graphics.TranslateTransform(30, 20)
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString("Login as Staff", btnSLILoginT, btnSLILoginB, 0, 0)
    End Sub

    Private Sub Staff_Login_Interface_Show_Side_Pane(sender As Object, e As EventArgs) Handles btniSLISideS.Click
        Staff_Login_Interface_Show_Side_Pane_Controller()
    End Sub

    Private Sub Staff_Login_Interface_Hide_Side_Pane(sender As Object, e As EventArgs) Handles btniSLISideH.Click
        Staff_Login_Interface_Hide_Side_Pane_Controller()
    End Sub

    Private Sub Staff_Login_Interface_SLIStaP_PasswordMode(sender As Object, e As EventArgs) Handles mxtSLIStaP.OnValueChanged
        If mxtSLIStaP.Text = vbNullString Then
            mxtSLIStaP.isPassword = False
        Else
            mxtSLIStaP.isPassword = True
        End If
    End Sub

    Private Sub Staff_Login_Interface_Show_Login_Button(sender As Object, e As EventArgs) Handles mxtSLIStaU.OnValueChanged, mxtSLIStaP.OnValueChanged
        If mxtSLIStaP.Text <> vbNullString And mxtSLIStaU.Text <> vbNullString Then
            trSLIHorizS.ShowSync(btnSLILogin)
        Else
            trSLIHorizS.HideSync(btnSLILogin)
        End If

        If mxtSLIStaP.Text <> vbNullString Or mxtSLIStaU.Text <> vbNullString Then
            Staff_Login_Interface_Hide_Side_Pane_Controller()
        End If
    End Sub

    Private Sub Staff_Login_Interface_Username_Enter_Pressed(sender As Object, e As KeyEventArgs) Handles mxtSLIStaU.KeyDown
        If e.KeyCode = Keys.Enter Then
            mxtSLIStaP.GetFocus()
        End If
    End Sub

    Private Sub Staff_Login_Interface_Password_Enter_Pressed(sender As Object, e As KeyEventArgs) Handles mxtSLIStaP.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSLILogin.PerformClick()
        End If
    End Sub

    Private Sub Staff_Login_Interface_Reset(sender As Object, e As EventArgs) Handles btnSLIRes.Click, btnSLIResSm.Click
        Staff_Login_Interface_User_Input_Reset()
        Staff_Login_Interface_Hide_Side_Pane_Controller()
    End Sub

    Private Sub Staff_Login_Interface_Minimise_Button(sender As Object, e As EventArgs) Handles btnSLIMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_EXIT_APPLICATION
    '##################################################################################################################################################################################################

    Private Sub Staff_Login_Interface_Exit_Application(sender As Object, e As EventArgs) Handles btnSLIClose.Click, btnSLIExit.Click, btnSLIExitSm.Click
        Staff_Login_Interface_Disable_Drag_Control()
        Staff_Login_Interface_Disable_Controls()
        Staff_Login_Interface_Hide_Side_Pane_Controller()

        Dim res As DialogResult = MessageBox.Show("You are about to leave staff login page and this will cause the application to close. Are you sure?", "Quit application.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            Application.Exit()

        Else
            Staff_Login_Interface_Focus()
            Staff_Login_Interface_Enable_Drag_Control()
            Staff_Login_Interface_Enable_Controls()
        End If


    End Sub

    'Private Sub Staff_Login_Interface_Exit_Application_Button(sender As Object, e As EventArgs) Handles btnSLIExit.Click, btnSLIExitSm.Click
    '    Popup_Interface_Exit_Application_Setting()
    '    Popup_Interface_Exit_Application_Form_Position()
    '    Staff_Login_Interface_Disable_Drag_Control()
    '    Staff_Login_Interface_Disable_Controls()
    '    Staff_Login_Interface_Hide_Side_Pane_Controller()
    'End Sub

    'Sub Staff_Login_Interface_Exit_Application_Confirmed(sender As Object, e As EventArgs)
    '    Popup_Interface_Reset_Display_Controller()
    '    Application.Exit()
    'End Sub

    'Sub Staff_Login_Interface_Exit_Application_Cancelled(sender As Object, e As EventArgs)
    '    popup.Visible = False
    '    Popup_Interface_Reset_Display_Controller()
    '    Staff_Login_Interface_Focus()
    '    Staff_Login_Interface_Enable_Drag_Control()
    '    Staff_Login_Interface_Enable_Controls()
    'End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_DATABASE_CONNECTION
    '##################################################################################################################################################################################################

    Sub Staff_Login_Interface_Database_Initial_Load()
        dbProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        dbSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        slCon.ConnectionString = dbProvider & dbSource
        'slCon.Open()
        'Sql = "SELECT * FROM STAFF_T"
        'da = New OleDb.OleDbDataAdapter(Sql, slCon)
        'da.Fill(ds, "staffCredentials")
        'slCon.Close()
    End Sub

    Sub Staff_Menu_Interface_Validate_Credentials()

        Dim username, password As String
        Dim staID As String = "NULL"
        Dim slcmd As OleDbCommand = New OleDbCommand(
            "SELECT sta_username, sta_password FROM STAFF_T WHERE sta_username = '" & Trim(mxtSLIStaU.Text) & "' AND sta_password = '" & Trim(mxtSLIStaP.Text) & "' ", slCon)

        slCon.Open()
        Dim slDR As OleDbDataReader = slcmd.ExecuteReader()
        Sql = "SELECT sta_id FROM STAFF_T WHERE sta_username = '" & Trim(mxtSLIStaU.Text) & "' AND sta_password = '" & Trim(mxtSLIStaP.Text) & "' "
        da = New OleDb.OleDbDataAdapter(Sql, slCon)
        da.Fill(ds, "staffID")
        If (slDR.Read() = True) Then

            username = slDR("sta_username")
            password = slDR("sta_password")
            staID = ds.Tables("staffID").Rows(0).Item(0).ToString
            ds.Tables("staffID").Rows.Clear()

            Staff_Login_Interface_Disable_Drag_Control()
            Staff_Login_Interface_Disable_Controls()
            Staff_Login_Interface_Hide_Side_Pane_Controller()
            Dim res As DialogResult = MessageBox.Show("Logged in successfully.", "Redirecting to Staff Menu.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                Staff_Login_Interface_Focus()
                Staff_Login_Interface_Enable_Drag_Control()
                Staff_Login_Interface_Hide_Side_Pane_Controller()
                Staff_Login_Interface_User_Input_Reset()
                Staff_Login_Interface_Disable_Controls()
                trSLITrans.HideSync(panSLISideSm)
                trSLITrans.HideSync(gpanSLIBack)
                Staff_Login_Interface_To_Staff_Menu_Interface_Notification()
                Staff_Login_Interface_To_Staff_Menu_Interface_Timer()

            End If

        Else

            Staff_Login_Interface_Disable_Drag_Control()
            Staff_Login_Interface_Disable_Controls()
            Staff_Login_Interface_Hide_Side_Pane_Controller()
            Dim res As DialogResult = MessageBox.Show("Your username or password is incorrect. Correct the input and try again.", "Invalid credentials.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                Staff_Login_Interface_Focus()
                Staff_Login_Interface_Enable_Drag_Control()
                Staff_Login_Interface_Enable_Controls()
                mxtSLIStaP.GetFocus()
            End If

        End If

        staffmenu.lblSMIStaID.Text = String.Format("Staff ID: {0}", Format(staID))
        slCon.Close()
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_REDIRECT_TO_STAFF_MENU_INTERFACE
    '##################################################################################################################################################################################################

    Private Sub Staff_Login_Interface_To_Staff_Menu_Interface(sender As Object, e As EventArgs) Handles btnSLILogin.Click
        Staff_Menu_Interface_Validate_Credentials()
    End Sub

    Sub Staff_Login_Interface_To_Staff_Menu_Interface_Notification()
        lblSLIIO.Text = "Please wait, redirecting you to Staff Menu Interface"
        lblSLIIO.Font = New Font("Century Gothic", 18)
        lblSLIIO.Location = New Point((Me.Width - lblSLIIO.Width) / 2, (Me.Height - lblSLIIO.Height) / 2)
    End Sub

    Sub Staff_Login_Interface_To_Staff_Menu_Interface_Timer()
        timSLIToSMI.Interval = 1000
        timSLIToSMI.Start()
    End Sub

    Private Sub Staff_Login_Interface_To_Staff_Menu_Interface_Timer_Set(sender As Object, e As EventArgs) Handles timSLIToSMI.Tick
        lsec += 1

        If lsec = 1 Then
            trSLITrans.ShowSync(lblSLIIO)
            Staff_Menu_Interface_Form_Position()
        ElseIf lsec = 3 Then
            trSLITrans.HideSync(lblSLIIO)
            staffmenu.BringToFront()
            Me.Hide()
            timSLIToSMI.Stop()
            lsec = 0
        End If
    End Sub

    Sub Staff_Menu_Interface_Form_Position()
        staffmenu.StartPosition = FormStartPosition.Manual
        staffmenu.Location = Me.Location
        staffmenu.Show()
        staffmenu.SendToBack()
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_REPOSITORY
    '##################################################################################################################################################################################################


    Public Sub Staff_Login_Interface_Controls_Load()
        trSLITrans.ShowSync(gpanSLIBack)
        trSLIHorizS.ShowSync(panSLISideSm)
    End Sub

    Sub Staff_Login_Interface_Focus()
        Me.Activate()
    End Sub

    Sub Staff_Login_Interface_User_Input_Reset()
        mxtSLIStaU.ResetText()
        mxtSLIStaP.ResetText()
    End Sub

    Sub Staff_Login_Interface_Enable_Drag_Control()
        dcSLI.TargetControl = gpanSLIBor
        dcSLI.Fixed = True
        dcSLI.Vertical = True
        dcSLI.Horizontal = True
    End Sub

    Sub Staff_Login_Interface_Disable_Drag_Control()
        dcSLI.TargetControl = gpanSLIBor
        dcSLI.Fixed = True
        dcSLI.Vertical = False
        dcSLI.Horizontal = False
    End Sub

    Public Sub Staff_Login_Interface_Enable_Controls()
        btnSLIClose.Enabled = True
        btnSLIMin.Enabled = True
        mxtSLIStaP.Enabled = True
        mxtSLIStaU.Enabled = True
        btniSLISideS.Enabled = True
        btnSLIResSm.Enabled = True
        btnSLIExitSm.Enabled = True
    End Sub

    Sub Staff_Login_Interface_Disable_Controls()
        btnSLIClose.Enabled = False
        btnSLIMin.Enabled = False
        mxtSLIStaP.Enabled = False
        mxtSLIStaU.Enabled = False
        btniSLISideS.Enabled = False
        btnSLIResSm.Enabled = False
        btnSLIExitSm.Enabled = False
    End Sub

    Sub Staff_Login_Interface_Show_Side_Pane_Controller()
        trSLIHorizS.HideSync(panSLISideSm)
        trSLIHorizS.ShowSync(panSLISide)
    End Sub

    Sub Staff_Login_Interface_Hide_Side_Pane_Controller()
        trSLIHorizS.HideSync(panSLISide)
        trSLIHorizS.ShowSync(panSLISideSm)
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_LOGIN_INTERFACE_END
    '##################################################################################################################################################################################################

End Class