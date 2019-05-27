<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserList
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
        Me.ReturnBtn = New System.Windows.Forms.Button()
        Me.UDGV = New System.Windows.Forms.DataGridView()
        CType(Me.UDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReturnBtn
        '
        Me.ReturnBtn.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ReturnBtn.Location = New System.Drawing.Point(475, 513)
        Me.ReturnBtn.Name = "ReturnBtn"
        Me.ReturnBtn.Size = New System.Drawing.Size(130, 56)
        Me.ReturnBtn.TabIndex = 1
        Me.ReturnBtn.Text = "戻る"
        Me.ReturnBtn.UseVisualStyleBackColor = True
        '
        'UDGV
        '
        Me.UDGV.AllowUserToAddRows = False
        Me.UDGV.AllowUserToDeleteRows = False
        Me.UDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UDGV.Location = New System.Drawing.Point(35, 26)
        Me.UDGV.Name = "UDGV"
        Me.UDGV.ReadOnly = True
        Me.UDGV.RowHeadersWidth = 51
        Me.UDGV.RowTemplate.Height = 21
        Me.UDGV.Size = New System.Drawing.Size(570, 466)
        Me.UDGV.TabIndex = 2
        '
        'UserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 581)
        Me.Controls.Add(Me.UDGV)
        Me.Controls.Add(Me.ReturnBtn)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.Name = "UserList"
        Me.Text = "社員一覧"
        CType(Me.UDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReturnBtn As Button
    Friend WithEvents UDGV As DataGridView
End Class
