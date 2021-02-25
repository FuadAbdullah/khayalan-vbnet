Public Class drinkselection

    '##################################################################################################################################################################################################
    '########## DRINK SELECTION INTERFACE START
    '##################################################################################################################################################################################################
    '########## DRINK SELECTION INTERFACE LOCAL VARIABLE
    '##################################################################################################################################################################################################

    Dim count, one, ten, qty, selectedItemi As Integer
    Dim cocacola, sprite, icedlemontea As Integer
    Dim selectedItem, selectedItemName As String
    Dim price, total As Double

    'For database connection use
    Dim dsCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Dim dsProvider, dsSource, dsTempSql, dsCurrSql, dsTotalSql As String     'Declaring database retrieval keywords
    Dim dsTempDs As DataSet = New DataSet("dsTempList")                       'Create a new data container for fetched data
    Dim dsCurrDs As DataSet = New DataSet("dsCurrList")                     'Create a new data container for fetched data
    Dim dsTotalDs As DataSet = New DataSet("dsTotalList")                                       'Create a new data container for fetched data
    Dim dsTempDa, dsCurrDa, dsTotalDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------

    '##################################################################################################################################################################################################
    '########## DRINK SELECTION INTERFACE CORE
    '##################################################################################################################################################################################################

    Private Sub FSI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        DSI_Elipse_Set()
        DSI_Database_Initial_Load()
        DSI_dsTempList_Load()
        DSI_dsCurrList_Load()
        DSI_dsTotalList_Load()
        DSI_Load_Total_All()
    End Sub

    Sub DSI_Elipse_Set()

        Dim elDSI As New Bunifu.Framework.UI.BunifuElipse
        elDSI.ApplyElipse(panDSIMain, 20)
        elDSI.ApplyElipse(panDSIFood, 20)
        elDSI.ApplyElipse(panDSIPrice, 20)
        elDSI.ApplyElipse(panDSITotalAll, 20)
        elDSI.ApplyElipse(panDSIHeader, 20)
    End Sub

    Sub DSI_Database_Initial_Load()
        dsProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        dsSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        dsCon.ConnectionString = dsProvider & dsSource
    End Sub

    Sub DSI_dsTempList_Load()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(dsTempDa)

        dsCon.Open()
        dsTempSql = "SELECT * FROM TEMP_T"
        dsTempDa = New OleDb.OleDbDataAdapter(dsTempSql, dsCon)
        dsTempDa.Fill(dsTempDs, "dsTempList")
        dsCon.Close()
    End Sub

    Sub DSI_dsCurrList_Load()
        Dim cbCurr As New OleDb.OleDbCommandBuilder(dsCurrDa)

        dsCon.Open()
        dsCurrSql = "SELECT * FROM TEMP_T"
        dsCurrDa = New OleDb.OleDbDataAdapter(dsCurrSql, dsCon)
        dsCurrDa.Fill(dsCurrDs, "dsCurrList")
        dsCon.Close()
    End Sub

    Sub DSI_dsTotalList_Load()
        Dim cbTotal As New OleDb.OleDbCommandBuilder(dsTotalDa)

        dsCon.Open()
        dsTotalSql = "SELECT SUM(REPLACE(item_total, 'RM', '') ) AS item_total_all FROM TEMP_T"
        dsTotalDa = New OleDb.OleDbDataAdapter(dsTotalSql, dsCon)
        dsTotalDa.Fill(dsTotalDs, "dsTotalList")
        dsCon.Close()
    End Sub

    Sub DSI_Load_Total_All()

        If IsDBNull(dsTotalDs.Tables("dsTotalList").Rows(0).Item(0)) = True Then
            lblDSITotalAll.Text = "RM0.00"
        Else
            lblDSITotalAll.Text = "RM" & Double.Parse(dsTotalDs.Tables("dsTotalList").Rows(0).Item(0)).ToString("N2")
        End If

    End Sub

    Sub DSI_Fetch_Temp_Per_Item()

        dsCurrDs.Tables("dsCurrList").Clear()

        dsCon.Open()
        dsCurrSql = "SELECT * FROM TEMP_T WHERE item_name = '" & selectedItemName & "'"
        dsCurrDa = New OleDb.OleDbDataAdapter(dsCurrSql, dsCon)
        dsCurrDa.Fill(dsCurrDs, "dsCurrList")
        dsCon.Close()

    End Sub

    Private Sub DSI_Add_To_Cart_Button(sender As Object, e As EventArgs) Handles btnDSIAdd.Click

        pbrDSIStep.Value = 100

        If btnDSIAdd.Text = "Add to Cart" Then
            DSI_Insert_dsTempList()
            btnDSIAdd.Text = "Update Cart"
        ElseIf btnDSIAdd.Text = "Update Cart" Then
            DSI_Update_dsTempList()
        End If

        If count = 0 And dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            trDSIVertS.HideSync(btnDSIAdd)
        End If

        dsTotalDs.Tables("dsTotalList").Clear()

        DSI_dsTotalList_Load()

        If IsDBNull(dsTotalDs.Tables("dsTotalList").Rows(0).Item(0)) = True Then
            lblDSITotalAll.Text = "RM0.00"
        Else
            lblDSITotalAll.Text = "RM" & Double.Parse(dsTotalDs.Tables("dsTotalList").Rows(0).Item(0)).ToString("N2")
        End If


    End Sub

    Sub DSI_Insert_dsTempList()

        Dim dsNewRow As DataRow
        DSI_Calculation_Definition()
        Dim final As String = "T00"
        Dim staffID As String = staffmenu.lblSMIStaID.Text

        dsTempDs.Tables("dsTempList").Clear()
        DSI_dsTempList_Load()

        For i = 0 To dsTempDs.Tables("dsTempList").Rows.Count - 1
            Dim check As String = dsTempDs.Tables("dsTempList").Rows(i).Item(0).ToString
            Dim store As String = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
            If check = store Then
                DSI_Temp_ID_Increment()
                store = String.Format("T{0}{1}", Format(ten, "0"), Format(one, "0"))
                final = store
            ElseIf store = "T99" Then
                MsgBox("blablabla")
                Me.Visible = False
            End If
        Next

        Dim cbTemp As New OleDb.OleDbCommandBuilder(dsTempDa)

        If selectedItem = "CocaCola" Then
            dsNewRow = dsTempDs.Tables("dsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblDSIOID.Text
            dsNewRow.Item(2) = lblDSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnDSICoLa.Text
            dsNewRow.Item(5) = "Drink"
            dsNewRow.Item(6) = lblDSIPrice.Text
            dsNewRow.Item(7) = lblDSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            dsTempDs.Tables("dsTempList").Rows.Add(dsNewRow)
            dsTempDa.Update(dsTempDs, "dsTempList")

        ElseIf selectedItem = "Sprite" Then
            dsNewRow = dsTempDs.Tables("dsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblDSIOID.Text
            dsNewRow.Item(2) = lblDSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnDSISprite.Text
            dsNewRow.Item(5) = "Drink"
            dsNewRow.Item(6) = lblDSIPrice.Text
            dsNewRow.Item(7) = lblDSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            dsTempDs.Tables("dsTempList").Rows.Add(dsNewRow)
            dsTempDa.Update(dsTempDs, "dsTempList")

        ElseIf selectedItem = "IcedLemonTea" Then
            dsNewRow = dsTempDs.Tables("dsTempList").NewRow
            dsNewRow.Item(0) = final
            dsNewRow.Item(1) = lblDSIOID.Text
            dsNewRow.Item(2) = lblDSICID.Text
            dsNewRow.Item(3) = staffID
            dsNewRow.Item(4) = btnDSIILTea.Text
            dsNewRow.Item(5) = "Drink"
            dsNewRow.Item(6) = lblDSIPrice.Text
            dsNewRow.Item(7) = lblDSICounter.Text
            dsNewRow.Item(8) = "RM" & total.ToString("N2")
            dsNewRow.Item(9) = "Pending"

            dsTempDs.Tables("dsTempList").Rows.Add(dsNewRow)
            dsTempDa.Update(dsTempDs, "dsTempList")

        End If

        final = "T00"
        DSI_Calculation_Reset()
        DSI_Reset_Temp_ID_Increment()

    End Sub

    Sub DSI_Update_dsTempList()
        Dim cbTemp As New OleDb.OleDbCommandBuilder(dsCurrDa)
        dSI_Calculation_Definition()

        dsCurrDs.Tables("dsCurrList").Clear()

        If selectedItem = "CocaCola" Then
            selectedItemName = btnDSICoLa.Text
            DSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "Sprite" Then
            selectedItemName = btnDSISprite.Text
            DSI_Fetch_Temp_Per_Item()
        ElseIf selectedItem = "IcedLemonTea" Then
            selectedItemName = btnDSIILTea.Text
            DSI_Fetch_Temp_Per_Item()
        End If

        Dim cbUpt As New OleDb.OleDbCommandBuilder(dsCurrDa)

        If qty > 0 Then
            dsCurrDs.Tables("dsCurrList").Rows(0).Item(7) = lblDSICounter.Text
            dsCurrDs.Tables("dsCurrList").Rows(0).Item(8) = "RM" & total.ToString("N2")

            dsCurrDa.Update(dsCurrDs, "dsCurrList")
            dsCurrDs.Tables("dsCurrList").Clear()
        ElseIf qty <= 0 Then
            dsCurrDs.Tables("dsCurrList").Rows(0).Delete()

            dsCurrDa.Update(dsCurrDs, "dsCurrList")
            btnDSIAdd.Text = "Add to Cart"
            dsCurrDs.Tables("dsCurrList").Clear()
        End If

        dSI_Calculation_Reset()
        dSI_Reset_Temp_ID_Increment()
    End Sub

    Private Sub DSI_To_FSI_Back_Button(sender As Object, e As EventArgs) Handles btniDSItoFSI.Click

        foodselection.pbrFSIStep.Value = 100
        foodselection.lblFSITotalAll.Text = lblDSITotalAll.Text
        foodselection.lblFSIOID.Text = lblDSIOID.Text
        foodselection.lblFSICID.Text = lblDSICID.Text
        DSI_Reset()
        DSI_Reset_Controls()

    End Sub

    Private Sub DSI_To_SSI_Next_Button(sender As Object, e As EventArgs) Handles btniDSItoSSI.Click

        sidesselection.lblSSITotalAll.Text = lblDSITotalAll.Text
        sidesselection.lblSSIOID.Text = lblDSIOID.Text
        sidesselection.lblSSICID.Text = lblDSICID.Text
        DSI_Reset()
        DSI_Reset_Controls()

    End Sub

    Private Sub DSI_Cancel_Order_Button(sender As Object, e As EventArgs)

        staffmenu.trSMIVertS.HideSync(staffmenu.panSMIOrdForm)
        staffmenu.trSMIVertS.ShowSync(staffmenu.panSMIBack)

        For Each form In {customerselection, foodselection, sidesselection} 'add payment and receipt as well
            form.visible = False
        Next
        Me.Visible = False

        DSI_Reset()
        DSI_Cancel_Order()
        DSI_Reset_Controls()

    End Sub

    Private Sub DSI_CocaCola_Button(sender As Object, e As EventArgs) Handles btnDSICoLa.Click
        selectedItemName = btnDSICoLa.Text
        DSI_Fetch_Temp_Per_Item()

        If dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            btnDSIAdd.Text = "Add to Cart"
        Else
            btnDSIAdd.Text = "Update Cart"
        End If

        selectedItem = "CocaCola"
        pbxDSIItem.Image = My.Resources.yyy_cocacola
        txtDSIDesc.Text = "A staple drink of every countries."
        lblDSIPrice.Text = "RM4.00"
        lblDSICounter.Text = cocacola
        txtDSIManQty.Text = cocacola
        selectedItemi = cocacola
        trDSIVertS.ShowSync(panDSIControl)

        dSI_Calculation_Definition()
        dSI_Total_Per_Item()
        DSI_Empty_Count_Check_DB()

    End Sub

    Private Sub DSI_Sprite_Button(sender As Object, e As EventArgs) Handles btnDSISprite.Click
        selectedItemName = btnDSISprite.Text
        DSI_Fetch_Temp_Per_Item()

        If dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            btnDSIAdd.Text = "Add to Cart"
        Else
            btnDSIAdd.Text = "Update Cart"
        End If

        selectedItem = "Sprite"
        pbxDSIItem.Image = My.Resources.yyy_sprite
        txtDSIDesc.Text = "A rehydrating soda drink."
        lblDSIPrice.Text = "RM2.50"
        lblDSICounter.Text = sprite
        txtDSIManQty.Text = sprite
        selectedItemi = sprite
        trDSIVertS.ShowSync(panDSIControl)

        DSI_Calculation_Definition()
        DSI_Total_Per_Item()
        DSI_Empty_Count_Check_DB()

    End Sub

    Private Sub DSI_FilletOFish_Button(sender As Object, e As EventArgs) Handles btnDSIILTea.Click
        selectedItemName = btnDSIILTea.Text
        DSI_Fetch_Temp_Per_Item()

        If dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            btnDSIAdd.Text = "Add to Cart"
        Else
            btnDSIAdd.Text = "Update Cart"
        End If

        selectedItem = "IcedLemonTea"
        pbxDSIItem.Image = My.Resources.yyy_icedlemontea
        txtDSIDesc.Text = "A refreshing lemon-flavoured drink."
        lblDSIPrice.Text = "RM3.00"
        lblDSICounter.Text = icedlemontea
        txtDSIManQty.Text = icedlemontea
        selectedItemi = icedlemontea
        trDSIVertS.ShowSync(panDSIControl)

        dSI_Calculation_Definition()
        DSI_Total_Per_Item()
        DSI_Empty_Count_Check_DB()


    End Sub

    Private Sub DSI_Counter_Increment(sender As Object, e As EventArgs) Handles btniDSIInc.Click

        If selectedItem = "CocaCola" Then

            count = cocacola
            count += 1

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            cocacola = count

        ElseIf selectedItem = "Sprite" Then

            count = sprite
            count += 1

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            sprite = count

        ElseIf selectedItem = "IcedLemonTea" Then

            count = icedlemontea
            count += 1

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            icedlemontea = count

        End If

        DSI_Calculation_Definition()
        DSI_Total_Per_Item()

        If count <> 0 Then
            trDSIVertS.ShowSync(btnDSIAdd)
        End If



    End Sub

    Private Sub DSI_Counter_Decrement(sender As Object, e As EventArgs) Handles btniDSIDec.Click

        If selectedItem = "CocaCola" Then
            selectedItemName = btnDSICoLa.Text
            DSI_Fetch_Temp_Per_Item()

            count = cocacola
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            cocacola = count

        ElseIf selectedItem = "Sprite" Then
            selectedItemName = btnDSISprite.Text
            DSI_Fetch_Temp_Per_Item()

            count = sprite
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            sprite = count

        ElseIf selectedItem = "IcedLemonTea" Then
            selectedItemName = btnDSIILTea.Text
            DSI_Fetch_Temp_Per_Item()

            count = icedlemontea
            count -= 1

            If count <= 0 Then
                count = 0
            End If

            lblDSICounter.Text = count
            txtDSIManQty.Text = count
            icedlemontea = count

        End If

        DSI_Calculation_Definition()
        DSI_Total_Per_Item()

        If count = 0 And dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            trDSIVertS.HideSync(btnDSIAdd)
        End If



    End Sub

    Private Sub DSI_Open_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles lblDSIManQty.Click

        If lblDSIManQty.Text = "Type instead..." Then
            lblDSIManQty.Text = "Hide input..."
            trDSIVertS.ShowSync(panDSIManQty)
            txtDSIManQty.Focus()
            txtDSIManQty.SelectAll()
        ElseIf lblDSIManQty.Text = "Hide input..." Then
            lblDSIManQty.Text = "Type instead..."
            trDSIVertS.HideSync(panDSIManQty)
        End If



    End Sub

    Private Sub DSI_Update_Counter_Manual_Quantity_Input(sender As Object, e As EventArgs) Handles txtDSIManQty.TextChanged

        Try
            If txtDSIManQty.Text.Length = 0 Then
                txtDSIManQty.Text = "0"
            ElseIf txtDSIManQty.Text = "0" Then
                txtDSIManQty.SelectAll()
            End If

            If selectedItem = "CocaCola" Then
                cocacola = txtDSIManQty.Text
                selectedItemi = cocacola
                selectedItemName = btnDSICoLa.Text
                DSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "Sprite" Then
                sprite = txtDSIManQty.Text
                selectedItemi = sprite
                selectedItemName = btnDSISprite.Text
                DSI_Fetch_Temp_Per_Item()
            ElseIf selectedItem = "IcedLemonTea" Then
                icedlemontea = txtDSIManQty.Text
                selectedItemi = icedlemontea
                selectedItemName = btnDSIILTea.Text
                DSI_Fetch_Temp_Per_Item()
            End If

            count = txtDSIManQty.Text
            lblDSICounter.Text = txtDSIManQty.Text

            DSI_Calculation_Definition()
            DSI_Total_Per_Item()
            DSI_Empty_Count_Check_DB()

        Catch ex As Exception

            MsgBox("Invalid input")
            txtDSIManQty.Text = "0"

        End Try



    End Sub

    Sub DSI_Temp_ID_Increment()

        one += 1
        If one = 10 Then
            ten += 1
            one = 0
        ElseIf ten = 10 Then
            one = 0
            ten = 0
        End If

    End Sub

    Sub DSI_Calculation_Definition()

        price = Replace(lblDSIPrice.Text, "RM", "")
        qty = Integer.Parse(lblDSICounter.Text)
        total = price * qty

    End Sub

    Sub DSI_Calculation_Reset()

        price = 0
        qty = 0
        total = 0

    End Sub

    Sub DSI_Reset_Temp_ID_Increment()

        one = 0
        ten = 0

    End Sub

    Sub DSI_Empty_Count_Check_DB()
        If selectedItemi <> 0 Or dsCurrDs.Tables("dsCurrList").Rows.Count > 0 Then
            trDSIVertS.ShowSync(btnDSIAdd)
        ElseIf selectedItemi = 0 And dsCurrDs.Tables("dsCurrList").Rows.Count = 0 Then
            trDSIVertS.HideSync(btnDSIAdd)
        End If
    End Sub

    Sub DSI_Total_Per_Item()
        lblDSITotal.Text = "RM" & total.ToString("N2")
    End Sub

    Sub DSI_Reset()

        count = 0
        one = 0
        ten = 0
        qty = 0

        cocacola = 0
        sprite = 0
        icedlemontea = 0

        selectedItemi = 0
        selectedItem = ""
        selectedItemName = ""

        price = 0
        total = 0


    End Sub

    Sub DSI_Cancel_Order()

        DSI_Clear_All_Datasets()
        DSI_dsTempList_Load()

        Dim cbDelAll As New OleDb.OleDbCommandBuilder(dsTempDa)

        For i = 0 To dsTempDs.Tables("dsTempList").Rows.Count - 1
            dsTempDs.Tables("dsTempList").Rows(i).Delete()
        Next

        dsTempDa.Update(dsTempDs, "fsTempList")
        dsTempDs.Tables("dsTempList").Clear()

    End Sub

    Sub DSI_Clear_All_Datasets()

        dsTempDs.Tables("dsTempList").Clear()
        dsCurrDs.Tables("dsCurrList").Clear()
        dsTotalDs.Tables("dsTotalList").Clear()

    End Sub

    Sub DSI_Reset_Controls()

        panDSIControl.Visible = False

        lblDSIManQty.Text = "Type instead..."
        panDSIManQty.Visible = False
        txtDSIManQty.Text = "0"

        btnDSIAdd.Visible = False
        btnDSIAdd.Text = "Add to Cart"
        lblDSITotal.Text = "RM0.00"

        pbxDSIItem.Image = My.Resources._030_milkshake
        lblDSIPrice.Text = "Select a drink"
        txtDSIDesc.Text = ""
        lblDSITotalAll.Text = "RM0.00"

        pbrDSIStep.Value = 0

        lblDSIOID.Text = "O00000"
        lblDSICID.Text = "C00000"

    End Sub

End Class