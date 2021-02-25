Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Public Class customerregister

    'REMINDER TO PUT A VALIDATION SO THAT THE DATETIME PICKER FOR DOB CANNOT GO BEYOND THE LOCAL SYSTEM DATE

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_START
    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_LOCAL_VARIABLE
    '##################################################################################################################################################################################################

    Dim one, ten, hundred, thousand, tthousand As Integer

    'For database connection use
    Dim crCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim crProvider, crSource, crCustSql, crGenderSql, crCountrySql As String     'Declaring database retrieval keywords
    Dim crCustDs As DataSet = New DataSet("crCustList")                         'Create a new data container for fetched data
    Dim crGenderDs As DataSet = New DataSet("crGenderList")                         'Create a new data container for fetched data
    Dim crCountryDs As DataSet = New DataSet("crCountryList")                         'Create a new data container for fetched data
    Dim crCustDa, crGenderDa, crCountryDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_CORE
    '##################################################################################################################################################################################################

    Private Sub Customer_Register_Interface_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        Customer_Registration_Interface_Elipse_Set()
        Customer_Registration_Interface_Database_Initial_Load()
        Customer_Registration_Interface_crCustList_Load()
        Customer_Registration_Interface_crGenderList_Load()
        Customer_Registration_Interface_crCountryList_Load()
        Customer_Registration_Interface_Controls_Load()
        Customer_Registration_Interface_Country_DropDownBox_Size()
    End Sub

    Sub Customer_Registration_Interface_Elipse_Set()
        Dim elCRI As Bunifu.Framework.UI.BunifuElipse = New Bunifu.Framework.UI.BunifuElipse
        elCRI.ApplyElipse(panCRISideSm, 10)
        elCRI.ApplyElipse(panCRISide, 10)
    End Sub

    Sub Customer_Registration_Interface_Country_DropDownBox_Size()
        dbxCRICountry.DropDownHeight = 200
        dbxCRICountry.DropDownWidth = 284
    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_CONTROL_SET
    '##################################################################################################################################################################################################

    Private Sub Customer_Registration_Interface_Show_Side_Panel(sender As Object, e As EventArgs) Handles btniCRISideS.Click
        Customer_Registration_Interface_Show_Side_Panel_Controller()
    End Sub

    Private Sub Customer_Registration_Interface_Hide_Side_Panel(sender As Object, e As EventArgs) Handles btniCRISideH.Click
        Customer_Registration_Interface_Hide_Side_Panel_Controller()
    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_CLOSE_WINDOW
    '##################################################################################################################################################################################################



    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_USER_INPUT_FUNCTIONS
    '##################################################################################################################################################################################################

    Private Sub Customer_Registration_Interface_First_Name_NoDigit(sender As Object, e As KeyPressEventArgs) Handles txtCRIFName.KeyPress 'Stack Overflow, 2012. Get a textbox to accept only characters in vb.net.
        Dim lowCase As Boolean = e.KeyChar >= "a"c And e.KeyChar <= "z"c
        Dim upCase As Boolean = e.KeyChar >= "A"c And e.KeyChar <= "Z"c
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)
        Dim enter As Boolean = e.KeyChar = ChrW(Keys.Enter)
        Dim bksp As Boolean = e.KeyChar = ChrW(Keys.Back)

        If lowCase = False And upCase = False And space = False And enter = False And bksp = False Then
            SendKeys.Send(vbBack)
            lblCRIFNameWarn.Visible = True
            lblCRIFNameWarn.Text = "Only alphabets are allowed!"
        ElseIf lowCase = True Or upCase = True Then
            lblCRIFNameWarn.Visible = False
            lblCRIFNameWarn.Text = "null"
        End If

        If txtCRIFName.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRIFName.Text = vbNullString Then
                txtCRIFName.Focus()
                lblCRIFNameWarn.Visible = True
                lblCRIFNameWarn.Text = "This section cannot be empty!"
            ElseIf lblCRIFNameWarn.Text = "This section cannot be empty!" Then
                txtCRIFName.Focus()
            Else
                lblCRIFNameWarn.Visible = False
                lblCRIFNameWarn.Text = "null"
                txtCRILName.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_First_Name_Empty(sender As Object, e As EventArgs) Handles txtCRIFName.TextChanged, txtCRIFName.MouseEnter
        If txtCRIFName.Text = vbNullString Then
            txtCRIFName.Focus()
            lblCRIFNameWarn.Visible = True
            lblCRIFNameWarn.Text = "This section cannot be empty!"
        ElseIf lblCRIFNameWarn.Text = "* First name is required!" Then
            lblCRIFNameWarn.Visible = False
            lblCRIFNameWarn.Text = "null"
        ElseIf txtCRIFName.Text.Length = 41 Then
            SendKeys.Send(vbBack)
            txtCRIFName.Focus()
            lblCRIFNameWarn.Visible = True
            lblCRIFNameWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRIFName.Text.Length > 41 Then
            txtCRIFName.Focus()
            lblCRIFNameWarn.Visible = True
            lblCRIFNameWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_First_Name_NotEmpty(sender As Object, e As EventArgs) Handles txtCRIFName.MouseLeave
        If lblCRIFNameWarn.Text = "Only alphabets are allowed!" Then
            lblCRIFNameWarn.Visible = False
            lblCRIFNameWarn.Text = "null"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Last_Name_NoDigit(sender As Object, e As KeyPressEventArgs) Handles txtCRILName.KeyPress 'Stack Overflow, 2012. Get a textbox to accept only characters in vb.net.
        Dim lowCase As Boolean = e.KeyChar >= "a"c And e.KeyChar <= "z"c
        Dim upCase As Boolean = e.KeyChar >= "A"c And e.KeyChar <= "Z"c
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)
        Dim enter As Boolean = e.KeyChar = ChrW(Keys.Enter)
        Dim bksp As Boolean = e.KeyChar = ChrW(Keys.Back)

        If lowCase = False And upCase = False And space = False And enter = False And bksp = False Then
            lblCRILNameWarn.Visible = True
            lblCRILNameWarn.Text = "Only alphabets are allowed!"
            SendKeys.Send(vbBack) 'Microsoft, n.d. Sendkeys.Send(String) Method. 
        ElseIf lowCase = True Or upCase = True Then
            lblCRILNameWarn.Visible = False
            lblCRILNameWarn.Text = "null"
        End If

        If txtCRILName.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRILName.Text = vbNullString Then
                txtCRILName.Focus()
                lblCRILNameWarn.Visible = True
                lblCRILNameWarn.Text = "This section cannot be empty!"
            ElseIf lblCRILNameWarn.Text = "This section cannot be empty!" Then
                txtCRILName.Focus()
            Else
                lblCRILNameWarn.Visible = False
                lblCRILNameWarn.Text = "null"
                dtpCRIDOB.Select()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Last_Name_Empty(sender As Object, e As EventArgs) Handles txtCRILName.TextChanged, txtCRILName.MouseEnter
        If txtCRILName.Text = vbNullString Then
            txtCRILName.Focus()
            lblCRILNameWarn.Visible = True
            lblCRILNameWarn.Text = "This section cannot be empty!"
        ElseIf lblCRILNameWarn.Text = "* Last name is required!" Then
            lblCRILNameWarn.Visible = False
            lblCRILNameWarn.Text = "null"
        ElseIf txtCRILName.Text.Length = 41 Then
            SendKeys.Send(vbBack)
            txtCRILName.Focus()
            lblCRILNameWarn.Visible = True
            lblCRILNameWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRILName.Text.Length > 41 Then
            txtCRILName.Focus()
            lblCRILNameWarn.Visible = True
            lblCRILNameWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Last_Name_NotEmpty(sender As Object, e As EventArgs) Handles txtCRILName.MouseLeave
        If lblCRILNameWarn.Text = "Only alphabets are allowed!" Then
            lblCRILNameWarn.Visible = False
            lblCRILNameWarn.Text = "null"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_DOB_HasFocus(sender As Object, e As EventArgs) Handles dtpCRIDOB.Click, dtpCRIDOB.GotFocus, dtpCRIDOB.MouseEnter
        lblCRIDOBWarn.Text = "Default value will be used if no user selection!"
        lblCRIDOBWarn.Visible = True
    End Sub

    Private Sub Customer_Registration_Interface_DOB_isClosed(sender As Object, e As EventArgs) Handles dtpCRIDOB.CloseUp
        lblCRIDOBWarn.Visible = False
        lblCRIDOBWarn.Text = "null"
        dbxCRIGender.Select()
    End Sub

    Private Sub Customer_Registration_Interface_DOB_MouseLeave(sender As Object, e As EventArgs) Handles dtpCRIDOB.MouseLeave
        lblCRIDOBWarn.Visible = False
        lblCRIDOBWarn.Text = "null"
    End Sub

    Private Sub Customer_Registration_Interface_Gender_HasFocus(sender As Object, e As EventArgs) Handles dbxCRIGender.Click, dbxCRIGender.GotFocus, dbxCRIGender.MouseEnter
        lblCRIGenderWarn.Text = "Default value ""Unspecified"" will be used if no selection!"
        lblCRIGenderWarn.Visible = True
    End Sub

    Private Sub Customer_Registration_Interface_Gender_isClosed(sender As Object, e As EventArgs) Handles dbxCRIGender.DropDownClosed
        lblCRIGenderWarn.Visible = False
        lblCRIGenderWarn.Text = "null"
        txtCRIEmail.Focus()
    End Sub

    Private Sub Customer_Registration_Interface_Gender_MouseLeave(sender As Object, e As EventArgs) Handles dbxCRIGender.MouseLeave
        lblCRIGenderWarn.Visible = False
        lblCRIGenderWarn.Text = "null"
    End Sub

    Private Sub Customer_Registration_Interface_Email_Format(sender As Object, e As KeyPressEventArgs) Handles txtCRIEmail.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRIEmail.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If space = True Then
            SendKeys.Send(vbBack)

        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRILName.Text = vbNullString Then
                txtCRIEmail.Focus()
                lblCRIEmailWarn.Visible = True
                lblCRIEmailWarn.Text = "This section cannot be empty!"
            ElseIf lblCRIEmailWarn.Text = "This section cannot be empty!" Then
                txtCRIEmail.Focus()
            Else
                lblCRIEmailWarn.Visible = False
                lblCRIEmailWarn.Text = "null"
                txtCRIPhone.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Email_Empty(sender As Object, e As EventArgs) Handles txtCRIEmail.TextChanged, txtCRIEmail.MouseEnter
        Dim pattern As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Dim compare As Match = pattern.Match(txtCRIEmail.Text)


        If txtCRIEmail.Text = vbNullString Then
            txtCRIEmail.Focus()
            lblCRIEmailWarn.Visible = True
            lblCRIEmailWarn.Text = "This section cannot be empty!"
        End If

        If Not (compare.Success) Then
            If txtCRIEmail.Text.Length < 50 Then
                lblCRIEmailWarn.Text = "Not a valid email address!"
                lblCRIEmailWarn.Visible = True
            ElseIf txtCRIEmail.Text.Length = 51 Then
                SendKeys.Send(vbBack)
                txtCRIEmail.Focus()
                lblCRIEmailWarn.Visible = True
                lblCRIEmailWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCRIEmail.Text.Length > 51 Then
                txtCRIEmail.Focus()
                lblCRIEmailWarn.Visible = True
                lblCRIEmailWarn.Text = "Beyond maximum amount of characters!"
            End If
        ElseIf (compare.Success) Then
            If txtCRIEmail.Text.Length < 50 Then
                lblCRIEmailWarn.Visible = False
                lblCRIEmailWarn.Text = "null"
            ElseIf txtCRIEmail.Text.Length = 51 Then
                SendKeys.Send(vbBack)
                txtCRIEmail.Focus()
                lblCRIEmailWarn.Visible = True
                lblCRIEmailWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCRIEmail.Text.Length > 51 Then
                txtCRIEmail.Focus()
                lblCRIEmailWarn.Visible = True
                lblCRIEmailWarn.Text = "Beyond maximum amount of characters!"
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Phone_Keys_Handler(sender As Object, e As KeyPressEventArgs) Handles txtCRIPhone.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRIPhone.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRIPhone.Text = vbNullString Then
                txtCRIPhone.Focus()
                lblCRIPhoneWarn.Visible = True
                lblCRIPhoneWarn.Text = "This section cannot be empty!"
            ElseIf lblCRIPhoneWarn.Text = "This section cannot be empty!" Then
                txtCRIPhone.Focus()
            Else
                lblCRIPhoneWarn.Visible = False
                lblCRIPhoneWarn.Text = "null"
                txtCRIStreet.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Phone_Empty_And_NoAlphabet(sender As Object, e As EventArgs) Handles txtCRIPhone.TextChanged, txtCRIPhone.MouseEnter
        Dim pattern As Regex = New Regex("\(?\+[0-9]{1,3}\)? ?-?[0-9]{1,3} ?-?[0-9]{3,5} ?-?[0-9]{4}( ?-?[0-9]{3})? ?(\w{1,10}\s?\d{1,6})?")
        Dim compare As Match = pattern.Match(txtCRIPhone.Text)

        If txtCRIPhone.Text = vbNullString Then
            txtCRIPhone.Focus()
            lblCRIPhoneWarn.Visible = True
            lblCRIPhoneWarn.Text = "This section cannot be empty!"
        End If

        If Not (compare.Success) Then
            If txtCRIPhone.Text.Length < 25 Then
                lblCRIPhoneWarn.Text = "Not a valid phone number!"
                lblCRIPhoneWarn.Visible = True
            ElseIf txtCRIPhone.Text.Length = 26 Then
                SendKeys.Send(vbBack)
                txtCRIPhone.Focus()
                lblCRIPhoneWarn.Visible = True
                lblCRIPhoneWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCRIPhone.Text.Length > 26 Then
                txtCRIPhone.Focus()
                lblCRIPhoneWarn.Visible = True
                lblCRIPhoneWarn.Text = "Beyond maximum amount of characters!"
            End If
        ElseIf (compare.Success) Then
            If txtCRIPhone.Text.Length < 25 Then
                lblCRIPhoneWarn.Visible = False
                lblCRIPhoneWarn.Text = "null"
            ElseIf txtCRIPhone.Text.Length = 26 Then
                SendKeys.Send(vbBack)
                txtCRIPhone.Focus()
                lblCRIPhoneWarn.Visible = True
                lblCRIPhoneWarn.Text = "Maximum amount of characters reached!"
            ElseIf txtCRIPhone.Text.Length > 26 Then
                txtCRIPhone.Focus()
                lblCRIPhoneWarn.Visible = True
                lblCRIPhoneWarn.Text = "Beyond maximum amount of characters!"
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Street_Keys_Handler(sender As Object, e As KeyPressEventArgs) Handles txtCRIStreet.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRIStreet.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRIStreet.Text = vbNullString Then
                txtCRIStreet.Focus()
                lblCRIStreetWarn.Visible = True
                lblCRIStreetWarn.Text = "This section cannot be empty!"
            ElseIf txtCRIStreet.Text = "This section cannot be empty!" Then
                txtCRIStreet.Focus()
            Else
                lblCRIStreetWarn.Visible = False
                lblCRIStreetWarn.Text = "null"
                txtCRICity.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Street_Empty(sender As Object, e As EventArgs) Handles txtCRIStreet.TextChanged, txtCRIStreet.MouseEnter
        If txtCRIStreet.Text = vbNullString Then
            txtCRIStreet.Focus()
            lblCRIStreetWarn.Visible = True
            lblCRIStreetWarn.Text = "This section cannot be empty!"
        ElseIf txtCRIStreet.Text.Length > 0 And txtCRIStreet.Text.Length < 50 Then
            lblCRIStreetWarn.Visible = False
            lblCRIStreetWarn.Text = "null"
        ElseIf txtCRIStreet.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCRIStreet.Focus()
            lblCRIStreetWarn.Visible = True
            lblCRIStreetWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRIStreet.Text.Length > 51 Then
            txtCRIStreet.Focus()
            lblCRIStreetWarn.Visible = True
            lblCRIStreetWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_City_Keys_Handler(sender As Object, e As KeyPressEventArgs) Handles txtCRICity.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRICity.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRICity.Text = vbNullString Then
                txtCRICity.Focus()
                lblCRICityWarn.Visible = True
                lblCRICityWarn.Text = "This section cannot be empty!"
            ElseIf txtCRICity.Text = "This section cannot be empty!" Then
                txtCRICity.Focus()
            Else
                lblCRICityWarn.Visible = False
                lblCRICityWarn.Text = "null"
                txtCRIState.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_City_Empty(sender As Object, e As EventArgs) Handles txtCRICity.TextChanged, txtCRICity.MouseEnter
        If txtCRICity.Text = vbNullString Then
            txtCRICity.Focus()
            lblCRICityWarn.Visible = True
            lblCRICityWarn.Text = "This section cannot be empty!"
        ElseIf txtCRICity.Text.Length > 0 And txtCRICity.Text.Length < 50 Then
            lblCRICityWarn.Visible = False
            lblCRICityWarn.Text = "null"
        ElseIf txtCRICity.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCRICity.Focus()
            lblCRICityWarn.Visible = True
            lblCRICityWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRICity.Text.Length > 51 Then
            txtCRICity.Focus()
            lblCRICityWarn.Visible = True
            lblCRICityWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_State_Keys_Handler(sender As Object, e As KeyPressEventArgs) Handles txtCRIState.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRIState.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRIState.Text = vbNullString Then
                txtCRIState.Focus()
                lblCRIStateWarn.Visible = True
                lblCRIStateWarn.Text = "This section cannot be empty!"
            ElseIf txtCRIState.Text = "This section cannot be empty!" Then
                txtCRIState.Focus()
            Else
                lblCRIStateWarn.Visible = False
                lblCRIStateWarn.Text = "null"
                txtCRIPostcode.Focus()
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_State_Empty(sender As Object, e As EventArgs) Handles txtCRIState.TextChanged, txtCRIState.MouseEnter
        If txtCRIState.Text = vbNullString Then
            txtCRIState.Focus()
            lblCRIStateWarn.Visible = True
            lblCRIStateWarn.Text = "This section cannot be empty!"
        ElseIf txtCRIState.Text.Length > 0 And txtCRIState.Text.Length < 50 Then
            lblCRIStateWarn.Visible = False
            lblCRIStateWarn.Text = "null"
        ElseIf txtCRIState.Text.Length = 51 Then
            SendKeys.Send(vbBack)
            txtCRIState.Focus()
            lblCRIStateWarn.Visible = True
            lblCRIStateWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRIState.Text.Length > 51 Then
            txtCRIState.Focus()
            lblCRIStateWarn.Visible = True
            lblCRIStateWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Postcode_Keys_Handler(sender As Object, e As KeyPressEventArgs) Handles txtCRIPostcode.KeyPress
        Dim space As Boolean = e.KeyChar = ChrW(Keys.Space)

        If txtCRIPostcode.Text = vbNullString And space = True Then
            SendKeys.Send(vbBack)
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtCRIPostcode.Text = vbNullString Then
                txtCRIPostcode.Focus()
                lblCRIPostcodeWarn.Visible = True
                lblCRIPostcodeWarn.Text = "This section cannot be empty!"
            ElseIf txtCRIPostcode.Text = "This section cannot be empty!" Then
                txtCRIPostcode.Focus()
            Else
                lblCRIPostcodeWarn.Visible = False
                lblCRIPostcodeWarn.Text = "null"
                dbxCRICountry.Select()
                dbxCRICountry.DroppedDown = True
            End If
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Postcode_Empty(sender As Object, e As EventArgs) Handles txtCRIPostcode.TextChanged, txtCRIPostcode.MouseEnter
        If txtCRIPostcode.Text = vbNullString Then
            txtCRIPostcode.Focus()
            lblCRIPostcodeWarn.Visible = True
            lblCRIPostcodeWarn.Text = "This section cannot be empty!"
        ElseIf txtCRIPostcode.Text.Length < 3 Then
            txtCRIPostcode.Focus()
            lblCRIPostcodeWarn.Visible = True
            lblCRIPostcodeWarn.Text = "Below minimum amount of characters!"
        ElseIf txtCRIPostcode.Text.Length >= 4 And txtCRIPostcode.Text.Length < 12 Then
            lblCRIPostcodeWarn.Visible = False
            lblCRIPostcodeWarn.Text = "null"
        ElseIf txtCRIPostcode.Text.Length = 13 Then
            SendKeys.Send(vbBack)
            txtCRIPostcode.Focus()
            lblCRIPostcodeWarn.Visible = True
            lblCRIPostcodeWarn.Text = "Maximum amount of characters reached!"
        ElseIf txtCRIPostcode.Text.Length > 13 Then
            txtCRIPostcode.Focus()
            lblCRIPostcodeWarn.Visible = True
            lblCRIPostcodeWarn.Text = "Beyond maximum amount of characters!"
        End If
    End Sub

    Private Sub Customer_Registration_Interface_Country_HasFocus(sender As Object, e As EventArgs) Handles dbxCRICountry.Click, dbxCRICountry.GotFocus,
        dbxCRICountry.MouseEnter
        lblCRICountryWarn.Text = "Default value ""Malaysia"" will be used if no selection!"
        lblCRICountryWarn.Visible = True
    End Sub

    Private Sub Customer_Registration_Interface_Country_isClosed(sender As Object, e As EventArgs) Handles dbxCRICountry.DropDownClosed
        lblCRICountryWarn.Visible = False
        lblCRICountryWarn.Text = "null"
    End Sub

    Private Sub Customer_Registration_Interface_Country_MouseLeave(sender As Object, e As EventArgs) Handles dbxCRICountry.MouseLeave
        lblCRICountryWarn.Visible = False
        lblCRICountryWarn.Text = "null"
    End Sub


    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_UPDATE_CUSTOMER_T_DB
    '##################################################################################################################################################################################################

    Private Sub Customer_Registration_Interface_Append_CUSTOMER_T_DB(sender As Object, e As EventArgs) Handles btnCRIDBAdd.Click
        Customer_Registration_Interface_crCustList_Load()
        Customer_Registration_Interface_Entry_Validation()
    End Sub

    Sub Customer_Registration_Interface_crCustList_Load()
        Dim cbCust As New OleDb.OleDbCommandBuilder(crCustDa)

        crCon.Open()
        crCustSql = "SELECT * FROM CUSTOMER_T"
        crCustDa = New OleDb.OleDbDataAdapter(crCustSql, crCon)
        crCustDa.Fill(crCustDs, "crCustList")
        crCon.Close()
    End Sub

    Sub Customer_Registration_Interface_Entry_Validation()

        Staff_Menu_Interface_Hide_Extended_Panes()
        Customer_Registration_Interface_Hide_Side_Panel_Controller()

        If txtCRIFName.Text = vbNullString OrElse
            txtCRILName.Text = vbNullString OrElse
            txtCRIEmail.Text = vbNullString OrElse
            txtCRIPhone.Text = vbNullString OrElse
            txtCRIStreet.Text = vbNullString OrElse
            txtCRICity.Text = vbNullString OrElse
            txtCRIState.Text = vbNullString OrElse
            txtCRIPostcode.Text = vbNullString Then
            Staff_Menu_Interface_Disable_Controls()
            Dim res As DialogResult = MessageBox.Show("You have left one or more fields blank. Insert relevant information and try again.", "Empty fields found.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                Staff_Menu_Interface_Enable_Controls()

            End If

            lblCRIFNameWarn.Text = "* First name is required!"
            lblCRILNameWarn.Text = "* Last name is required!"
            lblCRIEmailWarn.Text = "* Email address is required!"
            lblCRIPhoneWarn.Text = "* Phone number is required!"
            lblCRIStreetWarn.Text = "* Street address is required!"
            lblCRICityWarn.Text = "* City address is required!"
            lblCRIStateWarn.Text = "* State address is required!"
            lblCRIPostcodeWarn.Text = "* Postcode address is required!"

            For Each lbl As Bunifu.UI.WinForms.BunifuLabel In {lblCRIFNameWarn, lblCRILNameWarn, lblCRIEmailWarn, lblCRIPhoneWarn, lblCRIStreetWarn, lblCRICityWarn,
                lblCRIStateWarn, lblCRIPostcodeWarn}
                lbl.Visible = True
            Next

        ElseIf lblCRIEmailWarn.Text = "Not a valid email address!" Or
            lblCRIPhoneWarn.Text = "Not a valid phone number!" Or
            lblCRIPostcodeWarn.Text = "Below minimum amount of characters!" Then
            Staff_Menu_Interface_Disable_Controls()
            Dim res As DialogResult = MessageBox.Show("One or more fields have invalid formatting. Correct the fields and try again.", "Invalid formatting", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                Staff_Menu_Interface_Enable_Controls()
            End If

            If lblCRIEmailWarn.Text = "Not a valid email address!" Then
                lblCRIEmailWarn.Text = "A valid email format must have '@' and '.'"
            End If

            If lblCRIPhoneWarn.Text = "Not a valid phone number!" Then
                lblCRIPhoneWarn.Text = "Refer online for international phone number format"
            End If

            If lblCRIPostcodeWarn.Text = "Below minimum amount of characters!" Then
                lblCRIPostcodeWarn.Text = "Postcode must be at least 4 digits"
            End If

        Else
            Staff_Menu_Interface_Disable_Controls()

            '#################################
            'SIMPLIFY THESE INTO A SUBROUTINE

            lblCRIFNameWarn.Text = "null"
            lblCRILNameWarn.Text = "null"
            lblCRIDOBWarn.Text = "null"
            lblCRIGenderWarn.Text = "null"
            lblCRIEmailWarn.Text = "null"
            lblCRIPhoneWarn.Text = "null"
            lblCRIStreetWarn.Text = "null"
            lblCRICityWarn.Text = "null"
            lblCRIStateWarn.Text = "null"
            lblCRIPostcodeWarn.Text = "null"
            lblCRICountryWarn.Text = "null"

            For Each lbl As Bunifu.UI.WinForms.BunifuLabel In {lblCRIFNameWarn, lblCRILNameWarn, lblCRIDOBWarn, lblCRIGenderWarn, lblCRIEmailWarn, lblCRIPhoneWarn,
                lblCRIStreetWarn, lblCRICityWarn, lblCRIStateWarn, lblCRIPostcodeWarn, lblCRICountryWarn}
                lbl.Visible = False
            Next

            'SIMPLIFY THESE INTO A SUBROUTINE
            '#################################

            If dbxCRIGender.Text = "Select" Then
                dbxCRIGender.SelectedIndex = 2
                dbxCRIGender.Text = "Unspecified"
            End If

            If dbxCRICountry.Text = "Select" Then
                dbxCRICountry.SelectedIndex = 0
                dbxCRICountry.Text = "Malaysia"
            End If

            Dim ld As New OleDb.OleDbCommandBuilder(crCustDa)
            Dim dsNewRow As DataRow
            Dim staID As String = staffmenu.lblSMIStaID.Text
            staID = Replace(staID, "Staff ID: ", "")

            dsNewRow = crCustDs.Tables("crCustList").NewRow
            dsNewRow.Item(0) = txtCRICID.Text
            dsNewRow.Item(1) = txtCRIFName.Text
            dsNewRow.Item(2) = txtCRILName.Text
            dsNewRow.Item(3) = dtpCRIDOB.Value.ToString("dd/MM/yyyy")
            dsNewRow.Item(4) = dbxCRIGender.Text
            dsNewRow.Item(5) = txtCRIEmail.Text
            dsNewRow.Item(6) = txtCRIPhone.Text
            dsNewRow.Item(7) = txtCRIStreet.Text
            dsNewRow.Item(8) = txtCRICity.Text
            dsNewRow.Item(9) = txtCRIState.Text
            dsNewRow.Item(10) = txtCRIPostcode.Text
            dsNewRow.Item(11) = dbxCRICountry.Text
            dsNewRow.Item(12) = txtCRICDate.Text
            dsNewRow.Item(13) = txtCRICTime.Text
            dsNewRow.Item(14) = staID
            dsNewRow.Item(15) = "No"

            crCustDs.Tables("crCustList").Rows.Add(dsNewRow)
            crCustDa.Update(crCustDs, "crCustList")
            Dim res As DialogResult = MessageBox.Show("Customer has been registed. Would you like to register another?", "Successful registration.", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

            If res = DialogResult.Yes Then
                Customer_Registration_Interface_Reset_Form()
                Staff_Menu_Interface_Enable_Controls()
            Else
                Customer_Registration_Interface_Hide_Form()
                Staff_Menu_Interface_Enable_Controls()

            End If

        End If
    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_RESET_FORM_SIDE_PANE_BUTTON
    '##################################################################################################################################################################################################

    Private Sub Customer_Registration_Interface_Reset_Form_Button(sender As Object, e As EventArgs) Handles btnCRIReset.Click
        Staff_Menu_Interface_Disable_Controls()
        Staff_Menu_Interface_Hide_Extended_Panes()
        Customer_Registration_Interface_Hide_Side_Panel_Controller()

        Dim res As DialogResult = MessageBox.Show("The form will revert to its original state. Any changes will not be saved. Continue?", "Reset form.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            Customer_Registration_Interface_Reset_Form()
            Staff_Menu_Interface_Enable_Controls()

        Else
            Staff_Menu_Interface_Enable_Controls()
        End If


    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_CLOSE_FORM
    '##################################################################################################################################################################################################

    Private Sub Customer_Registration_Interface_Close_Form_Button(sender As Object, e As EventArgs) Handles btnCRICancel.Click
        Staff_Menu_Interface_Disable_Controls()
        Staff_Menu_Interface_Hide_Extended_Panes()
        Customer_Registration_Interface_Hide_Side_Panel_Controller()

        Dim res As DialogResult = MessageBox.Show("This form will close and any changes will not be saved. Continue?", "Closing form.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            Customer_Registration_Interface_Hide_Form()
            Staff_Menu_Interface_Enable_Controls()
        Else
            Staff_Menu_Interface_Enable_Controls()
        End If
    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_DATABASE_CONNECTION
    '##################################################################################################################################################################################################

    Sub Customer_Registration_Interface_Database_Initial_Load()
        crProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        crSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        crCon.ConnectionString = crProvider & crSource
    End Sub

    Sub Customer_Registration_Interface_crGenderList_Load()
        Dim gd As New OleDb.OleDbCommandBuilder(crGenderDa)

        crCon.Open()
        crGenderSql = "SELECT * FROM GENDER_T"
        crGenderDa = New OleDb.OleDbDataAdapter(crGenderSql, crCon)
        crGenderDa.Fill(crGenderDs, "crGenderList")
        crCon.Close()

        For i = 0 To crGenderDs.Tables("crGenderList").Rows.Count - 1
            dbxCRIGender.Items.Add(crGenderDs.Tables("crGenderList").Rows(i).Item(0).ToString)
        Next
    End Sub

    Sub Customer_Registration_Interface_crCountryList_Load()
        Dim ct As New OleDb.OleDbCommandBuilder(crCountryDa)

        crCon.Open()
        crCountrySql = "SELECT * FROM COUNTRY_T"
        crCountryDa = New OleDb.OleDbDataAdapter(crCountrySql, crCon)
        crCountryDa.Fill(crCountryDs, "crCountryList")
        crCon.Close()

        For i = 0 To crCountryDs.Tables("crCountryList").Rows.Count - 1
            dbxCRICountry.Items.Add(crCountryDs.Tables("crCountryList").Rows(i).Item(0).ToString)
        Next
    End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_REPOSITORY
    '##################################################################################################################################################################################################

    Sub Customer_Registration_Interface_Hide_Form()
        Me.Visible = False
        Customer_Registration_Interface_Reset_Form()
    End Sub

    Sub Customer_Registration_Interface_Reset_Form()
        Dim final As String = "C00000"
        Dim ld As New OleDb.OleDbCommandBuilder(crCustDa)
        Customer_Registration_Interface_crCustList_Load()

        For i = 0 To crCustDs.Tables("crCustList").Rows.Count - 1
            Dim check As String = crCustDs.Tables("crCustList").Rows(i).Item(0).ToString
            Dim store As String = String.Format("C{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
            If check = store Then
                Customer_Registration_Interface_Customer_ID_Increment()
                store = String.Format("C{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "C99999" Then
                MsgBox("The system has reached its boundary of reserved records. Unless the system is updated to allow more than 10,000 records, the application will no longer accept registration.")
                Me.Visible = False
            End If
        Next

        txtCRICID.Text = final
        txtCRICDate.Text = Format(Now, "dd/MM/yyyy")
        txtCRICTime.Text = Format(Now, "HH:mm:ss")
        Customer_Registration_Interface_Reset_Customer_ID_Increment()
        final = "C00000"

        txtCRIFName.Text = ""
        txtCRILName.Text = ""
        dtpCRIDOB.Value = "23/07/2001"
        dbxCRIGender.SelectedIndex = -1
        dbxCRIGender.Text = "Select"
        txtCRIEmail.Text = ""
        txtCRIPhone.Text = ""
        txtCRIStreet.Text = ""
        txtCRICity.Text = ""
        txtCRIState.Text = ""
        txtCRIPostcode.Text = ""
        dbxCRICountry.SelectedIndex = -1
        dbxCRICountry.Text = "Select"

        lblCRIFNameWarn.Text = "null"
        lblCRILNameWarn.Text = "null"
        lblCRIDOBWarn.Text = "null"
        lblCRIGenderWarn.Text = "null"
        lblCRIEmailWarn.Text = "null"
        lblCRIPhoneWarn.Text = "null"
        lblCRIStreetWarn.Text = "null"
        lblCRICityWarn.Text = "null"
        lblCRIStateWarn.Text = "null"
        lblCRIPostcodeWarn.Text = "null"
        lblCRICountryWarn.Text = "null"

        For Each lbl As Bunifu.UI.WinForms.BunifuLabel In {lblCRIFNameWarn, lblCRILNameWarn, lblCRIDOBWarn, lblCRIGenderWarn, lblCRIEmailWarn, lblCRIPhoneWarn, lblCRIStreetWarn, lblCRICityWarn, lblCRIStateWarn, lblCRIPostcodeWarn, lblCRICountryWarn}
            lbl.Visible = False
        Next

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

    Sub Staff_Menu_Interface_Hide_Extended_Panes()                                                                      'Hiding extended panes during certain events
        For Each panel In {staffmenu.panSMIOrd, staffmenu.panSMICust, staffmenu.panSMIMisc}        'Assigning affected panes into panel array
            staffmenu.trSMIVertS.HideSync(panel)                                                                        'Hiding every affected panes
        Next
    End Sub

    Sub Customer_Registration_Interface_Controls_Load()
        trCRIHorizS.ShowSync(panCRISideSm)
    End Sub

    Sub Customer_Registration_Interface_Show_Side_Panel_Controller()
        trCRIHorizS.HideSync(panCRISideSm)
        trCRIHorizS.ShowSync(panCRISide)
    End Sub

    Sub Customer_Registration_Interface_Hide_Side_Panel_Controller()
        trCRIHorizS.HideSync(panCRISide)
        trCRIHorizS.ShowSync(panCRISideSm)
    End Sub

    '#######################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_ENABLE/DISABLE_CONTROLS

    Sub Staff_Menu_Interface_Enable_Controls()      'Enable interactable controls during certain events
        btniCRISideS.Enabled = True                 'Enable Side extensible pane button
        txtCRIFName.Enabled = True                  'Enable First name textbox
        txtCRILName.Enabled = True                  'Enable Last name textbox
        dtpCRIDOB.Enabled = True                    'Enable DOB date time picker
        dbxCRIGender.Enabled = True                 'Enable Gender dropdown box
        txtCRIEmail.Enabled = True                  'Enable Email address textbox
        txtCRIPhone.Enabled = True                  'Enable Phone number textbox
        txtCRIStreet.Enabled = True                 'Enable Street address textbox
        txtCRICity.Enabled = True                   'Enable City address textbox
        txtCRIState.Enabled = True                  'Enable State address textbox
        txtCRIPostcode.Enabled = True               'Enable Postcode address textbox
        dbxCRICountry.Enabled = True                'Enable Country dropdown box
        staffmenu.btnSMIClose.Enabled = True        'Enable Close application button
        staffmenu.btnSMIMin.Enabled = True          'Enable Minimise application button
        staffmenu.btnSMIOrd.Enabled = True          'Enable Order button
        staffmenu.btnSMICust.Enabled = True         'Enable Customer button
        staffmenu.btnSMIMisc.Enabled = True         'Enable Miscellaneous button
    End Sub

    Sub Staff_Menu_Interface_Disable_Controls()     'Disable interactable controls during certain events
        btniCRISideS.Enabled = False                'Disable Side extensible pane button
        txtCRIFName.Enabled = False                 'Disable First name textbox
        txtCRILName.Enabled = False                 'Disable Last name textbox
        dtpCRIDOB.Enabled = False                   'Disable DOB date time picker
        dbxCRIGender.Enabled = False                'Disable Gender dropdown box
        txtCRIEmail.Enabled = False                 'Disable Email address textbox
        txtCRIPhone.Enabled = False                 'Disable Phone number textbox
        txtCRIStreet.Enabled = False                'Disable Street address textbox
        txtCRICity.Enabled = False                  'Disable City address textbox
        txtCRIState.Enabled = False                 'Disable State address textbox
        txtCRIPostcode.Enabled = False              'Disable Postcode address textbox
        dbxCRICountry.Enabled = False               'Disable Country dropdown box
        staffmenu.btnSMIClose.Enabled = False       'Disable Close application button
        staffmenu.btnSMIMin.Enabled = False         'Disable Minimise application button
        staffmenu.btnSMIOrd.Enabled = False         'Disable Order button
        staffmenu.btnSMICust.Enabled = False        'Disable Customer button
        staffmenu.btnSMIMisc.Enabled = False        'Disable Miscellaneous button
    End Sub

    '##########################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_UNUSED_SUB

    'Private Sub Customer_Registration_Interface_Open_Pane_Validation(sender As Object, e As EventArgs) Handles txtCRIFName.TextChanged, txtCRILName.TextChanged,
    '    txtCRIEmail.TextChanged, txtCRIPhone.TextChanged, txtCRIStreet.TextChanged, txtCRICity.TextChanged, txtCRIState.TextChanged, txtCRIPostcode.TextChanged

    '    If txtCRIFName.Text.Length <> 0 And lblCRIFNameWarn.Visible <> True And
    '       txtCRILName.Text.Length <> 0 And lblCRILNameWarn.Visible <> True And
    '       txtCRIEmail.Text.Length <> 0 And lblCRIEmailWarn.Visible <> True And
    '       txtCRIPhone.Text.Length <> 0 And lblCRIPhoneWarn.Visible <> True And
    '       txtCRIStreet.Text.Length <> 0 And lblCRIStreetWarn.Visible <> True And
    '       txtCRICity.Text.Length <> 0 And lblCRICityWarn.Visible <> True And
    '       txtCRIState.Text.Length <> 0 And lblCRIStateWarn.Visible <> True And
    '       txtCRIPostcode.Text.Length <> 0 And lblCRIPostcodeWarn.Visible <> True Then
    '        Customer_Registration_Interface_Show_Side_Panel_Controller()
    '    Else
    '        Customer_Registration_Interface_Hide_Side_Panel_Controller()
    '    End If
    'End Sub

    '##################################################################################################################################################################################################
    '##########_CUSTOMER_REGISTRATION_INTERFACE_END
    '##################################################################################################################################################################################################

End Class