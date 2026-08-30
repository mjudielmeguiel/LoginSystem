Imports MySql.Data.MySqlClient

Public Class frmcreateadmin

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validate required fields
        If txtDepartment.Text.Trim() = "" OrElse txtLastname.Text.Trim() = "" OrElse txtFirstname.Text.Trim() = "" OrElse
       txtUsername.Text.Trim() = "" OrElse txtEmail.Text.Trim() = "" OrElse
       txtPassword.Text = "" OrElse txtConfirmPass.Text = "" Then
            MsgBox("Please fill all required fields!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPass.Text Then
            MsgBox("Password does not match!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim fullName As String = $"{txtLastname.Text.Trim()}, {txtFirstname.Text.Trim()}"

        Call connection()

        Try
            ' 1. Updated: Query 'admins' table (plural)
            sql = "SELECT FullName FROM admins WHERE FullName=@full"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@full", fullName)
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                MsgBox("Full Name already exists!", MsgBoxStyle.Exclamation)
                dr.Close()
                Call DBconnection.CloseConnection()
                ClearAllFields()
                Exit Sub
            End If
            dr.Close()

            ' 2. Updated: Query 'admins' table (plural)
            sql = "SELECT Username FROM admins WHERE Username=@user"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                MsgBox("Username already exists!", MsgBoxStyle.Exclamation)
                dr.Close()
                Call DBconnection.CloseConnection()
                ClearAllFields()
                Exit Sub
            End If
            dr.Close()

            ' 3. Updated: Query 'admins' table (plural)
            sql = "SELECT Email FROM admins WHERE Email=@email"
            cmd = New MySqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                MsgBox("Email already exists!", MsgBoxStyle.Exclamation)
                dr.Close()
                Call DBconnection.CloseConnection()
                ClearAllFields()
                Exit Sub
            End If
            dr.Close()

            ' 4. Updated: INSERT INTO 'admins' table (plural)
            sql = "INSERT INTO admins (FullName, Email, Username, PasswordHash, RoleID, Status) " &
              "VALUES (@full, @email, @user, @pass, 2, 'Active')"

            cmd = New MySqlCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@full", fullName)
                .Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                .Parameters.AddWithValue("@user", txtUsername.Text.Trim())
                .Parameters.AddWithValue("@pass", txtPassword.Text)
                .ExecuteNonQuery()
            End With

            MsgBox("Admin Account Created Successfully!", MsgBoxStyle.Information)
            Call DBconnection.CloseConnection()
            ClearAllFields()

            Me.Hide()
            Dim login As New frmlogin
            login.Show()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
            Call DBconnection.CloseConnection()
            ClearAllFields()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
        Dim login As New frmlogin
        login.Show()
    End Sub

    Private Sub ClearAllFields()
        txtDepartment.Clear()
        txtLastname.Clear()
        txtFirstname.Clear()
        txtUsername.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        txtConfirmPass.Clear()
        lblPassStatus.Text = ""
        txtDepartment.Focus()
    End Sub

    Private Sub CheckPasswordMatch()
        If String.IsNullOrWhiteSpace(txtPassword.Text) AndAlso String.IsNullOrWhiteSpace(txtConfirmPass.Text) Then
            lblPassStatus.Text = ""
            lblPassStatus.ForeColor = Color.Black
            Return
        End If

        If txtPassword.Text = txtConfirmPass.Text Then
            lblPassStatus.Text = "✓ Password Match"
            lblPassStatus.ForeColor = Color.Green
        Else
            lblPassStatus.Text = "✗ Password does not match"
            lblPassStatus.ForeColor = Color.Red
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged, txtConfirmPass.TextChanged
        CheckPasswordMatch()
    End Sub

    Private Sub frmcreateadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPassStatus.Text = ""
    End Sub

End Class