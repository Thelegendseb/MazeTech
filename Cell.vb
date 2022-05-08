Public Class Cell

    Protected X, Y As Integer
    Protected Carvings(3) As Boolean 'U,R-D-L {0,1,2,3}

    Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
        SetAllCarvings()
    End Sub
    Public Sub SetCarving(Dir As Byte)
        If Dir > 3 Then
            Throw New Exception("Invalid carving direction")
        Else
            Me.Carvings(Dir) = True
        End If
    End Sub
    Public Sub SetCarvings(BoolArr() As Boolean)
        Me.Carvings = BoolArr
    End Sub
    Public Function GetCarvings() As Boolean()
        Return Me.Carvings
    End Function
    Public Function GetX() As Integer
        Return Me.X
    End Function
    Public Function GetY() As Integer
        Return Me.Y
    End Function
    Private Sub SetAllCarvings()
        For Each carving As Boolean In Me.Carvings
            carving = False
        Next
    End Sub


End Class
