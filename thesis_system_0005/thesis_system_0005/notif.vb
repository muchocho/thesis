Public Class notif



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pointssss As Integer


        Try
            Dim dt As DataTable = enterpass(TextBox2.Text)
            If dt.Rows.Count > 0 Then
                redeemlogs(Label15.Text, Label1.Text, Form1.Label1.Text)
                pointssss = Form3.Label15.Text - Label1.Text
                Form3.Label15.Text = pointssss
                Form1.Label15.Text = pointssss

                MsgBox("Product Redeemed!", vbInformation)

            Else
                MsgBox("Invalid password!!!", vbInformation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub
End Class