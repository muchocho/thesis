Imports System.IO.Ports
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim data As String
    Dim getid As Boolean
    Dim uid As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Enabled = True
        Panel5.BackColor = Color.IndianRed
        Button2.Enabled = False
        ComboBox1.Enabled = False
        TextBox7.Hide()
        Panel36.Hide()
        Panel11.Hide()
        Panel8.Show()
        Panel27.Hide()
        Panel9.Hide()
        Label9.Hide()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim logpoints As Integer
        getid = True
        Try
            data = SerialPort1.ReadExisting()
            If data <> "" Then
                If getid = True Then


                    connect()
                    Dim comm As New MySqlCommand("select * from user_info where uID='" & data & "'", conbin)
                    Dim dr As MySqlDataReader = comm.ExecuteReader
                    If (dr.Read) Then
                        Label16.Text = dr("lastN")
                        Label17.Text = dr("firstN")
                        Label18.Text = dr("middleE")
                        Label19.Text = dr("course_year")

                        numpoints = dr("numPoints")
                        dataID = data


                        Try
                            logpoints = usedpoints()
                            Label15.Text = numpoints - logpoints
                        Catch ex As Exception
                            MsgBox(ex.Message, vbInformation)
                        End Try

                    Else
                        MessageBox.Show("id not found")
                    End If


                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        TextBox7.Show()
        TextBox7.Focus()
        Panel36.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.Enabled = True


        Try
            ComboBox1.Items.Clear()
            For Each port As String In SerialPort.GetPortNames()
                ComboBox1.Items.Add(port)
            Next
            ComboBox1.SelectedIndex = 0
            Button2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Connect" Then
            SerialPort1.PortName = ComboBox1.SelectedItem
            SerialPort1.BaudRate = "9600"
            Try
                SerialPort1.Open()
                Timer1.Start()
                Panel27.Show()
                Panel8.Hide()
                Panel9.Show()
                Panel34.Hide()
                Button2.Text = "Disconnect"
                Panel5.BackColor = Color.LightGreen
                ComboBox1.Enabled = False
                Button1.Enabled = False
            Catch ex As Exception

            End Try
        Else
            SerialPort1.Close()
            Timer1.Stop()
            Panel5.BackColor = Color.IndianRed
            Button2.Text = "Connect"
            ComboBox1.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = False

        End If
    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        Timer1.Stop()
        Timer2.Start()
        Panel11.Show()
        Panel8.Hide()
        Panel9.Hide()
        Panel27.Hide()
        Panel34.Show()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            data = SerialPort1.ReadExisting
            If data <> "" Then
                If getid = True Then
                    uid = data
                    Label9.Text = data
                    MessageBox.Show("RFID successfully scaned.")
                    getid = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel26_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel26.MouseClick
        If Timer2.Enabled = True Then
            getid = True

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lgg As String = "Register"
        Try
            Dim dt As DataTable = check(uid)
            If dt.Rows.Count > 0 Then
                MsgBox("RFID card is already registered!", vbInformation)
            Else
                If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or uid = "" Then
                    MsgBox("All fields are required")

                Else
                    register(uid, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
                    logs(uid, lgg, Label1.Text)
                    MsgBox("User Successfully Registered", vbInformation)
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try







    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel34_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel34.MouseClick
        Timer1.Start()
        Timer2.Stop()
        Panel27.Show()
        Panel11.Hide()
        Panel9.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Panel35_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel35.MouseClick
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        Panel8.Show()
        Panel27.Hide()
        Panel11.Hide()
        Panel9.Hide()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label1.Text = Date.Now.ToString("MM/dd/yyyy")
        Label2.Text = Date.Now.ToString("hh:mm")
    End Sub

    Private Sub Panel36_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel36.MouseClick
        Try
            Dim dt As DataTable = login(user, TextBox7.Text)
            If dt.Rows.Count > 0 Then
                Form2.Show()
                Me.Close()
            Else
                MsgBox("Invalid userid or password!!!", vbInformation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub


    Private Sub Panel36_MouseLeave(sender As Object, e As EventArgs) Handles Panel36.MouseLeave
        TextBox7.Hide()
        Panel36.Hide()
        TextBox7.Clear()
    End Sub
End Class
