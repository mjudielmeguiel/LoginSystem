Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient

Public Class frmlogin

    Private Sub frmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyEdgeStyle()
        MakeButtonRounded(btnlogin, 6)
        MakeButtonRounded(btnClose, 6)

        txtUsername.Text = "Please Enter your username"
        txtUsername.ForeColor = Color.DarkGray
        txtPassword.Text = "Please Enter your Password"
        txtPassword.ForeColor = Color.DarkGray
        txtPassword.PasswordChar = Nothing
        lblError.Text = ""
        lblAttempts.Text = "0"
    End Sub

    ' -------------------------------------------------------------
    ' STYLING & CORNER RADIUS
    ' -------------------------------------------------------------
    Private Sub ApplyEdgeStyle()
        btnlogin.FlatStyle = FlatStyle.Flat
        btnlogin.FlatAppearance.BorderSize = 0
        btnlogin.BackColor = Color.FromArgb(0, 103, 184)
        btnlogin.ForeColor = Color.White
        btnlogin.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        btnlogin.Cursor = Cursors.Hand

        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.FlatAppearance.BorderSize = 1
        btnClose.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)
        btnClose.BackColor = Color.White
        btnClose.ForeColor = Color.FromArgb(32, 32, 32)
        btnClose.Font = New Font("Segoe UI", 10.0!, FontStyle.Regular)
        btnClose.Cursor = Cursors.Hand
    End Sub

    Private Sub MakeButtonRounded(btn As Button, radius As Integer)
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, btn.Height - radius, radius, radius, 90, 90)
        path.CloseAllFigures()
        btn.Region = New Region(path)
    End Sub

    ' -------------------------------------------------------------
    ' BUTTON HOVER EFFECTS
    ' -------------------------------------------------------------
    Private Sub btnlogin_MouseEnter(sender As Object, e As EventArgs) Handles btnlogin.MouseEnter
        btnlogin.BackColor = Color.FromArgb(0, 90, 158)
    End Sub

    Private Sub btnlogin_MouseLeave(sender As Object, e As EventArgs) Handles btnlogin.MouseLeave
        btnlogin.BackColor = Color.FromArgb(0, 103, 184)
    End Sub

    Private Sub btnlogin_MouseDown(sender As Object, e As MouseEventArgs) Handles btnlogin.MouseDown
        btnlogin.BackColor = Color.FromArgb(0, 78, 137)
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.White
    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        btnClose.BackColor = Color.FromArgb(225, 225, 225)
    End Sub

    ' -------------------------------------------------------------
    ' PLACEHOLDER & FOCUS LOGIC
    ' -------------------------------------------------------------
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

    ' -------------------------------------------------------------
    ' AUTHENTICATION LOGIC
    ' -------------------------------------------------------------
    Private Sub checkifuserexist()
        connection()
        lblError.Text = ""

        If cn.State <> ConnectionState.Open Then
            lblError.Text = "Cannot connect to database!"
            Exit Sub
        End If

        ' Query 'users' table
        sql = "SELECT Status FROM users WHERE Username=@user"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            If dr("Status").ToString().Trim() = "Inactive" Then
                lblError.Text = "Your account is inactive/deactivated."
                dr.Close()
                CloseConnection()
                Exit Sub
            End If

            dr.Close()
            CloseConnection()
            Login()
        Else
            dr.Close()

            ' Query 'admins' table
            sql = "SELECT AdminID FROM admins WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                dr.Close()
                CloseConnection()
                LoginAdmin()
            Else
                lblError.Text = "User does not exist."
                dr.Close()
                CloseConnection()
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        lblError.Text = ""
        Dim userInput As String = txtUsername.Text.Trim()
        Dim passInput As String = txtPassword.Text.Trim()

        If userInput = "" OrElse userInput = "Please Enter your username" OrElse
           passInput = "" OrElse passInput = "Please Enter your Password" Then
            lblError.Text = "Enter username and password."
            Return
        End If

        checkifuserexist()
    End Sub

    Private Sub Login()
        connection()
        lblError.Text = ""

        If cn.State <> ConnectionState.Open Then
            lblError.Text = "Cannot connect to database!"
            Exit Sub
        End If

        sql = "SELECT * FROM users WHERE Username=@user AND PasswordHash=@pass"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            LoggedFullname = dr("FullName").ToString()
            LoggedRole = dr("Role").ToString().Trim()
            Dim currentUser As String = txtUsername.Text.Trim()
            dr.Close()

            sql = "UPDATE users SET Status='Active', UpdatedAt=NOW() WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", currentUser)
            cmd.ExecuteNonQuery()

            CloseConnection()

            lblError.Text = "✓ Login Success! Redirecting..."
            Timer1.Interval = 800
            Timer1.Start()
        Else
            dr.Close()
            Dim currentAttempts As Integer
            If Not Integer.TryParse(lblAttempts.Text, currentAttempts) Then currentAttempts = 0
            currentAttempts += 1
            lblAttempts.Text = currentAttempts.ToString()

            If currentAttempts >= 3 Then
                lblError.Text = "3 failed attempts reached. Account deactivated."
                DeactAccts()
            Else
                lblError.Text = $"✗ Incorrect Password. Attempt {currentAttempts} of 3."
            End If

            CloseConnection()
        End If
    End Sub

    Private Sub LoginAdmin()
        connection()
        lblError.Text = ""

        If cn.State <> ConnectionState.Open Then
            lblError.Text = "Cannot connect to database!"
            Exit Sub
        End If

        sql = "SELECT * FROM admins WHERE Username=@user AND PasswordHash=@pass"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            LoggedFullname = dr("FullName").ToString()
            LoggedRole = "Administrator"
            Dim currentUser As String = txtUsername.Text.Trim()
            dr.Close()

            sql = "UPDATE admins SET LastLogin=NOW() WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", currentUser)
            cmd.ExecuteNonQuery()

            CloseConnection()

            lblError.Text = "✓ Admin Login Success! Redirecting..."
            Timer1.Interval = 800
            Timer1.Start()
        Else
            dr.Close()
            lblError.Text = "✗ Incorrect Admin Password."
            CloseConnection()
        End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Hide()
        frmMain.Show()
    End Sub

    Private Sub DeactAccts()
        connection()
        If cn.State <> ConnectionState.Open Then Exit Sub
        sql = "UPDATE users SET Status='Inactive' WHERE Username=@user"
        cmd = New MySqlCommand(sql, cn)
        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
        cmd.ExecuteNonQuery()
        CloseConnection()
    End Sub

    Private Sub btnShowPass_Click(sender As Object, e As EventArgs) Handles btnShowPass.Click
        txtPassword.PasswordChar = If(txtPassword.PasswordChar = "●"c, Char.MinValue, "●"c)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        frmcreateadmin.Show()
    End Sub

End Class