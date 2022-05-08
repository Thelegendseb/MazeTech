Public Class Maze

    Protected Grid As Cell(,)
    Protected Maze As New List(Of Cell)
    Protected Frontier As New List(Of Cell)
    Protected Shared Width, Height As Integer


    Sub New()
        Me.Width = 9
        Me.Height = 9
        CreateGrid(Me.Width, Me.Height)
    End Sub
    Public Sub Generate()
        Reset()

        Dim Firstcell As Cell = RandomCellFrom(Me.Grid)
        Me.Maze.Add(Firstcell)
        Me.Frontier.AddRange(NonMazeNeighbors(Firstcell))

        Dim CurrentCell As Cell

        Do

            CurrentCell = RandomCellFrom(Me.Frontier, False) 'ISNT MAZE

            Carve(CurrentCell, RandomCellFrom(Me.Maze, True)) 'IS MAZE

            SetIntoGrid(CurrentCell)

            Frontier.Remove(CurrentCell)
            Maze.Add(CurrentCell)
            Frontier.AddRange(NonMazeNeighbors(CurrentCell))

        Loop Until Frontier.Count = 0

    End Sub
    '==========================================
    Private Sub SetIntoGrid(Cell As Cell)
        Me.Grid(Cell.GetY, Cell.GetX).SetCarvings(Cell.GetCarvings)
    End Sub
    Private Sub Carve(ByRef Cell1 As Cell, ByRef Cell2 As Cell)
        If Cell1.GetX > Cell2.GetX Then
            Cell1.SetCarving(1)
            Cell2.SetCarving(3)
            Return
        ElseIf Cell1.GetX < Cell2.GetX Then
            Cell1.SetCarving(3)
            Cell2.SetCarving(1)
            Return
        End If
        If Cell1.GetY > Cell2.GetY Then
            Cell1.SetCarving(2)
            Cell2.SetCarving(0)
            Return
        ElseIf Cell1.GetY < Cell2.GetY Then
            Cell1.SetCarving(0)
            Cell2.SetCarving(2)
            Return
        End If
        Throw New Exception("Cells Unable to carve together")
    End Sub
    Private Function NonMazeNeighbors(Cell As Cell) As List(Of Cell)
        Dim R As New List(Of Cell)

        For i = -1 To 1
            For j = -1 To 1
                If (i = 0 Or j = 0) And i <> j Then 'vertical, horizontal, non-central

                    If (Cell.GetY + i < 0) Or (Cell.GetY + i > Me.Height) Or
                     (Cell.GetX + j < 0) Or (Cell.GetX + j > Me.Width) Then
                        ' Outside Bounds
                    Else

                        If Me.Maze.Contains(New Cell(Cell.GetX + i, Cell.GetY + i)) = False Then
                            R.Add(New Cell(Cell.GetX + j, Cell.GetY + i))
                        End If

                    End If
                End If
            Next
        Next
        Return R

    End Function
    Private Function RandomCellFrom(Grid(,) As Cell) As Cell
        Randomize()
        Dim randomy As Integer = Int(Rnd() * (Grid.GetLength(0) - 1))
        Dim randomx As Integer = Int(Rnd() * (Grid.GetLength(1) - 1))
        Return Grid(randomy, randomx)
    End Function
    Private Function RandomCellFrom(CellList As List(Of Cell), IsMaze As Boolean) As Cell
        Dim R As Cell
        Randomize()
        If IsMaze = False Then
            Do
                R = CellList(Rnd() * (CellList.Count - 1))
            Loop Until Me.Maze.Contains(R) = False
            Return R
        Else
            Return CellList(Rnd() * (CellList.Count - 1))
        End If
    End Function
    '==========================================
    Private Sub CreateGrid(width As Integer, height As Integer)
        Me.Grid = New Cell(height, width) {}
        For i = 0 To height
            For j = 0 To width
                Me.Grid(i, j) = New Cell(j, i)
            Next
        Next
    End Sub
    Private Sub InitialiseGrid()
        Me.Grid = New Cell(Height, Width) {}
    End Sub
    Private Sub Reset()
        ResetGrid()
        ResetMaze()
        ResetFrontier()
    End Sub
    Private Sub ResetGrid()
        For Each element As Cell In Me.Grid
            element = New Cell(element.GetX, element.GetY)
        Next
    End Sub
    Private Sub ResetMaze()
        Me.Maze.Clear()
    End Sub
    Private Sub ResetFrontier()
        Me.Frontier.Clear()
    End Sub

    '=========================================
    Public Function GetGrid() As Cell(,)
        Return Me.Grid
    End Function


End Class
