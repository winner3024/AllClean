''' <summary>ステージを扱うメインのクラス</summary>
Public Class Stage

    'X,Y方向のマスの数
    Public Const XCount As Integer = 15
    Public Const YCount As Integer = 12

    Public Const CellCount As Integer = 5 'マスの種類の数

    Dim _CellSize As Point
    ''' <summary>マスのサイズを座標で指定</summary>
    Public Property CellSize() As Point
        Get
            Return _CellSize
        End Get
        Set(ByVal value As Point)
            _CellSize = value
        End Set
    End Property

    Dim Images As New CellImages 'ゲームに使う画像

    'ステージ上の各マス
    Dim m_Cells(XCount - 1, YCount - 1) As Cell
    ''' <summary>指定された座標にあるマスを取得する</summary>
    ''' <param name="x">x座標</param>
    ''' <param name="y">y座標</param>
    Public Property Cells(ByVal x As Integer, ByVal y As Integer) As Cell
        Get
            Return m_Cells(x, y)
        End Get
        Set(ByVal value As Cell)
            m_Cells(x, y) = value
        End Set
    End Property

    '現在消したところのスコア
    Dim _Score As Integer = 0
    ''' <summary>現在消したところのスコア</summary>
    Public Property Score() As Integer
        Get
            Return _Score
        End Get
        Set(ByVal value As Integer)
            _Score = value
        End Set
    End Property



    ''' <summary>新しいステージが作成されたときの処理</summary>
    Public Sub New()

        Dim r As New Random

        '各マスを初期化
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1

                m_Cells(a, b) = New Cell 'インスタンスを作成して新しいマスを作る
                m_Cells(a, b).Status = 0 '状態は空白のマス
                m_Cells(a, b).Selected = False '選択をオフにする
                m_Cells(a, b).Position = New Point(a, b) '座標を設定

            Next b
        Next a



        'マスに使う画像の読み込み

        Dim BasePath As String = Application.StartupPath & "\Image" '画像があるフォルダの場所

        For n As Integer = 1 To CellCount
            'マスの画像がある場所から画像を取得
            Images.Images(n) = Image.FromFile(BasePath & "\Cell" & CStr(n) & ".bmp")
            '選択されたマスの画像を作る
            Images.SelectedImages(n) = Images.MakeSelectedImage(Images.Images(n), Color.White)
        Next n

        '空白のマスの画像
        Images.Images(0) = Image.FromFile(BasePath & "\Space.bmp")



    End Sub

    '''<summary>ステージの初期化</summary>
    Public Sub Initialize()
        Dim r As New Random

        '各マスを初期化
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1

                m_Cells(a, b).Status = r.Next(1, 6) '状態は1～5の整数をランダムに設定
                m_Cells(a, b).Selected = False '選択をオフにする
                m_Cells(a, b).Position = New Point(a, b) '座標を設定

            Next b
        Next a

        Score = 0 'スコアを0にする

    End Sub



    ''' <summary>マスの状態を描画</summary>
    Public Sub Draw(ByVal g As Graphics)

        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1

                'マスの描画
                Cells(a, b).Draw(g, CellSize, Images)

            Next b
        Next a

    End Sub



    ''' <summary>PictureBoxの座標からその位置にあるセルを取得する</summary>
    Public Function CellFromPoint(ByVal p As Point) As Cell
        Dim ThisCell As Cell

        '座標が範囲外の場合
        If p.X < 0 OrElse p.X >= XCount * CellSize.X Then
            Return Nothing
        End If
        If p.Y < 0 OrElse p.Y >= YCount * CellSize.Y Then
            Return Nothing
        End If

        ThisCell = Cells(p.X \ CellSize.X, p.Y \ CellSize.Y)

        Return ThisCell
    End Function

    ''' <summary>マスを選択したとき、
    ''' スコアをForm1に表示させるためのイベント</summary>
    Public Event MsgScore(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>同じ状態のマスを選択状態にする</summary>
    ''' <param name="ThisCell">マス</param>
    Public Sub CellSelect(ByVal ThisCell As Cell)

        'すべてのマスの選択を解除する
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1
                Cells(a, b).Selected = False
            Next b
        Next a

        'このマスが空白だったならば、マスを選択しない。
        If ThisCell.Status = 0 Then
            Exit Sub
        End If

        'このマスを選択する
        ThisCell.Selected = True

        '今回のDo-Loopであるマスが選択されたかどうか
        Dim s As Boolean = False

        Do

            s = False

            'マス全体を見る
            For a As Integer = 0 To XCount - 1
                For b As Integer = 0 To YCount - 1

                    'このマスが選択されていたら
                    If Cells(a, b).Selected = True Then

                        'このマスが一番左端でなく、その左のマスの状態がこのマスと同じだったら
                        If a > 0 AndAlso Cells(a - 1, b).Status = Cells(a, b).Status Then
                            'この左のマスが選択されていなかったら選択する
                            If Cells(a - 1, b).Selected = False Then
                                Cells(a - 1, b).Selected = True
                                s = True
                            End If
                        End If

                        '同様に、右・上・下に対しても行う
                        If a < XCount - 1 AndAlso Cells(a + 1, b).Status = Cells(a, b).Status Then
                            If Cells(a + 1, b).Selected = False Then
                                Cells(a + 1, b).Selected = True
                                s = True
                            End If
                        End If
                        If b > 0 AndAlso Cells(a, b - 1).Status = Cells(a, b).Status Then
                            If Cells(a, b - 1).Selected = False Then
                                Cells(a, b - 1).Selected = True
                                s = True
                            End If
                        End If
                        If b < YCount - 1 AndAlso Cells(a, b + 1).Status = Cells(a, b).Status Then
                            If Cells(a, b + 1).Selected = False Then
                                Cells(a, b + 1).Selected = True
                                s = True
                            End If
                        End If

                    End If

                Next b
            Next a

        Loop Until s = False '今回のループで1回もマスが選択されなくなるまでループを続ける

        'スコアを求める
        'スコアは(消したマスの個数-2)の2乗
        Score = (CountSelections() - 2) ^ 2

        RaiseEvent MsgScore(Me, New EventArgs) 'Form1に、選択したマスを消した場合のスコアを表示

    End Sub

    ''' <summary>選択マスの数を数える</summary>
    Public Function CountSelections()

        Dim Count As Integer = 0

        'マス全体を見る
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1
                'このマスが選択されていたならば
                If Cells(a, b).Selected = True Then
                    Count += 1
                End If
            Next b
        Next a

        Return Count

    End Function



    ''' <summary>マスをクリアしたときに発生させるイベント</summary>
    Public Event CellsClear(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>選択マスをクリアする</summary>
    ''' <remarks>選択マスが2個以上の場合にのみこのメソッドを実行する。</remarks>
    Public Sub Clear()

        '選択マスが1個以下の場合、マスをクリアしない。
        If CountSelections() <= 1 Then
            Exit Sub
        End If

        'sは現在の選択マスの数
        Dim s As Integer = CountSelections()

        'マス全体を見る
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1
                'このマスが選択されていたならば
                If Cells(a, b).Selected = True Then
                    'このマスをクリアし、選択を解除する
                    Cells(a, b).Status = 0
                    Cells(a, b).Selected = False
                End If
            Next b
        Next a

        Stuff() '空白マスの上のマスを落とし、横方向にも詰める

        'イベントによってForm1のスコアを更新
        RaiseEvent CellsClear(Me, New EventArgs)

    End Sub

    '''<summary>空白マスの上のマスを落とし、横方向にも詰める</summary>
    Private Sub Stuff()

        Dim f As Boolean = False '今回のDo-Loopでマスを落とし、または詰めたかどうか

        Do
            f = False

            'マス全体を見る(下から上に)
            For a As Integer = 0 To XCount - 1
                For b As Integer = YCount - 1 To 1 Step -1 '下から上に、上から2段目まで

                    'このマスが空白で、その上のマスが空白でなければ
                    If Cells(a, b).Status = 0 AndAlso Cells(a, b - 1).Status > 0 Then
                        Cells(a, b).Status = Cells(a, b - 1).Status 'このマスの状態を上のマスと同じにする
                        Cells(a, b - 1).Status = 0 '上のマスを空白にする
                        f = True
                    End If

                Next b
            Next a

        Loop Until f = False '今回のループで1回も落としたことがなくなるまでループを続ける

        '空白の縦列を右に詰める
        '最下段を右から左に見ていく。ただし、一番左のマスは除く
        'ここで、最下段が空白だったならその縦列全体が空白のマス

        Do
            f = False

            For a As Integer = XCount - 1 To 1 Step -1

                '最下段が空白で、その左が空白マスでなければ、縦列を右に詰める
                If Cells(a, YCount - 1).Status = 0 AndAlso Cells(a - 1, YCount - 1).Status > 0 Then

                    'マスを縦に見ていく
                    For b As Integer = 0 To YCount - 1
                        'このマスの状態をその左のマスと同じにして、左のマスを空白にする
                        Cells(a, b).Status = Cells(a - 1, b).Status
                        Cells(a - 1, b).Status = 0
                    Next b

                    f = True

                End If

            Next a

        Loop Until f = False '今回のループでマスを1回も詰めたことがなくなるまでループを続ける

    End Sub



    ''' <summary>今のステージで、1か所も消すことができないかどうか</summary>
    Public Function IsGameOver() As Boolean

        'あるマスの右に、同じ状態のマスがないかどうかチェック
        'そのマスは一番右以外でなくてはならない
        For a As Integer = 0 To XCount - 2
            For b As Integer = 0 To YCount - 1

                'このマスが空白でなく、
                'その右のマスの状態が、このマスと同じであったならゲームオーバーでない。
                If Cells(a, b).Status > 0 Then
                    If Cells(a + 1, b).Status = Cells(a, b).Status Then
                        Return False
                    End If
                End If
            Next b
        Next a

        'あるマスの下に、同じ状態のマスがないかどうかチェック
        'そのマスは一番下以外でなくてはならない
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 2

                'このマスが空白でなく、
                'その下のマスの状態が、このマスと同じであったならゲームオーバーでない。
                If Cells(a, b).Status > 0 Then
                    If Cells(a, b + 1).Status = Cells(a, b).Status Then
                        Return False
                    End If
                End If
            Next b
        Next a

        Return True 'いずれにも当てはまらなかったらゲームオーバー。

    End Function

    ''' <summary>今のステージで、空白以外のマスの個数を数える</summary>
    Public Function Count()

        Dim c As Integer = 0

        'マス全体を見る
        For a As Integer = 0 To XCount - 1
            For b As Integer = 0 To YCount - 1
                'このマスが空白以外だったならば
                If Cells(a, b).Status > 0 Then
                    c += 1
                End If
            Next b
        Next a

        Return c

    End Function

End Class
