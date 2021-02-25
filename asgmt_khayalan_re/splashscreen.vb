
Public Class splashscreen
    '##################################################################################################################################################################################################
    '##########_SPLASH_SCREEN_INTERFACE_START
    '##################################################################################################################################################################################################
    '##########_SPLASH_SCREEN_INTERFACE_LOCAL_VARIABLE
    '##################################################################################################################################################################################################

    Dim lsec As Integer

    '##################################################################################################################################################################################################
    '##########_SPLASH_SCREEN_INTERFACE_CORE
    '##################################################################################################################################################################################################

    Private Sub Splash_Screen_Interface_Startup_Sequence(sender As Object, e As EventArgs) Handles MyBase.Load
        Splash_Screen_Interface_Intro_Transition_Set()
        Splash_Screen_Interface_Startup_Timer_Start()
        Splash_Screen_Interface_Color_Transition_Set()
        Splash_Screen_Interface_Elipse_Set()
    End Sub

    Private Sub Splash_Screen_Interface_Lost_Focus_Check(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Activate()
        Me.TopMost = True
    End Sub

    Sub Splash_Screen_Interface_Startup_Timer_Start()
        timSplStart.Interval = 2000
        timSplStart.Start()
    End Sub

    Private Sub Splash_Screen_Interface_Startup_Timer_Set(sender As Object, e As EventArgs) Handles timSplStart.Tick
        Splash_Screen_Interface_Startup_Status()
    End Sub

    Sub Splash_Screen_Interface_Intro_Transition_Set()
        Dim ftrSplForm As New Bunifu.Framework.UI.BunifuFormFadeTransition
        ftrSplForm.ShowAsyc(Me)
    End Sub

    Sub Splash_Screen_Interface_Color_Transition_Set()
        Dim ctrSplBack As New BunifuColorTransition.BunifuColorTransition
        ctrSplBack.TransitionControl = Me
        ctrSplBack.StartColor = Color.Crimson
        ctrSplBack.EndColor = Color.DarkSlateGray
        ctrSplBack.ColorArray() = {Color.Crimson, Color.DarkSlateGray}
        ctrSplBack.Interval = 5
        ctrSplBack.AutoTransition = True

    End Sub

    Sub Splash_Screen_Interface_Elipse_Set()
        Dim elSplBack As New Bunifu.Framework.UI.BunifuElipse
        elSplBack.ApplyElipse(Me, 50)
    End Sub

    '##################################################################################################################################################################################################
    '##########_SPLASH_SCREEN_INTERFACE_LOAD_SEQUENCE
    '##################################################################################################################################################################################################

    Sub Splash_Screen_Interface_Load_Staff_Login_Interface()
        stafflogin.Show()
        stafflogin.SendToBack()
        stafflogin.Visible = False
    End Sub

    Sub Splash_Screen_Interface_Startup_Status()
        lsec += 1
        lblSplLoad.Visible = True
        If lsec = 2 Then
            Me.Enabled = False
            timSplStart.Interval = 500
            lblSplLoad.Text = "Loading... 100%"
        ElseIf lsec = 3 Then
            timSplStart.Interval = 100
            lblSplLoad.Text = "Loading modules... 100%"
        ElseIf lsec = 4 Then
            timSplStart.Interval = 600
            lblSplLoad.Text = "Loading UI... 100%"
            Splash_Screen_Interface_Load_Staff_Login_Interface()
        ElseIf lsec = 5 Then
            timSplStart.Interval = 250
            lblSplLoad.Text = "Loading font... 100%"
        ElseIf lsec = 6 Then
            timSplStart.Interval = 250
            lblSplLoad.Text = "Loading scripts... 100%"
        ElseIf lsec = 7 Then
            timSplStart.Interval = 400
            lblSplLoad.Text = "Establishing connection... 100%"
            stafflogin.Visible = True
        ElseIf lsec = 8 Then
            timSplStart.Interval = 500
            lblSplLoad.Text = "Finalising..."
        ElseIf lsec = 9 Then
            stafflogin.BringToFront()
            Me.Hide()
            timSplStart.Stop()
        End If
    End Sub

    '##################################################################################################################################################################################################
    '##########_SPLASH_SCREEN_INTERFACE_END
    '##################################################################################################################################################################################################

End Class
