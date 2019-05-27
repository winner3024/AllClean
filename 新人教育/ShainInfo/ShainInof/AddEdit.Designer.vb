<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEdit
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
        Me.ShainNum = New System.Windows.Forms.TextBox()
        Me.Num = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InsertBtn = New System.Windows.Forms.Button()
        Me.ReturnBtn = New System.Windows.Forms.Button()
        Me.KadouStatus = New System.Windows.Forms.ComboBox()
        Me.PHLabel1 = New System.Windows.Forms.Label()
        Me.PHLabel2 = New System.Windows.Forms.Label()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ShainNum
        '
        Me.ShainNum.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ShainNum.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ShainNum.Location = New System.Drawing.Point(254, 80)
        Me.ShainNum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ShainNum.MaxLength = 5
        Me.ShainNum.Name = "ShainNum"
        Me.ShainNum.Size = New System.Drawing.Size(306, 37)
        Me.ShainNum.TabIndex = 0
        '
        'Num
        '
        Me.Num.AutoSize = True
        Me.Num.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Num.Location = New System.Drawing.Point(130, 86)
        Me.Num.Name = "Num"
        Me.Num.Size = New System.Drawing.Size(92, 25)
        Me.Num.TabIndex = 1
        Me.Num.Text = "社員番号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(130, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "氏　　名"
        '
        'NameText
        '
        Me.NameText.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NameText.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.NameText.Location = New System.Drawing.Point(254, 162)
        Me.NameText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NameText.MaxLength = 20
        Me.NameText.Name = "NameText"
        Me.NameText.Size = New System.Drawing.Size(306, 37)
        Me.NameText.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(130, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "稼働状況"
        '
        'InsertBtn
        '
        Me.InsertBtn.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.InsertBtn.Location = New System.Drawing.Point(104, 361)
        Me.InsertBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.InsertBtn.Name = "InsertBtn"
        Me.InsertBtn.Size = New System.Drawing.Size(150, 72)
        Me.InsertBtn.TabIndex = 6
        Me.InsertBtn.Text = "登録"
        Me.InsertBtn.UseVisualStyleBackColor = True
        '
        'ReturnBtn
        '
        Me.ReturnBtn.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ReturnBtn.Location = New System.Drawing.Point(526, 361)
        Me.ReturnBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReturnBtn.Name = "ReturnBtn"
        Me.ReturnBtn.Size = New System.Drawing.Size(150, 72)
        Me.ReturnBtn.TabIndex = 8
        Me.ReturnBtn.Text = "戻る"
        Me.ReturnBtn.UseVisualStyleBackColor = True
        '
        'KadouStatus
        '
        Me.KadouStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.KadouStatus.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KadouStatus.FormattingEnabled = True
        Me.KadouStatus.Items.AddRange(New Object() {"", "稼働", "非稼働", "休職"})
        Me.KadouStatus.Location = New System.Drawing.Point(254, 247)
        Me.KadouStatus.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.KadouStatus.Name = "KadouStatus"
        Me.KadouStatus.Size = New System.Drawing.Size(305, 33)
        Me.KadouStatus.TabIndex = 5
        '
        'PHLabel1
        '
        Me.PHLabel1.AutoSize = True
        Me.PHLabel1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.PHLabel1.Font = New System.Drawing.Font("Meiryo UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHLabel1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.PHLabel1.Location = New System.Drawing.Point(261, 86)
        Me.PHLabel1.Name = "PHLabel1"
        Me.PHLabel1.Size = New System.Drawing.Size(174, 24)
        Me.PHLabel1.TabIndex = 9
        Me.PHLabel1.Text = "半角数字5文字以内"
        '
        'PHLabel2
        '
        Me.PHLabel2.AutoSize = True
        Me.PHLabel2.BackColor = System.Drawing.SystemColors.HighlightText
        Me.PHLabel2.Font = New System.Drawing.Font("Meiryo UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PHLabel2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.PHLabel2.Location = New System.Drawing.Point(261, 169)
        Me.PHLabel2.Name = "PHLabel2"
        Me.PHLabel2.Size = New System.Drawing.Size(110, 24)
        Me.PHLabel2.TabIndex = 10
        Me.PHLabel2.Text = "20文字以内"
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteBtn.Location = New System.Drawing.Point(314, 361)
        Me.DeleteBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(150, 72)
        Me.DeleteBtn.TabIndex = 7
        Me.DeleteBtn.Text = "削除"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'AddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 500)
        Me.Controls.Add(Me.DeleteBtn)
        Me.Controls.Add(Me.PHLabel2)
        Me.Controls.Add(Me.PHLabel1)
        Me.Controls.Add(Me.KadouStatus)
        Me.Controls.Add(Me.ReturnBtn)
        Me.Controls.Add(Me.InsertBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NameText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Num)
        Me.Controls.Add(Me.ShainNum)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "AddEdit"
        Me.Text = "新規登録"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ShainNum As TextBox
    Friend WithEvents Num As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents NameText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents InsertBtn As Button
    Friend WithEvents ReturnBtn As Button
    Friend WithEvents KadouStatus As ComboBox
    Friend WithEvents PHLabel1 As Label
    Friend WithEvents PHLabel2 As Label
    Friend WithEvents DeleteBtn As Button
End Class
