Imports System.Data.OleDb
Imports System.Text.RegularExpressions



'NOTE: AFTER WAKING UP, MAKE SURE TO ADD POPUP MESSAGEBOX FOR EVERY ERRATIC EVENT
' MAINLY MESSAGEBOXES DURING ORDERING PROCESS
'FOR CUST PROFILE, BE SURE TO RESET THE FORM EVERY TIME ANOTHER FORM OPENING BUTTON IS PRESSED
' FOR EXAMPLE, RESET PROFILE WHEN REGISTRATION IS PRESSED. VICE VERSA
' TROUBLESHOOT ERRORS AND DOCUMENT IT AS TESTING
' ONCE THE MESSAGEBOXES ARE DONE, YOUR APP IS COMPLETE.
' BE SURE TO INSPECT YOUR SIGN OUT MECHANISM




Public Class customerprofile
    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE START
    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE LOCAL VARIABLE
    '##################################################################################################################################################################################################

    Public searchInput As String

    'For database connection use
    Dim cpCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim cpProvider, cpSource, cpCustSql, cpStaffSql, cpGenderSql, cpCountrySql As String     'Declaring database retrieval keywords
    Dim cpCustDs As DataSet = New DataSet("cpCustList")                       'Create a new data container for fetched data
    Dim cpStaffDs As DataSet = New DataSet("cpStaffList")                     'Create a new data container for fetched data
    Dim cpGenderDs As DataSet = New DataSet("cpGenderList")                         'Create a new data container for fetched data
    Dim cpCountryDs As DataSet = New DataSet("cpCountryList")                         'Create a new data container for fetched data
    Dim cpCustDa, cpStaffDa, cpGenderDa, cpCountryDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE STARTUP SEQUENCE
    '##################################################################################################################################################################################################

    Private Sub CPI_Startup_Sequence() Handles MyBase.Load
        CPI_Elipse_Set()
        CPI_Database_Initial_Load()
        CPI_cpCustList_Load()
        CPI_cpStaffList_Load()
        CPI_cpGenderList_Load()
        CPI_cpCountryList_Load()
        CPI_Controls_Load()
        CPI_Populate_Criteria_DropDownBox()
        CPI_Resize_Country_DropDownBox_Size()
    End Sub

    Sub CPI_Elipse_Set()
        Dim elCPI As New Bunifu.Framework.UI.BunifuElipse
        elCPI.ApplyElipse(panCPISideSm, 10)
        elCPI.ApplyElipse(panCPISide, 10)
        elCPI.ApplyElipse(panCPIDBSearchSm, 10)
        elCPI.ApplyElipse(panCPIDBSearch, 10)
    End Sub

    Sub CPI_Populate_Criteria_DropDownBox()
        dbxCPICriteria.Items.Add("Customer ID")
        dbxCPICriteria.Items.Add("Name")
        dbxCPICriteria.Items.Add("Email Address")
        dbxCPICriteria.Items.Add("Phone Number")
    End Sub

    Sub CPI_Resize_Country_DropDownBox_Size()
        dbxCPICountry.DropDownHeight = 200
        dbxCPICountry.DropDownWidth = 284
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE DATABASE REPOSITORY
    '##################################################################################################################################################################################################

    Sub CPI_Database_Initial_Load()
        cpProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        cpSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        cpCon.ConnectionString = cpProvider & cpSource
    End Sub

    Sub CPI_cpCustList_Load()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)

        cpCon.Open()
        cpCustSql = "SELECT * FROM CUSTOMER_T"
        cpCustDa = New OleDb.OleDbDataAdapter(cpCustSql, cpCon)
        cpCustDa.Fill(cpCustDs, "cpCustList")
        cpCon.Close()
    End Sub

    Sub CPI_cpStaffList_Load()
        Dim cbStaff As New OleDb.OleDbCommandBuilder(cpStaffDa)

        cpCon.Open()
        cpStaffSql = "SELECT sta_first_name, sta_last_name FROM STAFF_T"
        cpStaffDa = New OleDb.OleDbDataAdapter(cpStaffSql, cpCon)
        cpStaffDa.Fill(cpStaffDs, "cpStaffList")
        cpCon.Close()
    End Sub

    Sub CPI_cpGenderList_Load()
        Dim cbGdr As New OleDb.OleDbCommandBuilder(cpGenderDa)

        cpCon.Open()
        cpGenderSql = "SELECT * FROM GENDER_T"
        cpGenderDa = New OleDb.OleDbDataAdapter(cpGenderSql, cpCon)
        cpGenderDa.Fill(cpGenderDs, "cpGenderListing")
        cpCon.Close()

        For i = 0 To cpGenderDs.Tables("cpGenderListing").Rows.Count - 1
            dbxCPIGender.Items.Add(cpGenderDs.Tables("cpGenderListing").Rows(i).Item(0).ToString)
        Next
    End Sub

    Sub CPI_cpCountryList_Load()
        Dim cbCty As New OleDb.OleDbCommandBuilder(cpCountryDa)

        cpCon.Open()
        cpCountrySql = "SELECT * FROM COUNTRY_T"
        cpCountryDa = New OleDb.OleDbDataAdapter(cpCountrySql, cpCon)
        cpCountryDa.Fill(cpCountryDs, "cpCountryList")
        cpCon.Close()

        For i = 0 To cpCountryDs.Tables("cpCountryList").Rows.Count - 1
            dbxCPICountry.Items.Add(cpCountryDs.Tables("cpCountryList").Rows(i).Item(0).ToString)
        Next
    End Sub

    Sub CPI_cpCustList_Fetch_ID()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)
        cpCustDs.Tables("cpCustList").Clear()

        cpCon.Open()
        cpCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_id = '" & searchInput & "' "
        cpCustDa = New OleDb.OleDbDataAdapter(cpCustSql, cpCon)
        cpCustDa.Fill(cpCustDs, "cpCustList")
        cpCon.Close()
    End Sub

    Sub CPI_cpCustList_Fetch_Name()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)
        cpCustDs.Tables("cpCustList").Clear()

        cpCon.Open()
        cpCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_first_name & "" "" & cust_last_name = '" & searchInput & "' "
        cpCustDa = New OleDb.OleDbDataAdapter(cpCustSql, cpCon)
        cpCustDa.Fill(cpCustDs, "cpCustList")
        cpCon.Close()
    End Sub

    Sub CPI_cpCustList_Fetch_Email()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)
        cpCustDs.Tables("cpCustList").Clear()

        cpCon.Open()
        cpCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_email = '" & searchInput & "' "
        cpCustDa = New OleDb.OleDbDataAdapter(cpCustSql, cpCon)
        cpCustDa.Fill(cpCustDs, "cpCustList")
        cpCon.Close()
    End Sub

    Sub CPI_cpCustListe_Fetch_Phone()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)
        cpCustDs.Tables("cpCustList").Clear()

        cpCon.Open()
        cpCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_phone = '" & searchInput & "' "
        cpCustDa = New OleDb.OleDbDataAdapter(cpCustSql, cpCon)
        cpCustDa.Fill(cpCustDs, "cpCustList")
        cpCon.Close()
    End Sub

    Sub CPI_cpStaffList_Fetch()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)
        cpStaffDs.Tables("cpStaffList").Clear()

        cpCon.Open()
        cpStaffSql = "SELECT sta_first_name, sta_last_name FROM STAFF_T WHERE sta_id = '" & Trim(txtCPICRegSID.Text) & "' "
        cpStaffDa = New OleDb.OleDbDataAdapter(cpStaffSql, cpCon)
        cpStaffDa.Fill(cpStaffDs, "cpStaffList")
        cpCon.Close()
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE SIDE CONTROL PANEL
    '##################################################################################################################################################################################################

    Private Sub CPI_Show_Side_Panel(sender As Object, e As EventArgs) Handles btniCPISideS.Click
        CPI_Show_Side_Panel_Controller()
    End Sub

    Private Sub CPI_Hide_Side_Panel(sender As Object, e As EventArgs) Handles btniCPISideH.Click
        CPI_Hide_Side_Panel_Controller()
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE SIDE SEARCH PANEL
    '##################################################################################################################################################################################################

    Private Sub CPI_Show_Search_Panel(sender As Object, e As EventArgs) Handles btniCPIDBSearchS.Click
        CPI_Show_Search_Panel_Controller()
    End Sub

    Private Sub CPI_Hide_Search_Panel(sender As Object, e As EventArgs) Handles btniCPIDBSearchH.Click
        CPI_Hide_Search_Panel_Controller()
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE INPUT FIELD EVENT HANDLER
    '##################################################################################################################################################################################################

    Private Sub CPI_First_Name_Only_Alphabets(sender As Object, e As KeyPressEventArgs) Handles txtCPIFName.KeyPress 'Stack Overflow, 2012. Get a textbox to accept only characters in vb.net. 
        Dim lowCase As Boolean = e.KeyChar >= "a"c And e.KeyChar <= "z"c
        Dim upCase As Boolean = e.KeyChar >= "A"c And e.KeyChar <= "Z"c
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)
        Dim enter As Boolean = e.KeyChar = ChrW(Keys.Enter)
        Dim bksp As Boolean = e.KeyChar = ChrW(Keys.Back)

        If lowCase = False And upCase = False And space = False And enter = False And bksp = False Then
            SendKeys.Send(vbBack) 'Microsoft, n.d. Sendkeys.Send(String) Method. 
            lblCPIFNameWarn.Visible = True
            lblCPIFNameWarn.Text = "Only alphabets are allowed!"
        ElseIf lowCase = True Or upCase = True Then
            lblCPIFNameWarn.Visible = False
            lblCPIFNameWarn.Text = "null"
        End If

        If txtCPIFName.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack) 'Microsoft, n.d. Sendkeys.Send(String) Method. 
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPIFName.Text = vbNullString Then
                txtCPIFName.Focus()
                lblCPIFNameWarn.Visible = True
                lblCPIFNameWarn.Text = "This section cannot be empty!"
            ElseIf lblCPIFNameWarn.Text = "This section cannot be empty!" Then
                txtCPIFName.Focus()
            Else
                lblCPIFNameWarn.Visible = False
                lblCPIFNameWarn.Text = "null"
                txtCPILName.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_First_Name_Character_Range(sender As Object, e As EventArgs) Handles txtCPIFName.TextChanged, txtCPIFName.MouseEnter
        If txtCPIFName.Text = vbNullString Then
            txtCPIFName.Focus()
            lblCPIFNameWarn.Visible = True
            lblCPIFNameWarn.Text = "This section cannot be empty!"
        ElseIf lblCPIFNameWarn.Text = "* First name is required!" Then
            lblCPIFNameWarn.Visible = False
            lblCPIFNameWarn.Text = "null"
        ElseIf txtCPIFName.Text.Length = 41 Then
            SendKeys.Send(vbBack)
            txtCPIFName.Focus()
            lblCPIFNameWarn.Visible = True
            lblCPIFNameWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPIFName.Text.Length > 41 Then
            txtCPIFName.Focus()
            lblCPIFNameWarn.Visible = True
            lblCPIFNameWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_First_Name_Hide_Warning(sender As Object, e As EventArgs) Handles txtCPIFName.MouseLeave
        If lblCPIFNameWarn.Text = "Only alphabets are allowed!" Then
            lblCPIFNameWarn.Visible = False
            lblCPIFNameWarn.Text = "null"
        End If
    End Sub

    Private Sub CPI_Last_Name_Only_Alphabets(sender As Object, e As KeyPressEventArgs) Handles txtCPILName.KeyPress 'Stack Overflow, 2012. Get a textbox to accept only characters in vb.net.
        Dim lowCase As Boolean = e.KeyChar >= "a"c And e.KeyChar <= "z"c
        Dim upCase As Boolean = e.KeyChar >= "A"c And e.KeyChar <= "Z"c
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)
        Dim enter As Boolean = e.KeyChar = ChrW(Keys.Enter)
        Dim bksp As Boolean = e.KeyChar = ChrW(Keys.Back)

        If lowCase = False And upCase = False And space = False And enter = False And bksp = False Then
            lblCPILNameWarn.Visible = True
            lblCPILNameWarn.Text = "Only alphabets are allowed!"
            SendKeys.Send(vbBack) 'Microsoft, n.d. Sendkeys.Send(String) Method. 
        ElseIf lowCase = True Or upCase = True Then
            lblCPILNameWarn.Visible = False
            lblCPILNameWarn.Text = "null"
        End If

        If txtCPILName.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack) 'Microsoft, n.d. Sendkeys.Send(String) Method. 
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPILName.Text = vbNullString Then
                txtCPILName.Focus()
                lblCPILNameWarn.Visible = True
                lblCPILNameWarn.Text = "This section cannot be empty!"
            ElseIf lblCPILNameWarn.Text = "This section cannot be empty!" Then
                txtCPILName.Focus()
            Else
                lblCPILNameWarn.Visible = False
                lblCPILNameWarn.Text = "null"
                dtpCPIDOB.Select()
            End If
        End If
    End Sub

    Private Sub CPI_Last_Name_Character_Range(sender As Object, e As EventArgs) Handles txtCPILName.TextChanged, txtCPILName.MouseEnter
        If txtCPILName.Text = vbNullString Then
            txtCPILName.Focus()
            lblCPILNameWarn.Visible = True
            lblCPILNameWarn.Text = "This section cannot be empty!"
        ElseIf lblCPILNameWarn.Text = "* Last name is required!" Then
            lblCPILNameWarn.Visible = False
            lblCPILNameWarn.Text = "null"
        ElseIf txtCPILName.Text.Length = 41 Then
            SendKeys.Send(vbBack)
            txtCPILName.Focus()
            lblCPILNameWarn.Visible = True
            lblCPILNameWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPILName.Text.Length > 41 Then
            txtCPILName.Focus()
            lblCPILNameWarn.Visible = True
            lblCPILNameWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_Last_Name_Hide_Warning(sender As Object, e As EventArgs) Handles txtCPILName.MouseLeave
        If lblCPILNameWarn.Text = "Only alphabets are allowed!" Then
            lblCPILNameWarn.Visible = False
            lblCPILNameWarn.Text = "null"
        End If
    End Sub

    Private Sub CPI_DOB_Has_Focus(sender As Object, e As EventArgs) Handles dtpCPIDOB.Click, dtpCPIDOB.GotFocus, dtpCPIDOB.MouseEnter
        lblCPIDOBWarn.Text = "Default value will be used if no user selection!"
        lblCPIDOBWarn.Visible = True
    End Sub

    Private Sub CPI_DOB_is_Closed(sender As Object, e As EventArgs) Handles dtpCPIDOB.CloseUp
        lblCPIDOBWarn.Visible = False
        lblCPIDOBWarn.Text = "null"
        dbxCPIGender.Select()
    End Sub

    Private Sub CPI_DOB_Lost_Focus(sender As Object, e As EventArgs) Handles dtpCPIDOB.MouseLeave
        lblCPIDOBWarn.Visible = False
        lblCPIDOBWarn.Text = "null"
    End Sub

    Private Sub CPI_Gender_Has_Focus(sender As Object, e As EventArgs) Handles dbxCPIGender.Click, dbxCPIGender.GotFocus, dbxCPIGender.MouseEnter
        lblCPIGenderWarn.Text = "Default value ""Unspecified"" will be used if no selection!"
        lblCPIGenderWarn.Visible = True
    End Sub

    Private Sub CPI_Gender_is_Closed(sender As Object, e As EventArgs) Handles dbxCPIGender.DropDownClosed
        lblCPIGenderWarn.Visible = False
        lblCPIGenderWarn.Text = "null"
        txtCPIEmail.Focus()
    End Sub

    Private Sub CPI_Gender_Lost_Focus(sender As Object, e As EventArgs) Handles dbxCPIGender.MouseLeave
        lblCPIGenderWarn.Visible = False
        lblCPIGenderWarn.Text = "null"
    End Sub

    Private Sub CPI_Email_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPIEmail.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPIEmail.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If


        If space = True Then
            SendKeys.Send(vbBack)

        End If


        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPILName.Text = vbNullString Then
                txtCPIEmail.Focus()
                lblCPIEmailWarn.Visible = True
                lblCPIEmailWarn.Text = "This section cannot be empty!"
            ElseIf lblCPIEmailWarn.Text = "This section cannot be empty!" Then
                txtCPIEmail.Focus()
            Else
                lblCPIEmailWarn.Visible = False
                lblCPIEmailWarn.Text = "null"
                txtCPIPhone.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_Email_Formatting(sender As Object, e As EventArgs) Handles txtCPIEmail.TextChanged, txtCPIEmail.MouseEnter
        Dim pattern As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Dim compare As Match = pattern.Match(txtCPIEmail.Text)

        If txtCPIEmail.Text = vbNullString Then
            txtCPIEmail.Focus()
            lblCPIEmailWarn.Visible = True
            lblCPIEmailWarn.Text = "This section cannot be empty!"
        End If



        If Not (compare.Success) Then
            If txtCPIEmail.Text.Length < 50 Then
                lblCPIEmailWarn.Text = "Not a valid email address!"
                lblCPIEmailWarn.Visible = True
            ElseIf txtCPIEmail.Text.Length = 51 Then
                SendKeys.Send(vbBack)
                txtCPIEmail.Focus()
                lblCPIEmailWarn.Visible = True
                lblCPIEmailWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCPIEmail.Text.Length > 51 Then
                txtCPIEmail.Focus()
                lblCPIEmailWarn.Visible = True
                lblCPIEmailWarn.Text = "Beyond maximum amount of characters!"
            End If
        ElseIf (compare.Success) Then
            If txtCPIEmail.Text.Length < 50 Then
                lblCPIEmailWarn.Visible = False
                lblCPIEmailWarn.Text = "null"
            ElseIf txtCPIEmail.Text.Length = 51 Then
                SendKeys.Send(vbBack)
                txtCPIEmail.Focus()
                lblCPIEmailWarn.Visible = True
                lblCPIEmailWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCPIEmail.Text.Length > 51 Then
                txtCPIEmail.Focus()
                lblCPIEmailWarn.Visible = True
                lblCPIEmailWarn.Text = "Beyond maximum amount of characters!"
            End If
        End If
    End Sub

    Private Sub CPI_Phone_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPIPhone.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPIPhone.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPIPhone.Text = vbNullString Then
                txtCPIPhone.Focus()
                lblCPIPhoneWarn.Visible = True
                lblCPIPhoneWarn.Text = "This section cannot be empty!"
            ElseIf lblCPIPhoneWarn.Text = "This section cannot be empty!" Then
                txtCPIPhone.Focus()
            Else
                lblCPIPhoneWarn.Visible = False
                lblCPIPhoneWarn.Text = "null"
                txtCPIStreet.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_Phone_Formatting(sender As Object, e As EventArgs) Handles txtCPIPhone.TextChanged, txtCPIPhone.MouseEnter
        Dim pattern As Regex = New Regex("\(?\+[0-9]{1,3}\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})? ?(\w{1,10}\s?\d{1,6})?")
        Dim compare As Match = pattern.Match(txtCPIPhone.Text)

        If txtCPIPhone.Text = vbNullString Then
            txtCPIPhone.Focus()
            lblCPIPhoneWarn.Visible = True
            lblCPIPhoneWarn.Text = "This section cannot be empty!"
        End If

        If Not (compare.Success) Then
            If txtCPIPhone.Text.Length < 25 Then
                lblCPIPhoneWarn.Text = "Not a valid phone number!"
                lblCPIPhoneWarn.Visible = True
            ElseIf txtCPIPhone.Text.Length = 26 Then
                SendKeys.Send(vbBack)
                txtCPIPhone.Focus()
                lblCPIPhoneWarn.Visible = True
                lblCPIPhoneWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCPIPhone.Text.Length > 26 Then
                txtCPIPhone.Focus()
                lblCPIPhoneWarn.Visible = True
                lblCPIPhoneWarn.Text = "Beyond maximum amount of characters!"
            End If
        ElseIf (compare.Success) Then
            If txtCPIPhone.Text.Length < 25 Then
                lblCPIPhoneWarn.Visible = False
                lblCPIPhoneWarn.Text = "null"
            ElseIf txtCPIPhone.Text.Length = 26 Then
                SendKeys.Send(vbBack)
                txtCPIPhone.Focus()
                lblCPIPhoneWarn.Visible = True
                lblCPIPhoneWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCPIPhone.Text.Length > 26 Then
                txtCPIPhone.Focus()
                lblCPIPhoneWarn.Visible = True
                lblCPIPhoneWarn.Text = "Beyond maximum amount of characters!"
            End If
        End If
    End Sub

    Private Sub CPI_Street_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPIStreet.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPIStreet.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPIStreet.Text = vbNullString Then
                txtCPIStreet.Focus()
                lblCPIStreetWarn.Visible = True
                lblCPIStreetWarn.Text = "This section cannot be empty!"
            ElseIf txtCPIStreet.Text = "This section cannot be empty!" Then
                txtCPIStreet.Focus()
            Else
                lblCPIStreetWarn.Visible = False
                lblCPIStreetWarn.Text = "null"
                txtCPICity.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_Street_Formatting(sender As Object, e As EventArgs) Handles txtCPIStreet.TextChanged, txtCPIStreet.MouseEnter
        If txtCPIStreet.Text = vbNullString Then
            txtCPIStreet.Focus()
            lblCPIStreetWarn.Visible = True
            lblCPIStreetWarn.Text = "This section cannot be empty!"
        ElseIf txtCPIStreet.Text.Length > 0 And txtCPIStreet.Text.Length < 50 Then
            lblCPIStreetWarn.Visible = False
            lblCPIStreetWarn.Text = "null"
        ElseIf txtCPIStreet.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCPIStreet.Focus()
            lblCPIStreetWarn.Visible = True
            lblCPIStreetWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPIStreet.Text.Length > 51 Then
            txtCPIStreet.Focus()
            lblCPIStreetWarn.Visible = True
            lblCPIStreetWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_City_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPICity.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPICity.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPICity.Text = vbNullString Then
                txtCPICity.Focus()
                lblCPICityWarn.Visible = True
                lblCPICityWarn.Text = "This section cannot be empty!"
            ElseIf txtCPICity.Text = "This section cannot be empty!" Then
                txtCPICity.Focus()
            Else
                lblCPICityWarn.Visible = False
                lblCPICityWarn.Text = "null"
                txtCPIState.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_City_Formatting(sender As Object, e As EventArgs) Handles txtCPICity.TextChanged, txtCPICity.MouseEnter
        If txtCPICity.Text = vbNullString Then
            txtCPICity.Focus()
            lblCPICityWarn.Visible = True
            lblCPICityWarn.Text = "This section cannot be empty!"
        ElseIf txtCPICity.Text.Length > 0 And txtCPICity.Text.Length < 50 Then
            lblCPICityWarn.Visible = False
            lblCPICityWarn.Text = "null"
        ElseIf txtCPICity.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCPICity.Focus()
            lblCPICityWarn.Visible = True
            lblCPICityWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPICity.Text.Length > 51 Then
            txtCPICity.Focus()
            lblCPICityWarn.Visible = True
            lblCPICityWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_State_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPIState.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPIState.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPIState.Text = vbNullString Then
                txtCPIState.Focus()
                lblCPIStateWarn.Visible = True
                lblCPIStateWarn.Text = "This section cannot be empty!"
            ElseIf txtCPIState.Text = "This section cannot be empty!" Then
                txtCPIState.Focus()
            Else
                lblCPIStateWarn.Visible = False
                lblCPIStateWarn.Text = "null"
                txtCPIPostcode.Focus()
            End If
        End If
    End Sub

    Private Sub CPI_State_Formatting(sender As Object, e As EventArgs) Handles txtCPIState.TextChanged, txtCPIState.MouseEnter
        If txtCPIState.Text = vbNullString Then
            txtCPIState.Focus()
            lblCPIStateWarn.Visible = True
            lblCPIStateWarn.Text = "This section cannot be empty!"
        ElseIf txtCPIState.Text.Length > 0 And txtCPIState.Text.Length < 50 Then
            lblCPIStateWarn.Visible = False
            lblCPIStateWarn.Text = "null"
        ElseIf txtCPIState.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCPIState.Focus()
            lblCPIStateWarn.Visible = True
            lblCPIStateWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPIState.Text.Length > 51 Then
            txtCPIState.Focus()
            lblCPIStateWarn.Visible = True
            lblCPIStateWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_Postcode_Not_Empty(sender As Object, e As KeyPressEventArgs) Handles txtCPIPostcode.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCPIPostcode.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCPIPostcode.Text = vbNullString Then
                txtCPIPostcode.Focus()
                lblCPIPostcodeWarn.Visible = True
                lblCPIPostcodeWarn.Text = "This section cannot be empty!"
            ElseIf txtCPIPostcode.Text = "This section cannot be empty!" Then
                txtCPIPostcode.Focus()
            Else
                lblCPIPostcodeWarn.Visible = False
                lblCPIPostcodeWarn.Text = "null"
                dbxCPICountry.Select()
                dbxCPICountry.DroppedDown = True
            End If
        End If
    End Sub

    Private Sub CPI_Postcode_Formatting(sender As Object, e As EventArgs) Handles txtCPIPostcode.TextChanged, txtCPIPostcode.MouseEnter
        If txtCPIPostcode.Text = vbNullString Then
            txtCPIPostcode.Focus()
            lblCPIPostcodeWarn.Visible = True
            lblCPIPostcodeWarn.Text = "This section cannot be empty!"
        ElseIf txtCPIPostcode.Text.Length < 3 Then
            txtCPIPostcode.Focus()
            lblCPIPostcodeWarn.Visible = True
            lblCPIPostcodeWarn.Text = "Below minimum amount of characters!"
        ElseIf txtCPIPostcode.Text.Length >= 4 And txtCPIPostcode.Text.Length < 12 Then
            lblCPIPostcodeWarn.Visible = False
            lblCPIPostcodeWarn.Text = "null"
        ElseIf txtCPIPostcode.Text.Length = 13 Then
            SendKeys.Send(vbBack)
            txtCPIPostcode.Focus()
            lblCPIPostcodeWarn.Visible = True
            lblCPIPostcodeWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCPIPostcode.Text.Length > 13 Then
            txtCPIPostcode.Focus()
            lblCPIPostcodeWarn.Visible = True
            lblCPIPostcodeWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub CPI_Country_Has_Focus(sender As Object, e As EventArgs) Handles dbxCPICountry.Click, dbxCPICountry.GotFocus,
        dbxCPICountry.MouseEnter
        lblCPICountryWarn.Text = "Default value ""Malaysia"" will be used if no selection!"
        lblCPICountryWarn.Visible = True
    End Sub

    Private Sub CPI_Country_is_Closed(sender As Object, e As EventArgs) Handles dbxCPICountry.DropDownClosed
        lblCPICountryWarn.Visible = False
        lblCPICountryWarn.Text = "null"
    End Sub

    Private Sub CPI_Country_Lost_Focus(sender As Object, e As EventArgs) Handles dbxCPICountry.MouseLeave
        lblCPICountryWarn.Visible = False
        lblCPICountryWarn.Text = "null"
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE ENABLE EDIT MODE
    '##################################################################################################################################################################################################

    Private Sub CPI_Enable_Edit_Mode_Button(sender As Object, e As EventArgs) Handles btnCPIEdit.Click
        SMI_CPI_Disable_Controls()
        CPI_Enable_Edit_Mode()
        SMI_Hide_Extended_Panes()
        CPI_Hide_Side_Panel_Controller()
    End Sub

    Sub CPI_Enable_Edit_Mode()

        If txtCPICID.Text <> vbNullString Then
            btnCPIEdit.Text = "Editing customer"
            Dim res As DialogResult = MessageBox.Show("Applied changes will be irreversible. Would you like to continue?", "Requesting edit permission.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            If res = DialogResult.Yes Then
                CPI_Enable_Edit_Mode_Controls()
                CPI_Enable_Edit_Mode_Fields()
                CPI_Enable_DropDownBoxes()
                SMI_CPI_Enable_Controls()
            Else
                CPI_Disable_Edit_Mode_Controls()
                CPI_Enable_Textboxes_ReadOnly()
                CPI_Disable_DropDownBoxes()
                trCPIHorizS.ShowSync(panCPIDBSearchSm)
                SMI_CPI_Enable_Controls()
            End If

        Else
            Dim res As DialogResult = MessageBox.Show("Unable to give edit permission as there is no customer being selected.", "Failed to give edit permission.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                SMI_CPI_Enable_Controls()
            End If
        End If

    End Sub

    Sub CPI_Enable_Edit_Mode_Controls()
        btnCPIEdit.Enabled = False
        btnCPIUpdate.Enabled = True
        btnCPIDelete.Enabled = True
        btnCPIReset.Enabled = True
    End Sub

    Sub CPI_Disable_Edit_Mode_Controls()
        btnCPIEdit.Text = "Request for edit"
        btnCPIEdit.Enabled = True
        btnCPIUpdate.Enabled = False
        btnCPIDelete.Enabled = False
        btnCPIReset.Enabled = False
    End Sub

    Sub CPI_Enable_Edit_Mode_Fields()
        txtCPIFName.Enabled = True                  'Enable First name textbox
        txtCPIFName.ReadOnly = False                  'Enable First name textbox
        txtCPILName.Enabled = True                  'Enable Last name textbox
        txtCPILName.ReadOnly = False                  'Enable Last name textbox
        txtCPIEmail.Enabled = True                  'Enable Email address textbox
        txtCPIEmail.ReadOnly = False                  'Enable Email address textbox
        txtCPIPhone.Enabled = True                  'Enable Phone number textbox
        txtCPIPhone.ReadOnly = False                  'Enable Phone number textbox
        txtCPIStreet.Enabled = True                 'Enable Street address textbox
        txtCPIStreet.ReadOnly = False                 'Enable Street address textbox
        txtCPICity.Enabled = True                   'Enable City address textbox
        txtCPICity.ReadOnly = False                   'Enable City address textbox
        txtCPIState.Enabled = True                  'Enable State address textbox
        txtCPIState.ReadOnly = False                  'Enable State address textbox
        txtCPIPostcode.Enabled = True               'Enable Postcode address textbox
        txtCPIPostcode.ReadOnly = False               'Enable Postcode address textbox
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE UPDATE CUSTOMER DETAILS
    '##################################################################################################################################################################################################

    Private Sub CPI_Update_Customer_Details_Button(sender As Object, e As EventArgs) Handles btnCPIUpdate.Click
        SMI_CPI_Disable_Controls()
        CPI_Update_Record()
        SMI_Hide_Extended_Panes()
        CPI_Hide_Side_Panel_Controller()
    End Sub

    Sub CPI_Update_Record()

        If txtCPIFName.Text = vbNullString OrElse
            txtCPILName.Text = vbNullString OrElse
            txtCPIEmail.Text = vbNullString OrElse
            txtCPIPhone.Text = vbNullString OrElse
            txtCPIStreet.Text = vbNullString OrElse
            txtCPICity.Text = vbNullString OrElse
            txtCPIState.Text = vbNullString OrElse
            txtCPIPostcode.Text = vbNullString Then

            Dim res As DialogResult = MessageBox.Show("System has found one or more empty fields. Fill in with required information and try again.", "Fields cannot be empty.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                CPI_Enable_Edit_Mode_Controls()
                CPI_Enable_Edit_Mode_Fields()
                CPI_Enable_DropDownBoxes()
                SMI_CPI_Enable_Controls()
                CPI_Update_Record_Fields_Not_Empty()
            End If




        ElseIf lblCPIEmailWarn.Text = "Not a valid email address!" Or
            lblCPIPhoneWarn.Text = "Not a valid phone number!" Or
            lblCPIPostcodeWarn.Text = "Below minimum amount of characters!" Then
            Dim res As DialogResult = MessageBox.Show("System has found one or more fields with invalid formatting. Correct the format and try again.", "Invalid formatting.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                CPI_Enable_Edit_Mode_Controls()
                CPI_Enable_Edit_Mode_Fields()
                CPI_Enable_DropDownBoxes()
                SMI_CPI_Enable_Controls()
                CPI_Update_Record_Invalid_Formatting()
            End If

        Else

            CPI_Hide_Warning_Labels()
            CPI_Update_Record_Default_Selection()
            CPI_Update_Record_To_Database()
            CPI_Update_Record_Check_Selected_Criteria()
            Dim res As DialogResult = MessageBox.Show("Customer changes have been applied. Would you like to continue with edit mode enabled?", "Customer updated.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

            If res = DialogResult.Yes Then
                CPI_Enable_Edit_Mode_Controls()
                CPI_Enable_Edit_Mode_Fields()
                CPI_Enable_DropDownBoxes()
                SMI_CPI_Enable_Controls()
            Else
                CPI_Disable_Edit_Mode_Controls()
                CPI_Enable_Textboxes_ReadOnly()
                CPI_Disable_DropDownBoxes()
                trCPIHorizS.ShowSync(panCPIDBSearchSm)
                SMI_CPI_Enable_Controls()
            End If

        End If
    End Sub

    Sub CPI_Update_Record_Fields_Not_Empty()

        lblCPIFNameWarn.Text = "* First name is required!"
        lblCPILNameWarn.Text = "* Last name is required!"
        lblCPIEmailWarn.Text = "* Email address is required!"
        lblCPIPhoneWarn.Text = "* Phone number is required!"
        lblCPIStreetWarn.Text = "* Street address is required!"
        lblCPICityWarn.Text = "* City address is required!"
        lblCPIStateWarn.Text = "* State address is required!"
        lblCPIPostcodeWarn.Text = "* Postcode address is required!"

        For Each lbl As Bunifu.UI.WinForms.BunifuLabel In {lblCPIFNameWarn, lblCPILNameWarn, lblCPIEmailWarn, lblCPIPhoneWarn, lblCPIStreetWarn, lblCPICityWarn,
                lblCPIStateWarn, lblCPIPostcodeWarn}
            lbl.Visible = True
        Next

    End Sub

    Sub CPI_Update_Record_Invalid_Formatting()

        If lblCPIEmailWarn.Text = "Not a valid email address!" Then
            lblCPIEmailWarn.Text = "A valid email format must have '@' and '.'"
        End If

        If lblCPIPhoneWarn.Text = "Not a valid phone number!" Then
            lblCPIPhoneWarn.Text = "Refer online for international phone number format"
        End If

        If lblCPIPostcodeWarn.Text = "Below minimum amount of characters!" Then
            lblCPIPostcodeWarn.Text = "Postcode must be at least 4 digits"
        End If

    End Sub

    Sub CPI_Update_Record_Default_Selection()

        If dbxCPIGender.Text = "Select" Then
            dbxCPIGender.SelectedIndex = 2
            dbxCPIGender.Text = "Unspecified"
        End If

        If dbxCPICountry.Text = "Select" Then
            dbxCPICountry.SelectedIndex = 0
            dbxCPICountry.Text = "Malaysia"
        End If

    End Sub

    Sub CPI_Update_Record_To_Database()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)

        cpCustDs.Tables("cpCustList").Rows(0).Item(1) = txtCPIFName.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(2) = txtCPILName.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(3) = dtpCPIDOB.Value.ToString("dd/MM/yyyy")
        cpCustDs.Tables("cpCustList").Rows(0).Item(4) = dbxCPIGender.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(5) = txtCPIEmail.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(6) = txtCPIPhone.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(7) = txtCPIStreet.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(8) = txtCPICity.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(9) = txtCPIState.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(10) = txtCPIPostcode.Text
        cpCustDs.Tables("cpCustList").Rows(0).Item(11) = dbxCPICountry.Text
        cpCustDa.Update(cpCustDs, "cpCustList")
    End Sub

    Sub CPI_Update_Record_Check_Selected_Criteria()

        If dbxCPICriteria.Text = "Customer ID" Then
            CPI_cpCustList_Fetch_ID()
        ElseIf dbxCPICriteria.Text = "Name" Then
            CPI_cpCustList_Fetch_Name()
        ElseIf dbxCPICriteria.Text = "Email Address" Then
            CPI_cpCustList_Fetch_Email()
        ElseIf dbxCPICriteria.Text = "Phone Number" Then
            CPI_cpCustListe_Fetch_Phone()
        End If

    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE DELETE CUSTOMER
    '##################################################################################################################################################################################################

    Private Sub CPI_Delete_Customer_Button(sender As Object, e As EventArgs) Handles btnCPIDelete.Click
        SMI_CPI_Disable_Controls()
        SMI_Hide_Extended_Panes()
        CPI_Hide_Side_Panel_Controller()
        Dim res As DialogResult = MessageBox.Show("This customer will become inaccessible. Continue?", "Deleting customer.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        If res = DialogResult.Yes Then
            CPI_Delete_Customer()
            CPI_Reset_Fields()
            CPI_Hide_Warning_Labels()
            CPI_Disable_Edit_Mode_Controls()
            CPI_Revert_Fields_To_Original()
            trCPIHorizS.ShowSync(panCPIDBSearchSm)
            searchInput = ""
            SMI_CPI_Enable_Controls()

        Else
            CPI_Enable_Edit_Mode_Controls()
            CPI_Enable_Edit_Mode_Fields()
            CPI_Enable_DropDownBoxes()
            SMI_CPI_Enable_Controls()

        End If

    End Sub

    Sub CPI_Delete_Customer()
        Dim cbCust As New OleDb.OleDbCommandBuilder(cpCustDa)

        cpCustDs.Tables("cpCustList").Rows(0).Item(15) = "Yes"
        cpCustDa.Update(cpCustDs, "cpCustList")

    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE REVERT TO ORIGINAL
    '##################################################################################################################################################################################################

    Private Sub CPI_Revert_To_Original_Button(sender As Object, e As EventArgs) Handles btnCPIReset.Click
        SMI_CPI_Disable_Controls()
        SMI_Hide_Extended_Panes()
        CPI_Hide_Side_Panel_Controller()
        Dim res As DialogResult = MessageBox.Show("Edit permission will be revoked and customer details will be reverted back to original. Continue?", "Revert form to original.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        If res = DialogResult.Yes Then
            CPI_Revert_To_Original()
            SMI_CPI_Enable_Controls()

        Else
            CPI_Enable_Edit_Mode_Controls()
            CPI_Enable_Edit_Mode_Fields()
            CPI_Enable_DropDownBoxes()
            SMI_CPI_Enable_Controls()
        End If

    End Sub

    Sub CPI_Revert_To_Original()
        CPI_Load_Customer_Details()
        CPI_Disable_Edit_Mode_Controls()
        CPI_Revert_Fields_To_Original()
        CPI_Hide_Warning_Labels()
        trCPIHorizS.ShowSync(panCPIDBSearchSm)
    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE CRITERIA SELECTION
    '##################################################################################################################################################################################################

    Private Sub CPI_Criteria_Selection_DropDownBox(sender As Object, e As EventArgs) Handles dbxCPICriteria.SelectedIndexChanged

        If dbxCPICriteria.Text <> "Criteria" Or dbxCPICriteria.Text <> vbNullString Then
            CPI_Criteria_Selection_Check()
            txtCPISearch.Enabled = True
            btniCPISearch.Visible = True
            trCPIVertS.ShowSync(btnCPISReset)
        End If

    End Sub

    Sub CPI_Criteria_Selection_Check()

        If dbxCPICriteria.Text = "Customer ID" Then
            txtCPISearch.Clear()
            txtCPISearch.PlaceholderText = "C00000"
        ElseIf dbxCPICriteria.Text = "Name" Then
            txtCPISearch.Clear()
            txtCPISearch.PlaceholderText = "John Doe"
        ElseIf dbxCPICriteria.Text = "Email Address" Then
            txtCPISearch.Clear()
            txtCPISearch.PlaceholderText = "john_doe@mail.com"
        ElseIf dbxCPICriteria.Text = "Phone Number" Then
            txtCPISearch.Clear()
            txtCPISearch.PlaceholderText = "+6017-650 3929"
        End If

    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE SEARCH CUSTOMER PROFILE
    '##################################################################################################################################################################################################

    Private Sub CPI_Search_Customer_Profile_Button(sender As Object, e As EventArgs) Handles btniCPISearch.Click
        CPI_Search_Customer_Profile()
        SMI_Hide_Extended_Panes()
        CPI_Hide_Search_Panel_Controller()
        txtCPISearch.Clear()
        txtCPISearch.PlaceholderText = "Search"
    End Sub

    Private Sub CPI_Search_Customer_Profile_Reset_Button(sender As Object, e As EventArgs) Handles btnCPISReset.Click
        dbxCPICriteria.SelectedIndex = -1
        dbxCPICriteria.Text = "Criteria"
        txtCPISearch.Clear()
        txtCPISearch.PlaceholderText = "Search"
        txtCPISearch.Enabled = False
        btniCPISearch.Visible = False
        trCPIVertS.HideSync(btnCPISReset)
        CPI_Reset_Fields()
        CPI_Revert_Fields_To_Original()
        CPI_Hide_Warning_Labels()
        searchInput = ""
    End Sub

    Sub CPI_Search_Customer_Profile()

        searchInput = txtCPISearch.Text

        If dbxCPICriteria.Text = "Customer ID" And txtCPISearch.Text <> vbNullString Then
            CPI_cpCustList_Fetch_ID()
            CPI_Load_Customer_Details()
        ElseIf dbxCPICriteria.Text = "Name" And txtCPISearch.Text <> vbNullString Then
            CPI_cpCustList_Fetch_Name()
            CPI_Load_Customer_Details()
        ElseIf dbxCPICriteria.Text = "Email Address" And txtCPISearch.Text <> vbNullString Then
            CPI_cpCustList_Fetch_Email()
            CPI_Load_Customer_Details()
        ElseIf dbxCPICriteria.Text = "Phone Number" And txtCPISearch.Text <> vbNullString Then
            CPI_cpCustListe_Fetch_Phone()
            CPI_Load_Customer_Details()
        Else
            SMI_CPI_Disable_Controls()
            Dim res As DialogResult = MessageBox.Show("You cannot leave the search box blank. Insert a valid input and try again.", "Empty search", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                SMI_CPI_Enable_Controls()

            End If
        End If
    End Sub

    Sub CPI_Load_Customer_Details()

        Try
            CPI_Reset_Fields()

            Dim isDeleted As String = "null"

            isDeleted = cpCustDs.Tables("cpCustList").Rows(0).Item(15)

            If isDeleted = "No" Then
                txtCPICID.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(0)
                txtCPIFName.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(1)
                txtCPILName.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(2)
                dtpCPIDOB.Value = cpCustDs.Tables("cpCustList").Rows(0).Item(3)
                dbxCPIGender.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(4)
                txtCPIEmail.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(5)
                txtCPIPhone.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(6)
                txtCPIStreet.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(7)
                txtCPICity.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(8)
                txtCPIState.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(9)
                txtCPIPostcode.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(10)
                dbxCPICountry.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(11)
                txtCPICDate.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(12)
                txtCPICRegSID.Text = cpCustDs.Tables("cpCustList").Rows(0).Item(14)

                CPI_cpStaffList_Fetch()
                txtCPICRegName.Text = cpStaffDs.Tables("cpStaffList").Rows(0).Item(0) & " " & cpStaffDs.Tables("cpStaffList").Rows(0).Item(1)
                CPI_Enable_Textboxes_ReadOnly()
                CPI_Hide_Warning_Labels()
            ElseIf isDeleted = "Yes" Then
                SMI_CPI_Disable_Controls()
                Dim res As DialogResult = MessageBox.Show("Cannot access a deleted customer record. Try again.", "Deleted customer.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                If res = DialogResult.OK Then
                    SMI_CPI_Enable_Controls()

                End If

            End If
        Catch ex As Exception
            SMI_CPI_Disable_Controls()
            CPI_Disable_Textboxes_ReadOnly()
            CPI_Reset_Fields()

            Dim res As DialogResult = MessageBox.Show("Search cannot find any record by the inserted input. Try again.", "Invalid search.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                SMI_CPI_Enable_Controls()

            End If
        End Try

    End Sub

    '##################################################################################################################################################################################################
    '########## CUSTOMER PROFILE INTERFACE REPOSITORY
    '##################################################################################################################################################################################################

    Sub CPI_Revert_Fields_To_Original()
        txtCPIFName.Enabled = False                  'Enable First name textbox
        txtCPIFName.ReadOnly = False                  'Enable First name textbox
        txtCPILName.Enabled = False                  'Enable Last name textbox
        txtCPILName.ReadOnly = False                  'Enable Last name textbox
        dtpCPIDOB.Enabled = False                    'Enable DOB date time picker
        dbxCPIGender.Enabled = False                 'Enable Gender dropdown box
        txtCPIEmail.Enabled = False                  'Enable Email address textbox
        txtCPIEmail.ReadOnly = False                  'Enable Email address textbox
        txtCPIPhone.Enabled = False                  'Enable Phone number textbox
        txtCPIPhone.ReadOnly = False                  'Enable Phone number textbox
        txtCPIStreet.Enabled = False                 'Enable Street address textbox
        txtCPIStreet.ReadOnly = False                 'Enable Street address textbox
        txtCPICity.Enabled = False                   'Enable City address textbox
        txtCPICity.ReadOnly = False                   'Enable City address textbox
        txtCPIState.Enabled = False                  'Enable State address textbox
        txtCPIState.ReadOnly = False                  'Enable State address textbox
        txtCPIPostcode.Enabled = False               'Enable Postcode address textbox
        txtCPIPostcode.ReadOnly = False               'Enable Postcode address textbox
        dbxCPICountry.Enabled = False                'Enable Country dropdown box
    End Sub

    Sub CPI_Enable_Textboxes_ReadOnly()
        txtCPIFName.Enabled = True
        txtCPIFName.ReadOnly = True
        txtCPILName.Enabled = True
        txtCPILName.ReadOnly = True
        txtCPIEmail.Enabled = True
        txtCPIEmail.ReadOnly = True
        txtCPIPhone.Enabled = True
        txtCPIPhone.ReadOnly = True
        txtCPIStreet.Enabled = True
        txtCPIStreet.ReadOnly = True
        txtCPICity.Enabled = True
        txtCPICity.ReadOnly = True
        txtCPIState.Enabled = True
        txtCPIState.ReadOnly = True
        txtCPIPostcode.Enabled = True
        txtCPIPostcode.ReadOnly = True
    End Sub

    Sub CPI_Disable_Textboxes_ReadOnly()
        txtCPIFName.Enabled = False
        txtCPIFName.ReadOnly = False
        txtCPILName.Enabled = False
        txtCPILName.ReadOnly = False
        txtCPIEmail.Enabled = False
        txtCPIEmail.ReadOnly = False
        txtCPIPhone.Enabled = False
        txtCPIPhone.ReadOnly = False
        txtCPIStreet.Enabled = False
        txtCPIStreet.ReadOnly = False
        txtCPICity.Enabled = False
        txtCPICity.ReadOnly = False
        txtCPIState.Enabled = False
        txtCPIState.ReadOnly = False
        txtCPIPostcode.Enabled = False
        txtCPIPostcode.ReadOnly = False
    End Sub

    Sub CPI_Enable_DropDownBoxes()
        dtpCPIDOB.Enabled = True
        dbxCPIGender.Enabled = True
        dbxCPICountry.Enabled = True
    End Sub

    Sub CPI_Disable_DropDownBoxes()
        dtpCPIDOB.Enabled = False
        dbxCPIGender.Enabled = False
        dbxCPICountry.Enabled = False
    End Sub

    Sub CPI_Reset_Fields()
        txtCPICID.Text = ""
        txtCPICDate.Text = ""
        txtCPICRegName.Text = ""
        txtCPICRegSID.Text = ""

        txtCPIFName.Text = ""
        txtCPILName.Text = ""
        dtpCPIDOB.Value = "23/07/2001"
        dbxCPIGender.Text = "Null"
        txtCPIEmail.Text = ""
        txtCPIPhone.Text = ""

        txtCPIStreet.Text = ""
        txtCPICity.Text = ""
        txtCPIState.Text = ""
        txtCPIPostcode.Text = ""
        dbxCPICountry.Text = "Null"
    End Sub

    Sub CPI_Hide_Warning_Labels()

        lblCPIFNameWarn.Text = "null"
        lblCPIFNameWarn.Visible = False
        lblCPILNameWarn.Text = "null"
        lblCPILNameWarn.Visible = False
        lblCPIDOBWarn.Text = "null"
        lblCPIDOBWarn.Visible = False
        lblCPIGenderWarn.Text = "null"
        lblCPIGenderWarn.Visible = False
        lblCPIEmailWarn.Text = "null"
        lblCPIEmailWarn.Visible = False
        lblCPIPhoneWarn.Text = "null"
        lblCPIPhoneWarn.Visible = False
        lblCPIStreetWarn.Text = "null"
        lblCPIStreetWarn.Visible = False
        lblCPICityWarn.Text = "null"
        lblCPICityWarn.Visible = False
        lblCPIStateWarn.Text = "null"
        lblCPIStateWarn.Visible = False
        lblCPIPostcodeWarn.Text = "null"
        lblCPIPostcodeWarn.Visible = False
        lblCPICountryWarn.Text = "null"
        lblCPICountryWarn.Visible = False

    End Sub

    Private Sub CPI_Disable_Mouse_Scroll_In_DropDownBoxes(sender As Object, e As MouseEventArgs) Handles dbxCPIGender.MouseWheel, dbxCPICriteria.MouseWheel, dbxCPICountry.MouseWheel
        Dim dbx As Bunifu.UI.WinForms.BunifuDropdown = sender

        If dbx.Enabled = False Then
            Dim mwe As HandledMouseEventArgs = e
            mwe.Handled = True
        End If
    End Sub

    Sub SMI_Hide_Extended_Panes()                                                                      'Hiding extended panes during certain events
        For Each panel In {staffmenu.panSMIOrd, staffmenu.panSMICust, staffmenu.panSMIMisc}        'Assigning affected panes into panel array
            staffmenu.trSMIVertS.HideSync(panel)                                                                        'Hiding every affected panes
        Next
    End Sub

    Sub CPI_Show_Side_Panel_Controller()
        trCPIHorizS.HideSync(panCPISideSm)
        trCPIHorizS.HideSync(panCPIDBSearchSm)
        trCPIHorizS.ShowSync(panCPISide)
    End Sub

    Sub CPI_Hide_Side_Panel_Controller()
        trCPIHorizS.HideSync(panCPISide)
        trCPIHorizS.ShowSync(panCPISideSm)

        If btnCPIEdit.Text <> "Editing customer" Then
            trCPIHorizS.ShowSync(panCPIDBSearchSm)
        End If
    End Sub

    Sub CPI_Show_Search_Panel_Controller()
        trCPIHorizS.HideSync(panCPIDBSearchSm)
        trCPIHorizS.HideSync(panCPISideSm)
        trCPIHorizS.ShowSync(panCPIDBSearch)
    End Sub

    Sub CPI_Hide_Search_Panel_Controller()
        trCPIHorizS.HideSync(panCPIDBSearch)
        trCPIHorizS.ShowSync(panCPIDBSearchSm)
        trCPIHorizS.ShowSync(panCPISideSm)
    End Sub

    'Sub Customer_Profile_Interface_Hide_Search_Button_During_Edit()
    '    panCPIDBSearchSm.Visible = False
    'End Sub

    Sub CPI_Controls_Load()
        trCPIHorizS.ShowSync(panCPIDBSearchSm)
        trCPIHorizS.ShowSync(panCPISideSm)
    End Sub

    Sub SMI_CPI_Enable_Controls()      'Enable interactable controls during certain events
        btniCPISideS.Enabled = True                 'Enable Side extensible pane button
        btniCPIDBSearchS.Enabled = True             'Enable Search extensible pane button
        'txtCPIFName.Enabled = True                  'Enable First name textbox
        'txtCPILName.Enabled = True                  'Enable Last name textbox
        'dtpCPIDOB.Enabled = True                    'Enable DOB date time picker
        'dbxCPIGender.Enabled = True                 'Enable Gender dropdown box
        'txtCPIEmail.Enabled = True                  'Enable Email address textbox
        'txtCPIPhone.Enabled = True                  'Enable Phone number textbox
        'txtCPIStreet.Enabled = True                 'Enable Street address textbox
        'txtCPICity.Enabled = True                   'Enable City address textbox
        'txtCPIState.Enabled = True                  'Enable State address textbox
        'txtCPIPostcode.Enabled = True               'Enable Postcode address textbox
        'dbxCPICountry.Enabled = True                'Enable Country dropdown box
        staffmenu.btnSMIClose.Enabled = True        'Enable Close application button
        staffmenu.btnSMIMin.Enabled = True          'Enable Minimise application button
        staffmenu.btnSMIOrd.Enabled = True          'Enable Order button
        staffmenu.btnSMICust.Enabled = True         'Enable Customer button
        staffmenu.btnSMIMisc.Enabled = True         'Enable Miscellaneous button
    End Sub

    Sub SMI_CPI_Disable_Controls()     'Disable interactable controls during certain events
        btniCPISideS.Enabled = False                'Disable Side extensible pane button
        btniCPIDBSearchS.Enabled = False            'Disable Search extensible pane button
        txtCPIFName.Enabled = False                 'Disable First name textbox
        txtCPILName.Enabled = False                 'Disable Last name textbox
        dtpCPIDOB.Enabled = False                   'Disable DOB date time picker
        dbxCPIGender.Enabled = False                'Disable Gender dropdown box
        txtCPIEmail.Enabled = False                 'Disable Email address textbox
        txtCPIPhone.Enabled = False                 'Disable Phone number textbox
        txtCPIStreet.Enabled = False                'Disable Street address textbox
        txtCPICity.Enabled = False                  'Disable City address textbox
        txtCPIState.Enabled = False                 'Disable State address textbox
        txtCPIPostcode.Enabled = False              'Disable Postcode address textbox
        dbxCPICountry.Enabled = False               'Disable Country dropdown box
        staffmenu.btnSMIClose.Enabled = False       'Disable Close application button
        staffmenu.btnSMIMin.Enabled = False         'Disable Minimise application button
        staffmenu.btnSMIOrd.Enabled = False         'Disable Order button
        staffmenu.btnSMICust.Enabled = False        'Disable Customer button
        staffmenu.btnSMIMisc.Enabled = False        'Disable Miscellaneous button
    End Sub

    'Private Sub Customer_Profile_Interface_Dataset_Load_Timer(sender As Object, e As EventArgs) Handles timCPIIntro.Tick
    '    lsec += 1

    '    If lsec = 1 Then
    '        CPI_cpCustList_Load()
    '    ElseIf lsec = 5 Then
    '        CPI_cpStaffList_Load()
    '        lsec = 0
    '        timCPIIntro.Stop()
    '    End If
    'End Sub


    '##################################################################################################################################################################################################
    '##########_CUSTOMER_PROFILE_INTERFACE_END
    '##################################################################################################################################################################################################

End Class