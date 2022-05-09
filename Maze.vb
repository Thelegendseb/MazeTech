Public Class Maze

    Protected Grid As Cell(,)
    Protected Maze As New List(Of Cell)
    Protected Frontier As New List(Of Cell)
    Protected Width, Height As Integer

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

            CurrentCell = RandomCellFrom(Me.Frontier) 'ISNT MAZE

            Carve(CurrentCell, RandomMazeNeighbor(CurrentCell)) 'IS MAZE

            Me.Frontier.Remove(CurrentCell)
            Me.Maze.Add(CurrentCell)
            Me.Frontier.AddRange(NonMazeNeighbors(CurrentCell))

        Loop Until Me.Frontier.Count = 0

    End Sub
    '==========================================
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
        Throw New Exception("Param ""Cell1"" and ""Cell2"" have equal coordinates.")
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

                        If ListContainsCell(Me.Maze, Me.Grid(Cell.GetY + i, Cell.GetX + j)) = False Then
                            R.Add(Me.Grid(Cell.GetY + i, Cell.GetX + j))
                        End If

                    End If
                End If
            Next
        Next
        Return R

    End Function
    Private Function RandomMazeNeighbor(Cell As Cell) As Cell
        Dim R As New List(Of Cell)

        For i = -1 To 1
            For j = -1 To 1
                If (i = 0 Or j = 0) And i <> j Then 'vertical, horizontal, non-central

                    If (Cell.GetY + i < 0) Or (Cell.GetY + i > Me.Height) Or
                     (Cell.GetX + j < 0) Or (Cell.GetX + j > Me.Width) Then
                        ' Outside Bounds
                    Else

                        If ListContainsCell(Me.Maze, Me.Grid(Cell.GetY + i, Cell.GetX + j)) = True Then
                            R.Add(Me.Grid(Cell.GetY + i, Cell.GetX + j))
                        End If

                    End If

                End If
            Next
        Next
        Randomize()
        Dim Index As Integer = Int(Rnd() * (R.Count - 1))
        Return R(Index)
    End Function
    Private Function RandomCellFrom(Grid(,) As Cell) As Cell
        Randomize()
        Dim randomy As Integer = Int(Rnd() * (Grid.GetLength(0) - 1))
        Dim randomx As Integer = Int(Rnd() * (Grid.GetLength(1) - 1))
        Return Grid(randomy, randomx)
    End Function
    Private Function RandomCellFrom(CellList As List(Of Cell)) As Cell
        Randomize()
        Return CellList(Int(Rnd() * (CellList.Count - 1)))
    End Function
    '==========================================
    Private Function ListContainsCell(List As List(Of Cell), Cell As Cell) As Boolean
        For Each C As Cell In List
            If C.GetX = Cell.GetX And C.GetY = Cell.GetY Then Return True

        Next
        Return False
    End Function
    Private Sub CreateGrid(width As Integer, height As Integer)
        ResetGrid()
        For i = 0 To height
            For j = 0 To width
                Me.Grid(i, j) = New Cell(j, i)
            Next
        Next
    End Sub
    Private Sub Reset()
        CreateGrid(Me.Width, Me.Height)
        ResetMaze()
        ResetFrontier()
    End Sub
    Private Sub ResetGrid()
        Me.Grid = New Cell(Height, Width) {}
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