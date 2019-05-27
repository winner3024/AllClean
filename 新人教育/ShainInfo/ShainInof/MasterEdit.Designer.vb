<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MasterEdit
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.buttonView = New System.Windows.Forms.Button()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonApply = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(30, 32)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 51
        Me.dgv.RowTemplate.Height = 24
        Me.dgv.Size = New System.Drawing.Size(542, 550)
        Me.dgv.TabIndex = 0
        '
        'buttonView
        '
        Me.buttonView.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.buttonView.Location = New System.Drawing.Point(617, 98)
        Me.buttonView.Name = "buttonView"
        Me.buttonView.Size = New System.Drawing.Size(150, 72)
        Me.buttonView.TabIndex = 1
        Me.buttonView.Text = "再表示"
        Me.buttonView.UseVisualStyleBackColor = True
        '
        'buttonCancel
        '
        Me.buttonCancel.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.buttonCancel.Location = New System.Drawing.Point(617, 510)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(150, 72)
        Me.buttonCancel.TabIndex = 3
        Me.buttonCancel.Text = "戻る"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonApply
        '
        Me.buttonApply.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.buttonApply.Location = New System.Drawing.Point(617, 231)
        Me.buttonApply.Name = "buttonApply"
        Me.buttonApply.Size = New System.Drawing.Size(150, 72)
        Me.buttonApply.TabIndex = 2
        Me.buttonApply.Text = "適用"
        Me.buttonApply.UseVisualStyleBackColor = True
        '
        'MasterEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 608)
        Me.Controls.Add(Me.buttonApply)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonView)
        Me.Controls.Add(Me.dgv)
        Me.Name = "MasterEdit"
        Me.Text = "マスタ訂正"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents buttonView As Button
    Friend WithEvents buttonCancel As Button
    Friend WithEvents buttonApply As Button
End Class
