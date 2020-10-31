Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim pwd As String
            user = TextBox1.Text
            pwd = TextBox2.Text
            Dim dt As DataTable = login(user, pwd)
            If dt.Rows.Count > 0 Then
                If ComboBox1.Text = "bin_sys" Then
                    Form1.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                ElseIf ComboBox1.Text = "admin_option"

                    Panel4.Show()
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If

            Else
                MsgBox("Invalid userid or password!!!", vbInformation)
                TextBox1.Clear()
                TextBox2.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "bin_sys"
        Panel4.Hide()
        Panel5.Hide()
        Panel10.Hide()
        Panel11.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        Panel4.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel10.Show()
        Panel11.Show()
    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        Panel4.Show()
        Panel5.Hide()
    End Sub


    Private Sub Panel11_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel11.MouseClick
        Try
            Dim dt As DataTable = login(user, TextBox4.Text)
            If dt.Rows.Count > 0 Then
                Panel5.Show()
                Panel4.Hide()
                Panel10.Hide()
                Panel11.Hide()
                TextBox4.Clear()
            Else
                MsgBox("Invalid userid or password!!!", vbInformation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If TextBox3.Text = "" Or TextBox5.Text = "" Then
                MsgBox("All fields are required")
            Else
                appointadd(TextBox3.Text, TextBox5.Text)
                MsgBox("Admin Appointed!", vbInformation)
                TextBox3.Clear()
                TextBox5.Clear()
                Panel5.Hide()
                Panel5.Hide()
                deleteadd(user)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub
End Class