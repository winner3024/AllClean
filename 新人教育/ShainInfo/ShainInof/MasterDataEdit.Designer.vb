<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MasterDataEdit
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
        CType(Me.MGDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MGDV
        '
        Me.MGDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MGDV.Location = New System.Drawing.Point(47, 34)
        Me.MGDV.Margin = New System.Windows.Forms.Padding(4)
        Me.MGDV.Name = "MGDV"
        Me.MGDV.RowTemplate.Height = 21
        Me.MGDV.Size = New System.Drawing.Size(401, 522)
        Me.MGDV.TabIndex = 0
        '
        'RetrunBtn
        '
        Me.RetrunBtn.Location = New System.Drawing.Point(285, 582)
        Me.RetrunBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.RetrunBtn.Name = "RetrunBtn"
        Me.RetrunBtn.Size = New System.Drawing.Size(163, 51)
        Me.RetrunBtn.TabIndex = 1
        Me.RetrunBtn.Text = "戻る"
        Me.RetrunBtn.UseVisualStyleBackColor = True
        '
        'MasterDataEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 671)
        Me.Controls.Add(Me.RetrunBtn)
        Me.Controls.Add(Me.MGDV)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MasterDataEdit"
        Me.Text = "マスタ訂正一覧"
        CType(Me.MGDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MGDV As DataGridView
    Friend WithEvents RetrunBtn As Button
End Class
