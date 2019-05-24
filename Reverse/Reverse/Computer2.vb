Public Class Computer2

    Dim Grid As ReverseGrid
    Public Standard As CellStatus

    Public Sub New(ByVal Grid As ReverseGrid, ByVal Standard As CellStatus)

        Me.Grid = Grid
        Me.Standard = Standard

    End Sub
    Public Sub Put()

        Dim X As Integer
        Dim Y As Integer

        '角に置けるなら角におく
        If Grid.CanPut(Standard, 0, 0) Then
            Grid.Put(Standard, 0, 0)
            Return
        End If

        If Grid.CanPut(Standard, 0, ReverseGrid.YCount - 1) Then
            Grid.Put(Standard, 0, ReverseGrid.YCount - 1)
            Return
        End If

        If Grid.CanPut(Standard, ReverseGrid.XCount - 1, 0) Then
            Grid.Put(Standard, ReverseGrid.XCount - 1, 0)
            Return
        End If

        If Grid.CanPut(Standard, ReverseGrid.XCount - 1, ReverseGrid.YCount - 1) Then
            Grid.Put(Standard, ReverseGrid.XCount - 1, ReverseGrid.YCount - 1)
            Return
        End If

        '順番に見ていってはじめに置けるところにどこでもいいから置く
        For Y = 0 To ReverseGrid.YCount - 1
            For X = 0 To ReverseGrid.XCount - 1
                If Grid.CanPut(Standard, X, Y) Then
                    Grid.Put(Standard, X, Y)
                    Return
                End If
            Next
        Next

    End Sub

End Class
