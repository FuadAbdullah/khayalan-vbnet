Public Class receiptorder


    'For database connection use
    Public roCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Public roProvider, roSource, roHisSql, roFinalSql, roClearSql As String     'Declaring database retrieval keywords
    Public roHisDs As DataSet = New DataSet("roHisList")                     'Create a new data container for fetched data
    Public roFinalDs As DataSet = New DataSet("roFinalList")                       'Create a new data container for fetched data
    Public roClearDs As DataSet = New DataSet("roClearList")                                       'Create a new data container for fetched data
    Public roHisDa, roFinalDa, roClearDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------


    Private Sub ROI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load

        ROI_Elipse_Set()

    End Sub

    Private Sub btnROIComplete_Click(sender As Object, e As EventArgs) Handles btnROIComplete.Click
        ROI_Clear_TEMP_T()
        ROI_Clear_TEMP_T_Refresh()
        ROI_Reset_Controls()
    End Sub

    Sub ROI_Clear_TEMP_T()

        ROI_Database_Initial_Load()

        Dim cbClear As New OleDb.OleDbCommandBuilder(roclearda)

        roCon.Open()
        roClearSql = "SELECT * FROM TEMP_T"

        roclearda = New OleDb.OleDbDataAdapter(roClearSql, roCon)
        roClearDa.Fill(roClearDs, "roClearList")
        roCon.Close()

        ROI_roClearList_Clear()

    End Sub

    Sub ROI_roClearList_Clear()

        Dim cbClear As New OleDb.OleDbCommandBuilder(roClearDa)

        For i = 0 To roClearDs.Tables("roClearList").Rows.Count - 1

            roClearDs.Tables("roClearList").Rows(0).Delete()

            roClearDa.Update(roClearDs, "roClearList")

        Next

    End Sub

    Sub ROI_Clear_TEMP_T_Refresh()

        ROI_Database_Initial_Load()

        roClearDs.Tables("roClearList").Clear()

        Dim cbClear As New OleDb.OleDbCommandBuilder(roClearDa)

        roCon.Open()
        roClearSql = "SELECT * FROM TEMP_T"

        roClearDa = New OleDb.OleDbDataAdapter(roClearSql, roCon)
        roClearDa.Fill(roClearDs, "roClearList")
        roCon.Close()

    End Sub

    Sub ROI_Reset_Controls()
        lblROICID.Text = "C00000"
        lblROIOID.Text = "O00000"
        lblROISID.Text = "S000"
        lblROISID.Text = "S000"

        lblROIDate.Text = "dd/MM/yyyy, HH:mm:ss"
        lblROICName.Text = "John Doe"

        lblROIPayable.Text = "RM0.00"
        lblROITax.Text = "RM0.00"
        lblROIPaid.Text = "RM0.00"
        lblROIChange.Text = "RM0.00"
        txtROIRemarks.Text = ""

    End Sub

    Public Sub ROI_Database_Initial_Load()

        roProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        roSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        roCon.ConnectionString = roProvider & roSource

    End Sub

    Public Sub ROI_roHisDs_Load()

        ROI_Database_Initial_Load()

        Dim cbCust As New OleDb.OleDbCommandBuilder(roHisDa)

        roCon.Open()
        roHisSql = "SELECT *
                     FROM ORDER_T
                     WHERE ord_id = '" & lblROIOID.Text & "'"

        roHisDa = New OleDb.OleDbDataAdapter(roHisSql, roCon)
        roHisDa.Fill(roHisDs, "roHisList")
        roCon.Close()

    End Sub

    Public Sub ROI_roHisDs_Refresh_From_POI()

        ROI_Database_Initial_Load()

        roHisDs.Tables("roHisList").Clear()


        Dim cbCust As New OleDb.OleDbCommandBuilder(roHisDa)

        roCon.Open()
        roHisSql = "SELECT *
                     FROM ORDER_T
                     WHERE ord_id = '" & lblROIOID.Text & "'"

        roHisDa = New OleDb.OleDbDataAdapter(roHisSql, roCon)
        roHisDa.Fill(roHisDs, "roHisList")
        roCon.Close()

    End Sub

    Public Sub ROI_roFinalDs_Load()

        ROI_Database_Initial_Load()

        Dim cbFinal As New OleDb.OleDbCommandBuilder(roFinalDa)

        roCon.Open()
        roFinalSql = "SELECT DISTINCT item_name,
                                      item_type,
                                      item_price,
                                      item_qty,
                                      item_total
                     FROM ORDER_T
                     WHERE ord_id = '" & lblROIOID.Text & "'"

        roFinalDa = New OleDb.OleDbDataAdapter(roFinalSql, roCon)
        roFinalDa.Fill(roFinalDs, "roFinalList")
        roCon.Close()

    End Sub

    Public Sub ROI_roFinalDs_Refresh_From_POI()

        ROI_Database_Initial_Load()

        roFinalDs.Tables("roFinalList").Clear()

        Dim cbFinal As New OleDb.OleDbCommandBuilder(roFinalDa)


        roCon.Open()
        roFinalSql = "SELECT DISTINCT item_name,
                                      item_type,
                                      item_price,
                                      item_qty,
                                      item_total
                     FROM ORDER_T
                     WHERE ord_id = '" & lblROIOID.Text & "'"

        roFinalDa = New OleDb.OleDbDataAdapter(roFinalSql, roCon)
        roFinalDa.Fill(roFinalDs, "roFinalList")
        roCon.Close()

        dgvROIFinal.DataSource = roFinalDs.Tables("roFinalList")
        dgvROIFinal.Refresh()
    End Sub



    Sub ROI_Elipse_Set()

        Dim elROI As Bunifu.Framework.UI.BunifuElipse = New Bunifu.Framework.UI.BunifuElipse
        elROI.ApplyElipse(panROIBack, 20)
        elROI.ApplyElipse(panROISummary, 20)
        elROI.ApplyElipse(panROIHeader, 20)

    End Sub

End Class