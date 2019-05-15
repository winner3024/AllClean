<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.MasterEditListBtn = New System.Windows.Forms.Button()
        Me.UserListBtn = New System.Windows.Forms.Button()
        Me.EndBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AddBtn
        '
        Me.AddBtn.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AddBtn.Location = New System.Drawing.Point(133, 30)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(201, 49)
        Me.AddBtn.TabIndex = 0
        Me.AddBtn.Text = "新規"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'UserListBtn
        '
        Me.UserListBtn.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UserListBtn.Location = New System.Drawing.Point(133, 114)
        Me.UserListBtn.Name = "UserListBtn"
        Me.UserListBtn.Size = New System.Drawing.Size(201, 49)
        Me.UserListBtn.TabIndex = 1
        Me.UserListBtn.Text = "一覧"
        Me.UserListBtn.UseVisualStyleBackColor = True
        '
        'MasterEditListBtn
        '
        Me.MasterEditListBtn.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MasterEditListBtn.Location = New System.Drawing.Point(133, 202)
        Me.MasterEditListBtn.Name = "MasterEditListBtn"
        Me.MasterEditListBtn.Size = New System.Drawing.Size(201, 49)
        Me.MasterEditListBtn.TabIndex = 2
        Me.MasterEditListBtn.Text = "マスタ訂正一覧"
        Me.MasterEditListBtn.UseVisualStyleBackColor = True
        '
        'EndBtn
        '
        Me.EndBtn.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EndBtn.Location = New System.Drawing.Point(369, 271)
        Me.EndBtn.Name = "EndBtn"
        Me.EndBtn.Size = New System.Drawing.Size(101, 49)
        Me.EndBtn.TabIndex = 3
        Me.EndBtn.Text = "終了"
        Me.EndBtn.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 332)
        Me.Controls.Add(Me.EndBtn)
        Me.Controls.Add(Me.UserListBtn)
        Me.Controls.Add(Me.MasterEditListBtn)
        Me.Controls.Add(Me.AddBtn)
        Me.Name = "Menu"
        Me.Text = "社員情報"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AddBtn As Button
    Friend WithEvents MasterEditListBtn As Button
    Friend WithEvents UserListBtn As Button
    Friend WithEvents EndBtn As Button
End Class
