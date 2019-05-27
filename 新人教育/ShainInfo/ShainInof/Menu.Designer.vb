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
        Me.AddBtn.Font = New System.Drawing.Font("Meiryo UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.AddBtn.Location = New System.Drawing.Point(174, 61)
        Me.AddBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(283, 69)
        Me.AddBtn.TabIndex = 0
        Me.AddBtn.Text = "新規登録"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'MasterEditListBtn
        '
        Me.MasterEditListBtn.Font = New System.Drawing.Font("Meiryo UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MasterEditListBtn.Location = New System.Drawing.Point(174, 314)
        Me.MasterEditListBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MasterEditListBtn.Name = "MasterEditListBtn"
        Me.MasterEditListBtn.Size = New System.Drawing.Size(283, 69)
        Me.MasterEditListBtn.TabIndex = 2
        Me.MasterEditListBtn.Text = "マスタ訂正"
        Me.MasterEditListBtn.UseVisualStyleBackColor = True
        '
        'UserListBtn
        '
        Me.UserListBtn.Font = New System.Drawing.Font("Meiryo UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UserListBtn.Location = New System.Drawing.Point(174, 187)
        Me.UserListBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.UserListBtn.Name = "UserListBtn"
        Me.UserListBtn.Size = New System.Drawing.Size(283, 69)
        Me.UserListBtn.TabIndex = 1
        Me.UserListBtn.Text = "社員一覧"
        Me.UserListBtn.UseVisualStyleBackColor = True
        '
        'EndBtn
        '
        Me.EndBtn.Font = New System.Drawing.Font("Meiryo UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EndBtn.Location = New System.Drawing.Point(495, 381)
        Me.EndBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EndBtn.Name = "EndBtn"
        Me.EndBtn.Size = New System.Drawing.Size(150, 72)
        Me.EndBtn.TabIndex = 3
        Me.EndBtn.Text = "終了"
        Me.EndBtn.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 475)
        Me.Controls.Add(Me.EndBtn)
        Me.Controls.Add(Me.UserListBtn)
        Me.Controls.Add(Me.MasterEditListBtn)
        Me.Controls.Add(Me.AddBtn)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Menu"
        Me.Text = "社員情報管理システム"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AddBtn As Button
    Friend WithEvents MasterEditListBtn As Button
    Friend WithEvents UserListBtn As Button
    Friend WithEvents EndBtn As Button
End Class
