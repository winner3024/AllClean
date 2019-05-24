Public Class MainForm
    Private Panel As Panel
    Private Board As New Board
    Private Count As Integer
    Private rNum As Integer
    Private flag As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("スライドパズルです" & vbCrLf & "300秒以内にそろえてください！" & vbCrLf & "ヒントボタンを押すと、揃っているパネルは赤枠" & vbCrLf & "空パネルは緑枠、パネル内には画像の番号が表示されます" & vbCrLf & "スタートボタンで開始します")
        Init()
        btnHint.Enabled = False
        'アプリケーションパス取得用
        'この下に画像フォルダを配置すること
        'Dim value As String
        'value = Application.StartupPath
        'MsgBox(value)
        'テスト用
        '画像の大きさをPictureBoxに合わせる
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        '絶対パスで画像を表示する
        'PictureBox1.Image = System.Drawing.Image.FromFile("C:\Users\ASUPAGE\Documents\石田作業用\制作物\puzzle\puzzle\bin\Debug\Images\Image1.jpg")

    End Sub

    Private Sub Init()
        '制限時間セット
        Count = 300
        flag = True

        Randomize()
        '画像をランダムで選ぶ
        rNum = Int(Rnd() * 9) + 1
        '画像パス生成
        Dim Img As Image = Image.FromFile(Application.StartupPath & "\Images\Image" & rNum & ".jpg")
        Board.Shuffle(Img)
        'Trueでヒントが見れるようになる
        btnHint.Enabled = True 'False
        btnStart.Text = "スタート"
        PictureBox2.Image = Img
        lblTime.Text = "300秒"
        PictureBox1.Enabled = False
        PictureBox1.Invalidate()

    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'スタートボタンでパネル操作を可能にしタイマーを開始する
        PictureBox1.Enabled = True
        Timer.Start()
        btnStart.Enabled = False
        btnHint.Enabled = True
    End Sub
    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        Me.Close()
    End Sub
    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If Count >= 1 Then
            Count -= 1
        Else
            '時間切れ終了時処理
            lblTime.Text = "000秒"
            PictureBox1.Enabled = False
            Timer.Stop()
            MsgBox("時間切れです！" & vbCrLf & "   ( ´・ω・` )")
        End If
        '桁数で前ゼロ付き時間表示する
        If Count \ 100 > 0 Then
            lblTime.Text = Count & "秒"
        ElseIf Count \ 10 > 0 Then
            lblTime.Text = "0" & Count & "秒"
        Else
            lblTime.Text = "00" & Count & "秒"
        End If
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim Pos As Point = PictureBox1.PointToClient(Cursor.Position)

        Dim ThisPanel As Panel = Board.PanelFormPosition(Pos.X, Pos.Y)

        Board.Move(ThisPanel.Position.X, ThisPanel.Position.Y)
        PictureBox1.Invalidate()
        '完成した時の処理
        If Board.ChackBoard = True Then
            Timer.Stop()
            MsgBox("おめでとうございます！" & vbCrLf & 300 - Count & "秒でクリアしました" & vbCrLf & "   ( `・ω・´ )")
            PictureBox1.Enabled = False
        End If

    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        Dim ThisPanel As Panel

        ThisPanel = Board.PanelFormPosition(e.X, e.Y)

        If Not IsNothing(ThisPanel) Then
            ThisPanel.Focus()
            PictureBox1.Invalidate()
        End If

    End Sub
    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave

        For X As Integer = 0 To Board.Count - 1
            For Y As Integer = 0 To Board.Count - 1
                Board.Panels(X, Y).Focused = False
            Next
        Next

        PictureBox1.Invalidate()

    End Sub
    '描画のために必要
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Board.Draw(e.Graphics)
    End Sub
    'ヒント
    Private Sub btnHint_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles btnHint.MouseDown
        Board.Hint()
    End Sub
    Private Sub btnHint_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles btnHint.MouseUp
        'ヒントを表示したままにするにはここをコメント
        Board.unHint()
    End Sub
    Private Sub BtnReStart_Click(sender As Object, e As EventArgs) Handles btnReStart.Click
        '再挑戦時処理
        btnReStart.Refresh()
        MsgBox("スライドパズルです" & vbCrLf & "300秒以内にそろえてください！" & vbCrLf & "ヒントボタンを押すと、揃っているパネルは赤枠" & vbCrLf & "空パネルは緑枠、パネル内には画像の番号が表示されます" & vbCrLf & "スタートボタンで開始します")
        Init()
        Timer.Stop()
        btnStart.Enabled = True
        btnHint.Enabled = False
    End Sub

End Class
