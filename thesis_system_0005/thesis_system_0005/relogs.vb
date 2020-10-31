Public Class relogs
    Private _pname As String
    Private _pprice As Integer
    Private _date1 As String
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

    Public Property date1 As String
        Get
            Return _date1
        End Get
        Set(value As String)
            _date1 = value
            Label2.Text = value
        End Set
    End Property


End Class
