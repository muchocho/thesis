Imports MySql.Data.MySqlClient
Public Class Form4
    Private WithEvents _products As New products
    Dim i As Integer
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim dt As DataTable = checkProduct(TextBox1.Text)

            If dt.Rows.Count > 0 Then
                MsgBox("Product name already existing!", vbInformation)
            Else
                If TextBox1.Text = "" Or TextBox2.Text = "" Then
                    MsgBox("Please fillout the information needed!", vbInformation)
                Else
                    addproduct(TextBox1.Text, TextBox2.Text)
                    MsgBox("Product successfully entered", vbInformation)
                    TextBox1.Clear()
                    TextBox2.Clear()

                    FlowLayoutPanel1.Controls.Clear()

                    connect()
                    Dim cmd As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
                    Dim table As New DataTable
                    cmd.Fill(table)

                    Dim count As Integer = productNum()
                    For i = 0 To count - 1
                        _products = New products
                        FlowLayoutPanel1.Controls.Add(_products)
                        _products.Pname = table.Rows(i).Item(1).ToString
                        _products.Pprice = table.Rows(i).Item(2).ToString

                    Next



                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FlowLayoutPanel1.Controls.Clear()

        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
        Dim table As New DataTable
        cmd.Fill(table)

        Dim count As Integer = productNum()
        For i = 0 To count - 1
            _products = New products
            FlowLayoutPanel1.Controls.Add(_products)
            _products.Pname = table.Rows(i).Item(1).ToString
            _products.Pprice = table.Rows(i).Item(2).ToString

        Next



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim productdd As Integer
            connect()
            Dim cmd As New MySqlCommand("SELECT productId FROM product_info WHERE productName = @1", conbin)
            cmd.Parameters.AddWithValue("@1", TextBox3.Text)
            Dim dr As MySqlDataReader = cmd.ExecuteReader
            dr.Read()
            productdd = dr("productId")

            alterproduct(TextBox3.Text, TextBox4.Text, productdd)
            MsgBox("Product successfully altered", vbInformation)

            FlowLayoutPanel1.Controls.Clear()

            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
            Dim table As New DataTable
            cmd1.Fill(table)

            Dim count As Integer = productNum()
            For i = 0 To count - 1
                _products = New products
                FlowLayoutPanel1.Controls.Add(_products)
                _products.Pname = table.Rows(i).Item(1).ToString
                _products.Pprice = table.Rows(i).Item(2).ToString

            Next
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then
            FlowLayoutPanel1.Controls.Clear()

            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
            Dim table As New DataTable
            cmd.Fill(table)

            Dim count As Integer = productNum()
            For i = 0 To count - 1
                _products = New products
                FlowLayoutPanel1.Controls.Add(_products)
                _products.Pname = table.Rows(i).Item(1).ToString
                _products.Pprice = table.Rows(i).Item(2).ToString

            Next
        Else
            FlowLayoutPanel1.Controls.Clear()

            connect()
            Dim cmd As New MySqlCommand("SELECT COUNT(productId) FROM product_info WHERE productName LIKE '%" & TextBox5.Text & "%'", conbin)
            Dim sqlresult1 As Integer
            sqlresult1 = cmd.ExecuteScalar

            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM product_info WHERE productName LIKE '%" & TextBox5.Text & "%'", conbin)
            Dim table1 As New DataTable
            cmd1.Fill(table1)

            For q = 0 To sqlresult1 - 1
                _products = New products
                FlowLayoutPanel1.Controls.Add(_products)
                _products.Pname = table1.Rows(q).Item(1).ToString
                _products.Pprice = table1.Rows(q).Item(2).ToString
            Next

        End If
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox6.Text = "" Then
                MsgBox("error: Empty Field! ", vbInformation)
            Else
                delprod(TextBox6.Text)
                TextBox6.Clear()

                FlowLayoutPanel1.Controls.Clear()

                connect()
                Dim cmd1 As New MySqlDataAdapter("SELECT * FROM product_info", conbin)
                Dim table As New DataTable
                cmd1.Fill(table)

                Dim count As Integer = productNum()
                For i = 0 To count - 1
                    _products = New products
                    FlowLayoutPanel1.Controls.Add(_products)
                    _products.Pname = table.Rows(i).Item(1).ToString
                    _products.Pprice = table.Rows(i).Item(2).ToString

                Next

                MsgBox("Product Deleted!", vbInformation)

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class