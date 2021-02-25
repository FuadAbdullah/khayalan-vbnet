Public Class paymentorder

    Dim paid As Double
    Dim subtractEnabled As Boolean = False

    'For database connection use
    Public poCon As New OleDb.OleDbConnection                                 'Establish staff login connection to database
    Public poProvider, poSource, poSumSql, poOrdSql, poHisSql, poClearSql As String     'Declaring database retrieval keywords
    Public poSumDs As DataSet = New DataSet("poSumList")                       'Create a new data container for fetched data
    Public poOrdDs As DataSet = New DataSet("poOrdList")                                       'Create a new data container for fetched data
    Public poHisDs As DataSet = New DataSet("poHisList")                     'Create a new data container for fetched data
    Public poClearDs As DataSet = New DataSet("poClearList")                     'Create a new data container for fetched data
    Public poSumDa, poOrdDa, poHisDa, poClearDa As OleDb.OleDbDataAdapter              'Act as bridge between database and dataset
    '---------------------------


    Private Sub POI_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        POI_Elipse_Set()
        'POI_Database_Initial_Load()
    End Sub

    Sub POI_Elipse_Set()
        Dim elPOI As Bunifu.Framework.UI.BunifuElipse = New Bunifu.Framework.UI.BunifuElipse
        elPOI.ApplyElipse(panPOIHeader, 20)
        elPOI.ApplyElipse(panPOIBack, 20)
        elPOI.ApplyElipse(panPOIChange, 20)
        elPOI.ApplyElipse(panPOIPaid, 20)
        elPOI.ApplyElipse(panPOIPayable, 20)
        elPOI.ApplyElipse(panPOIHeader, 20)
        elPOI.ApplyElipse(panPOIControls, 20)
        elPOI.ApplyElipse(panPOICDet, 20)
        elPOI.ApplyElipse(panPOIPayableSec, 20)
        elPOI.ApplyElipse(panPOIChangeSec, 20)
        elPOI.ApplyElipse(panPOIPaidSec, 20)
        elPOI.ApplyElipse(panPOIRemarks, 20)
        elPOI.ApplyElipse(dgvPOIOrder, 20)

    End Sub


    Public Sub POI_Database_Initial_Load()

        poProvider = "PROVIDER = Microsoft.ACE.OLEDB.12.0;"
        poSource = "DATA SOURCE = khayalancafeteriadb.accdb"
        poCon.ConnectionString = poProvider & poSource

    End Sub


    Public Sub POI_poSumDs_Load()

        POI_Database_Initial_Load()

        Dim cbSum As New OleDb.OleDbCommandBuilder(poSumDa)

        poCon.Open()
        poSumSql = "SELECT item_name AS [Item Name], 
                            item_type AS [Item Type], 
                            item_price AS [Price], 
                            item_qty AS [Quantity], 
                            item_total AS [Total]
                     FROM TEMP_T"

        poSumDa = New OleDb.OleDbDataAdapter(poSumSql, poCon)
        poSumDa.Fill(poSumDs, "poSumList")
        poCon.Close()

    End Sub

    Sub POI_Load_TEMP_T_For_Deletion()

        POI_Database_Initial_Load()

        Dim cbClear As New OleDb.OleDbCommandBuilder(poClearDa)

        poCon.Open()
        poClearSql = "SELECT * FROM TEMP_T"

        poClearDa = New OleDb.OleDbDataAdapter(poClearSql, poCon)
        poClearDa.Fill(poClearDs, "poClearList")
        poCon.Close()

    End Sub

    Sub POI_Load_TEMP_T_After_Deletion()

        POI_Database_Initial_Load()

        poClearDs.Tables("poClearList").Clear()

        Dim cbClear As New OleDb.OleDbCommandBuilder(poClearDa)

        poCon.Open()
        poClearSql = "SELECT * FROM TEMP_T"

        poClearDa = New OleDb.OleDbDataAdapter(poClearSql, poCon)
        poClearDa.Fill(poClearDs, "poClearList")
        poCon.Close()

    End Sub

    Public Sub POI_poSumDs_Refresh_From_SOI()

        POI_Database_Initial_Load()

        poSumDs.Tables("poSumList").Clear()

        Dim cbSum As New OleDb.OleDbCommandBuilder(poSumDa)

        poCon.Open()
        poSumSql = "SELECT item_name AS [Item Name], 
                            item_type AS [Item Type], 
                            item_price AS [Price], 
                            item_qty AS [Quantity], 
                            item_total AS [Total]
                     FROM TEMP_T"

        poSumDa = New OleDb.OleDbDataAdapter(poSumSql, poCon)
        poSumDa.Fill(poSumDs, "poSumList")
        poCon.Close()

        dgvPOIOrder.DataSource = poSumDs.Tables("poSumList")
        dgvPOIOrder.Refresh()
    End Sub

    Public Sub POI_poOrdDs_Load()

        POI_Database_Initial_Load()

        Dim cbSum As New OleDb.OleDbCommandBuilder(poOrdDa)

        poCon.Open()
        poOrdSql = "SELECT DISTINCT ord_id,
                                    total_wtax
                     FROM ORDER_T
                     WHERE ord_id = '" & lblPOIOID.Text & "'"

        poOrdDa = New OleDb.OleDbDataAdapter(poOrdSql, poCon)
        poOrdDa.Fill(poOrdDs, "poOrdList")
        poCon.Close()

    End Sub

    Public Sub POI_poOrdDs_Refresh_From_SOI()

        POI_Database_Initial_Load()

        poOrdDs.Tables("poOrdList").Clear()

        Dim cbSum As New OleDb.OleDbCommandBuilder(poOrdDa)

        poCon.Open()
        poOrdSql = "SELECT DISTINCT ord_id,
                                    total_wtax
                     FROM ORDER_T
                     WHERE ord_id = '" & lblPOIOID.Text & "'"

        poOrdDa = New OleDb.OleDbDataAdapter(poOrdSql, poCon)
        poOrdDa.Fill(poOrdDs, "poOrdList")
        poCon.Close()

    End Sub

    Public Sub POI_poHisDs_Load() 'Used as the primary initialisation for poHis dataset that handles ORDER_T

        POI_Database_Initial_Load()

        Dim cbHis As New OleDb.OleDbCommandBuilder(poHisDa)

        poCon.Open()
        poHisSql = "SELECT * FROM ORDER_T WHERE ord_id = '" & lblPOIOID.Text & "'"

        poHisDa = New OleDb.OleDbDataAdapter(poHisSql, poCon)
        poHisDa.Fill(poHisDs, "poHisList")
        poCon.Close()

    End Sub

    Sub POI_poHisDs_Cancellation_Refresh() 'Used to refresh database once order is cancelled right before payment

        POI_Database_Initial_Load()

        poHisDs.Tables("poHisList").Clear()

        Dim cbHis As New OleDb.OleDbCommandBuilder(poHisDa)


        poCon.Open()
        poHisSql = "SELECT * FROM ORDER_T"

        poHisDa = New OleDb.OleDbDataAdapter(poHisSql, poCon)
        poHisDa.Fill(poHisDs, "poOrdList")
        poCon.Close()


    End Sub

    Public Sub POI_poHisDs_Refresh_From_SOI() 'Used to refresh database when the button from Summary order interface is pressed

        POI_Database_Initial_Load()

        poHisDs.Tables("poHisList").Clear()

        Dim cbHis As New OleDb.OleDbCommandBuilder(poHisDa)

        poCon.Open()
        poHisSql = "SELECT * FROM ORDER_T WHERE ord_id = '" & lblPOIOID.Text & "'"

        poHisDa = New OleDb.OleDbDataAdapter(poHisSql, poCon)
        poHisDa.Fill(poHisDs, "poOrdList")
        poCon.Close()

    End Sub

    Public Sub POI_Load_Details()
        Dim rounded As Double = Replace(poOrdDs.Tables("poOrdList").Rows(0).Item(1), "RM", "")

        lblPOIPayableRM.Text = "RM" & (Math.Round(rounded, 1)).ToString("N2")
    End Sub

    Private Sub POI_5c_Button(sender As Object, e As EventArgs) Handles btniPOI5c.Click

        If subtractEnabled = False Then
            paid += 0.05
            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 0.05

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_5c_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOI5c.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 0.05
                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 0.05

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()

            End If
        End If
    End Sub

    Private Sub POI_10c_Button(sender As Object, e As EventArgs) Handles btniPOI10c.Click

        If subtractEnabled = False Then
            paid += 0.1
            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 0.1

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_10c_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOI10c.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 0.1
                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 0.1

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()

            End If
        End If
    End Sub

    Private Sub POI_20c_Button(sender As Object, e As EventArgs) Handles btniPOI20c.Click

        If subtractEnabled = False Then
            paid += 0.2

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 0.2

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_20c_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOI20c.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 0.2

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 0.2

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_50c_Button(sender As Object, e As EventArgs) Handles btniPOI50c.Click

        If subtractEnabled = False Then
            paid += 0.5

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 0.5

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_50c_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOI50c.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 0.5

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 0.5

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM1_Button(sender As Object, e As EventArgs) Handles btniPOIrm1.Click

        If subtractEnabled = False Then
            paid += 1.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 1.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM1_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm1.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 1.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 1.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM5_Button(sender As Object, e As EventArgs) Handles btniPOIrm5.Click

        If subtractEnabled = False Then
            paid += 5.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 5.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM5_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm5.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 5.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 5.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM10_Button(sender As Object, e As EventArgs) Handles btniPOIrm10.Click

        If subtractEnabled = False Then
            paid += 10.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 10.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM10_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm10.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 10.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 10.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM20_Button(sender As Object, e As EventArgs) Handles btniPOIrm20.Click

        If subtractEnabled = False Then
            paid += 20.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 20.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM20_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm20.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 20.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 20.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM50_Button(sender As Object, e As EventArgs) Handles btniPOIrm50.Click

        If subtractEnabled = False Then
            paid += 50.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 50.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM50_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm50.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 50.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 50.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Private Sub POI_RM100_Button(sender As Object, e As EventArgs) Handles btniPOIrm100.Click

        If subtractEnabled = False Then
            paid += 100.0

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        ElseIf subtractEnabled = True Then
            paid -= 100.0

            If paid <= 0.00 Then
                paid = 0.00
            End If

            POI_Total_Paid_Counter()
            POI_Show_Total_Paid_Counter()
            POI_Total_Change_Counter()
            POI_Show_Subtract_Button()
        End If

    End Sub

    Private Sub POI_RM100_Button_Enter(sender As Object, e As KeyEventArgs) Handles btniPOIrm100.KeyDown

        If e.KeyCode = Keys.Enter Then

            If subtractEnabled = False Then
                paid += 100.0

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            ElseIf subtractEnabled = True Then
                paid -= 100.0

                If paid <= 0.00 Then
                    paid = 0.00
                End If

                POI_Total_Paid_Counter()
                POI_Show_Total_Paid_Counter()
                POI_Total_Change_Counter()
                POI_Show_Subtract_Button()
            End If

        End If

    End Sub

    Sub POI_Total_Change_Counter()
        Dim payable As Double
        Dim change As Double
        payable = Replace(lblPOIPayableRM.Text, "RM", "")
        change = paid - payable

        lblPOIChangeRM.Text = "RM" & (Math.Round(change, 2)).ToString("N2")

        If paid >= payable Then
            btnPOIComp.Visible = True
        ElseIf paid < payable Then
            btnPOIComp.Visible = False

        End If

        If paid > payable Then
            trPOIVertS.ShowSync(panPOIChange)
        ElseIf paid <= payable Then
            trPOIVertS.HideSync(panPOIChange)
        End If


    End Sub

    Sub POI_Show_Total_Paid_Counter()

        If paid > 0 Then
            trPOIVertS.ShowSync(panPOIPaid)
        ElseIf paid <= 0 Then
            trPOIVertS.HideSync(panPOIPaid)
        End If
    End Sub

    Sub POI_Total_Paid_Counter()
        lblPOIPaidRM.Text = "RM" & (Math.Round(paid, 2)).ToString("N2")
    End Sub

    Sub POI_Show_Subtract_Button()

        If paid > 0 Then

            btnPOIOp.Visible = True

        ElseIf paid <= 0 Then
            btnPOIOp.Visible = False
            btnPOIOp.Text = "Subtract"
            subtractEnabled = False

        End If

    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles btnPOIOp.Click

        If btnPOIOp.Text = "Add" Then
            subtractEnabled = False
            btnPOIOp.Text = "Subtract"

        ElseIf btnPOIOp.Text = "Subtract" Then
            subtractEnabled = True
            btnPOIOp.Text = "Add"

        End If



    End Sub

    Private Sub btnPOIComp_Click(sender As Object, e As EventArgs) Handles btnPOIComp.Click

        POI_Amend_Order()
        ROI_Refresh_From_POI()
        POI_Reset()

    End Sub

    Sub POI_Amend_Order()

        Dim desc As String

        poHisDs.Tables("poHisList").Clear()
        POI_poHisDs_Load()

        If txtPOIRemarks.Text.Length = 0 Then
            desc = "No remarks given."
        Else
            desc = txtPOIRemarks.Text
        End If

        Dim cbHis As New OleDb.OleDbCommandBuilder(poHisDa)
        For i = 0 To poHisDs.Tables("poHislist").Rows.Count - 1

            poHisDs.Tables("poHisList").Rows(i).Item(11) = "Confirmed, Paid"
            poHisDs.Tables("poHisList").Rows(i).Item(15) = lblPOIPayableRM.Text
            poHisDs.Tables("poHisList").Rows(i).Item(16) = lblPOIPaidRM.Text
            poHisDs.Tables("poHisList").Rows(i).Item(17) = lblPOIChangeRM.Text
            poHisDs.Tables("poHisList").Rows(i).Item(18) = desc

            poHisDa.Update(poHisDs, "poHisList")

        Next
        poHisDs.Tables("poHisList").Clear()
    End Sub

    Private Sub btnPOICancel_Click(sender As Object, e As EventArgs) Handles btnPOICancel.Click 'this event handles the cancellation of order while in payment menu.

        POI_Disable()

        Dim res As DialogResult = MessageBox.Show("This order will be cancelled. Continue?", "Cancelling order.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If res = DialogResult.Yes Then

            POI_poHisDs_Load()
            POI_poHisDs_Clear()
            POI_poHisDs_Cancellation_Refresh()

            POI_Load_TEMP_T_For_Deletion()
            POI_Clear_TEMP_T()
            POI_Load_TEMP_T_After_Deletion()

            staffmenu.trSMIVertS.HideSync(staffmenu.panSMIOrdForm)
            staffmenu.trSMIVertS.ShowSync(staffmenu.panSMIBack)


            For Each form In {foodselection, drinkselection, sidesselection, summaryorder, receiptorder}
                form.visible = False
            Next
            Me.Visible = False

            POI_Reset()
            POI_Enable()
        Else
            POI_Enable()

        End If
    End Sub

    Sub POI_Disable()
        btnPOIRemarksS.Enabled = False
        txtPOIRemarks.Enabled = False
        btnPOIOrderS.Enabled = False
        btnPOIOp.Enabled = False
        btniPOI5c.Enabled = False
        btniPOI10c.Enabled = False
        btniPOI20c.Enabled = False
        btniPOI50c.Enabled = False
        btniPOIrm1.Enabled = False
        btniPOIrm5.Enabled = False
        btniPOIrm10.Enabled = False
        btniPOIrm20.Enabled = False
        btniPOIrm50.Enabled = False
        btniPOIrm100.Enabled = False
        btnPOIComp.Enabled = False
        btnPOICancel.Enabled = False


    End Sub

    Sub POI_Enable()
        btnPOIRemarksS.Enabled = True
        txtPOIRemarks.Enabled = True
        btnPOIOrderS.Enabled = True
        btnPOIOp.Enabled = True
        btniPOI5c.Enabled = True
        btniPOI10c.Enabled = True
        btniPOI20c.Enabled = True
        btniPOI50c.Enabled = True
        btniPOIrm1.Enabled = True
        btniPOIrm5.Enabled = True
        btniPOIrm10.Enabled = True
        btniPOIrm20.Enabled = True
        btniPOIrm50.Enabled = True
        btniPOIrm100.Enabled = True
        btnPOIComp.Enabled = True
        btnPOICancel.Enabled = True


    End Sub

    Sub POI_poHisDs_Clear()

        Dim cbClear As New OleDb.OleDbCommandBuilder(poHisDa)

        For i = 0 To poHisDs.Tables("poHisList").Rows.Count - 1

            poHisDs.Tables("poHisList").Rows(0).Delete()

            poHisDa.Update(poHisDs, "poHisList")

        Next

    End Sub

    Sub POI_Clear_TEMP_T()

        Dim cbClear As New OleDb.OleDbCommandBuilder(poClearDa)

        For i = 0 To poClearDs.Tables("poClearList").Rows.Count - 1

            poClearDs.Tables("poClearList").Rows(0).Delete()

            poClearDa.Update(poClearDs, "poClearList")

        Next

    End Sub

    Sub ROI_Refresh_From_POI()

        receiptorder.lblROIOID.Text = lblPOIOID.Text
        receiptorder.lblROICID.Text = lblPOICID.Text
        receiptorder.ROI_roHisDs_Load()
        receiptorder.ROI_roHisDs_Refresh_From_POI()
        receiptorder.ROI_roFinalDs_Load()
        receiptorder.ROI_roFinalDs_Refresh_From_POI()

        receiptorder.lblROISID.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(2)
        receiptorder.lblROICName.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(3)
        receiptorder.lblROIDate.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(4) & ", " & receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(5)
        receiptorder.lblROITax.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(13)
        receiptorder.lblROIPayable.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(15)
        receiptorder.lblROIPaid.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(16)
        receiptorder.lblROIChange.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(17)
        receiptorder.txtROIRemarks.Text = receiptorder.roHisDs.Tables("roHisList").Rows(0).Item(18)

    End Sub

    Sub POI_Reset()
        lblPOIPayableRM.Text = "RM0.00"
        lblPOIPaidRM.Text = "RM0.00"
        lblPOIChangeRM.Text = "RM0.00"

        lblPOICID.Text = "C00000"
        lblPOIOID.Text = "O00000"

        txtPOIRemarks.Text = ""

        panPOIRemarks.Location = New Point(810, 500)
        panPOIOrder.Location = New Point(810, 500)

        subtractEnabled = False
        btnPOIOp.Visible = False
        btnPOIOp.Text = "Subtract"
        btnPOIComp.Visible = False

        panPOIChange.Visible = False
        panPOIPaid.Visible = False


        paid = 0

    End Sub

    Private Sub POI_Show_Remarks_Button(sender As Object, e As EventArgs) Handles btnPOIRemarksS.Click
        panPOIRemarks.Location = New Point(145, 70)
        btnPOIRemarksS.Visible = False
    End Sub

    Private Sub POI_Hide_Remarks_Button(sender As Object, e As EventArgs) Handles btniPOIRemarksH.Click
        panPOIRemarks.Location = New Point(810, 500)
        btnPOIRemarksS.Visible = True
    End Sub

    Private Sub POI_Show_Order_Button(sender As Object, e As EventArgs) Handles btnPOIOrderS.Click
        panPOIOrder.Location = New Point(22, 165)
        btnPOIOrderS.Visible = False

    End Sub

    Private Sub POI_Hide_Order_Button(sender As Object, e As EventArgs) Handles btnPOIOrderH.Click
        panPOIOrder.Location = New Point(810, 500)
        btnPOIOrderS.Visible = True
    End Sub

End Class