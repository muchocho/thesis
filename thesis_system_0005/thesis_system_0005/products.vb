Public Class products


    Private _pname As String
    Private _pprice As Integer

    Public Property Pname As String
        Get
            Return _pname
        End Get
        Set(value As String)
            _pname = value
            Label16.Text = value
        End Set
    End Property

    Public Property Pprice As Integer
        Get
            Return _pprice
        End Get
        Set(value As Integer)
            _pprice = value
            Label1.Text = value
        End Set
    End Property


End Class
