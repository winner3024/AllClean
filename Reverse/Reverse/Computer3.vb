Public Class Computer3

    Dim Grid As ReverseGrid
    Public Standard As CellStatus

    Public Sub New(ByVal Grid As ReverseGrid, ByVal Standard As CellStatus)

        Me.Grid = Grid
        Me.Standard = Standard

    End Sub
    Public Sub Put()

        Dim X As Integer
        Dim Y As Integer
        Dim PlayerColor As CellStatus

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

        If Standard = CellStatus.Black Then
            PlayerColor = CellStatus.White
        Else
            PlayerColor = CellStatus.Black
        End If

        '順番に見ていってはじめに置けるところを探す
        Dim ImageGrid As ReverseGrid
        Dim Puts As New ArrayList

        For Y = 0 To ReverseGrid.YCount - 1
            For X = 0 To ReverseGrid.XCount - 1

                If Grid.CanPut(Standard, X, Y) Then

                    Puts.Add(New Point(X, Y))

                    '▼まず、コピーのグリッドに石を置いてみる
                    ImageGrid = Grid.Copy
                    ImageGrid.Put(Standard, X, Y)

                    'この状態で相手に角を取られる可能性があるか検証する
                    Select Case True
                        Case ImageGrid.CanPut(PlayerColor, 0, 0)
                            '左上の角を取られてしまうので何もしない
                        Case ImageGrid.CanPut(PlayerColor, 0, ReverseGrid.YCount - 1)
                            '左下の角を取られてしまうので何もしない
                        Case ImageGrid.CanPut(PlayerColor, ReverseGrid.XCount - 1, 0)
                            '右上の角を取られてしまうので何もしない
                        Case ImageGrid.CanPut(PlayerColor, ReverseGrid.XCount - 1, ReverseGrid.YCount - 1)
                            '右下の角を取られてしまうので何もしない
                        Case Else
                            '角を取られる心配がないのでこの位置に石を置く
                            Grid.Put(Standard, X, Y)
                            Return
                    End Select

                End If

            Next
        Next

        '角を取られる位置にしか置けない場合、仕方ないので置く
        Dim Pos As Point = DirectCast(Puts(0), Point)
        Grid.Put(Standard, Pos.X, Pos.Y)

    End Sub

End Class
