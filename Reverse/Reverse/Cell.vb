Public Class Cell

    Public Status As CellStatus 'セルの状態。黒・白・空。
    Public Grid As ReverseGrid
    Public Position As Point '論理位置
    Public Rectangle As Rectangle '物理位置

    Dim FrontBrush As New SolidBrush(Color.Black)
    '■コンストラクタ
    ''' <summary>論理位置を指定してセルを作成します。</summary>
    ''' <param name="Grid">セルが属するグリッドを指定します。</param>
    ''' <param name="Position">セルの論理位置を指定します。</param>
    Public Sub New(ByVal Grid As ReverseGrid, ByVal Position As Point)

        Me.Grid = Grid
        Me.Position = Position

        Dim Rect As New Rectangle

        '論理位置から物理位置を求めます。
        Rect.X = Position.X * ReverseGrid.CellSize
        Rect.Y = Position.Y * ReverseGrid.CellSize
        Rect.Width = ReverseGrid.CellSize
        Rect.Height = ReverseGrid.CellSize

        Me.Rectangle = Rect
    End Sub

    Dim BackBrush As New SolidBrush(Color.White)

    '■Draw
    ''' <summary>現在の状態を描画します。</summary>
    ''' <param name="g">描画対象のGraphicsオブジェクトを指定します。</param>
    Public Sub Draw(ByVal g As Graphics)

        Dim CellRect As Rectangle '描画領域

        '▼描画領域の算定

        'セルいっぱいに描画するとぎちぎちになるので範囲を-2する。
        CellRect = Me.Rectangle
        CellRect.Inflate(-2, -2)

        '▼描画状態の設定
        Select Case Me.Status
            Case CellStatus.Black
                FrontBrush.Color = Color.Black '表を黒に設定
                BackBrush.Color = Color.White '裏を白に設定
            Case CellStatus.White
                FrontBrush.Color = Color.White '表を白に設定
                BackBrush.Color = Color.Black '裏を黒に設定
        End Select

        '▼描画実行
        If Me.Status <> CellStatus.Nothing Then

            '裏面描画
            CellRect.Y += 2 '裏と表をちょっとずらして立体的に見せる
            g.FillEllipse(BackBrush, CellRect)

            '表面描画
            CellRect.Y -= 2
            g.FillEllipse(FrontBrush, CellRect)

        End If

        '▼アクティブな場合は枠を描画する

        If Me.Focused Then
            g.DrawRectangle(Pens.Orange, CellRect)
        End If

    End Sub
    Public Focused As Boolean

    '■Focus
    ''' <summary>セルをアクティブにします。</summary>
    ''' <remarks>アクティブなセルとはFocusedプロパティがTrueのセルです。
    ''' このメソッドを呼び出すと同じ盤に属するその他のセルのFocusedプロパティをFalseにします。
    ''' アクティブであることにそれ以上の効果はありませんが、
    ''' 描画の際にFocusedプロパティがTrueのセルに枠線を描画します。
    ''' </remarks>
    Public Sub Focus()

        Dim X As Integer
        Dim Y As Integer

        '同じグリッドに属する自分以外のセルを非アクティブにする。
        For X = 0 To ReverseGrid.XCount - 1
            For Y = 0 To ReverseGrid.YCount - 1
                Grid.Cells(X, Y).Focused = False
            Next
        Next

        '自分自身をアクティブにする。
        Me.Focused = True

    End Sub
End Class
