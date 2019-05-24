''' <summary>ゲーム画面を扱うクラス</summary>
Public Class Form1

    Dim WithEvents Stage As New Stage 'ステージ
    Dim NormaPoint As Integer 'ステージクリアに必要なスコア
    Const HighScoreCount As Integer = 5 'ハイスコアとして表示する個数

    ''' <summary>Form1の読み込み時</summary>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'ステージ上のマスのサイズをPictureBox1のサイズに合わせて設定
        Stage.CellSize = New Point(PictureBox1.Width / Stage.XCount, PictureBox1.Height / Stage.YCount)

        'ハイスコアのファイルからの読み込み
        LoadHighScore()

    End Sub

    ''' <summary>Form1のサイズ変更時</summary>
    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

        'ステージ上のマスのサイズをPictureBox1のサイズに合わせて設定
        Stage.CellSize = New Point(PictureBox1.Width / Stage.XCount, PictureBox1.Height / Stage.YCount)
        'PictureBox1の描画
        PictureBox1.Invalidate()

    End Sub

    ''' <summary>Form1を閉じようとしているとき</summary>
    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing

        '画面が操作可能(プレイ中)な場合
        If PictureBox1.Enabled = True Then

            If MsgBox("本当にゲームをやめてもよいですか？" & vbCrLf & _
          "現在プレイ中のゲームのスコアはハイスコアには残りません", MsgBoxStyle.YesNo) _
          = MsgBoxResult.No Then '表示されたメッセージで「いいえ」を選んだら

                e.Cancel = True '閉じるのをキャンセルする

            End If

        End If

    End Sub


    ''' <summary>マスを選択したときのStageのイベント</summary>
    Private Sub Stage_MsgScore(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stage.MsgScore

        If Stage.CountSelections = 1 Then '選択マスが1つだけの場合
            lblSelectionScore.Text = "単独コマは消せません"
        Else
            'スコアをlblSelectionScoreに表示する
            lblSelectionScore.Text = CStr(Stage.Score) & "点"
        End If

    End Sub

    ''' <summary>マスをクリアしたときに発生させるStageのイベント</summary>
    Private Sub Stage_CellsClear(ByVal sender As Object, ByVal e As System.EventArgs) Handles Stage.CellsClear

        lblScore.Text = CInt(lblScore.Text) + Stage.Score 'スコアの表示

    End Sub



#Region "画面の操作"

    ''' <summary>PictureBox1の操作</summary>
    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles PictureBox1.Click, PictureBox1.DoubleClick

        '選択マスをクリアする
        Stage.Clear()

        'PictureBox1の描画
        PictureBox1.Invalidate()

        'もし、このステージで1か所も消せるマスがなかったらステージクリアかゲームオーバー
        If Stage.IsGameOver = True Then

            StageEnd()

        End If

    End Sub

    ''' <summary>PictureBox1の上でマウスを動かしたときにマスを選択する</summary>
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

        'マウスの座標をPictureBox1のコントロール座標に変換する。
        Dim p As Point = PictureBox1.PointToClient(Windows.Forms.Cursor.Position)
        'その座標がステージの範囲外だったら
        If p.X < 0 OrElse p.X >= Stage.XCount * Stage.CellSize.X Then
            Exit Sub
        End If
        If p.Y < 0 OrElse p.Y >= Stage.YCount * Stage.CellSize.Y Then
            Exit Sub
        End If

        lblSelectionScore.Text = "" 'マスを選択する前にクリアする

        'コントロール座標をマスの座標に変換してマスを選択する
        Stage.CellSelect(Stage.CellFromPoint(p))

        'PictureBox1の描画
        PictureBox1.Invalidate()

    End Sub

#End Region



    ''' <summary>ステージのPictureBox1への描画</summary>
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Stage.Draw(e.Graphics)
    End Sub



#Region "ステージの変更関係"

    ''' <summary>「開始」ボタン</summary>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        'btnStartのテキストが「やり直し」のときは、メッセージボックスを表示させて、
        'それで「はい」を選択したときだけゲームをやり直す
        If btnStart.Text = "やり直し" Then

            If MsgBox("本当にゲームをやり直してよいですか？" & vbCrLf & _
                      "現在プレイ中のゲームのスコアはハイスコアには残りません", MsgBoxStyle.YesNo) _
                      = MsgBoxResult.No Then

                Exit Sub
            End If
        End If



        lblScore.Text = "0" 'スコアの表示を0にする
        btnStart.Text = "やり直し"
        lblSelectionScore.Text = ""

        'ステージを1にする
        lblStage.Text = "1"

        NormaPoint = 300 'ステージ1の通過点は300点
        lblNorma.Text = CInt(NormaPoint) & "点以上で" & vbCrLf & "ステージクリア"


        Stage.Initialize() 'ステージの初期化


        'PictureBox1の描画
        PictureBox1.Invalidate()

        'PictureBox1を使用可能にする
        PictureBox1.Enabled = True



    End Sub

    ''' <summary>ステージ終了時の処理</summary>
    Private Sub StageEnd()

        lblSelectionScore.Text = ""
        Application.DoEvents()
        System.Threading.Thread.Sleep(600) '0.600秒待機

        'もし、ステージ上に1個も空白以外のマスがなかったら1000点をボーナスとして加える
        If Stage.Count = 0 Then

            MsgBox("ステージ上のマスをすべてクリアしましたので、" & vbCrLf & _
                   "1000点をボーナスとして得点に入れます")
            lblScore.Text = CStr(CInt(lblScore.Text) + 1000)

        ElseIf Stage.Count <= 10 Then 'ステージ上の空白以外のマスが10個以下の場合、ボーナスは300点

            MsgBox("ステージ上に残ったマスが10個以下なので、" & vbCrLf & _
                   "300点をボーナスとして得点に入れます")
            lblScore.Text = CStr(CInt(lblScore.Text) + 300)

        End If

        If CInt(lblScore.Text) >= NormaPoint Then 'ステージごとの通過点に達していたならステージクリア
            StageClear()
        Else '通過点に満たなかったならゲームオーバー
            GameOver()
        End If

    End Sub

    ''' <summary>ゲームオーバー時の処理</summary>
    Private Sub GameOver()

        PictureBox1.Enabled = False 'PictureBox1を使用不可にする

        MsgBox("ゲームオーバー")

        MsgHighScore()

        btnStart.Text = "開始"

    End Sub

    ''' <summary>ステージクリア時の処理</summary>
    Private Sub StageClear()

        PictureBox1.Enabled = False 'PictureBox1を使用不可にする

        'ステージが10だったならメソッド GameOver と同様な処理を行う
        'この「10」という数は変更してよい
        If CInt(lblStage.Text) = 10 Then

            MsgBox("おめでとう！" & vbCrLf & "全ステージクリア")

            MsgHighScore()

            btnStart.Text = "開始"

        Else 'それ以外

            MsgBox("おめでとう！" & vbCrLf & "ステージクリア")

            'ステージを1増やす
            lblStage.Text = CStr(CInt(lblStage.Text) + 1)

            'ステージごとに通過点を設定
            '計算式 (通過点) = ((ステージ数)の2乗 + 2×(ステージ数))×100

            'ステージ 通過点
            '(      1    300)
            '       2    800
            '       3   1500
            '       4   2400
            '       5   3500
            '       6   4800
            '       7   6300
            '       8   8000
            '       9   9900
            '      10  12000

            NormaPoint = (CInt(lblStage.Text) ^ 2 + 2 * CInt(lblStage.Text)) * 100

            lblNorma.Text = CInt(NormaPoint) & "点以上で" & vbCrLf & "ステージクリア"

            Stage.Initialize() 'ステージの初期化


            'PictureBox1の描画
            PictureBox1.Invalidate()

            'PictureBox1を使用可能にする
            PictureBox1.Enabled = True

        End If

    End Sub

#End Region



#Region "ハイスコア関係"

    'ハイスコアのファイルは改変されない前提で以下のコードは作られている。

    ''' <summary>ハイスコアを読み込んでlisbHighScoreに表示させる</summary>
    Private Sub LoadHighScore()

        Dim HighScorePath As String = Application.StartupPath & "\High Score.txt" 'ハイスコアのテキストファイルの場所
        Dim HighScoreText As String 'ハイスコアのテキストファイルの内容
        Dim HighScores() As String 'ハイスコアの配列

        'そこに、ハイスコアのファイルが存在したら
        If IO.File.Exists(HighScorePath) = True Then

            'ハイスコアのファイルの内容を取得する
            HighScoreText = My.Computer.FileSystem.ReadAllText(HighScorePath)
            'ハイスコアのデータをコンマで区切って配列に格納
            HighScores = HighScoreText.Split(",")

            'ハイスコアの内容を初めから5番目までをlisbHighScoreに表示させる
            Dim n As Integer = 0 '回数
            For Each i As String In HighScores

                n += 1
                If n > HighScoreCount Then '読み取るのは5個目まで
                    Exit For
                End If

                'lisbHighScoreに表示する
                lisbHighScore.Items.Add(i)

            Next i

        Else '存在しなかったら




            'テキストファイルに0,0,…,0のデータを書き込む

            Dim st As String = ""

            For n As Integer = 1 To HighScoreCount - 1
                st &= "0,"
            Next

            st &= "0"

            My.Computer.FileSystem.WriteAllText(HighScorePath, st, False)

            For n As Integer = 0 To HighScoreCount - 1
                lisbHighScore.Items.Add("0")
            Next

        End If

    End Sub

    ''' <summary>ハイスコアを出したときにメッセージを表示させる</summary>
    Private Sub MsgHighScore()

        '(例)
        '
        'ハイスコア
        '          ←600(1位より大きい)：記録更新
        '      500
        '         
        '      400
        '         
        '      300 ←300(2位より小さく3位と等しい)：3位(タイ)
        '          ←250(3位より小さく4位より大きい)：4位
        '      200
        '         
        '      100
        '         

        Dim score As Integer = CInt(lblScore.Text) 'ゲームのスコア



        'スコアがハイスコアの一番上の項目より大きかったら
        If score > CInt(lisbHighScore.Items(0)) Then

            MsgBox("おめでとうございます。" & vbCrLf & "ハイスコア更新！")

            lisbHighScore.Items.Insert(0, score) 'lisbの一番上にハイスコアを挿入する

            'ハイスコアの更新
            HighScore()

            Exit Sub

        End If



        '1位から規定の順位までlisbHighScoreを見る。
        'ここで、lisbHighScoreの要素の個数は規定の個数以下である。
        For n As Integer = 1 To lisbHighScore.Items.Count

            'スコアがハイスコアのn番目以上だったならば
            If score >= CInt(lisbHighScore.Items(n - 1)) Then

                MsgBox("おめでとうございます。" & vbCrLf & "あなたは " & CStr(n) & " 位にランクインしました。")

                lisbHighScore.Items.Insert(n - 1, score) 'lisbにハイスコアを挿入する

                'ハイスコアの更新
                HighScore()

                Exit Sub

            End If

        Next

    End Sub

    ''' <summary>ハイスコアのlisbHighScoreへの表示・ファイルへの書き込み</summary>
    Private Sub HighScore()

        'lisbの最後の項目を削除する
        lisbHighScore.Items.RemoveAt(HighScoreCount)


        Dim HighScorePath As String = Application.StartupPath & "\High Score.txt" 'ハイスコアのテキストファイルの場所

        Dim st As String = ""

        'ハイスコアを1列にして表示
        For n As Integer = 0 To HighScoreCount - 2
            st &= lisbHighScore.Items(n) & ","
        Next
        st &= lisbHighScore.Items(HighScoreCount - 1)

        'ハイスコアをファイルに書き込む
        My.Computer.FileSystem.WriteAllText(HighScorePath, st, False)

    End Sub

#End Region

End Class