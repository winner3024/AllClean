<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnHint = New System.Windows.Forms.Button()
        Me.btnEnd = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.btnReStart = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(29, 21)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(796, 750)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 13.0!)
        Me.Label1.Location = New System.Drawing.Point(896, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "完成図"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(901, 75)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(193, 181)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 13.0!)
        Me.Label2.Location = New System.Drawing.Point(896, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 22)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "残り時間"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("MS UI Gothic", 30.0!)
        Me.lblTime.Location = New System.Drawing.Point(926, 336)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(147, 50)
        Me.lblTime.TabIndex = 8
        Me.lblTime.Text = "300秒"
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("MS UI Gothic", 17.0!)
        Me.btnStart.Location = New System.Drawing.Point(901, 461)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(192, 68)
        Me.btnStart.TabIndex = 9
        Me.btnStart.Text = "スタート"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnHint
        '
        Me.btnHint.Font = New System.Drawing.Font("MS UI Gothic", 17.0!)
        Me.btnHint.Location = New System.Drawing.Point(901, 548)
        Me.btnHint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnHint.Name = "btnHint"
        Me.btnHint.Size = New System.Drawing.Size(192, 68)
        Me.btnHint.TabIndex = 10
        Me.btnHint.Text = "ヒント"
        Me.btnHint.UseVisualStyleBackColor = True
        '
        'btnEnd
        '
        Me.btnEnd.Font = New System.Drawing.Font("MS UI Gothic", 17.0!)
        Me.btnEnd.Location = New System.Drawing.Point(902, 724)
        Me.btnEnd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEnd.Name = "btnEnd"
        Me.btnEnd.Size = New System.Drawing.Size(192, 61)
        Me.btnEnd.TabIndex = 11
        Me.btnEnd.Text = "終了"
        Me.btnEnd.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'btnReStart
        '
        Me.btnReStart.Font = New System.Drawing.Font("MS UI Gothic", 17.0!)
        Me.btnReStart.Location = New System.Drawing.Point(902, 634)
        Me.btnReStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReStart.Name = "btnReStart"
        Me.btnReStart.Size = New System.Drawing.Size(192, 68)
        Me.btnReStart.TabIndex = 12
        Me.btnReStart.Text = "再挑戦"
        Me.btnReStart.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1152, 798)
        Me.Controls.Add(Me.btnReStart)
        Me.Controls.Add(Me.btnEnd)
        Me.Controls.Add(Me.btnHint)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "MainForm"
        Me.Text = "15puzzle"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents btnHint As Button
    Friend WithEvents btnEnd As Button
    Friend WithEvents Timer As Timer
    Friend WithEvents btnReStart As Button
End Class
