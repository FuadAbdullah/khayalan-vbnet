Imports System.Data.OleDb

Public Class staffmenu
    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_START
    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_LOCAL_VARIABLE
    '##################################################################################################################################################################################################

    Dim lsec, one, ten, hundred, thousand, tthousand As Integer
    Dim lblSMIIntro As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel
    Dim panSMIInitial As Panel = New Panel
    Dim lblSMIHeader As Bunifu.UI.WinForms.BunifuLabel = New Bunifu.UI.WinForms.BunifuLabel
    Dim sprSMIHeader As Bunifu.Framework.UI.BunifuSeparator = New Bunifu.Framework.UI.BunifuSeparator

    'For database connection use
    Dim smCon As New OleDb.OleDbConnection          'Establish staff login connection to database
    Dim dbProvider, dbSource, smLoad As String     'Declaring database retrieval keywords
    Dim smdsLoad As DataSet = New DataSet("customerDetails")                      'Create a new data container for fetched data
    Dim smdaLoad As OleDb.OleDbDataAdapter            'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_CORE
    '##################################################################################################################################################################################################

    Private Sub Staff_Login_Interface_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        Staff_Menu_Interface_Focus()
        Staff_Menu_Interface_Disable_Controls()
        Staff_Menu_Interface_Elipse_Set()
        Staff_Menu_Interface_Database_Initial_Load()
        Staff_Menu_Interface_Load_Customer_Profile_Interface()
        Staff_Menu_Interface_Load_Customer_Registration_Interface()
        Staff_Menu_Interface_Load_Customer_Selection_Interface()
        Staff_Menu_Interface_Add_Controls()
        Staff_Menu_Interface_Logon_Load_Sequence()
        Staff_Menu_Interface_Logon_Load_Sequence_Text()
        Staff_Menu_Interface_Intro_Transition_Set()
        Staff_Menu_Interface_Startup_Timer_Start()
        Staff_Menu_Interface_Initialise_Clock()
    End Sub

    Sub Staff_Menu_Interface_Startup_Timer_Start()
        timSMIStart.Interval = 1000
        timSMIStart.Start()
    End Sub

    Sub Staff_Menu_Interface_Initialise_Clock()
        timSMIClock.Interval = 1000
        timSMIClock.Start()
    End Sub

    Private Sub Staff_Menu_Interface_Startup_Timer_Set(sender As Object, e As EventArgs) Handles timSMIStart.Tick
        lsec += 1
        If lsec = 1 Then
            trSMITrans.ShowSync(lblSMIIntro)
        ElseIf lsec = 2 Then
            lblSMIIntro.Text = "Loading header..."
            Staff_Menu_Interface_Primary_Header_Default()
            Staff_Menu_Interface_Primary_Header_Separator_Default()
        ElseIf lsec = 3 Then
            lblSMIIntro.Text = "Finalising components..."
            Staff_Menu_Interface_Addhandlers()
            Staff_Menu_Interface_Enable_Controls()
            trSMITrans.HideSync(lblSMIIntro)
            panSMIInitial.Controls.Remove(lblSMIIntro)
        ElseIf lsec = 4 Then
            trSMITrans.HideSync(panSMIInitial)
            lsec = 0
            timSMIStart.Stop()
        End If
    End Sub

    Private Sub Staff_Menu_Interface_Initialise_Clock_Set(sender As Object, e As EventArgs) Handles timSMIClock.Tick
        Dim day As String
        day = DateTime.Now.DayOfWeek.ToString()
        lblSMIClock.Text = day & DateTime.Now.ToString(", dd/MM/yyyy, hh:mm:ss tt")
    End Sub

    Sub Staff_Menu_Interface_Intro_Transition_Set()
        Dim ftrSMIForm As New Bunifu.Framework.UI.BunifuFormFadeTransition
        ftrSMIForm.ShowAsyc(Me)
    End Sub

    Sub Staff_Menu_Interface_Elipse_Set()
        Dim elSMI As New Bunifu.Framework.UI.BunifuElipse
        elSMI.ApplyElipse(Me, 20)
    End Sub

    Sub Staff_Menu_Interface_Logon_Load_Sequence()
        panSMIInitial.Size = New Size(808, 570)
        panSMIInitial.Location = New Point(0, 30)
        panSMIInitial.BackColor = Color.LightGray
        panSMIInitial.Visible = True
        Me.Controls.Add(panSMIInitial)
        panSMIInitial.BringToFront()
    End Sub

    Sub Staff_Menu_Interface_Add_Controls()
        lblSMIIntro.Visible = False
        Controls.Add(lblSMIIntro)
        lblSMIHeader.Visible = False
        gpanSMIHeader.Controls.Add(lblSMIHeader)
        sprSMIHeader.Visible = False
        gpanSMIHeader.Controls.Add(sprSMIHeader)
    End Sub

    Sub Staff_Menu_Interface_Logon_Load_Sequence_Text()
        lblSMIIntro.Text = "Loading Staff Menu Interface"
        lblSMIIntro.Font = New Font("Century Gothic", 18)
        'lblSMIIntro.Location = New Point((Me.Width - lblSMIIntro.Width) / 2, ((Me.Height - lblSMIIntro.Height) - 60) / 2)
        lblSMIIntro.AutoSize = False
        lblSMIIntro.Size = New Size(600, 40)
        lblSMIIntro.Location = New Point(30, 280)
        lblSMIIntro.Visible = False
        panSMIInitial.Controls.Add(lblSMIIntro)
    End Sub

    Sub Staff_Menu_Interface_Addhandlers() 'Microsoft, n.d. Addhandler Statement. 

        AddHandler customerselection.btnCSIProc.Click, AddressOf CSI_To_FSI

        AddHandler foodselection.btniFSItoDSI.Click, AddressOf FSI_To_DSI

        AddHandler drinkselection.btniDSItoSSI.Click, AddressOf DSI_To_SSI

        'AddHandler sidesselection.btniSSItoSOI.Click, AddressOf SSI_To_SOI

        AddHandler summaryorder.btniSOItoPOI.Click, AddressOf SOI_To_POI

        AddHandler paymentorder.btnPOIComp.Click, AddressOf POI_To_ROI

        AddHandler receiptorder.btnROIComplete.Click, AddressOf ROI_To_SMI



        AddHandler summaryorder.btniSOItoSSI.Click, AddressOf SOI_To_SSI

        AddHandler sidesselection.btniSSItoDSI.Click, AddressOf SSI_To_DSI

        AddHandler drinkselection.btniDSItoFSI.Click, AddressOf DSI_To_FSI

        'AddHandler foodselection.btniFSItoCSI.Click, AddressOf FSI_To_CSI
    End Sub
    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_CONTROL_SET
    '##################################################################################################################################################################################################

    Private Sub Staff_Menu_Interface_Open_Order_Pane(sender As Object, e As EventArgs) Handles btnSMIOrd.Click

        If panSMICust.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMICust)
            btnSMICust.Enabled = True
        End If

        If panSMIMisc.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMIMisc)
            btnSMIMisc.Enabled = True
        End If

        If customerprofile.Visible = True Then
            customerprofile.Visible = False
            Customer_Profile_Reset_Default()
        End If

        If customerregister.Visible = True Then
            customerregister.Visible = False
            Customer_Registration_Reset_Default()
        End If

        btnSMIOrd.Enabled = False
        trSMIVertS.TimeStep = 0.02
        trSMIVertS.ShowSync(panSMIOrd)
    End Sub

    Private Sub Staff_Menu_Interface_Close_Order_Pane(sender As Object, e As EventArgs) Handles btnSMIOrdC.Click, btnSMITkOrd.Click
        trSMIVertS.TimeStep = 0.03
        trSMIVertS.HideSync(panSMIOrd)
        btnSMIOrd.Enabled = True
    End Sub

    Private Sub Staff_Menu_Interface_Open_Customer_Pane(sender As Object, e As EventArgs) Handles btnSMICust.Click
        If panSMIOrd.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMIOrd)
            btnSMIOrd.Enabled = True
        End If

        If panSMIMisc.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMIMisc)
            btnSMIMisc.Enabled = True
        End If

        If customerprofile.Visible = True Then
            customerprofile.Visible = False
            Customer_Profile_Reset_Default()
        End If

        If customerregister.Visible = True Then
            customerregister.Visible = False
            Customer_Registration_Reset_Default()
        End If

        btnSMICust.Enabled = False
        trSMIVertS.TimeStep = 0.02
        trSMIVertS.ShowSync(panSMICust)
    End Sub

    Sub Customer_Registration_Reset_Default()
        customerregister.Customer_Registration_Interface_Reset_Form()
        customerregister.panCRISide.Visible = False
        customerregister.panCRISideSm.Visible = True
    End Sub

    Sub Customer_Profile_Reset_Default()
        customerprofile.panCPISide.Visible = False         'hide side panel
        customerprofile.panCPIDBSearch.Visible = False          'hide search panel
        customerprofile.panCPISideSm.Visible = True         'show side panel button

        customerprofile.CPI_Disable_Edit_Mode_Controls()
        customerprofile.CPI_Revert_Fields_To_Original()
        customerprofile.CPI_Disable_DropDownBoxes()
        customerprofile.CPI_Reset_Fields()
        customerprofile.CPI_Hide_Warning_Labels()

        customerprofile.dbxCPICriteria.SelectedIndex = -1
        customerprofile.dbxCPICriteria.Text = "Criteria"
        customerprofile.txtCPISearch.Clear()
        customerprofile.txtCPISearch.PlaceholderText = "Search"
        customerprofile.txtCPISearch.Enabled = False
        customerprofile.btniCPISearch.Visible = False
        customerprofile.btnCPISReset.Visible = False
        customerprofile.searchInput = ""

        If customerprofile.btnCPIEdit.Text <> "Editing customer" Then
            customerprofile.panCPIDBSearchSm.Visible = True         'show search panel button only when it is not in edit mode
        End If



    End Sub


    Private Sub Staff_Menu_Interface_Close_Customer_Pane(sender As Object, e As EventArgs) Handles btnSMICustC.Click, btnSMIPCust.Click, btnSMIRCust.Click
        trSMIVertS.TimeStep = 0.03
        trSMIVertS.HideSync(panSMICust)
        btnSMICust.Enabled = True
    End Sub

    Private Sub Staff_Menu_Interface_Open_Miscellaneous_Pane(sender As Object, e As EventArgs) Handles btnSMIMisc.Click
        If panSMIOrd.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMIOrd)
            btnSMIOrd.Enabled = True
        End If
        If panSMICust.Visible = True Then
            trSMIVertS.TimeStep = 0.03
            trSMIVertS.HideSync(panSMICust)
            btnSMICust.Enabled = True
        End If

        If customerprofile.Visible = True Then
            customerprofile.Visible = False
            Customer_Profile_Reset_Default()
        End If

        If customerregister.Visible = True Then
            customerregister.Visible = False
            Customer_Registration_Reset_Default()
        End If

        btnSMIMisc.Enabled = False
        trSMIVertS.TimeStep = 0.02
        trSMIVertS.ShowSync(panSMIMisc)
    End Sub

    Private Sub Staff_Menu_Interface_Close_Miscellaneous_Pane(sender As Object, e As EventArgs) Handles btnSMIMiscC.Click, btnSMISOMisc.Click
        trSMIVertS.TimeStep = 0.03
        trSMIVertS.HideSync(panSMIMisc)
        btnSMIMisc.Enabled = True
    End Sub

    Private Sub Staff_Menu_Interface_Minimise_Button(sender As Object, e As EventArgs) Handles btnSMIMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub CSI_To_FSI(sender As Object, e As EventArgs)
        btnSMIClose.Enabled = False

        Staff_Menu_Interface_Load_Food_Selection_Interface()
        customerselection.Visible = False
    End Sub

    Sub FSI_To_DSI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Drink_Selection_Interface()
        foodselection.Visible = False
    End Sub

    Sub DSI_To_SSI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Sides_Selection_Interface()
        drinkselection.Visible = False
    End Sub

    Sub SSI_To_SOI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Summary_Order_Interface()
        sidesselection.Visible = False
    End Sub

    Sub SOI_To_POI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Payment_Order_Interface()
        summaryorder.Visible = False
    End Sub

    Sub POI_To_ROI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Receipt_Order_Interface()
        paymentorder.Visible = False
    End Sub

    Sub ROI_To_SMI(sender As Object, e As EventArgs)
        'trSMIVertS.HideSync(panSMIOrd)
        'panSMIBack.BringToFront()
        'trSMIVertS.ShowSync(panSMIBack)
        'receiptorder.Visible = False

        trSMIVertS.HideSync(panSMIOrdForm)
        panSMIBack.BringToFront()
        trSMIVertS.ShowSync(panSMIBack)
        btnSMIClose.Enabled = True


        For Each form In {customerselection, foodselection, drinkselection, sidesselection, summaryorder, paymentorder, receiptorder} 'add payment and receipt as well
            form.visible = False
        Next


    End Sub




    Sub POI_To_SOI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Summary_Order_Interface()
        paymentorder.Visible = False
    End Sub

    Sub SOI_To_SSI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Sides_Selection_Interface()
        summaryorder.Visible = False
    End Sub

    Sub SSI_To_DSI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Drink_Selection_Interface()
        sidesselection.Visible = False
    End Sub

    Sub DSI_To_FSI(sender As Object, e As EventArgs)
        Staff_Menu_Interface_Load_Food_Selection_Interface()
        drinkselection.Visible = False
    End Sub

    Sub FSI_To_CSI(sender As Object, e As EventArgs)
        btnSMIClose.Enabled = True

        customerselection.Visible = True
        foodselection.Visible = False
    End Sub


    Private Sub SMI_Log_Out(sender As Object, e As EventArgs) Handles btnSMISOMisc.Click


        Staff_Menu_Interface_Disable_Drag_Control()
        Staff_Menu_Interface_Disable_Controls()
        Staff_Menu_Interface_Hide_Extended_Panes()

        If customerprofile.Visible = True Then
            Customer_Profile_Interface_Disable_Controls()
        End If

        If customerregister.Visible = True Then
            Customer_Registration_Interface_Disable_Controls()
        End If

        If customerselection.Visible = True Then
            CSI_Disable_Controls()
        End If


        Dim res As DialogResult = MessageBox.Show("You are leaving the Staff Menu and will be redirected back to login page. Continue?", "Logging out.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            Me.Hide()
            stafflogin.Show()
            SMI_Reset_Login_Form()

            Staff_Menu_Interface_Focus()
            Staff_Menu_Interface_Enable_Drag_Control()
            Staff_Menu_Interface_Enable_Controls()

            If customerprofile.Visible = True Then
                Customer_Profile_Interface_Enable_Controls()
            End If

            If customerregister.Visible = True Then
                Customer_Registration_Interface_Enable_Controls()
            End If

            If customerselection.Visible = True Then
                CSI_Enable_Controls()
            End If

        Else

            Staff_Menu_Interface_Focus()
            Staff_Menu_Interface_Enable_Drag_Control()
            Staff_Menu_Interface_Enable_Controls()

            If customerprofile.Visible = True Then
                Customer_Profile_Interface_Enable_Controls()
            End If

            If customerregister.Visible = True Then
                Customer_Registration_Interface_Enable_Controls()
            End If

            If customerselection.Visible = True Then
                CSI_Enable_Controls()
            End If


        End If


    End Sub

    Sub SMI_Reset_Login_Form()
        stafflogin.Staff_Login_Interface_Enable_Controls()
        stafflogin.Staff_Login_Interface_Controls_Load()
        stafflogin.gpanSLIBack.Visible = True
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_EXIT_APPLICATION
    '##################################################################################################################################################################################################

    Private Sub Staff_Menu_Interface_Exit_Application(sender As Object, e As EventArgs) Handles btnSMIClose.Click

        Staff_Menu_Interface_Disable_Drag_Control()
        Staff_Menu_Interface_Disable_Controls()
        Staff_Menu_Interface_Hide_Extended_Panes()

        If customerprofile.Visible = True Then
            Customer_Profile_Interface_Disable_Controls()
        End If

        If customerregister.Visible = True Then
            Customer_Registration_Interface_Disable_Controls()
        End If

        If customerselection.Visible = True Then
            CSI_Disable_Controls()
        End If



        Dim res As DialogResult = MessageBox.Show("You are leaving Khayalan Staff Menu. Are you sure?", "Leaving Khayalan Staff Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            Application.Exit()
        Else

            Staff_Menu_Interface_Focus()
            Staff_Menu_Interface_Enable_Drag_Control()
            Staff_Menu_Interface_Enable_Controls()

            If customerprofile.Visible = True Then
                Customer_Profile_Interface_Enable_Controls()
            End If

            If customerregister.Visible = True Then
                Customer_Registration_Interface_Enable_Controls()
            End If

            If customerselection.Visible = True Then
                CSI_Enable_Controls()
            End If

        End If

    End Sub

    Private Sub Staff_Menu_Interface_Load_Customer_Selection_Interface_Panel(sender As Object, e As EventArgs) Handles btnSMITkOrd.Click
        For Each form In {customerprofile, customerregister}
            form.Visible = False
        Next

        trSMIVertS.HideSync(panSMIBack)
        panSMIOrdForm.BringToFront()
        customerselection.Visible = True
        trSMIVertS.ShowSync(panSMIOrdForm)
        customerselection.CSI_csOrdList_Refresh()
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_LOAD_CUSTOMER_PROFILE_INTERFACE
    '##################################################################################################################################################################################################

    Private Sub Staff_Menu_Interface_Load_Customer_Profile_Interface_Panel(sender As Object, e As EventArgs) Handles btnSMIPCust.Click
        For Each form In {customerselection, customerregister}
            form.Visible = False
        Next

        Staff_Menu_Interface_Resize_Form_Container_Type_A()
        customerprofile.Visible = True
    End Sub


    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_LOAD_CUSTOMER_REGISTRATION_INTERFACE
    '##################################################################################################################################################################################################

    Private Sub Staff_Menu_Interface_Load_Customer_Registration_Interface_Panel(sender As Object, e As EventArgs) Handles btnSMIRCust.Click
        Dim final As String = "C00000"
        Dim ld As New OleDb.OleDbCommandBuilder(smdaLoad)
        Staff_Menu_Interface_Refresh_customerDetails_Dataset()

        For i = 0 To smdsLoad.Tables("customerDetails").Rows.Count - 1
            Dim check As String = smdsLoad.Tables("customerDetails").Rows(i).Item(0).ToString
            Dim store As String = String.Format("C{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
            If check = store Then
                Customer_Registration_Interface_Customer_ID_Increment()
                store = String.Format("C{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "C99999" Then
                MsgBox("The system has reached its boundary of reserved records. Unless the system is updated to allow more than 10,000 records, the application will no longer accept registration.")
                customerregister.Visible = False
            End If
        Next
        customerregister.txtCRICID.Text = final
        customerregister.txtCRICDate.Text = Format(Now, "dd/MM/yyyy")
        customerregister.txtCRICTime.Text = Format(Now, "HH:mm:ss")
        Customer_Registration_Interface_Reset_Customer_ID_Increment()
        final = "C00000"

        For Each form In {customerselection, customerprofile}
            form.Visible = False
        Next

        Staff_Menu_Interface_Resize_Form_Container_Type_A()
        customerregister.Visible = True
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_DATABASE_CONNECTION
    '##################################################################################################################################################################################################

    Sub Staff_Menu_Interface_Database_Initial_Load()
        dbProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        dbSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        smCon.ConnectionString = dbProvider & dbSource
        Staff_Menu_Interface_Refresh_customerDetails_Dataset()
    End Sub

    Sub Staff_Menu_Interface_Refresh_customerDetails_Dataset()
        smCon.Open()
        smLoad = "SELECT cust_id FROM CUSTOMER_T ORDER BY cust_id"
        smdaLoad = New OleDb.OleDbDataAdapter(smLoad, smCon)
        smdaLoad.Fill(smdsLoad, "customerDetails")
        smCon.Close()
    End Sub

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_REPOSITORY
    '##################################################################################################################################################################################################



    Sub CSI_Enable_Controls()
        customerselection.btnCSICancel.Enabled = True
        customerselection.btnCSISearch.Enabled = True
        customerselection.txtCSISearch.Enabled = True
        customerselection.dbxCSICriteria.Enabled = True
    End Sub

    Sub CSI_Disable_Controls()
        customerselection.btnCSICancel.Enabled = False
        customerselection.btnCSISearch.Enabled = False
        customerselection.txtCSISearch.Enabled = False
        customerselection.dbxCSICriteria.Enabled = False
    End Sub


    Sub Staff_Menu_Interface_Primary_Header_Default()
        lblSMIHeader.Text = "Hello, What would you like to do today?"
        lblSMIHeader.Font = New Font("Century Gothic", 18)
        lblSMIHeader.Location = New Point((gpanSMIHeader.Width - lblSMIHeader.Width) / 2, 40)
        lblSMIHeader.Visible = True
        lblSMIHeader.BringToFront()
    End Sub

    Sub Staff_Menu_Interface_Primary_Header_Separator_Default()
        sprSMIHeader.Size = New Size(400, 35)
        sprSMIHeader.Location = New Point((gpanSMIHeader.Width - sprSMIHeader.Width) / 2, 70)
        sprSMIHeader.Visible = True
    End Sub

    Sub Staff_Menu_Interface_Load_Customer_Selection_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            customerselection.TopLevel = False
            customerselection.Size = New Size(808, 570)
            customerselection.Location = New Point(0, 0)
            customerselection.WindowState = FormWindowState.Normal
            customerselection.Visible = False
            panSMIOrdForm.Controls.Add(customerselection)

        Catch ex As Exception

            MsgBox("Random error during Customer Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Food_Selection_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try

            foodselection.TopLevel = False
            foodselection.Size = New Size(808, 570)
            foodselection.Location = New Point(0, 0)
            foodselection.WindowState = FormWindowState.Normal
            foodselection.Visible = True
            panSMIOrdForm.Controls.Add(foodselection)

        Catch ex As Exception

            MsgBox("Random error during Food Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Drink_Selection_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            drinkselection.TopLevel = False
            drinkselection.Size = New Size(808, 570)
            drinkselection.Location = New Point(0, 0)
            drinkselection.WindowState = FormWindowState.Normal
            drinkselection.Visible = True
            panSMIOrdForm.Controls.Add(drinkselection)

        Catch ex As Exception

            MsgBox("Random error during Drink Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Sides_Selection_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            sidesselection.TopLevel = False
            sidesselection.Size = New Size(808, 570)
            sidesselection.Location = New Point(0, 0)
            sidesselection.WindowState = FormWindowState.Normal
            sidesselection.Visible = True
            panSMIOrdForm.Controls.Add(sidesselection)

        Catch ex As Exception

            MsgBox("Random error during Drink Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Summary_Order_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            summaryorder.TopLevel = False
            summaryorder.Size = New Size(808, 570)
            summaryorder.Location = New Point(0, 0)
            summaryorder.WindowState = FormWindowState.Normal
            summaryorder.Visible = True
            panSMIOrdForm.Controls.Add(summaryorder)

        Catch ex As Exception

            MsgBox("Random error during Drink Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Payment_Order_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            paymentorder.TopLevel = False
            paymentorder.Size = New Size(808, 570)
            paymentorder.Location = New Point(0, 0)
            paymentorder.WindowState = FormWindowState.Normal
            paymentorder.Visible = True
            panSMIOrdForm.Controls.Add(paymentorder)

        Catch ex As Exception

            MsgBox("Random error during Drink Selection load has occured and catched as an exception.")

        End Try
    End Sub

    Sub Staff_Menu_Interface_Load_Receipt_Order_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try
            receiptorder.TopLevel = False
            receiptorder.Size = New Size(808, 570)
            receiptorder.Location = New Point(0, 0)
            receiptorder.WindowState = FormWindowState.Normal
            receiptorder.Visible = True
            panSMIOrdForm.Controls.Add(receiptorder)

        Catch ex As Exception

            MsgBox("Random error during Drink Selection load has occured and catched as an exception.")

        End Try
    End Sub

    '###############################################################
    '##########_STAFF_MENU_INTERFACE_LOAD_CUSTOMER_PROFILE_INTERFACE

    Sub Staff_Menu_Interface_Load_Customer_Profile_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try

            customerprofile.TopLevel = False
            customerprofile.Size = New Size(600, 360)
            customerprofile.panCPIBack.Size = New Size(578, 360)
            customerprofile.Location = New Point(0, 0)
            customerprofile.WindowState = FormWindowState.Normal
            customerprofile.Visible = False
            panSMIFrmCtr.Controls.Add(customerprofile)

        Catch ex As Exception

            MsgBox("Random error during Customer Profile load has occured and catched as an exception.")

        End Try
    End Sub

    '####################################################################
    '##########_STAFF_MENU_INTERFACE_LOAD_CUSTOMER_REGISTRATION_INTERFACE

    Sub Staff_Menu_Interface_Load_Customer_Registration_Interface() 'CodeProject, 2012. C# - Form inside a Panel. 
        Try

            customerregister.TopLevel = False
            customerregister.Size = New Size(600, 360)
            customerregister.panCRIBack.Size = New Size(578, 360)
            customerregister.Location = New Point(0, 0)
            customerregister.WindowState = FormWindowState.Normal
            customerregister.Visible = False
            panSMIFrmCtr.Controls.Add(customerregister)
        Catch ex As Exception
            MsgBox("Random error during Customer Registration load has occured and catched as an exception.")
        End Try
    End Sub

    Sub Customer_Registration_Interface_Customer_ID_Increment()
        one += 1
        If one = 10 Then
            ten += 1
            one = 0
        ElseIf ten = 10 Then
            hundred += 1
            ten = 0
        ElseIf hundred = 10 Then
            thousand += 1
            hundred = 0
        ElseIf thousand = 10 Then
            tthousand += 1
            thousand = 0
        ElseIf tthousand = 10 Then
            one = 0
            ten = 0
            hundred = 0
            thousand = 0
            tthousand = 0
        End If
    End Sub

    Sub Customer_Registration_Interface_Reset_Customer_ID_Increment()
        one = 0
        ten = 0
        hundred = 0
        thousand = 0
        tthousand = 0
    End Sub

    '##########################################################
    '##########_STAFF_MENU_INTERFACE_FORM_CONTAINER_RESIZE_TYPE

    Sub Staff_Menu_Interface_Resize_Form_Container_Type_A()
        panSMIFrmCtr.Size = New Size(600, 360)
        panSMIFrmCtr.Location = New Point(100, 180)
    End Sub

    Sub Staff_Menu_Interface_Resize_Form_Container_Type_B()
        panSMIFrmCtr.Size = New Size(780, 360)
        panSMIFrmCtr.Location = New Point(10, 180)
    End Sub

    '###############################################
    '##########_STAFF_MENU_INTERFACE_GIVE_FORM_FOCUS

    Sub Staff_Menu_Interface_Focus()        'Giving the form focus
        Me.Activate()                       'Activating the form to gain focus
    End Sub

    '###################################################
    '##########_STAFF_MENU_INTERFACE_HIDE_EXTENDED_PANES

    Sub Staff_Menu_Interface_Hide_Extended_Panes()                              'Hiding extended panes during certain events
        For Each panel In {panSMIOrd, panSMICust, panSMIMisc}        'Assigning affected panes into panel array
            trSMIVertS.HideSync(panel)                                          'Hiding every affected panes
        Next
    End Sub

    '#######################################################
    '##########_STAFF_MENU_INTERFACE_ENABLE/DISABLE_CONTROLS

    Sub Staff_Menu_Interface_Enable_Drag_Control()      'Enable form dragging mechanism during certain events
        dcSMI.TargetControl = gpanSMIBor                'Assigning targeted border for dragging control function
        dcSMI.Fixed = True
        dcSMI.Vertical = True                           'Enabling vertical movement of the form
        dcSMI.Horizontal = True                         'Enabling horizontal movement of the form
    End Sub

    Sub Staff_Menu_Interface_Disable_Drag_Control()     'Disable form dragging mechanism during certain events
        dcSMI.TargetControl = gpanSMIBor                'Assigning targeted border for dragging control function
        dcSMI.Fixed = True
        dcSMI.Vertical = False                          'Disabling vertical movement of the form
        dcSMI.Horizontal = False                        'Disabling horizontal movement of the form
    End Sub

    Sub Staff_Menu_Interface_Enable_Controls()      'Enable interactable controls during certain events
        btnSMIClose.Enabled = True                  'Enable Close application button
        btnSMIMin.Enabled = True                    'Enable Minimise application button
        btnSMIOrd.Enabled = True                    'Enable Order extensible pane button
        btnSMICust.Enabled = True                   'Enable Customer extensible pane button
        btnSMIMisc.Enabled = True                   'Enable Miscellaneous extensible pane button
    End Sub

    Sub Staff_Menu_Interface_Disable_Controls()     'Disable interactable controls during certain events
        btnSMIClose.Enabled = False                 'Disabling Close application button
        btnSMIMin.Enabled = False                   'Disabling Minimise application button
        btnSMIOrd.Enabled = False                   'Disabling Order extensible pane button
        btnSMICust.Enabled = False                  'Disabling Customer extensible pane button
        btnSMIMisc.Enabled = False                  'Disabling Miscellaneous extensible pane button
    End Sub

    Sub Customer_Registration_Interface_Enable_Controls()      'Enable interactable controls during certain events
        customerregister.btniCRISideS.Enabled = True                'Disable Side extensible pane button
        customerregister.txtCRIFName.Enabled = True                 'Disable First name textbox
        customerregister.txtCRILName.Enabled = True                 'Disable Last name textbox
        customerregister.dtpCRIDOB.Enabled = True                   'Disable DOB date time picker
        customerregister.dbxCRIGender.Enabled = True                'Disable Gender dropdown box
        customerregister.txtCRIEmail.Enabled = True                 'Disable Email address textbox
        customerregister.txtCRIPhone.Enabled = True                 'Disable Phone number textbox
        customerregister.txtCRIStreet.Enabled = True                'Disable Street address textbox
        customerregister.txtCRICity.Enabled = True                  'Disable City address textbox
        customerregister.txtCRIState.Enabled = True                 'Disable State address textbox
        customerregister.txtCRIPostcode.Enabled = True              'Disable Postcode address textbox
        customerregister.dbxCRICountry.Enabled = True               'Disable Country dropdown box
    End Sub

    Sub Customer_Registration_Interface_Disable_Controls()
        customerregister.trCRIHorizS.HideSync(customerregister.panCRISide)
        customerregister.trCRIHorizS.ShowSync(customerregister.panCRISideSm)
        customerregister.btniCRISideS.Enabled = False                'Disable Side extensible pane button
        customerregister.txtCRIFName.Enabled = False                 'Disable First name textbox
        customerregister.txtCRILName.Enabled = False                 'Disable Last name textbox
        customerregister.dtpCRIDOB.Enabled = False                   'Disable DOB date time picker
        customerregister.dbxCRIGender.Enabled = False                'Disable Gender dropdown box
        customerregister.txtCRIEmail.Enabled = False                 'Disable Email address textbox
        customerregister.txtCRIPhone.Enabled = False                 'Disable Phone number textbox
        customerregister.txtCRIStreet.Enabled = False                'Disable Street address textbox
        customerregister.txtCRICity.Enabled = False                  'Disable City address textbox
        customerregister.txtCRIState.Enabled = False                 'Disable State address textbox
        customerregister.txtCRIPostcode.Enabled = False              'Disable Postcode address textbox
        customerregister.dbxCRICountry.Enabled = False               'Disable Country dropdown box
    End Sub

    Sub Customer_Profile_Interface_Enable_Controls()      'Enable interactable controls during certain events
        customerprofile.btniCPISideS.Enabled = True                'Disable Side extensible pane button
        customerprofile.btniCPIDBSearchS.Enabled = True            'Disable Search extensible pane button
        customerprofile.txtCPIFName.Enabled = True                 'Disable First name textbox
        customerprofile.txtCPILName.Enabled = True                 'Disable Last name textbox
        customerprofile.dtpCPIDOB.Enabled = True                   'Disable DOB date time picker
        customerprofile.dbxCPIGender.Enabled = True                'Disable Gender dropdown box
        customerprofile.txtCPIEmail.Enabled = True                 'Disable Email address textbox
        customerprofile.txtCPIPhone.Enabled = True                 'Disable Phone number textbox
        customerprofile.txtCPIStreet.Enabled = True                'Disable Street address textbox
        customerprofile.txtCPICity.Enabled = True                  'Disable City address textbox
        customerprofile.txtCPIState.Enabled = True                 'Disable State address textbox
        customerprofile.txtCPIPostcode.Enabled = True              'Disable Postcode address textbox
        customerprofile.dbxCPICountry.Enabled = True               'Disable Country dropdown box
    End Sub

    Sub Customer_Profile_Interface_Disable_Controls()

        If customerprofile.panCPIDBSearchSm.Visible = True Or customerprofile.panCPIDBSearch.Visible = True Then
            customerprofile.trCPIHorizS.HideSync(customerprofile.panCPIDBSearch)
            customerprofile.trCPIHorizS.ShowSync(customerprofile.panCPIDBSearchSm)
        End If
        customerprofile.trCPIHorizS.HideSync(customerprofile.panCPISide)
        customerprofile.trCPIHorizS.ShowSync(customerprofile.panCPISideSm)
        customerprofile.btniCPISideS.Enabled = False                'Disable Side extensible pane button
        customerprofile.btniCPIDBSearchS.Enabled = False            'Disable Search extensible pane button
        customerprofile.txtCPIFName.Enabled = False                 'Disable First name textbox
        customerprofile.txtCPILName.Enabled = False                 'Disable Last name textbox
        customerprofile.dtpCPIDOB.Enabled = False                   'Disable DOB date time picker
        customerprofile.dbxCPIGender.Enabled = False                'Disable Gender dropdown box
        customerprofile.txtCPIEmail.Enabled = False                 'Disable Email address textbox
        customerprofile.txtCPIPhone.Enabled = False                 'Disable Phone number textbox
        customerprofile.txtCPIStreet.Enabled = False                'Disable Street address textbox
        customerprofile.txtCPICity.Enabled = False                  'Disable City address textbox
        customerprofile.txtCPIState.Enabled = False                 'Disable State address textbox
        customerprofile.txtCPIPostcode.Enabled = False              'Disable Postcode address textbox
        customerprofile.dbxCPICountry.Enabled = False               'Disable Country dropdown box
    End Sub

    '##########################################
    '##########_STAFF_MENU_INTERFACE_UNUSED_SUB

    'Private Sub Staff_Login_Interface_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Staff_Menu_Interface_Focus()
    '    Staff_Menu_Interface_Disable_Controls()
    '    Staff_Menu_Interface_Elipse_Set()
    '    Staff_Menu_Interface_Add_Controls()
    '    Staff_Menu_Interface_Logon_Load_Sequence()
    '    Staff_Menu_Interface_Logon_Load_Sequence_Text()
    '    Staff_Menu_Interface_Intro_Transition_Set()
    '    Staff_Menu_Interface_Startup_Timer_Start()
    '    Staff_Menu_Interface_Initialise_Clock()


    '    'Staff_Menu_Interface_Elipse_Set()
    '    'Staff_Menu_Interface_Add_Controls()


    '    'Staff_Menu_Interface_Primary_Header_Default()
    '    'Staff_Menu_Interface_Primary_Header_Separator_Default()

    '    'Staff_Menu_Interface_Load_Customer_Profile_Interface()
    '    'Staff_Menu_Interface_Load_Customer_Registration_Interface()
    '    'Staff_Menu_Interface_Load_Staff_Profile_Interface()
    '    'Staff_Menu_Interface_Load_Staff_Note_Interface()
    'End Sub

    'Sub Staff_Menu_Interface_Add_Intro_Panel()
    '    panSMIIntro.BackColor = Color.LightGray
    '    panSMIIntro.Size = New Size(800, 570)
    '    panSMIIntro.Location = New Point(0, 30)
    '    panSMIIntro.Visible = True
    '    panSMIIntro.Enabled = True
    '    Me.Controls.Add(panSMIIntro)
    '    panSMIIntro.BringToFront()
    'End Sub

    'Private Sub Staff_Menu_Interface_Order_Button_Text(sender As Object, e As PaintEventArgs) Handles btnSMIOrd.Paint
    '    Dim text As Font = New Font("Century Gothic", 12)
    '    Dim brush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
    '    e.Graphics.TranslateTransform(14, 78)
    '    e.Graphics.RotateTransform(270)
    '    e.Graphics.DrawString("Order", text, brush, 0, 0)
    'End Sub

    'Private Sub Staff_Menu_Interface_Customer_Button_Text(sender As Object, e As PaintEventArgs) Handles btnSMICust.Paint
    '    Dim text As Font = New Font("Century Gothic", 12)
    '    Dim brush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
    '    e.Graphics.TranslateTransform(14, 90)
    '    e.Graphics.RotateTransform(270)
    '    e.Graphics.DrawString("Customer", text, brush, 0, 0)
    'End Sub

    'Private Sub Staff_Menu_Interface_Staff_Button_Text(sender As Object, e As PaintEventArgs) Handles btnSMISta.Paint
    '    Dim text As Font = New Font("Century Gothic", 12)
    '    Dim brush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
    '    e.Graphics.TranslateTransform(14, 70)
    '    e.Graphics.RotateTransform(270)
    '    e.Graphics.DrawString("Staff", text, brush, 0, 0)
    'End Sub

    'Private Sub Staff_Menu_Interface_Miscellaneous_Button_Text(sender As Object, e As PaintEventArgs) Handles btnSMIMisc.Paint
    '    Dim text As Font = New Font("Century Gothic", 12)
    '    Dim brush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
    '    e.Graphics.TranslateTransform(14, 70)
    '    e.Graphics.RotateTransform(270)
    '    e.Graphics.DrawString("Misc.", text, brush, 0, 0)
    'End Sub

    'Private Sub Staff_Menu_Interface_Close_Buttons_Text(sender As Object, e As PaintEventArgs) Handles btnSMIOrdC.Paint, btnSMICustC.Paint, btnSMIStaC.Paint, btnSMIMiscC.Paint
    '    Dim text As Font = New Font("Century Gothic", 12)
    '    Dim brush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.White)
    '    e.Graphics.TranslateTransform(14, 76)
    '    e.Graphics.RotateTransform(270)
    '    e.Graphics.DrawString("Close", text, brush, 0, 0)
    'End Sub

    Sub Staff_Menu_Interface_Controls_Load()

    End Sub


    '#####################################
    '##########_STAFF_MENU_INTERFACE_NOTES

    'Continue editing the intro animation for the form. 
    'make it so that it will show the header since the beginning and only load the label and separator afterwards

    'Continue finishing Staff Menu Interface with all forms ready

    'Continue customer profile customisation
    'Reset form every time menu button is pressed

    'Continue with Note, Punch-in and Log Out functions. Ignore Order functions first. Once all three are done, jump to admin menu

    '#######################################

    '##################################################################################################################################################################################################
    '##########_STAFF_MENU_INTERFACE_END
    '##################################################################################################################################################################################################

End Class