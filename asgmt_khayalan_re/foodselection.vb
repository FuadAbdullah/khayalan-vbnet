
Imports System.Data.OleDb
Public Class foodselection

    '##################################################################################################################################################################################################
    '########## FOOD SELECTION INTERFACE START
    '##################################################################################################################################################################################################
    '########## FOOD SELECTION INTERFACE LOCAL VARIABLE
    '##################################################################################################################################################################################################


    Dim count, one, ten, qty, selectedItemi As Integer
    Dim chickbur, beefbur, fillfish As Integer
    Dim selectedItem, selectedItemName As String
    Dim price, total As Double

    'For database connection use
    Dim fsCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim fsProvider, fsSource, fsTempSql, fsCurrSql, fsTotalSql, fsClearSql, fsClearOrdSql As String     'Declaring database retrieval keywords
    Dim fsTempDs As DataSet = New DataSet("fsTempList")                       'Create a new data container for fetched data
    Dim fsCurrDs As DataSet = New DataSet("fsCurrList")                     'Create a new data container for fetched data
    Dim fsTotalDs As DataSet = New DataSet("fsTotalList")                                       'Create a new data container for fetched data
    Dim fsClearDs As DataSet = New DataSet("fsClearList")                                   'Create a new data container for fetched data
    Dim fsClearOrdDs As DataSet = New DataSet("fsClearOrdList")                                   'Create a new data container for fetched data
    Dim fsTempDa, fsCurrDa, fsTotalDa, fsClearDa, fsClearOrdDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '########## FOOD SELECTION INTERFACE CORE
    '##################################################################################################################################################################################################

    Private Sub FSI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        FSI_Elipse_Set()
        FSI_Database_Initial_Load()
        FSI_fsTempList_Load()
        FSI_fsCurrList_Load()
        FSI_fsTotalList_Load()
        FSI_Load_TEMP_T_For_Deletion()
        FSI_Load_ORDER_T_For_Deletion()
        FSI_Load_Total_All()
    End Sub

    Sub FSI_Elipse_Set()

        Dim elFSI As New Bunifu.Framework.UI.BunifuElipse
        elFSI.ApplyElipse(panFSIMain, 20)
        elFSI.ApplyElipse(panFSIFood, 20)
        elFSI.ApplyElipse(panFSIPrice, 20)
        elFSI.ApplyElipse(panFSITotalAll, 20)
        elFSI.ApplyElipse(panFSIHeader, 20)
    End Sub

    Sub FSI_Database_Initial_Load()
        fsProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        fsSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        fsCon.ConnectionString = fsProvider & fsSource
    End Sub

    Sub FSI_fsTempList_Load()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(fsTempDa)

        fsCon.Open()
        fsTempSql = "SELECT * FROM TEMP_T"
        fsTempDa = New OleDb.OleDbDataAdapter(fsTempSql, fsCon)
        fsTempDa.Fill(fsTempDs, "fsTempList")
        fsCon.Close()
    End Sub

    Sub FSI_fsCurrList_Load()
        Dim cbCurr As New OleDb.OleDbCommandBuilder(fsCurrDa)

        fsCon.Open()
        fsCurrSql = "SELECT * FROM TEMP_T"
        fsCurrDa = New OleDb.OleDbDataAdapter(fsCurrSql, fsCon)
        fsCurrDa.Fill(fsCurrDs, "fsCurrList")
        fsCon.Close()
    End Sub

    Sub FSI_fsTotalList_Load()
        Dim cbTotal As New OleDb.OleDbCommandBuilder(fsTotalDa)

        fsCon.Open()
        fsTotalSql = "SELECT SUM(REPLACE(item_total, 'RM', '') ) AS item_total_all FROM TEMP_T"
        fsTotalDa = New OleDb.OleDbDataAdapter(fsTotalSql, fsCon)
        fsTotalDa.Fill(fsTotalDs, "fsTotalList")
        fsCon.Close()
    End Sub

    Sub FSI_Load_TEMP_T_For_Deletion()

        Dim cbClear As New OleDb.OleDbCommandBuilder(fsClearDa)

        fsCon.Open()
        fsClearSql = "SELECT * FROM TEMP_T"
        fsClearDa = New OleDb.OleDbDataAdapter(fsClearSql, fsCon)
        fsClearDa.Fill(fsClearDs, "fsClearList")
        fsCon.Close()

    End Sub

    Sub FSI_Refresh_TEMP_After_Deletion()

        fsClearDs.Tables("fsClearList").Clear()

        Dim cbClear As New OleDb.OleDbCommandBuilder(fsClearDa)

        fsCon.Open()
        fsClearSql = "SELECT * FROM TEMP_T"
        fsClearDa = New OleDb.OleDbDataAdapter(fsClearSql, fsCon)
        fsClearDa.Fill(fsClearDs, "fsClearList")
        fsCon.Close()

    End Sub

    Sub FSI_Load_ORDER_T_For_Deletion()

        Dim cbClearOrd As New OleDb.OleDbCommandBuilder(fsClearOrdDa)

        fsCon.Open()
        fsClearOrdSql = "SELECT * FROM ORDER_T WHERE ord_id = '" & lblFSIOID.Text & "'"
        fsClearOrdDa = New OleDb.OleDbDataAdapter(fsClearOrdSql, fsCon)
        fsClearOrdDa.Fill(fsClearOrdDs, "fsClearOrdList")
        fsCon.Close()

    End Sub

    Sub FSI_Refresh_ORDER_After_Deletion()

        fsClearOrdDs.Tables("fsClearOrdList").Clear()

        Dim cbClearOrd As New OleDb.OleDbCommandBuilder(fsClearOrdDa)

        fsCon.Open()
        fsClearOrdSql = "SELECT * FROM ORDER_T"
        fsClearOrdDa = New OleDb.OleDbDataAdapter(fsClearOrdSql, fsCon)
        fsClearOrdDa.Fill(fsClearOrdDs, "fsClearOrdList")
        fsCon.Close()

    End Sub

    Sub FSI_Load_Total_All()

        If IsDBNull(fsTotalDs.Tables("fsTotalList").Rows(0).Item(0)) = True Then
            lblFSITotalAll.Text = "RM0.00"
        Else
            lblFSITotalAll.Text = "RM" & Double.Parse(fsTotalDs.Tables("fsTotalList").Rows(0).Item(0)).ToString("N2")
        End If

    End Sub

    Sub FSI_Fetch_Temp_Per_Item()

        fsCurrDs.Tables("fsCurrList").Clear()

        fsCon.Open()
        fsCurrSql = "SELECT * FROM TEMP_T WHERE item_name = '" & selectedItemName & "'"
        fsCurrDa = New OleDb.OleDbDataAdapter(fsCurrSql, fsCon)
        fsCurrDa.Fill(fsCurrDs, "fsCurrList")
        fsCon.Close()

    End Sub

    Private Sub FSI_Add_To_Cart_Button(sender As Object, e As EventArgs) Handles btnFSIAdd.Click

        pbrFSIStep.Value = 100

        If btnFSIAdd.Text = "Add to Cart" Then
            FSI_Insert_fsTempList()
            btnFSIAdd.Text = "Update Cart"
        ElseIf btnFSIAdd.Text = "Update Cart" Then
            FSI_Update_fsTempList()
        End If

        If count = 0 And fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            trFSIVertS.HideSync(btnFSIAdd)
        End If

        fsTotalDs.Tables("fsTotalList").Clear()

        FSI_fsTotalList_Load()

        If IsDBNull(fsTotalDs.Tables("fsTotalList").Rows(0).Item(0)) = True Then
            lblFSITotalAll.Text = "RM0.00"
        Else
            lblFSITotalAll.Text = "RM" & Double.Parse(fsTotalDs.Tables("fsTotalList").Rows(0).Item(0)).ToString("N2")
        End If



    End Sub

    Sub FSI_Insert_fsTempList()

        Dim dsNewRow As DataRow
        FSI_Calculation_Definition()
        Dim final As String = "T00"
        Dim staffID As String = staffmenu.lblSMIStaID.Text

        fsTempDs.Tables("fsTempList").Clear()
        FSI_fsTempList_Load()

        For i = 0 To fsTempDs.Tables("fsTempList").Rows.Count - 1
            Dim check As String = fsTempDs.Tables("fsTempList").Rows(i).Item(0).ToString
            Dim store As String = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
            If check = store Then
                FSI_Temp_ID_Increment()
                store = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "T99" Then
                MsgBox("blablabla")
                Me.Visible = False
            End If
        Next

        Dim cbTemp As New OleDb.OleDbCommandBuilder(fsTempDa)

        If selectedItem = "ChickenBurger" Then
            dsNewRow = fsTempDs.Tables("fsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblFSIOID.Text
            dsNewRow.Item(2) = lblFSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnFSIChickBur.Text
            dsNewRow.Item(5) = "Food"
            dsNewRow.Item(6) = lblFSIPrice.Text
            dsNewRow.Item(7) = lblFSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            fsTempDs.Tables("fsTempList").Rows.Add(dsNewRow)
            fsTempDa.Update(fsTempDs, "fsTempList")

        ElseIf selectedItem = "BeefBurger" Then
            dsNewRow = fsTempDs.Tables("fsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblFSIOID.Text
            dsNewRow.Item(2) = lblFSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnFSIBeefBur.Text
            dsNewRow.Item(5) = "Food"
            dsNewRow.Item(6) = lblFSIPrice.Text
            dsNewRow.Item(7) = lblFSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            fsTempDs.Tables("fsTempList").Rows.Add(dsNewRow)
            fsTempDa.Update(fsTempDs, "fsTempList")

        ElseIf selectedItem = "FilletOFish" Then
            dsNewRow = fsTempDs.Tables("fsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblFSIOID.Text
            dsNewRow.Item(2) = lblFSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnFSIFillFish.Text
            dsNewRow.Item(5) = "Food"
            dsNewRow.Item(6) = lblFSIPrice.Text
            dsNewRow.Item(7) = lblFSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            fsTempDs.Tables("fsTempList").Rows.Add(dsNewRow)
            fsTempDa.Update(fsTempDs, "fsTempList")

        End If

        final = "T00"
        FSI_Calculation_Reset()
        FSI_Reset_Temp_ID_Increment()
        pbrFSIStep.Value = 100

    End Sub

    Sub FSI_Update_fsTempList()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(fsCurrDa)
        FSI_Calculation_Definition()

        If selectedItem = "ChickenBurger" Then
            selectedItemName = btnFSIChickBur.Text
            FSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "BeefBurger" Then
            selectedItemName = btnFSIBeefBur.Text
            FSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "FilletOFish" Then
            selectedItemName = btnFSIFillFish.Text
            FSI_Fetch_Temp_Per_Item()
        End If

        Dim cbUpt As New OleDb.OleDbCommandBuilder(fsCurrDa)

        If qty > 0 Then
            fsCurrDs.Tables("fsCurrList").Rows(0).Item(7) = lblFSICounter.Text
            fsCurrDs.Tables("fsCurrList").Rows(0).Item(8) = "RM" & total.ToString("N2")

            fsCurrDa.Update(fsCurrDs, "fsCurrList")
            fsCurrDs.Tables("fsCurrList").Clear()

        ElseIf qty <= 0 Then
            fsCurrDs.Tables("fsCurrList").Rows(0).Delete()

            fsCurrDa.Update(fsCurrDs, "fsCurrList")
            btnFSIAdd.Text = "Add to Cart"
            fsCurrDs.Tables("fsCurrList").Clear()
        End If

        FSI_Calculation_Reset()
        FSI_Reset_Temp_ID_Increment()
    End Sub

    Private Sub FSI_To_CSI_Cancel_Order_Button(sender As Object, e As EventArgs) Handles btniFSItoCSI.Click
        FSI_Disable_Buttons()

        Dim res As DialogResult = MessageBox.Show("You will cancel the ongoing order. Are you sure?", "Cancelling order", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then
            staffmenu.btnSMIClose.Enabled = True

            customerselection.Visible = True
            Me.Visible = False
            FSI_Load_TEMP_T_For_Deletion()
            FSI_Clear_TEMP_T()

            FSI_Load_ORDER_T_For_Deletion()
            FSI_Clear_ORDER_T()
            FSI_Reset()
            FSI_Reset_Controls()
            FSI_Enable_Buttons()

        Else
            FSI_Enable_Buttons()
        End If

    End Sub

    Sub FSI_Disable_Buttons()
        btniFSItoCSI.Enabled = False
        btniFSItoDSI.Enabled = False
        trFSIVertS.HideSync(panFSIControl)

        For Each btn In {btnFSIChickBur, btnFSIBeefBur, btnFSIFillFish}
            btn.Enabled = False
        Next

    End Sub

    Sub FSI_Enable_Buttons()
        btniFSItoCSI.Enabled = True
        btniFSItoDSI.Enabled = True

        For Each btn In {btnFSIChickBur, btnFSIBeefBur, btnFSIFillFish}
            btn.Enabled = True
        Next
    End Sub

    Private Sub FSI_To_DSI_Next_Button(sender As Object, e As EventArgs) Handles btniFSItoDSI.Click

        drinkselection.lblDSITotalAll.Text = lblFSITotalAll.Text
        drinkselection.lblDSIOID.Text = lblFSIOID.Text
        drinkselection.lblDSICID.Text = lblFSICID.Text
        FSI_Reset()
        FSI_Reset_Controls()

    End Sub

    Private Sub FSI_ChickenBurger_Button(sender As Object, e As EventArgs) Handles btnFSIChickBur.Click
        selectedItemName = btnFSIChickBur.Text
        FSI_Fetch_Temp_Per_Item()

        If fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            btnFSIAdd.Text = "Add to Cart"
        Else
            btnFSIAdd.Text = "Update Cart"
        End If

        selectedItem = "ChickenBurger"
        pbxFSIItem.Image = My.Resources.zzz_chickenburger
        txtFSIDesc.Text = "A tasty chicken burger."
        lblFSIPrice.Text = "RM12.00"
        lblFSICounter.Text = chickbur
        txtFSIManQty.Text = chickbur
        selectedItemi = chickbur
        trFSIVertS.ShowSync(panFSIControl)

        FSI_Calculation_Definition()
        FSI_Total_Per_Item()
        FSI_Empty_Count_Check_DB()


    End Sub

    Private Sub FSI_BeefBurger_Button(sender As Object, e As EventArgs) Handles btnFSIBeefBur.Click
        selectedItemName = btnFSIBeefBur.Text
        FSI_Fetch_Temp_Per_Item()

        If fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            btnFSIAdd.Text = "Add to Cart"
        Else
            btnFSIAdd.Text = "Update Cart"
        End If

        selectedItem = "BeefBurger"
        pbxFSIItem.Image = My.Resources.zzz_beefburger
        txtFSIDesc.Text = "A scrumptious beef burger."
        lblFSIPrice.Text = "RM14.50"
        lblFSICounter.Text = beefbur
        txtFSIManQty.Text = beefbur
        selectedItemi = beefbur
        trFSIVertS.ShowSync(panFSIControl)

        FSI_Calculation_Definition()
        FSI_Total_Per_Item()
        FSI_Empty_Count_Check_DB()


    End Sub

    Private Sub FSI_FilletOFish_Button(sender As Object, e As EventArgs) Handles btnFSIFillFish.Click
        selectedItemName = btnFSIFillFish.Text
        FSI_Fetch_Temp_Per_Item()

        If fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            btnFSIAdd.Text = "Add to Cart"
        Else
            btnFSIAdd.Text = "Update Cart"
        End If

        selectedItem = "FilletOFish"
        pbxFSIItem.Image = My.Resources.zzz_filletofish
        txtFSIDesc.Text = "A fresh dory fish burger."
        lblFSIPrice.Text = "RM11.00"
        lblFSICounter.Text = fillfish
        txtFSIManQty.Text = fillfish
        selectedItemi = fillfish
        trFSIVertS.ShowSync(panFSIControl)

        FSI_Calculation_Definition()
        FSI_Total_Per_Item()
        FSI_Empty_Count_Check_DB()


    End Sub

    Sub FSI_Clear_TEMP_T()

        Dim cbClear As New OleDb.OleDbCommandBuilder(fsClearDa)

        If fsClearDs.Tables("fsClearList").Rows.Count > 0 Then

            For i = 0 To fsClearDs.Tables("fsClearList").Rows.Count - 1

                fsClearDs.Tables("fsClearList").Rows(0).Delete()

                fsClearDa.Update(fsClearDs, "fsClearList")

            Next

        End If

    End Sub

    Sub FSI_Clear_ORDER_T()

        Dim cbClearOrd As New OleDb.OleDbCommandBuilder(fsClearOrdDa)

        If fsClearOrdDs.Tables("fsClearOrdList").Rows.Count > 0 Then

            For i = 0 To fsClearOrdDs.Tables("fsClearOrdList").Rows.Count - 1

                fsClearOrdDs.Tables("fsClearOrdList").Rows(0).Delete()

                fsClearOrdDa.Update(fsClearOrdDs, "fsClearOrdList")

            Next

        End If



    End Sub

    Private Sub FSI_Counter_Increment(sender As Object, e As EventArgs) Handles btniFSIInc.Click

        If selectedItem = "ChickenBurger" Then

            count = chickbur
            count += 1

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            chickbur = count

        ElseIf selectedItem = "BeefBurger" Then

            count = beefbur
            count += 1

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            beefbur = count

        ElseIf selectedItem = "FilletOFish" Then

            count = fillfish
            count += 1

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            fillfish = count

        End If

        FSI_Calculation_Definition()
        FSI_Total_Per_Item()

        If count <> 0 Then
            trFSIVertS.ShowSync(btnFSIAdd)
        End If



    End Sub

    Private Sub FSI_Counter_Decrement(sender As Object, e As EventArgs) Handles btniFSIDec.Click

        If selectedItem = "ChickenBurger" Then
            selectedItemName = btnFSIChickBur.Text
            FSI_Fetch_Temp_Per_Item()

            count = chickbur
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            chickbur = count

        ElseIf selectedItem = "BeefBurger" Then
            selectedItemName = btnFSIBeefBur.Text
            FSI_Fetch_Temp_Per_Item()

            count = beefbur
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            beefbur = count

        ElseIf selectedItem = "FilletOFish" Then
            selectedItemName = btnFSIFillFish.Text
            FSI_Fetch_Temp_Per_Item()

            count = fillfish
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblFSICounter.Text = count
            txtFSIManQty.Text = count
            fillfish = count

        End If

        FSI_Calculation_Definition()
        FSI_Total_Per_Item()

        If count = 0 And fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            trFSIVertS.HideSync(btnFSIAdd)
        End If



    End Sub

    Private Sub FSI_Open_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles lblFSIManQty.Click

        If lblFSIManQty.Text = "Type instead..." Then
            lblFSIManQty.Text = "Hide input..."
            trFSIVertS.ShowSync(panFSIManQty)
            txtFSIManQty.Focus()
            txtFSIManQty.SelectAll()
        ElseIf lblFSIManQty.Text = "Hide input..." Then
            lblFSIManQty.Text = "Type instead..."
            trFSIVertS.HideSync(panFSIManQty)
        End If



    End Sub

    Private Sub FSI_Update_Counter_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles txtFSIManQty.TextChanged

        Try
            If txtFSIManQty.Text.Length = 0 Then
                txtFSIManQty.Text = "0"
            ElseIf txtFSIManQty.Text = "0" Then
                txtFSIManQty.SelectAll()
            End If

            If selectedItem = "ChickenBurger" Then
                chickbur = txtFSIManQty.Text
                selectedItemi = chickbur
                selectedItemName = btnFSIChickBur.Text
                FSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "BeefBurger" Then
                beefbur = txtFSIManQty.Text
                selectedItemi = beefbur
                selectedItemName = btnFSIBeefBur.Text
                FSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "FilletOFish" Then
                fillfish = txtFSIManQty.Text
                selectedItemi = fillfish
                selectedItemName = btnFSIFillFish.Text
                FSI_Fetch_Temp_Per_Item()
            End If

            count = txtFSIManQty.Text
            lblFSICounter.Text = txtFSIManQty.Text

            FSI_Calculation_Definition()
            FSI_Total_Per_Item()
            FSI_Empty_Count_Check_DB()

        Catch ex As Exception

            MsgBox("Invalid input")
            txtFSIManQty.Text = "0"

        End Try



    End Sub

    Sub FSI_Temp_ID_Increment()

        one += 1
        If one = 10 Then
            ten += 1
            one = 0
        ElseIf ten = 10 Then
            one = 0
            ten = 0
        End If

    End Sub

    Sub FSI_Calculation_Definition()

        price = Replace(lblFSIPrice.Text, "RM", "")
        qty = Integer.Parse(lblFSICounter.Text)
        total = price * qty

    End Sub

    Sub FSI_Calculation_Reset()

        price = 0
        qty = 0
        total = 0

    End Sub

    Sub FSI_Reset_Temp_ID_Increment()

        one = 0
        ten = 0

    End Sub

    Sub FSI_Empty_Count_Check_DB()

        If selectedItemi <> 0 Or fsCurrDs.Tables("fsCurrList").Rows.Count > 0 Then
            trFSIVertS.ShowSync(btnFSIAdd)
        ElseIf selectedItemi = 0 And fsCurrDs.Tables("fsCurrList").Rows.Count = 0 Then
            trFSIVertS.HideSync(btnFSIAdd)
        End If

    End Sub

    Sub FSI_Total_Per_Item()

        lblFSITotal.Text = "RM" & total.ToString("N2")

    End Sub

    Sub FSI_Reset()

        count = 0
        one = 0
        ten = 0
        qty = 0

        chickbur = 0
        beefbur = 0
        fillfish = 0

        selectedItemi = 0
        selectedItem = ""
        selectedItemName = ""

        price = 0
        total = 0


    End Sub

    'Sub FSI_Cancel_Order()

    '    FSI_Clear_All_Datasets()
    '    FSI_fsTempList_Load()

    '    Dim cbDelAll As New OleDb.OleDbCommandBuilder(fsTempDa)

    '    For i = 0 To fsTempDs.Tables("fsTempList").Rows.Count - 1
    '        fsTempDs.Tables("fsTempList").Rows(i).Delete()
    '    Next

    '    fsTempDa.Update(fsTempDs, "fsTempList")
    '    fsTempDs.Tables("fsTempList").Clear()

    'End Sub

    Sub FSI_Clear_All_Datasets()

        fsTempDs.Tables("fsTempList").Clear()
        fsCurrDs.Tables("fsCurrList").Clear()
        fsTotalDs.Tables("fsTotalList").Clear()

    End Sub

    Sub FSI_Reset_Controls()

        panFSIControl.Visible = False

        lblFSIManQty.Text = "Type instead..."
        panFSIManQty.Visible = False
        txtFSIManQty.Text = "0"

        btnFSIAdd.Visible = False
        btnFSIAdd.Text = "Add to Cart"
        lblFSITotal.Text = "RM0.00"

        pbxFSIItem.Image = My.Resources._001_bbq
        lblFSIPrice.Text = "Select a food"
        txtFSIDesc.Text = ""
        lblFSITotalAll.Text = "RM0.00"

        pbrFSIStep.Value = 0

        lblFSIOID.Text = "O00000"
        lblFSICID.Text = "C00000"

    End Sub

End Class