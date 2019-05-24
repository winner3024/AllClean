Public Class Board

    Public Const Size As Integer = 150                 'パネルサイズ
    Public Const Count As Integer = 4                  'パネル数
    Private Panel As Panel                             'パネルのインスタンス
    Private Images(Count - 1, Count - 1) As Image      '画像配列
    Private Shuffles(Count - 1, Count - 1) As Integer  '画像の位置
    Private BlackImg As Image = Image.FromFile(Application.StartupPath & "\Images\black.jpg")
    Private mPanel(Count - 1, Count - 1) As Panel      'パネルの2次元配列

    'コンストラクタ
    Public Sub New()

        For X As Integer = 0 To Count - 1
            For Y As Integer = 0 To Count - 1
                mPanel(X, Y) = New Panel(Me, New Point(X, Y))
            Next
        Next

    End Sub

    '描画処理
    Public Sub Draw(ByVal g As Graphics)
        For Each p As Panel In mPanel
            p.Draw(g)
        Next
    End Sub

    ''' <summary>パネルを動かす</summary>
    ''' <param name="X">動かすパネルのX座標</param>
    ''' <param name="Y">動かすパネルのY座標</param>
    ''' <returns>動かせたらTrue</returns>
    Public Function Move(ByVal X As Integer, ByVal Y As Integer) As Boolean

        'このパネルを動かせるか調べる
        Dim Direction As Direction = CanMove(X, Y)
        Dim imgPanel As Image                         '画像交換に必要な変数
        Dim numPanel As Integer                       '画像番号を交換する
        Dim Black As Point = BlackPanel()


        If Direction = Direction.false Then

            If X = Black.X And Y = Black.Y Then
                Return False
            End If

            If X = Black.X Then
                If Y > Black.Y Then
                    For i As Integer = Black.Y To Y Step 1
                        Move(X, i)
                    Next
                Else
                    For i As Integer = Black.Y To Y Step -1
                        Move(X, i)
                    Next
                End If
            End If

            If Y = Black.Y Then
                If X > Black.X Then
                    For i As Integer = Black.X To X Step 1
                        Move(i, Y)
                    Next
                Else
                    For i As Integer = Black.X To X Step -1
                        Move(i, Y)
                    Next
                End If
            End If

            Return True

        End If

        imgPanel = Panels(X, Y).Image
        Panels(X, Y).PanelStatus = Status.FalsePanel

        numPanel = Panels(X, Y).Now '画像番号
        Select Case Direction
            Case Direction.up
                '上の画像と交換
                Panels(X, Y).Image = Panels(X, Y - 1).Image
                Panels(X, Y - 1).Image = imgPanel
                Panels(X, Y - 1).PanelStatus = Status.TruePanel 'パネルの状態を入れ替える

                '画像番号交換
                Panels(X, Y).Now = Panels(X, Y - 1).Now
                Panels(X, Y - 1).Now = numPanel

            Case Direction.down
                '下の画像と交換
                Panels(X, Y).Image = Panels(X, Y + 1).Image
                Panels(X, Y + 1).Image = imgPanel
                Panels(X, Y + 1).PanelStatus = Status.TruePanel 'パネルの状態を入れ替える

                '画像番号交換
                Panels(X, Y).Now = Panels(X, Y + 1).Now
                Panels(X, Y + 1).Now = numPanel

            Case Direction.left
                '左の画像と交換
                Panels(X, Y).Image = Panels(X - 1, Y).Image
                Panels(X - 1, Y).Image = imgPanel
                Panels(X - 1, Y).PanelStatus = Status.TruePanel 'パネルの状態を入れ替える

                '画像番号交換
                Panels(X, Y).Now = Panels(X - 1, Y).Now
                Panels(X - 1, Y).Now = numPanel

            Case Direction.right
                '右の画像と交換
                Panels(X, Y).Image = Panels(X + 1, Y).Image
                Panels(X + 1, Y).Image = imgPanel
                Panels(X + 1, Y).PanelStatus = Status.TruePanel 'パネルの状態を入れ替える

                '画像番号交換
                Panels(X, Y).Now = Panels(X + 1, Y).Now
                Panels(X + 1, Y).Now = numPanel
        End Select

        Return True

    End Function

    ''' <summary>パネルが動かせるか調べる</summary>
    ''' <param name="X">調べたいパネルのX座標</param>
    ''' <param name="Y">調べたいパネルのY座標</param>
    ''' <returns>動かせる方向(動かせないときはfales)</returns>
    Public Function CanMove(ByVal X As Integer, ByVal Y As Integer) As Direction

        Dim TestX, TestY As Integer

        '右側
        TestX = X + 1
        TestY = Y
        If X < Count - 1 And X >= 0 Then
            If Panels(TestX, TestY).PanelStatus = Status.FalsePanel Then
                Return Direction.right
            End If
        End If

        '左側
        TestX = X - 1
        TestY = Y
        If X < Count And X > 0 Then
            If Panels(TestX, TestY).PanelStatus = Status.FalsePanel Then
                Return Direction.left
            End If
        End If

        '上側
        TestX = X
        TestY = Y - 1
        If Y < Count And Y > 0 Then
            If Panels(TestX, TestY).PanelStatus = Status.FalsePanel Then
                Return Direction.up
            End If
        End If

        '下側
        TestX = X
        TestY = Y + 1
        If Y < Count - 1 And Y >= 0 Then
            If Panels(TestX, TestY).PanelStatus = Status.FalsePanel Then
                Return Direction.down
            End If
        End If

        Return Direction.false

    End Function

    '座標変換
    Public Function PanelFormPosition(ByVal X As Integer, ByVal Y As Integer) As Panel

        Dim ThisPanel As Panel

        If X < 0 OrElse X > Size * Count Then
            Return Nothing
        End If

        If Y < 0 OrElse Y > Size * Count Then
            Return Nothing
        End If

        ThisPanel = Panels(X \ Size, Y \ Size)

        Return ThisPanel

    End Function

    ''' <summary>パネルのプロパティ</summary>
    ''' <param name="X">パネルのX座標</param>
    ''' <param name="Y">パネルのY座標</param>
    ''' <returns>パネルを返す</returns>
    Public Property Panels(ByVal X As Integer, ByVal Y As Integer) As Panel
        Get
            'PictureBox1の範囲を出ると例外が発生する
            '画像より少し小さければ回避できる
            Return mPanel(X, Y)
        End Get
        Set(ByVal value As Panel)
            mPanel(X, Y) = value
        End Set
    End Property

    ''' <summary>動かせる座標を調べる</summary>
    ''' <returns>動かせる座標を配列で返す</returns>
    Public Function MovePanel() As Point()

        Dim result(4) As Point
        Dim i = 0

        For x As Integer = 0 To Count - 1
            For y As Integer = 0 To Count - 1
                If Not CanMove(x, y) = Direction.false Then
                    result(i) = New Point(x, y)
                    i += 1
                End If
            Next
        Next

        Return result

    End Function

    ''' <summary>空パネルの座標を返す</summary>
    Private Function BlackPanel() As Point

        For x As Integer = 0 To Count - 1
            For y As Integer = 0 To Count - 1
                If mPanel(x, y).Now + 1 = 16 Then
                    Return New Point(x, y)
                End If
            Next
        Next

    End Function

    ''' <summary>画像を表示する</summary>
    ''' <param name="Img">表示する画像を受け取る</param>
    Public Sub Shuffle(ByVal Img As Image)

        For X As Integer = 0 To Count - 1
            For Y As Integer = 0 To Count - 1
                If (X = Count - 1) And (Y = Count - 1) Then
                    Panels(X, Y).PanelStatus = Status.FalsePanel
                    Panels(X, Y).Now = 15
                    Panels(X, Y).Image = BlackImg
                Else
                    Panels(X, Y).PanelStatus = Status.TruePanel
                    Dim bmp As Bitmap = New Bitmap(Img)
                    Dim bmp2 As Bitmap = New Bitmap(Size, Size)
                    Using g As Graphics = Graphics.FromImage(bmp2)
                        g.DrawImage(bmp, 0, 0, New Rectangle(Size * X, Size * Y, Size, Size), GraphicsUnit.Pixel)
                        Panels(X, Y).Image = bmp2
                    End Using
                    Panels(X, Y).Now = X + Y * Count
                End If
            Next
        Next

        Rand(500)

    End Sub

    ''' <summary>shuffle関数で表示した画像をバラバラにする</summary>
    ''' <param name="Num">シャッフル回数を指定</param>
    ''' <returns></returns>
    Private Function Rand(ByVal Num As Integer) As Boolean

        Randomize()

        Dim i As Integer

        For i = 0 To Num


            Dim p(4) As Point
            p = MovePanel()
            Dim ram As Integer = Int(Rnd() * p.Length)

            Move(p(ram).X, p(ram).Y)

        Next

        Return True

    End Function

    '正誤チェック
    Public Function ChackBoard() As Boolean

        '画像番号をチェックしていき、あっていたらTrueを返す

        Dim flag As Boolean = False

        For x As Integer = 0 To Count - 1
            For y As Integer = 0 To Count - 1
                If Panels(x, y).Now = x + y * Count Then
                Else
                    flag = True
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    'ヒント
    Public Sub Hint()

        For x As Integer = 0 To Count - 1
            For y As Integer = 0 To Count - 1
                If Panels(x, y).Now = x + y * Count Then
                    Panels(x, y).Hint()
                End If
                Panels(x, y).TrueHint = True
            Next
        Next

        MainForm.PictureBox1.Invalidate()

    End Sub

    Public Sub unHint()

        For x As Integer = 0 To Count - 1
            For y As Integer = 0 To Count - 1
                If Panels(x, y).Now = x + y * Count Then
                    Panels(x, y).unHint()
                End If
                Panels(x, y).TrueHint = False
            Next
        Next

        MainForm.PictureBox1.Invalidate()

    End Sub

End Class

Public Enum Direction
    [false] = 0
    up
    down
    left
    right
End Enum
