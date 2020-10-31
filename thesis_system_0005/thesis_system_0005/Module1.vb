Imports MySql.Data.MySqlClient
Module Module1

    Public product_name As String
    Public product_price As Integer
    Public WithEvents _products As New products
    Public WithEvents _redlogs As New relogs
    Public productID As Integer
    Public dataID As String
    Public numpoints As Integer
    Public user As String

    Public conbin As New MySqlConnection("server=localhost;database=bin_data;uid=root;pwd=root;")
    Public Sub connect()
        If conbin.State = ConnectionState.Open Then
            conbin.Close()
            conbin.Open()
        Else
            conbin.Open()
        End If
    End Sub

    Public Function check(uID As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM user_info WHERE uID = @1", conbin)
        cmd.Parameters.AddWithValue("@1", uID)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function checkpoints(uID As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM user_points WHERE uID = @1", conbin)
        cmd.Parameters.AddWithValue("@1", uID)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function checkProduct(productName As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM product_info WHERE productName=@1", conbin)
        cmd.Parameters.AddWithValue("@1", productName)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function login(userid As String, password As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM admin_info WHERE adminID = @1 AND password = @2", conbin)
        cmd.Parameters.AddWithValue("@1", userid)
        cmd.Parameters.AddWithValue("@2", password)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function enterpass(pwd As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM user_info WHERE uID = '" & dataID & "' AND password = @1", conbin)
        cmd.Parameters.AddWithValue("@1", pwd)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function register(uid As String, idnumber As String, last As String, first As String, middle As String, courseyear As String, pass As String)
        Dim points As Integer = 0
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO user_info(uID,idNumber,lastN,firstN,middleE,course_year,password,numPoints)VALUES(@1,@2,@3,@4,@5,@6,@7,@8)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", uid)
            .Parameters.AddWithValue("@2", idnumber)
            .Parameters.AddWithValue("@3", last + ",")
            .Parameters.AddWithValue("@4", first)
            .Parameters.AddWithValue("@5", middle + ".")
            .Parameters.AddWithValue("@6", courseyear)
            .Parameters.AddWithValue("@7", pass)
            .Parameters.AddWithValue("@8", points)
            .ExecuteNonQuery()
        End With
        Return True

    End Function

    Public Function logs(uid As String, start As String, datew As String)
        Dim points As Integer = 0
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO red_logs(uID,prod_Name,prod_price,date)VALUES(@1,@2,'" & points & "',@3)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", uid)
            .Parameters.AddWithValue("@2", start)
            .Parameters.AddWithValue("@3", datew)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function appointadd(uid As Integer, pwd As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO admin_info(adminID,password)VALUES(@1,@2)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", uid)
            .Parameters.AddWithValue("@2", pwd)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function deleteadd(uid As Integer)
        connect()
        Dim cmd As New MySqlCommand("DELETE FROM admin_info WHERE adminID=@1", conbin)
        With cmd
            .Parameters.AddWithValue("@1", uid)
            .ExecuteNonQuery()
        End With
        Return True

    End Function

    Public Function delprod(prodname As String)
        connect()
        Dim cmd As New MySqlCommand("DELETE FROM product_info WHERE productName=@1", conbin)
        With cmd
            .Parameters.AddWithValue("@1", prodname)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function redeemlogs(prod_name As String, prod_price As Integer, date1 As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO red_logs(uID,prod_Name,prod_price,date)VALUES('" & dataID & "',@1,@2,@3)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", prod_name)
            .Parameters.AddWithValue("@2", prod_price)
            .Parameters.AddWithValue("@3", date1)
            .ExecuteNonQuery()
        End With
        Return True
    End Function
    Public Function addproduct(productName As String, productPrice As Integer)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO product_info(productName,productPrice)VALUES(@1,@2)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", productName)
            .Parameters.AddWithValue("@2", productPrice)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function productNum()
        connect()
        Dim cmd As New MySqlCommand("SELECT COUNT(productId) FROM product_info", conbin)
        Dim sqlresult As Integer
        sqlresult = cmd.ExecuteScalar
        Return sqlresult
    End Function

    Public Function redNume()
        connect()
        Dim cmd As New MySqlCommand("SELECT COUNT(*) FROM red_logs WHERE uID = '" & dataID & "'", conbin)
        Dim sqlresult As Integer
        sqlresult = cmd.ExecuteScalar
        Return sqlresult

    End Function

    Public Function usedpoints()
        connect()
        Dim cmd As New MySqlCommand("SELECT SUM(prod_price) FROM red_logs WHERE uID = '" & dataID & "'", conbin)
        Dim sqlresult As Integer
        sqlresult = cmd.ExecuteScalar
        Return sqlresult
    End Function



    Public Function alterproduct(productName As String, productPrice As String, productdd As Integer)
        connect()
        Dim cmd As New MySqlCommand("UPDATE product_info SET productName = @1, productPrice = @2 WHERE productId = @3", conbin)
        With cmd
            .Parameters.AddWithValue("@1", productName)
            .Parameters.AddWithValue("@2", productPrice)
            .Parameters.AddWithValue("@3", productdd)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function alteruser(idnumber As Integer, last As String, first As String, middle As String, course As String, pass As String)
        connect()
        Dim cmd As New MySqlCommand("UPDATE user_info SET idNumber = @1, lastN = @2, firstN = @3, middleE = @4, course_year = @5, password = @6 WHERE uID = '" & dataID & "'", conbin)
        With cmd
            .Parameters.AddWithValue("@1", idnumber)
            .Parameters.AddWithValue("@2", last)
            .Parameters.AddWithValue("@3", first)
            .Parameters.AddWithValue("@4", middle)
            .Parameters.AddWithValue("@5", course)
            .Parameters.AddWithValue("@6", pass)
            .ExecuteNonQuery()

        End With
        Return True
    End Function



End Module
