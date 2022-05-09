Public Class Form1

    Private MyMaze As Maze
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyMaze = New Maze
    End Sub
    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.MouseDown
        MyMaze.Generate()
        DrawGrid(MyMaze.GetGrid)
    End Sub

    'GUI FOR TESTING====================================

    Public Sub DrawGrid(Grid(,) As Cell)   'TESTING
        Dim CellSize As Integer = 50
        Dim WallSize As Integer = 8
        Me.Height = Grid.GetLength(0) * (CellSize + 10)
        Me.Width = Grid.GetLength(1) * (CellSize + 10)

        Using g As Graphics = Me.CreateGraphics
            g.Clear(Me.BackColor)
        End Using
        For i = 0 To Grid.GetLength(0) - 1
            For j = 0 To Grid.GetLength(1) - 1
                DrawCell(Grid(i, j), (j * CellSize) + 35, (i * CellSize) + 35, CellSize, WallSize)
            Next
        Next

    End Sub

    Private Sub DrawCell(Cell As Cell, x As Integer, y As Integer, CellSize As Integer, WallSize As Integer)
        Dim HalfWall As Integer = WallSize / 2
        Using g As Graphics = Me.CreateGraphics
            Dim Carvings() As Boolean = Cell.GetCarvings
            If Carvings(0) = True Then
                g.FillRectangle(Brushes.Black, x, y - HalfWall, CellSize, WallSize)
            End If
            If Carvings(1) = True Then
                g.FillRectangle(Brushes.Black, x + CellSize - HalfWall, y, WallSize, CellSize)
            End If
            If Carvings(2) = True Then
                g.FillRectangle(Brushes.Black, x, y + CellSize - HalfWall, CellSize, WallSize)
            End If
            If Carvings(3) = True Then
                g.FillRectangle(Brushes.Black, x - HalfWall, y, WallSize, CellSize)
            End If
        End Using
    End Sub

    'GUI FOR TESTING====================================
End Class