Public Class sidesselection

    '##################################################################################################################################################################################################
    '########## SIDES SELECTION INTERFACE START
    '##################################################################################################################################################################################################
    '########## SIDES SELECTION INTERFACE LOCAL VARIABLE
    '##################################################################################################################################################################################################

    Dim count, one, ten, qty, selectedItemi As Integer
    Dim frenchfriess, curlyfriess, onionringss As Integer
    Dim selectedItem, selectedItemName As String
    Dim price, total As Double

    'For database connection use
    Public ssCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim ssProvider, ssSource, ssTempSql, ssCurrSql, ssTotalSql As String     'Declaring database retrieval keywords
    Dim ssTempDs As DataSet = New DataSet("ssTempList")                       'Create a new data container for fetched data
    Dim ssCurrDs As DataSet = New DataSet("ssCurrList")                     'Create a new data container for fetched data
    Dim ssTotalDs As DataSet = New DataSet("ssTotalList")                                       'Create a new data container for fetched data
    'Dim soSumDs As DataSet = New DataSet("soSumList")                                       'Create a new data container for fetched data
    Dim ssTempDa, ssCurrDa, ssTotalDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '########## SIDES SELECTION INTERFACE CORE
    '##################################################################################################################################################################################################


    Private Sub SSI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        SSI_Elipse_Set()
        SSI_Database_Initial_Load()
        SSI_ssTempList_Load()
        SSI_ssCurrList_Load()
        SSI_ssTotalList_Load()
        'SOI_soSumList_Load()
        SSI_Load_Total_All()
    End Sub

    Sub SSI_Elipse_Set()

        Dim elSSI As New Bunifu.Framework.UI.BunifuElipse
        elSSI.ApplyElipse(panSSIMain, 20)
        elSSI.ApplyElipse(panSSIFood, 20)
        elSSI.ApplyElipse(panSSIPrice, 20)
        elSSI.ApplyElipse(panSSITotalAll, 20)
        elSSI.ApplyElipse(panSSIHeader, 20)

    End Sub

    Sub SSI_Database_Initial_Load()
        ssProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        ssSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        ssCon.ConnectionString = ssProvider & ssSource
    End Sub

    Sub SSI_ssTempList_Load()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(ssTempDa)

        ssCon.Open()
        ssTempSql = "SELECT * FROM TEMP_T"
        ssTempDa = New OleDb.OleDbDataAdapter(ssTempSql, ssCon)
        ssTempDa.Fill(ssTempDs, "ssTempList")
        ssCon.Close()
    End Sub

    Sub SSI_ssCurrList_Load()
        Dim cbCurr As New OleDb.OleDbCommandBuilder(ssCurrDa)

        ssCon.Open()
        ssCurrSql = "SELECT * FROM TEMP_T"
        ssCurrDa = New OleDb.OleDbDataAdapter(ssCurrSql, ssCon)
        ssCurrDa.Fill(ssCurrDs, "ssCurrList")
        ssCon.Close()
    End Sub

    Sub SSI_ssTotalList_Load()
        Dim cbTotal As New OleDb.OleDbCommandBuilder(ssTotalDa)

        ssCon.Open()
        ssTotalSql = "SELECT SUM(REPLACE(item_total, 'RM', '') ) AS item_total_all FROM TEMP_T"
        ssTotalDa = New OleDb.OleDbDataAdapter(ssTotalSql, ssCon)
        ssTotalDa.Fill(ssTotalDs, "ssTotalList")
        ssCon.Close()
    End Sub

    Sub SSI_Load_Total_All()

        If IsDBNull(ssTotalDs.Tables("ssTotalList").Rows(0).Item(0)) = True Then
            lblSSITotalAll.Text = "RM0.00"
        Else
            lblSSITotalAll.Text = "RM" & Double.Parse(ssTotalDs.Tables("ssTotalList").Rows(0).Item(0)).ToString("N2")
        End If

    End Sub

    Sub SSI_Fetch_Temp_Per_Item()

        ssCurrDs.Tables("ssCurrList").Clear()

        ssCon.Open()
        ssCurrSql = "SELECT * FROM TEMP_T WHERE item_name = '" & selectedItemName & "'"
        ssCurrDa = New OleDb.OleDbDataAdapter(ssCurrSql, ssCon)
        ssCurrDa.Fill(ssCurrDs, "ssCurrList")
        ssCon.Close()

    End Sub

    'Sub SOI_soSumList_Load()
    '    Dim cbSum As New OleDb.OleDbCommandBuilder(soSumDa)

    '    summaryorder.soSumDs.Tables("ssTotalList").Clear()

    '    ssCon.Open()
    '    soSumSql = "SELECT * FROM TEMP_T"
    '    soSumDa = New OleDb.OleDbDataAdapter(soSumSql, ssCon)
    '    soSumDa.Fill(soSumDs, "ssTotalList")
    '    ssCon.Close()
    'End Sub

    Sub SOI_soSumList_Refresh()

        Dim cbSum As New OleDb.OleDbCommandBuilder(summaryorder.soSumDa)

        ssCon.Open()
        summaryorder.soSumSql = "SELECT item_name AS [Item Name], 
                                    item_type AS [Item Type], 
                                    item_price AS [Price], 
                                    item_qty AS [Quantity], 
                                    item_total AS [Total]
                                 FROM TEMP_T"
        summaryorder.soSumDa = New OleDb.OleDbDataAdapter(summaryorder.soSumSql, ssCon)
        summaryorder.soSumDa.Fill(summaryorder.soSumDs, "soSumList")
        ssCon.Close()

    End Sub

    Private Sub SSI_Add_To_Cart_Button(sender As Object, e As EventArgs) Handles btnSSIAdd.Click

        pbrSSIStep.Value = 100

        If btnSSIAdd.Text = "Add to Cart" Then
            SSI_Insert_dsTempList()
            btnSSIAdd.Text = "Update Cart"
        ElseIf btnSSIAdd.Text = "Update Cart" Then
            SSI_Update_dsTempList()
        End If

        If count = 0 And ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            trSSIVertS.HideSync(btnSSIAdd)
        End If

        ssTotalDs.Tables("ssTotalList").Clear()

        SSI_ssTotalList_Load()

        If IsDBNull(ssTotalDs.Tables("ssTotalList").Rows(0).Item(0)) = True Then
            lblSSITotalAll.Text = "RM0.00"
        Else
            lblSSITotalAll.Text = "RM" & Double.Parse(ssTotalDs.Tables("ssTotalList").Rows(0).Item(0)).ToString("N2")
        End If

    End Sub

    Sub SSI_Insert_dsTempList()

        Dim dsNewRow As DataRow
        SSI_Calculation_Definition()
        Dim final As String = "T00"
        Dim staffID As String = staffmenu.lblSMIStaID.Text

        ssTempDs.Tables("ssTempList").Clear()
        SSI_ssTempList_Load()

        For i = 0 To ssTempDs.Tables("ssTempList").Rows.Count - 1
            Dim check As String = ssTempDs.Tables("ssTempList").Rows(i).Item(0).ToString
            Dim store As String = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
            If check = store Then
                SSI_Temp_ID_Increment()
                store = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "T99" Then
                MsgBox("blablabla")
                Me.Visible = False
            End If
        Next

        Dim cbTemp As New OleDb.OleDbCommandBuilder(ssTempDa)

        If selectedItem = "FrenchFriesS" Then
            dsNewRow = ssTempDs.Tables("ssTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblSSIOID.Text
            dsNewRow.Item(2) = lblSSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnSSIFFriesS.Text
            dsNewRow.Item(5) = "Side Dish"
            dsNewRow.Item(6) = lblSSIPrice.Text
            dsNewRow.Item(7) = lblSSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            ssTempDs.Tables("ssTempList").Rows.Add(dsNewRow)
            ssTempDa.Update(ssTempDs, "ssTempList")

        ElseIf selectedItem = "CurlyFriesS" Then
            dsNewRow = ssTempDs.Tables("ssTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblSSIOID.Text
            dsNewRow.Item(2) = lblSSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnSSICFriesS.Text
            dsNewRow.Item(5) = "Side Dish"
            dsNewRow.Item(6) = lblSSIPrice.Text
            dsNewRow.Item(7) = lblSSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            ssTempDs.Tables("ssTempList").Rows.Add(dsNewRow)
            ssTempDa.Update(ssTempDs, "ssTempList")

        ElseIf selectedItem = "OnionRingsS" Then
            dsNewRow = ssTempDs.Tables("ssTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblSSIOID.Text
            dsNewRow.Item(2) = lblSSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnSSIOringsS.Text
            dsNewRow.Item(5) = "Side Dish"
            dsNewRow.Item(6) = lblSSIPrice.Text
            dsNewRow.Item(7) = lblSSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            ssTempDs.Tables("ssTempList").Rows.Add(dsNewRow)
            ssTempDa.Update(ssTempDs, "ssTempList")

        End If

        final = "T00"
        SSI_Calculation_Reset()
        SSI_Reset_Temp_ID_Increment()

    End Sub

    Sub SSI_Update_dsTempList()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(ssCurrDa)
        sSI_Calculation_Definition()

        ssCurrDs.Tables("ssCurrList").Clear()

        If selectedItem = "FrenchFriesS" Then
            selectedItemName = btnSSIFFriesS.Text
            SSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "CurlyFriesS" Then
            selectedItemName = btnSSICFriesS.Text
            SSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "OnionRingsS" Then
            selectedItemName = btnSSIOringsS.Text
            SSI_Fetch_Temp_Per_Item()
        End If

        Dim cbUpt As New OleDb.OleDbCommandBuilder(ssCurrDa)

        If qty > 0 Then
            ssCurrDs.Tables("ssCurrList").Rows(0).Item(7) = lblSSICounter.Text
            ssCurrDs.Tables("ssCurrList").Rows(0).Item(8) = "RM" & total.ToString("N2")

            ssCurrDa.Update(ssCurrDs, "ssCurrList")
            ssCurrDs.Tables("ssCurrList").Clear()
        ElseIf qty <= 0 Then
            ssCurrDs.Tables("ssCurrList").Rows(0).Delete()

            ssCurrDa.Update(ssCurrDs, "ssCurrList")
            btnSSIAdd.Text = "Add to Cart"
            ssCurrDs.Tables("ssCurrList").Clear()
        End If

        SSI_Calculation_Reset()
        SSI_Reset_Temp_ID_Increment()
    End Sub

    Private Sub SSI_To_DSI_Button(sender As Object, e As EventArgs) Handles btniSSItoDSI.Click

        drinkselection.pbrDSIStep.Value = 100
        drinkselection.lblDSITotalAll.Text = lblSSITotalAll.Text
        drinkselection.lblDSIOID.Text = lblSSIOID.Text
        drinkselection.lblDSICID.Text = lblSSICID.Text
        SSI_Reset()
        SSI_Reset_Controls()

    End Sub

    Private Sub SSI_To_SOI_Button(sender As Object, e As EventArgs) Handles btniSSItoSOI.Click

        ssTempDs.Tables("ssTempList").Clear()
        SSI_ssTempList_Load()

        If ssTempDs.Tables("ssTempList").Rows.Count <= 0 Then
            SSI_Disable_Controls()
            Dim res As DialogResult = MessageBox.Show("You have not selected any item. Select an item to continue.", "Empty order.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)

            If res = DialogResult.OK Then
                SSI_Enable_Controls()
            End If

        Else
            staffmenu.Staff_Menu_Interface_Load_Summary_Order_Interface()
            Me.Visible = False
            SOI_Refresh_Form_From_SSI()
            SSI_Reset()
            SSI_Reset_Controls()

        End If

    End Sub

    Sub SSI_Disable_Controls()
        btniSSItoDSI.Enabled = False
        btniSSItoSOI.Enabled = False
        trSSIVertS.HideSync(panSSIControl)


        For Each btn In {btnSSICFriesS, btnSSIFFriesS, btnSSIOringsS}
            btn.Enabled = False
        Next
    End Sub

    Sub SSI_Enable_Controls()
        btniSSItoDSI.Enabled = True
        btniSSItoSOI.Enabled = True


        For Each btn In {btnSSICFriesS, btnSSIFFriesS, btnSSIOringsS}
            btn.Enabled = True
        Next
    End Sub

    Sub SOI_Refresh_Form_From_SSI()
        Const taxrate As Double = 0.06
        Dim payable, tax As Double

        summaryorder.SOI_soSumDs_Load_From_SSI()
        summaryorder.SOI_soSumDs_Refresh_From_SSI()
        summaryorder.lblSOIOID.Text = lblSSIOID.Text
        summaryorder.lblSOICID.Text = lblSSICID.Text
        summaryorder.SOI_soCustDs_Load_From_SSI()
        summaryorder.SOI_soCustDs_Refresh_From_SSI()
        summaryorder.SOI_soOrdList_Load()
        summaryorder.txtSOITotalExTax.Text = lblSSITotalAll.Text

        payable = Replace(summaryorder.txtSOITotalExTax.Text, "RM", "")
        tax = payable * taxrate
        summaryorder.txtSOITotalPayable.Text = "RM" & (Math.Round((payable + tax), 2)).ToString("N2")


        summaryorder.txtSOICName.Text = summaryorder.soCustDs.Tables("soCustList").Rows(0).Item(0)
        summaryorder.txtSOICEmail.Text = summaryorder.soCustDs.Tables("soCustList").Rows(0).Item(1)
        summaryorder.txtSOICPhone.Text = summaryorder.soCustDs.Tables("soCustList").Rows(0).Item(2)
        summaryorder.txtSOIODate.Text = Date.Now.ToString("dd/MM/yyyy")
        summaryorder.txtSOIOTime.Text = Date.Now.ToString("HH:mm:ss")

        payable = 0
        tax = 0


    End Sub

    Private Sub SSI_Cancel_Order_Button(sender As Object, e As EventArgs)

        staffmenu.trSMIVertS.HideSync(staffmenu.panSMIOrdForm)
        staffmenu.trSMIVertS.ShowSync(staffmenu.panSMIBack)

        For Each form In {customerselection, foodselection, drinkselection}
            form.visible = False
        Next
        Me.Visible = False

        SSI_Reset()
        SSI_Cancel_Order()
        SSI_Reset_Controls()

    End Sub

    Private Sub SSI_FrenchFriesS_Button(sender As Object, e As EventArgs) Handles btnSSIFFriesS.Click
        selectedItemName = btnSSIFFriesS.Text
        SSI_Fetch_Temp_Per_Item()

        If ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            btnSSIAdd.Text = "Add to Cart"
        Else
            btnSSIAdd.Text = "Update Cart"
        End If

        selectedItem = "FrenchFriesS"
        pbxSSIItem.Image = My.Resources.xxx_frenchfries
        txtSSIDesc.Text = "A common yet fitting sides to complement your main. (Small portion)"
        lblSSIPrice.Text = "RM3.00"
        lblSSICounter.Text = frenchfriess
        txtSSIManQty.Text = frenchfriess
        selectedItemi = frenchfriess
        trSSIVertS.ShowSync(panSSIControl)

        sSI_Calculation_Definition()
        sSI_Total_Per_Item()
        SSI_Empty_Count_Check_DB()

    End Sub

    Private Sub SSI_CurlyFriesS_Button(sender As Object, e As EventArgs) Handles btnSSICFriesS.Click
        selectedItemName = btnSSICFriesS.Text
        SSI_Fetch_Temp_Per_Item()

        If ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            btnSSIAdd.Text = "Add to Cart"
        Else
            btnSSIAdd.Text = "Update Cart"
        End If

        selectedItem = "CurlyFriesS"
        pbxSSIItem.Image = My.Resources.xxx_curlyfries
        txtSSIDesc.Text = "A uniquely cut fries that can be eaten anywhere at any time. (Small portion)"
        lblSSIPrice.Text = "RM4.00"
        lblSSICounter.Text = curlyfriess
        txtSSIManQty.Text = curlyfriess
        selectedItemi = curlyfriess
        trSSIVertS.ShowSync(panSSIControl)

        sSI_Calculation_Definition()
        sSI_Total_Per_Item()
        SSI_Empty_Count_Check_DB()

    End Sub

    Private Sub SSI_OnionRingsS_Button(sender As Object, e As EventArgs) Handles btnSSIOringsS.Click
        selectedItemName = btnSSIOringsS.Text
        SSI_Fetch_Temp_Per_Item()

        If ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            btnSSIAdd.Text = "Add to Cart"
        Else
            btnSSIAdd.Text = "Update Cart"
        End If

        selectedItem = "OnionRingsS"
        pbxSSIItem.Image = My.Resources.xxx_onionrings
        txtSSIDesc.Text = "A spiceful, breaded Holland Onion sliced and cooked to perfection. (Small portion)"
        lblSSIPrice.Text = "RM4.00"
        lblSSICounter.Text = onionringss
        txtSSIManQty.Text = onionringss
        selectedItemi = onionringss
        trSSIVertS.ShowSync(panSSIControl)

        SSI_Calculation_Definition()
        SSI_Total_Per_Item()
        SSI_Empty_Count_Check_DB()

    End Sub

    Private Sub SSI_Counter_Increment(sender As Object, e As EventArgs) Handles btniSSIInc.Click

        If selectedItem = "FrenchFriesS" Then

            count = frenchfriess
            count += 1

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            frenchfriess = count

        ElseIf selectedItem = "CurlyFriesS" Then

            count = curlyfriess
            count += 1

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            curlyfriess = count

        ElseIf selectedItem = "OnionRingsS" Then

            count = onionringss
            count += 1

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            onionringss = count

        End If

        SSI_Calculation_Definition()
        SSI_Total_Per_Item()

        If count <> 0 Then
            trSSIVertS.ShowSync(btnSSIAdd)
        End If


    End Sub

    Private Sub SSI_Counter_Decrement(sender As Object, e As EventArgs) Handles btniSSIDec.Click

        If selectedItem = "FrenchFriesS" Then
            selectedItemName = btnSSIFFriesS.Text
            SSI_Fetch_Temp_Per_Item()

            count = frenchfriess
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            frenchfriess = count

        ElseIf selectedItem = "CurlyFriesS" Then
            selectedItemName = btnSSICFriesS.Text
            SSI_Fetch_Temp_Per_Item()

            count = curlyfriess
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            curlyfriess = count

        ElseIf selectedItem = "OnionRingsS" Then
            selectedItemName = btnSSIOringsS.Text
            SSI_Fetch_Temp_Per_Item()

            count = onionringss
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblSSICounter.Text = count
            txtSSIManQty.Text = count
            onionringss = count

        End If

        sSI_Calculation_Definition()
        sSI_Total_Per_Item()

        If count = 0 And ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            trSSIVertS.HideSync(btnSSIAdd)
        End If


    End Sub

    Private Sub SSI_Open_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles lblSSIManQty.Click

        If lblSSIManQty.Text = "Type instead..." Then
            lblSSIManQty.Text = "Hide input..."
            trSSIVertS.ShowSync(panSSIManQty)
            txtSSIManQty.Focus()
            txtSSIManQty.SelectAll()
        ElseIf lblsSIManQty.Text = "Hide input..." Then
            lblSSIManQty.Text = "Type instead..."
            trSSIVertS.HideSync(panSSIManQty)
        End If


    End Sub

    Private Sub SSI_Update_Counter_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles txtSSIManQty.TextChanged

        Try
            If txtSSIManQty.Text.Length = 0 Then
                txtSSIManQty.Text = "0"
            ElseIf txtSSIManQty.Text = "0" Then
                txtSSIManQty.SelectAll()
            End If

            If selectedItem = "FrenchFriesS" Then
                frenchfriess = txtSSIManQty.Text
                selectedItemi = frenchfriess
                selectedItemName = btnSSIFFriesS.Text
                SSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "CurlyFriesS" Then
                curlyfriess = txtSSIManQty.Text
                selectedItemi = curlyfriess
                selectedItemName = btnSSICFriesS.Text
                SSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "OnionRingsS" Then
                onionringss = txtSSIManQty.Text
                selectedItemi = onionringss
                selectedItemName = btnSSIOringsS.Text
                SSI_Fetch_Temp_Per_Item()
            End If

            count = txtSSIManQty.Text
            lblSSICounter.Text = txtSSIManQty.Text

            sSI_Calculation_Definition()
            SSI_Total_Per_Item()
            SSI_Empty_Count_Check_DB()

        Catch ex As Exception

            MsgBox("Invalid input")
            txtSSIManQty.Text = "0"

        End Try


    End Sub

    Sub SSI_Temp_ID_Increment()

        one += 1
        If one = 10 Then
            ten += 1
            one = 0
        ElseIf ten = 10 Then
            one = 0
            ten = 0
        End If

    End Sub

    Sub SSI_Calculation_Definition()

        price = Replace(lblSSIPrice.Text, "RM", "")
        qty = Integer.Parse(lblSSICounter.Text)
        total = price * qty

    End Sub

    Sub SSI_Calculation_Reset()

        price = 0
        qty = 0
        total = 0

    End Sub

    Sub SSI_Reset_Temp_ID_Increment()

        one = 0
        ten = 0

    End Sub

    Sub SSI_Empty_Count_Check_DB()
        If selectedItemi <> 0 Or ssCurrDs.Tables("ssCurrList").Rows.Count > 0 Then
            trSSIVertS.ShowSync(btnSSIAdd)
        ElseIf selectedItemi = 0 And ssCurrDs.Tables("ssCurrList").Rows.Count = 0 Then
            trSSIVertS.HideSync(btnSSIAdd)
        End If
    End Sub

    Sub SSI_Total_Per_Item()
        lblSSITotal.Text = "RM" & total.ToString("N2")
    End Sub

    Sub SSI_Reset()

        count = 0
        one = 0
        ten = 0
        qty = 0

        frenchfriess = 0
        curlyfriess = 0
        onionringss = 0

        selectedItemi = 0
        selectedItem = ""
        selectedItemName = ""

        price = 0
        total = 0


    End Sub

    Sub SSI_Cancel_Order()

        SSI_Clear_All_Datasets()
        SSI_ssTempList_Load()

        Dim cbDelAll As New OleDb.OleDbCommandBuilder(ssTempDa)

        For i = 0 To ssTempDs.Tables("ssTempList").Rows.Count - 1
            ssTempDs.Tables("ssTempList").Rows(i).Delete()
        Next

        ssTempDa.Update(ssTempDs, "ssTempList")
        ssTempDs.Tables("ssTempList").Clear()

    End Sub

    Sub SSI_Clear_All_Datasets()

        ssTempDs.Tables("ssTempList").Clear()
        ssCurrDs.Tables("ssCurrList").Clear()
        ssTotalDs.Tables("ssTotalList").Clear()

    End Sub

    Sub SSI_Reset_Controls()

        panSSIControl.Visible = False

        lblSSIManQty.Text = "Type instead..."
        panSSIManQty.Visible = False
        txtSSIManQty.Text = "0"

        btnSSIAdd.Visible = False
        btnSSIAdd.Text = "Add to Cart"
        lblSSITotal.Text = "RM0.00"

        pbxSSIItem.Image = My.Resources._022_french_fries
        lblSSIPrice.Text = "Select a side"
        txtSSIDesc.Text = ""
        lblSSITotalAll.Text = "RM0.00"

        pbrSSIStep.Value = 0

        lblSSIOID.Text = "O00000"
        lblSSICID.Text = "C00000"
    End Sub

End Class