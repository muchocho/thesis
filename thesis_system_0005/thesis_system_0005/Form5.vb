Imports System.IO.Ports
Imports MySql.Data.MySqlClient
Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim comm As New MySqlCommand("select * from user_info where uID='" & dataID & "'", conbin)
            Dim dr As MySqlDataReader = comm.ExecuteReader
            If (dr.Read) Then
                TextBox1.Text = dr("idNumber")
                TextBox2.Text = dr("lastN")
                TextBox3.Text = dr("firstN")
                TextBox4.Text = dr("middleE")
                TextBox5.Text = dr("course_year")
                TextBox6.Text = dr("password")
            Else
                MessageBox.Show("id not found")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.Text = "admin" Then
            Panel3.Hide()
        Else
            Try
                Dim dt As DataTable = enterpass(TextBox7.Text)
                If dt.Rows.Count > 0 Then
                    Panel3.Hide()
                Else
                    MsgBox("Invalid password!!!", vbInformation)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If

    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        Try
            alteruser(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
            MsgBox("Successfully altered", vbInformation)
            Form1.Show()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        Form1.Show()
        Me.Close()
    End Sub
End Class