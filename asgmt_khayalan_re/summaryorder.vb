Public Class summaryorder

    'For database connection use
    Public soCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Public soProvider, soSource, soSumSql, soCustSql, soOrdSql As String     'Declaring database retrieval keywords
    Public soSumDs As DataSet = New DataSet("soSumList")                       'Create a new data container for fetched data
    Public soCustDs As DataSet = New DataSet("soCustList")                     'Create a new data container for fetched data
    Public soOrdDs As DataSet = New DataSet("soOrdList")                               'Create a new data container for fetched data
    Public soSumDa, soCustDa, soOrdDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    Private Sub SOI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load

        SOI_Elipse_Set()
        'SOI_Database_Initial_Load()
        'SOI_soSumDs_Load()
        'SOI_soCustDs_Load_()
        'SOI_soOrdList_Load()
        'SOI_Summary_DataGridView_Load()
        'SOI_soSumDs_Load()
        'SOI_soDetDs_Load()
        'SOI_Summary_DataGridView_Load()

    End Sub

    Sub SOI_Database_Initial_Load()

        soProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        soSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        soCon.ConnectionString = soProvider & soSource

    End Sub

    Sub SOI_Elipse_Set()

        Dim elSOI As Bunifu.Framework.UI.BunifuElipse = New Bunifu.Framework.UI.BunifuElipse
        elSOI.ApplyElipse(panSOISummary, 20)
        elSOI.ApplyElipse(panSOIDetails, 20)
        elSOI.ApplyElipse(panSOIHeader, 20)
    End Sub

    Public Sub SOI_soSumDs_Load_From_SSI()

        SOI_Database_Initial_Load()
        Dim cbSum As New OleDb.OleDbCommandBuilder(soSumDa)

        soCon.Open()
        soSumSql = "SELECT item_name AS [Item Name], 
                            item_type AS [Item Type], 
                            item_price AS [Price], 
                            item_qty AS [Quantity], 
                            item_total AS [Total]
                     FROM TEMP_T"

        soSumDa = New OleDb.OleDbDataAdapter(soSumSql, sidesselection.ssCon)
        soSumDa.Fill(soSumDs, "soSumList")
        soCon.Close()

    End Sub

    Public Sub SOI_soCustDs_Load_From_SSI()

        SOI_Database_Initial_Load()
        Dim cbCust As New OleDb.OleDbCommandBuilder(soCustDa)


        soCon.Open()
        soCustSql = "SELECT cust_first_name & "" "" & cust_last_name AS [Customer Name],
                             cust_email AS [Customer Email],
                             cust_phone AS [Customer Phone]
                     FROM CUSTOMER_T
                     WHERE cust_id = '" & lblSOICID.Text & "'"

        soCustDa = New OleDb.OleDbDataAdapter(soCustSql, sidesselection.ssCon)
        soCustDa.Fill(soCustDs, "soCustList")
        soCon.Close()


    End Sub

    Public Sub SOI_soOrdList_Load()
        SOI_Database_Initial_Load()

        Dim cbOrd As New OleDb.OleDbCommandBuilder(soOrdDa)

        soCon.Open()
        soOrdSql = "SELECT * FROM ORDER_T"
        soOrdDa = New OleDb.OleDbDataAdapter(soOrdSql, sidesselection.ssCon)
        soOrdDa.Fill(soOrdDs, "soOrdList")
        soCon.Close()

    End Sub


    Public Sub SOI_soSumDs_Refresh_From_SSI()
        SOI_Database_Initial_Load()

        soSumDs.Tables("soSumList").Clear()


        Dim cbSum As New OleDb.OleDbCommandBuilder(soSumDa)

        soCon.Open()
        soSumSql = "SELECT item_name AS [Item Name], 
                            item_type AS [Item Type], 
                            item_price AS [Price], 
                            item_qty AS [Quantity], 
                            item_total AS [Total]
                     FROM TEMP_T"

        soSumDa = New OleDb.OleDbDataAdapter(soSumSql, sidesselection.ssCon)
        soSumDa.Fill(soSumDs, "soSumList")
        soCon.Close()

        dgvSOISummary.DataSource = soSumDs.Tables("soSumList")
        dgvSOISummary.Refresh()
    End Sub

    Public Sub SOI_soCustDs_Refresh_From_SSI()
        SOI_Database_Initial_Load()

        soCustDs.Tables("soCustList").Clear()

        Dim cbSum As New OleDb.OleDbCommandBuilder(soCustDa)

        soCon.Open()
        soCustSql = "SELECT cust_first_name & "" "" & cust_last_name AS [Customer Name],
                             cust_email AS [Customer Email],
                             cust_phone AS [Customer Phone]
                     FROM CUSTOMER_T
                     WHERE cust_id = '" & lblSOICID.Text & "'"

        soCustDa = New OleDb.OleDbDataAdapter(soCustSql, sidesselection.ssCon)
        soCustDa.Fill(soCustDs, "soCustList")
        soCon.Close()


    End Sub

    Private Sub SOI_To_SSI_Back_Button(sender As Object, e As EventArgs) Handles btniSOItoSSI.Click
        sidesselection.pbrSSIStep.Value = 100
        sidesselection.lblSSITotalAll.Text = txtSOITotalExTax.Text
        sidesselection.lblSSIOID.Text = lblSOIOID.Text
        sidesselection.lblSSICID.Text = lblSOICID.Text
        SOI_Reset_Controls()
    End Sub

    Private Sub SOI_SOI_To_POI_Next_Button(sender As Object, e As EventArgs) Handles btniSOItoPOI.Click
        SOI_Insert_Order()
        POI_Refresh_From_SOI()
        SOI_Reset_Controls()
    End Sub

    Sub POI_Refresh_From_SOI()

        paymentorder.lblPOIOID.Text = lblSOIOID.Text
        paymentorder.lblPOICID.Text = lblSOICID.Text
        paymentorder.POI_poSumDs_Load()
        paymentorder.POI_poSumDs_Refresh_From_SOI()
        paymentorder.POI_poOrdDs_Load()
        paymentorder.POI_poOrdDs_Refresh_From_SOI()
        paymentorder.POI_poHisDs_Load()
        paymentorder.POI_poHisDs_Refresh_From_SOI()
        paymentorder.POI_Load_Details()
        SOI_Reset_Controls()


    End Sub

    Sub SOI_Insert_Order()

        Const taxrate As Double = 0.06
        Dim payable, tax As Double
        Dim dsNewRow As DataRow
        Dim staffID As String = Replace(staffmenu.lblSMIStaID.Text, "Staff ID: ", "")
        payable = Replace(txtSOITotalExTax.Text, "RM", "")
        tax = payable * taxrate

        soOrdDs.Tables("soOrdList").Clear()
        SOI_soOrdList_Load()

        Dim cbOrd As New OleDb.OleDbCommandBuilder(soOrdDa)
        For i = 0 To dgvSOISummary.Rows.Count - 1
            dsNewRow = soOrdDs.Tables("soOrdList").NewRow
            dsNewRow.Item(0) = lblSOIOID.Text
            dsNewRow.Item(1) = lblSOICID.Text
            dsNewRow.Item(2) = staffID
            dsNewRow.Item(3) = txtSOICName.Text
            dsNewRow.Item(4) = txtSOIODate.Text
            dsNewRow.Item(5) = txtSOIOTime.Text
            dsNewRow.Item(6) = dgvSOISummary.Rows(i).Cells(0).Value
            dsNewRow.Item(7) = dgvSOISummary.Rows(i).Cells(1).Value
            dsNewRow.Item(8) = dgvSOISummary.Rows(i).Cells(2).Value
            dsNewRow.Item(9) = dgvSOISummary.Rows(i).Cells(3).Value
            dsNewRow.Item(10) = dgvSOISummary.Rows(i).Cells(4).Value
            dsNewRow.Item(11) = "Confirmed, Not Paid"
            dsNewRow.Item(12) = txtSOITotalExTax.Text
            dsNewRow.Item(13) = "RM" & (Math.Round(tax, 2)).ToString("N2")
            dsNewRow.Item(14) = "RM" & (Math.Round((payable + tax), 2)).ToString("N2")

            soOrdDs.Tables("soOrdList").Rows.Add(dsNewRow)
            soOrdDa.Update(soOrdDs, "soOrdList")
        Next

        tax = 0
        payable = 0

    End Sub

    Sub SOI_Reset_Controls()

        lblSOIOID.Text = "O00000"
        lblSOICID.Text = "C00000"

        txtSOICName.Text = ""
        txtSOICEmail.Text = ""
        txtSOICPhone.Text = ""
        txtSOIODate.Text = ""
        txtSOIOTime.Text = ""

        txtSOITotalExTax.Text = ""
        txtSOITotalPayable.Text = ""



    End Sub

    '33333333333333333333333333333333

    'Sub SOI_Database_Initial_Load()

    '    soProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
    '    soSource = "DATA SOURCE = khayalancafeteriadb.accdb"
    '    soCon.ConnectionString = soProvider & soSource

    'End Sub

    'Sub SOI_soSumDs_Load()


    '    Dim cbSum As New OleDb.OleDbCommandBuilder(soSumDa)

    '    soCon.Open()
    '    soSumSql = "SELECT item_name AS [Item Name], 
    '                        item_type AS [Item Type], 
    '                        item_price AS [Price], 
    '                        item_qty AS [Quantity], 
    '                        item_total AS [Total]
    '                 FROM TEMP_T"

    '    soSumDa = New OleDb.OleDbDataAdapter(soSumSql, soCon)
    '    soSumDa.Fill(soSumDs, "soSumList")
    '    soCon.Close()
    'End Sub


    'Sub SOI_soCustDs_Load_()
    '    Dim cbCust As New OleDb.OleDbCommandBuilder(soCustDa)


    '    soCon.Open()
    '    soCustSql = "SELECT cust_first_name & "" "" & cust_last_name AS [Customer Name],
    '                         cust_email AS [Customer Email],
    '                         cust_phone AS [Customer Phone]
    '                 FROM CUSTOMER_T
    '                 WHERE cust_id = '" & lblSOICID.Text & "'"

    '    soCustDa = New OleDb.OleDbDataAdapter(soCustSql, soCon)
    '    soCustDa.Fill(soCustDs, "soCustList")
    '    soCon.Close()


    'End Sub

    'Sub SOI_soOrdList_Load()

    '    Dim cbOrd As New OleDb.OleDbCommandBuilder(soOrdDa)

    '    soCon.Open()
    '    soOrdSql = "SELECT * FROM ORDER_T"
    '    soOrdDa = New OleDb.OleDbDataAdapter(soOrdSql, soCon)
    '    soOrdDa.Fill(soOrdDs, "soOrdList")
    '    soCon.Close()

    'End Sub


    'Sub SOI_Summary_DataGridView_Load()

    '    dgvSOISummary.DataSource = soSumDs.Tables("soSumList")

    'End Sub

    '33333333333333333333333333333333

End Class