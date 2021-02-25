Imports System.Data.OleDb
Public Class customerselection

    Dim searchInput As String
    Dim one, ten, hundred, thousand, tthousand As Integer


    'For database connection use
    Dim csCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim csProvider, csSource, csCustSql, csOrdSql As String     'Declaring database retrieval keywords
    Dim csCustDs As DataSet = New DataSet("csCustList")                       'Create a new data container for fetched data                                    'Create a new data container for fetched data
    Dim csOrdDs As DataSet = New DataSet("csOrdList")                       'Create a new data container for fetched data                                    'Create a new data container for fetched data                      'Create a new data container for fetched data                                    'Create a new data container for fetched data
    Dim csCustDa, csOrdDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    Private Sub CSI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        CSI_Elipse_Set()
        CSI_Database_Initial_Load()
        CSI_csCustList_Load()
        CSI_csOrdList_Load()
        CSI_Populate_Criteria_Selection_DropDownBox()
    End Sub

    Sub CSI_Elipse_Set()
        Dim elCPI As Bunifu.Framework.UI.BunifuElipse = New Bunifu.Framework.UI.BunifuElipse
        elCPI.ApplyElipse(panCSIBack, 20)
        elCPI.ApplyElipse(panCSIHeader, 20)

    End Sub

    Sub CSI_Database_Initial_Load()
        csProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        csSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        csCon.ConnectionString = csProvider & csSource
    End Sub

    Sub CSI_csCustList_Load()
        Dim cbCust As New OleDb.OleDbCommandBuilder(csCustDa)

        csCon.Open()
        csCustSql = "SELECT * FROM CUSTOMER_T"
        csCustDa = New OleDb.OleDbDataAdapter(csCustSql, csCon)
        csCustDa.Fill(csCustDs, "csCustList")
        csCon.Close()
    End Sub

    Sub CSI_csOrdList_Load()
        Dim cbOrd As New OleDb.OleDbCommandBuilder(csOrdDa)

        csCon.Open()
        csOrdSql = "SELECT * FROM ORDER_T"
        csOrdDa = New OleDb.OleDbDataAdapter(csOrdSql, csCon)
        csOrdDa.Fill(csOrdDs, "csOrdList")
        csCon.Close()
    End Sub

    Public Sub CSI_csOrdList_Refresh()

        csOrdDs.Tables("csOrdlist").Clear()

        Dim cbOrd As New OleDb.OleDbCommandBuilder(csOrdDa)

        csCon.Open()
        csOrdSql = "SELECT * FROM ORDER_T"
        csOrdDa = New OleDb.OleDbDataAdapter(csOrdSql, csCon)
        csOrdDa.Fill(csOrdDs, "csOrdList")
        csCon.Close()
    End Sub

    Sub CSI_csCustList_Fetch_ID()

        csCustDs.Tables("csCustList").Clear()

        csCon.Open()
        csCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_id = '" & searchInput & "'"
        csCustDa = New OleDb.OleDbDataAdapter(csCustSql, csCon)
        csCustDa.Fill(csCustDs, "csCustList")
        csCon.Close()

    End Sub

    Sub CSI_csCustList_Fetch_Name()

        csCustDs.Tables("csCustList").Clear()

        csCon.Open()
        csCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_first_name & "" "" & cust_last_name = '" & searchInput & "' "
        csCustDa = New OleDb.OleDbDataAdapter(csCustSql, csCon)
        csCustDa.Fill(csCustDs, "csCustList")
        csCon.Close()

    End Sub

    Sub CSI_csCustList_Fetch_Email()

        csCustDs.Tables("csCustList").Clear()

        csCon.Open()
        csCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_email = '" & searchInput & "' "
        csCustDa = New OleDb.OleDbDataAdapter(csCustSql, csCon)
        csCustDa.Fill(csCustDs, "csCustList")
        csCon.Close()

    End Sub

    Sub CSI_csCustList_Fetch_Phone()

        csCustDs.Tables("csCustList").Clear()

        csCon.Open()
        csCustSql = "SELECT * FROM CUSTOMER_T WHERE cust_phone = '" & searchInput & "' "
        csCustDa = New OleDb.OleDbDataAdapter(csCustSql, csCon)
        csCustDa.Fill(csCustDs, "csCustList")
        csCon.Close()

    End Sub

    Sub CSI_Populate_Criteria_Selection_DropDownBox()
        dbxCSICriteria.Items.Add("Customer ID")
        dbxCSICriteria.Items.Add("Name")
        dbxCSICriteria.Items.Add("Email Address")
        dbxCSICriteria.Items.Add("Phone Number")
    End Sub







    Private Sub CSI_Criteria_Selection_DropDownBox(sender As Object, e As EventArgs) Handles dbxCSICriteria.SelectedIndexChanged

        If dbxCSICriteria.Text <> "Search by" Then
            CSI_Criteria_Selection_Check()
            txtCSISearch.Enabled = True
        End If

    End Sub

    Sub CSI_Criteria_Selection_Check()
        If dbxCSICriteria.Text = "Customer ID" Then
            pbrCSIStep.Value = 30
            txtCSISearch.PlaceholderText = "C00000"
            txtCSISearch.Text = ""
            trCSIVertS.ShowSync(txtCSISearch)
        ElseIf dbxCSICriteria.Text = "Name" Then
            pbrCSIStep.Value = 30
            txtCSISearch.PlaceholderText = "John Doe"
            txtCSISearch.Text = ""
            trCSIVertS.ShowSync(txtCSISearch)
        ElseIf dbxCSICriteria.Text = "Email Address" Then
            pbrCSIStep.Value = 30
            txtCSISearch.PlaceholderText = "john_doe@mail.com"
            txtCSISearch.Text = ""
            trCSIVertS.ShowSync(txtCSISearch)
        ElseIf dbxCSICriteria.Text = "Phone Number" Then
            pbrCSIStep.Value = 30
            txtCSISearch.PlaceholderText = "+017-650 3929"
            txtCSISearch.Text = ""
            trCSIVertS.ShowSync(txtCSISearch)
        End If
    End Sub

    Private Sub CSI_Search_TextBox(sender As Object, e As EventArgs) Handles txtCSISearch.TextChanged
        If txtCSISearch.Text <> vbNullString Then
            btnCSISearch.Visible = True
            pbrCSIStep.Value = 60
        Else
            btnCSISearch.Visible = False
        End If
    End Sub

    Private Sub CSI_Search_Button(sender As Object, e As EventArgs) Handles btnCSISearch.Click
        pbrCSIStep.Value = 90
        panCSINotice.BringToFront()
        CSI_csOrdList_Refresh()
        searchInput = txtCSISearch.Text

        If dbxCSICriteria.Text = "Customer ID" And txtCSISearch.Text <> vbNullString Then
            CSI_csCustList_Fetch_ID()
            CSI_Load_Customer_Details()
        ElseIf dbxCSICriteria.Text = "Name" And txtCSISearch.Text <> vbNullString Then
            CSI_csCustList_Fetch_Name()
            CSI_Load_Customer_Details()
        ElseIf dbxCSICriteria.Text = "Email Address" And txtCSISearch.Text <> vbNullString Then
            CSI_csCustList_Fetch_Email()
            CSI_Load_Customer_Details()
        ElseIf dbxCSICriteria.Text = "Phone Number" And txtCSISearch.Text <> vbNullString Then
            CSI_csCustList_Fetch_Phone()
            CSI_Load_Customer_Details()
        Else
            CSI_Disable_Buttons()
            Dim res As DialogResult = MessageBox.Show("You cannot leave the search box blank. Insert a valid input and try again.", "Empty search", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                CSI_Enable_Buttons()
            End If
        End If

    End Sub

    Sub CSI_Load_Customer_Details()

        Try
            CSI_Reset_Fields()

            Dim isDeleted As String = "null"

            isDeleted = csCustDs.Tables("csCustList").Rows(0).Item(15)

            If isDeleted = "No" Then
                trCSIVertS.ShowSync(panCSINotice)

                txtCSICID.Text = csCustDs.Tables("csCustList").Rows(0).Item(0)
                txtCSICName.Text = csCustDs.Tables("csCustList").Rows(0).Item(1) & " " & csCustDs.Tables("csCustList").Rows(0).Item(2)
                txtCSICEmail.Text = csCustDs.Tables("csCustList").Rows(0).Item(5)
                txtCSICPhone.Text = csCustDs.Tables("csCustList").Rows(0).Item(6)

            ElseIf isDeleted = "Yes" Then
                CSI_Disable_Buttons()
                Dim res As DialogResult = MessageBox.Show("Cannot access a deleted customer record. Try again.", "Deleted customer.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                If res = DialogResult.OK Then
                    CSI_Enable_Buttons()
                End If

            End If
        Catch ex As Exception
            CSI_Disable_Buttons()
            Dim res As DialogResult = MessageBox.Show("Search cannot find any record by the inserted input. Try again.", "Invalid search.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            If res = DialogResult.OK Then
                CSI_Enable_Buttons()
            End If

            CSI_Reset_Fields()
        End Try

    End Sub


    Sub CSI_Disable_Buttons()
        btnCSICancel.Enabled = False
        btnCSISearch.Enabled = False
        txtCSISearch.Enabled = False
        dbxCSICriteria.Enabled = False
        staffmenu.btnSMIClose.Enabled = False
        staffmenu.btnSMIMin.Enabled = False
    End Sub
    Sub CSI_Enable_Buttons()
        btnCSICancel.Enabled = True
        btnCSISearch.Enabled = True
        txtCSISearch.Enabled = True
        dbxCSICriteria.Enabled = True
        staffmenu.btnSMIClose.Enabled = True
        staffmenu.btnSMIMin.Enabled = True
    End Sub

    Private Sub CSI_Cancel_Ordering_Button(sender As Object, e As EventArgs) Handles btnCSICancel.Click
        staffmenu.trSMIVertS.HideSync(staffmenu.panSMIOrdForm)
        staffmenu.trSMIVertS.ShowSync(staffmenu.panSMIBack)

        For Each form In {foodselection, drinkselection, sidesselection, summaryorder, paymentorder, receiptorder} 'add payment and receipt as well
            form.visible = False
        Next
        Me.Visible = False

        CSI_Reset()
    End Sub

    Private Sub CSI_Wrong_Customer_Button(sender As Object, e As EventArgs) Handles btnCSIDProc.Click
        pbrCSIStep.Value = 60
        CSI_Wrong_Button_Return()
    End Sub

    Private Sub CSI_Correct_Customer_Button(sender As Object, e As EventArgs) Handles btnCSIProc.Click

        Dim final As String = "O00000"


        For i = 0 To csOrdDs.Tables("csOrdList").Rows.Count - 1
            Dim check As String = csOrdDs.Tables("csOrdList").Rows(i).Item(0).ToString
            Dim store As String = String.Format("O{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
            If check = store Then
                CSI_Order_ID_Increment()
                store = String.Format("O{0}{1}{2}{3}{4}", Format(tthousand, "0"), Format(thousand, "0"), Format(hundred, "0"), Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "O99999" Then
                MsgBox("blablabla")
                Me.Visible = False
            End If
        Next

        foodselection.lblFSICID.Text = txtCSICID.Text
        foodselection.lblFSIOID.Text = final

        final = "O00000"
        CSI_Reset_Order_ID_Increment()
        CSI_Reset()
    End Sub

    Sub CSI_Reset()
        panCSINotice.Visible = False
        pbrCSIStep.Value = 0
        txtCSICID.Text = ""
        txtCSICName.Text = ""
        txtCSICEmail.Text = ""
        txtCSICPhone.Text = ""
        dbxCSICriteria.SelectedIndex = -1
        dbxCSICriteria.Text = "Search by"
        txtCSISearch.Text = ""
        txtCSISearch.Visible = False
        txtCSISearch.Enabled = False
        btnCSISearch.Visible = False
    End Sub

    Sub CSI_Wrong_Button_Return()
        trCSIVertS.HideSync(panCSINotice)
        txtCSICID.Text = ""
        txtCSICName.Text = ""
        txtCSICEmail.Text = ""
        txtCSICPhone.Text = ""
        panCSINotice.SendToBack()
    End Sub

    Sub CSI_Reset_Fields()
        txtCSICID.Text = ""
        txtCSICName.Text = ""
        txtCSICEmail.Text = ""
        txtCSICPhone.Text = ""
    End Sub

    Sub CSI_Order_ID_Increment()

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

    Sub CSI_Reset_Order_ID_Increment()

        one = 0
        ten = 0
        hundred = 0
        thousand = 0
        tthousand = 0

    End Sub

End Class