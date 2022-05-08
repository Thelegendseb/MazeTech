Public Class Form1

    Private MyMaze As Maze
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyMaze = New Maze()
        MyMaze.Generate()
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DrawGrid(MyMaze.GetGrid)
    End Sub

    Private Sub DrawGrid(Grid(,) As Cell)
        Dim CellSize As Integer = 32
        Me.Height = Grid.GetLength(0) * (CellSize + 1)
        Me.Width = Grid.GetLength(1) * (CellSize + 1)

        For i = 0 To Grid.GetLength(0) - 1
            For j = 0 To Grid.GetLength(1) - 1
                DrawCell(Grid(i, j), j * CellSize, i * CellSize)
            Next
        Next


    End Sub

    Private Sub DrawCell(Cell As Cell, x As Integer, y As Integer)
        Using g As Graphics = Me.CreateGraphics
            Dim Carvings() As Boolean = Cell.GetCarvings
            If Carvings(0) = True Then
                g.FillRectangle(Brushes.Black, x, y, 32, 32)
            End If
            If Carvings(1) = True Then
                g.FillRectangle(Brushes.Black, x, y, 32, 32)
            End If
            If Carvings(2) = True Then
                g.FillRectangle(Brushes.Black, x, y, 32, 32)
            End If
            If Carvings(3) = True Then
                g.FillRectangle(Brushes.Black, x, y, 32, 32)
            End If
        End Using
    End Sub
End Class
