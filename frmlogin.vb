Imports MySql.Data.MySqlClient

Public Class frmlogin

    Private Sub frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = "Please Enter your username"
        txtUsername.ForeColor = Color.DarkGray
        txtPassword.Text = "Please Enter your Password"
        txtPassword.ForeColor = Color.DarkGray
        txtPassword.PasswordChar = Nothing
        lblError.Text = ""
        lblAttempts.Text = "0"
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        lblError.Text = ""
        If txtUsername.Text = "Please Enter your username" Then
            txtUsername.Clear()
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            txtUsername.Text = "Please Enter your username"
            txtUsername.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        lblError.Text = ""
        If txtPassword.Text = "Please Enter your Password" Then
            txtPassword.Clear()
            txtPassword.ForeColor = Color.Black
            txtPassword.PasswordChar = "●"c
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            txtPassword.Text = "Please Enter your Password"
            txtPassword.ForeColor = Color.DarkGray
            txtPassword.PasswordChar = Nothing
        End If
    End Sub

    Private Sub checkifuserexist()
        Call connection()
        lblError.Text = ""

        sql = "SELECT LoginAttempts, AccountStatus FROM users WHERE Username=@user"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            lblAttempts.Text = dr("LoginAttempts").ToString()

            If dr("AccountStatus").ToString() = "Locked" Then
                lblError.Text = "⚠ Your account is locked/deactivated."
                dr.Close()
                Call DBconnection.CloseConnection()
                Exit Sub
            End If

            dr.Close()
            Call DBconnection.CloseConnection()
            Call Login()
        Else
            dr.Close()
            Call DBconnection.CloseConnection()

            ' Check sa Admin Table kung wala sa Users
            Call connection()
            sql = "SELECT AdminID FROM admin WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text)
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                dr.Close()
                Call DBconnection.CloseConnection()
                Call LoginAdmin()
            Else
                lblError.Text = "User does not exist."
                dr.Close()
                Call DBconnection.CloseConnection()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        lblError.Text = ""
        If txtUsername.Text = "" Or txtUsername.Text = "Please Enter your username" Or
           txtPassword.Text = "" Or txtPassword.Text = "Please Enter your Password" Then
            lblError.Text = "Enter username and password."
        Else
            checkifuserexist()
        End If
    End Sub

    Private Sub Login()
        Call connection()
        lblError.Text = ""

        sql = "SELECT * FROM users WHERE Username=@user AND Password=@pass"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text)
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            LoggedFullname = dr("FullName").ToString()
            Dim currentUser As String = txtUsername.Text
            dr.Close()

            sql = "UPDATE users SET LoginAttempts=0, AccountStatus='Active' WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", currentUser)
            cmd.ExecuteNonQuery()

            Call DBconnection.CloseConnection()

            lblError.Text = "✓ Login Success! Redirecting..."
            Timer1.Interval = 800
            Timer1.Start()
        Else
            dr.Close()
            lblAttempts.Text = CInt(lblAttempts.Text) + 1
            Call UpdateAttempts()

            If CInt(lblAttempts.Text) >= 3 Then
                lblError.Text = "3 failed attempts reached. Account locked."
                Call DeactAccts()
            Else
                lblError.Text = $"Incorrect Password. Attempt {lblAttempts.Text} of 3."
            End If
            Call DBconnection.CloseConnection()
        End If
    End Sub

    Private Sub LoginAdmin()
        Call connection()
        lblError.Text = ""

        sql = "SELECT * FROM admin WHERE Username=@user AND Password=@pass"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text)
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            LoggedFullname = dr("FullName").ToString()
            dr.Close()
            Call DBconnection.CloseConnection()

            lblError.Text = "✓ Admin Login Success! Redirecting..."
            Timer1.Interval = 800
            Timer1.Start()
        Else
            dr.Close()
            lblError.Text = "Incorrect Admin Password."
            Call DBconnection.CloseConnection()
        End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Hide()
        frmMain.Show()
    End Sub

    Private Sub UpdateAttempts()
        Call connection()
        sql = "UPDATE users SET LoginAttempts=@attempts WHERE Username=@user"
        cmd = New MySqlCommand(sql, cn)
        With cmd
            .Parameters.AddWithValue("@attempts", lblAttempts.Text)
            .Parameters.AddWithValue("@user", txtUsername.Text)
            .ExecuteNonQuery()
        End With
        Call DBconnection.CloseConnection()
    End Sub

    Private Sub DeactAccts()
        Call connection()
        sql = "UPDATE users SET AccountStatus='Locked' WHERE Username=@user"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text)
        cmd.ExecuteNonQuery()
        Call DBconnection.CloseConnection()
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        If txtPassword.PasswordChar = "●"c Then
            txtPassword.PasswordChar = Char.MinValue
        Else
            txtPassword.PasswordChar = "●"c
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        frmcreateadmin.Show()
    End Sub

End Class