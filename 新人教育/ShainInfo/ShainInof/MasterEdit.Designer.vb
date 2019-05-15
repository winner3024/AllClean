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
        Me.MGDV = New System.Windows.Forms.DataGridView()
        Me.RetrunBtn = New System.Windows.Forms.Button()
        Me.DataEdit = New System.Windows.Forms.Button()
        CType(Me.MGDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MGDV
        '
        Me.MGDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MGDV.Location = New System.Drawing.Point(35, 27)
        Me.MGDV.Name = "MGDV"
        Me.MGDV.RowTemplate.Height = 21
        Me.MGDV.Size = New System.Drawing.Size(301, 418)
        Me.MGDV.TabIndex = 0
        '
        'RetrunBtn
        '
        Me.RetrunBtn.Location = New System.Drawing.Point(214, 466)
        Me.RetrunBtn.Name = "RetrunBtn"
        Me.RetrunBtn.Size = New System.Drawing.Size(122, 41)
        Me.RetrunBtn.TabIndex = 1
        Me.RetrunBtn.Text = "戻る"
        Me.RetrunBtn.UseVisualStyleBackColor = True
        '
        'DataEdit
        '
        Me.DataEdit.Location = New System.Drawing.Point(72, 466)
        Me.DataEdit.Name = "DataEdit"
        Me.DataEdit.Size = New System.Drawing.Size(122, 41)
        Me.DataEdit.TabIndex = 2
        Me.DataEdit.Text = "登録"
        Me.DataEdit.UseVisualStyleBackColor = True
        '
        'MasterEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 537)
        Me.Controls.Add(Me.DataEdit)
        Me.Controls.Add(Me.RetrunBtn)
        Me.Controls.Add(Me.MGDV)
        Me.Name = "MasterEdit"
        Me.Text = "各マスタ訂正画面"
        CType(Me.MGDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MGDV As DataGridView
    Friend WithEvents RetrunBtn As Button
    Friend WithEvents DataEdit As Button
End Class
