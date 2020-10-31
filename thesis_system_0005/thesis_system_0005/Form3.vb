Imports MySql.Data.MySqlClient
Public Class Form3

    Dim i As Integer
    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        Form1.Show()
        Me.Close()
        Form1.Panel27.Show()
        Form1.Panel11.Hide()
        Form1.Panel8.Hide()
        FlowLayoutPanel2.Controls.Clear()

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel2.Controls.Clear()
        Label2.Text = Form1.Label16.Text
        Label4.Text = Form1.Label17.Text + " " + Form1.Label18.Text
        Label5.Text = Form1.Label19.Text
        Label15.Text = Form1.Label15.Text

        connect()
        Dim cmd1 As New MySqlDataAdapter("SELECT * FROM red_logs WHERE uID = '" & dataID & "'", conbin)
        Dim tabl1 As New DataTable
        cmd1.Fill(tabl1)

        Dim counr As Integer = redNume()
        For i = 0 To counr - 1
            _redlogs = New relogs
            FlowLayoutPanel2.Controls.Add(_redlogs)
            _redlogs.Pname = tabl1.Rows(i).Item(1).ToString
            _redlogs.Pprice = tabl1.Rows(i).Item(2).ToString
            _redlogs.date1 = tabl1.Rows(i).Item(3).ToString

        Next

        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
        Dim table As New DataTable
        cmd.Fill(table)

        Products1.Pname = table.Rows(0).Item(1).ToString
        Products1.Pprice = table.Rows(0).Item(2).ToString
        Products2.Pname = table.Rows(1).Item(1).ToString
        Products2.Pprice = table.Rows(1).Item(2).ToString
        Products3.Pname = table.Rows(2).Item(1).ToString
        Products3.Pprice = table.Rows(2).Item(2).ToString
        Products4.Pname = table.Rows(3).Item(1).ToString
        Products4.Pprice = table.Rows(3).Item(2).ToString
        Products5.Pname = table.Rows(4).Item(1).ToString
        Products5.Pprice = table.Rows(4).Item(2).ToString
        Products6.Pname = table.Rows(5).Item(1).ToString
        Products6.Pprice = table.Rows(5).Item(2).ToString
        Products7.Pname = table.Rows(6).Item(1).ToString
        Products7.Pprice = table.Rows(6).Item(2).ToString
        Products8.Pname = table.Rows(7).Item(1).ToString
        Products8.Pprice = table.Rows(7).Item(2).ToString
        Products9.Pname = table.Rows(8).Item(1).ToString
        Products9.Pprice = table.Rows(8).Item(2).ToString
        Products10.Pname = table.Rows(9).Item(1).ToString
        Products10.Pprice = table.Rows(9).Item(2).ToString



    End Sub

    Private Sub Products1_MouseClick(sender As Object, e As MouseEventArgs) Handles Products1.MouseClick
        If Products1.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products1.Pname
            notif.Label1.Text = Products1.Pprice
        End If
    End Sub

    Private Sub Products2_MouseClick(sender As Object, e As MouseEventArgs) Handles Products2.MouseClick

        If Products2.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products2.Pname
            notif.Label1.Text = Products2.Pprice
        End If
    End Sub

    Private Sub Products3_MouseClick(sender As Object, e As MouseEventArgs) Handles Products3.MouseClick

        If Products3.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products3.Pname
            notif.Label1.Text = Products3.Pprice
        End If
    End Sub

    Private Sub Products4_MouseClick(sender As Object, e As MouseEventArgs) Handles Products4.MouseClick

        If Products4.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products4.Pname
            notif.Label1.Text = Products4.Pprice
        End If
    End Sub

    Private Sub Products5_MouseClick(sender As Object, e As MouseEventArgs) Handles Products5.MouseClick

        If Products5.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products5.Pname
            notif.Label1.Text = Products5.Pprice
        End If
    End Sub

    Private Sub Products6_MouseClick(sender As Object, e As MouseEventArgs) Handles Products6.MouseClick

        If Products6.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products6.Pname
            notif.Label1.Text = Products6.Pprice
        End If
    End Sub

    Private Sub Products7_MouseClick(sender As Object, e As MouseEventArgs) Handles Products7.MouseClick

        If Products7.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products7.Pname
            notif.Label1.Text = Products7.Pprice
        End If
    End Sub

    Private Sub Products8_MouseClick(sender As Object, e As MouseEventArgs) Handles Products8.MouseClick

        If Products8.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products8.Pname
            notif.Label1.Text = Products8.Pprice
        End If
    End Sub

    Private Sub Products9_MouseClick(sender As Object, e As MouseEventArgs) Handles Products9.MouseClick

        If Products9.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products9.Pname
            notif.Label1.Text = Products9.Pprice
        End If
    End Sub

    Private Sub Products10_MouseClick(sender As Object, e As MouseEventArgs) Handles Products10.MouseClick

        If Products10.Pprice > Label15.Text Then
            MsgBox("You dont have enough points!", vbInformation)
        Else
            notif.Show()
            notif.Label15.Text = Products10.Pname
            notif.Label1.Text = Products10.Pprice
        End If
    End Sub


End Class