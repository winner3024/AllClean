''' <summary>マスを扱うクラス</summary>
Public Class Cell

    Dim _Status As Integer
    ''' <summary>マスの状態
    ''' 0…空白</summary>
    Public Property Status() As Integer
        Get
            Return _Status
        End Get
        Set(ByVal value As Integer)
            _Status = value
        End Set
    End Property

    Dim _Selected As Boolean
    ''' <summary>マスが選択されているかどうか</summary>
    Public Property Selected() As Boolean
        Get
            Return _Selected
        End Get
        Set(ByVal value As Boolean)
            _Selected = value
        End Set
    End Property

    Dim _Position As Point
    ''' <summary>マスの座標</summary>
    Public Property Position() As Point
        Get
            Return _Position
        End Get
        Set(ByVal value As Point)
            _Position = value
        End Set
    End Property

    ''' <summary>1つのマスの描画</summary>
    ''' <param name="CellSize">マスの大きさを座標で指定</param>
    ''' <param name="Images">このマスの描画に使う画像のクラス</param>
    Public Sub Draw(ByVal g As Graphics, ByVal CellSize As Point, ByVal Images As CellImages)

        'マスの範囲
        Dim rect As Rectangle = New Rectangle(CellSize.X * Position.X, CellSize.Y * Position.Y, CellSize.X, CellSize.Y)

        'このマスが選択されていたら
        If Selected = True Then
            g.DrawImage(Images.SelectedImages(Status), rect)
        Else '選択されていなかったら
            g.DrawImage(Images.Images(Status), rect)
        End If

    End Sub

End Class
