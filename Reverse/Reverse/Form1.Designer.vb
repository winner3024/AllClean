<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    'Visual Basic 初級講座より
    Inherits System.Windows.Forms.Form
    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBlackCount = New System.Windows.Forms.Label()
        Me.lblWhiteCount = New System.Windows.Forms.Label()
        Me.lblBlackTurn = New System.Windows.Forms.Label()
        Me.lblWhiteTurn = New System.Windows.Forms.Label()
        Me.btnStartBlack = New System.Windows.Forms.Button()
        Me.btnStartWhite = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Location = New System.Drawing.Point(32, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(598, 553)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(713, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "黒"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(713, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 42)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "白"
        '
        'lblBlackCount
        '
        Me.lblBlackCount.AutoSize = True
        Me.lblBlackCount.Font = New System.Drawing.Font("Meiryo UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBlackCount.Location = New System.Drawing.Point(847, 91)
        Me.lblBlackCount.Name = "lblBlackCount"
        Me.lblBlackCount.Size = New System.Drawing.Size(38, 42)
        Me.lblBlackCount.TabIndex = 3
        Me.lblBlackCount.Text = "0"
        Me.lblBlackCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWhiteCount
        '
        Me.lblWhiteCount.AutoSize = True
        Me.lblWhiteCount.Font = New System.Drawing.Font("Meiryo UI", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblWhiteCount.Location = New System.Drawing.Point(847, 181)
        Me.lblWhiteCount.Name = "lblWhiteCount"
        Me.lblWhiteCount.Size = New System.Drawing.Size(38, 42)
        Me.lblWhiteCount.TabIndex = 4
        Me.lblWhiteCount.Text = "0"
        Me.lblWhiteCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBlackTurn
        '
        Me.lblBlackTurn.BackColor = System.Drawing.Color.Red
        Me.lblBlackTurn.Location = New System.Drawing.Point(717, 133)
        Me.lblBlackTurn.Name = "lblBlackTurn"
        Me.lblBlackTurn.Size = New System.Drawing.Size(185, 5)
        Me.lblBlackTurn.TabIndex = 5
        '
        'lblWhiteTurn
        '
        Me.lblWhiteTurn.BackColor = System.Drawing.Color.Red
        Me.lblWhiteTurn.Location = New System.Drawing.Point(717, 223)
        Me.lblWhiteTurn.Name = "lblWhiteTurn"
        Me.lblWhiteTurn.Size = New System.Drawing.Size(185, 5)
        Me.lblWhiteTurn.TabIndex = 6
        '
        'btnStartBlack
        '
        Me.btnStartBlack.Location = New System.Drawing.Point(720, 314)
        Me.btnStartBlack.Name = "btnStartBlack"
        Me.btnStartBlack.Size = New System.Drawing.Size(173, 43)
        Me.btnStartBlack.TabIndex = 7
        Me.btnStartBlack.Text = "黒（先手）で開始"
        Me.btnStartBlack.UseVisualStyleBackColor = True
        '
        'btnStartWhite
        '
        Me.btnStartWhite.Location = New System.Drawing.Point(720, 387)
        Me.btnStartWhite.Name = "btnStartWhite"
        Me.btnStartWhite.Size = New System.Drawing.Size(173, 43)
        Me.btnStartWhite.TabIndex = 8
        Me.btnStartWhite.Text = "白（後手）で開始"
        Me.btnStartWhite.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(951, 631)
        Me.Controls.Add(Me.btnStartWhite)
        Me.Controls.Add(Me.btnStartBlack)
        Me.Controls.Add(Me.lblWhiteTurn)
        Me.Controls.Add(Me.lblBlackTurn)
        Me.Controls.Add(Me.lblWhiteCount)
        Me.Controls.Add(Me.lblBlackCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Reversi"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Dim WithEvents Grid As New ReverseGrid
    '''''''''''''弱いAI
    'Dim Computer As New Computer1(Grid, CellStatus.White)
    '''''''''''''少しマシになったAI（角を取りに行く）
    'Dim Computer As New Computer2(Grid, CellStatus.White)
    '''''''''''''ちょっと強いAI（１手先をシミュレーションする、角を取られないようにする）
    Dim Computer As New Computer3(Grid, CellStatus.White)
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

        Grid.Draw(e.Graphics)

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid.Initialize()
        lblBlackCount.Text = Grid.Count(CellStatus.Black)
        lblWhiteCount.Text = Grid.Count(CellStatus.White)
        lblWhiteTurn.Visible = False
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        'マウスの座標をPictureBox1のコントロール座標に変換する。
        Dim Pos As Point = PictureBox1.PointToClient(Windows.Forms.Cursor.Position)
        Dim ThisCell As Cell

        ThisCell = Grid.CellFromPoint(Pos.X, Pos.Y)

        If Grid.Put(Turn, ThisCell.Position.X, ThisCell.Position.Y) Then
            ChangeTurn()
        End If

    End Sub

    ''' <summary>マウスの移動に伴ってセルにアクティブを示す枠を描画する</summary>
    Private Sub PictureBox1_MousuMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles PictureBox1.MouseMove

        Dim ThisCell As Cell

        'マウスがある位置のセルを取得
        ThisCell = Grid.CellFromPoint(e.X, e.Y)

        If Not IsNothing(ThisCell) Then
            'セルが取得できた場合は、セルにアクティブを示す枠を描画
            ThisCell.Focus()

            '現在の状態を描画(PictureBox1のPaintイベントを発生させる)
            PictureBox1.Invalidate()

        End If

    End Sub
    Private Sub BtnStartBlack_Click(sender As Object, e As EventArgs) Handles btnStartBlack.Click
        Start(CellStatus.Black)
    End Sub
    Private Sub btnStartWhite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartWhite.Click
        Start(CellStatus.White)
    End Sub

    Dim Turn As CellStatus = CellStatus.Black '今どっちの順番か
    Dim PlayerColor As CellStatus = CellStatus.Black 'プレイヤーの色

    '■ChangeTurn
    ''' <summary>ターン交代</summary>
    Public Sub ChangeTurn()

        '現在の状態を描画(PictureBox1のPaintイベントを発生させる)
        PictureBox1.Invalidate()

        '▼勝敗判定
        If Grid.Count(CellStatus.Nothing) = 0 Then
            '全セルへの配置が終了した場合は勝敗判定して終了
            If Grid.Count(CellStatus.Black) > Grid.Count(CellStatus.White) Then
                MsgBox("黒の勝ちです！")
            ElseIf Grid.Count(CellStatus.Black) < Grid.Count(CellStatus.White) Then
                MsgBox("白の勝ちです！")
            Else
                MsgBox("引き分けです！！")
            End If
            Return
        ElseIf Grid.PuttableCount(CellStatus.Black) = 0 AndAlso Grid.PuttableCount(CellStatus.White) = 0 Then
            '空いているセルがあるのに黒も白も置けない場合
            If Grid.Count(CellStatus.Black) > Grid.Count(CellStatus.White) Then
                MsgBox("黒の勝ちです！")
            ElseIf Grid.Count(CellStatus.Black) < Grid.Count(CellStatus.White) Then
                MsgBox("白の勝ちです！")
            Else
                MsgBox("引き分けです！！")
            End If
            Return
        ElseIf Grid.Count(CellStatus.Black) = 0 Then
            'すべての石が白になった場合(=黒の石が0個の場合)
            MsgBox("白の勝ちです！")
            Return
        ElseIf Grid.Count(CellStatus.White) = 0 Then
            'すべての石が黒になった場合(=白の石が0個の場合)
            MsgBox("黒の勝ちです！")
            Return
        End If

        '▼次のターンの決定
        If Turn = CellStatus.Black Then
            Turn = CellStatus.White
            lblBlackTurn.Visible = False
            lblWhiteTurn.Visible = True
        Else
            Turn = CellStatus.Black
            lblBlackTurn.Visible = True
            lblWhiteTurn.Visible = False
        End If

        '▼置ける場所があるか判定
        If Grid.PuttableCount(Turn) = 0 Then
            '置く場所がなければパスして次のターン
            ChangeTurn()
        End If

        '▼人間かコンピュータかで処理を分岐
        If Turn = PlayerColor Then
            '人間の番ならば、PictureBoxを使用可能にする。
            PictureBox1.Enabled = True
        Else
            'コンピュータの番ならば、PictureBoxを使用不可にする。
            PictureBox1.Enabled = False

            'ちょっと時間をおく
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)

            'コンピュータに石を置かせる。どのセルに置くかはコンピュータ(AI)が決定する。
            Computer.Put()
            ChangeTurn() 'プレイヤーの番へ
        End If
    End Sub

    ''' <summary>石を置いたときに発生するイベント</summary>
    Private Sub Grid_PutNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.PutNew

        Call Grid_Reversed(sender, e)

    End Sub
    ''' <summary>石がひっくり返されたときに発生するイベント</summary>
    Private Sub Grid_Reversed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.Reversed

        '現在の状態を描画(PictureBox1のPaintイベントを発生させる)
        PictureBox1.Invalidate()
        '現在の黒と白の石の数を表示する
        lblBlackCount.Text = Grid.Count(CellStatus.Black)
        lblWhiteCount.Text = Grid.Count(CellStatus.White)

        'ちょっと時間をおく
        Application.DoEvents()
        System.Threading.Thread.Sleep(500)
    End Sub

    '■Start
    ''' <summary>ゲームを開始します。</summary>
    ''' <param name="PlayerColor">人間の石の色を指定します。</param>
    ''' <remarks>黒が先手になります。</remarks>
    Private Sub Start(ByVal PlayerColor As CellStatus)

        Grid.Initialize()

        Me.PlayerColor = PlayerColor '人間の色

        If PlayerColor = CellStatus.Black Then
            Computer.Standard = CellStatus.White 'コンピュータの色は白
        Else
            Computer.Standard = CellStatus.Black 'コンピュータの色は黒
        End If

        '現在の黒と白の駒の数を表示する
        lblBlackCount.Text = Grid.Count(CellStatus.Black)
        lblWhiteCount.Text = Grid.Count(CellStatus.White)

        'ChangeTurnを呼び出して黒の番を開始する。そのために仮に今は白の番であることにする。
        Turn = CellStatus.White
        ChangeTurn()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblBlackCount As Label
    Friend WithEvents lblWhiteCount As Label
    Friend WithEvents lblBlackTurn As Label
    Friend WithEvents lblWhiteTurn As Label
    Friend WithEvents btnStartBlack As Button
    Friend WithEvents btnStartWhite As Button

End Class

