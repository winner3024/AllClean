Imports System.Data.OleDb
Public Class MasterEdit

    Public SelectTableName As String

    Private Cnn As OleDbConnection
    Private Cmd As OleDbCommand
    Private InsCmd As OleDbCommand
    Private UpdCmd As OleDbCommand
    Private DelCmd As OleDbCommand

    Private Dta As OleDbDataAdapter
    Private Txn As OleDbTransaction

    Private Dts As DataSet = New DataSet
    Private cancelFlag As Boolean = False
    Private DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")
    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CnnStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "DATA SOURCE=" & DbPath & ";" &
            "Persist Security Info = False"

        Cnn = New OleDbConnection(CnnStr)
        Cmd = New OleDbCommand
        InsCmd = New OleDbCommand
        UpdCmd = New OleDbCommand
        DelCmd = New OleDbCommand
        Dta = New OleDbDataAdapter

        Cnn.Open()

        SetDataSource()

        '適用ボタン非活性
        Me.buttonApply.Enabled = False
        'フォーム名変更
        Me.Text = SelectTableName & "マスタ訂正"

    End Sub

    Private Sub TestFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Validate()

        Try
            'キャンセルボタンの場合、保存しないで終了。 
            If (cancelFlag = True) Then
                Return
            End If

            If Dts.HasChanges Then

                Dim result As DialogResult
                result = MessageBox.Show("データが変更されています。保存しますか?", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                Select Case (result)
                    Case DialogResult.Yes
                        Apply()
                    Case DialogResult.No

                    Case DialogResult.Cancel
                        e.Cancel = True
                    Case Else
                        e.Cancel = True
                End Select

                Return
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If (Not (Dta) Is Nothing) Then Dta.Dispose()
            If (Not (DelCmd) Is Nothing) Then DelCmd.Dispose()
            If (Not (UpdCmd) Is Nothing) Then UpdCmd.Dispose()
            If (Not (InsCmd) Is Nothing) Then InsCmd.Dispose()
            If (Not (Cmd) Is Nothing) Then Cmd.Dispose()
            If (Not (Dts) Is Nothing) Then Dts.Dispose()
            If (Not (Cnn) Is Nothing) Then Cnn.Close()
        End Try

    End Sub

    Private Sub Dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged

        'セルの値が変更されたら適用ボタンを活性化
        Me.buttonApply.Enabled = True

    End Sub

    Private Sub Dgv_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv.UserDeletedRow

        '行削除が行われたら適用ボタンを活性化
        Me.buttonApply.Enabled = True

    End Sub

    Private Sub ButtonView_Click(sender As Object, e As EventArgs) Handles buttonView.Click

        'DataGridViewのデータソースを設定
        SetDataSource()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click

        'キャンセル
        cancelFlag = True
        Me.Close()

    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles buttonApply.Click

        '適用
        Apply()
        SetDataSource()
        Me.buttonApply.Enabled = False

    End Sub

    Private Sub Apply()

        Try
            If Dts.HasChanges Then

                'トランザクションを開始
                Txn = Cnn.BeginTransaction

                Dta.UpdateCommand.Transaction = Txn
                Dta.DeleteCommand.Transaction = Txn
                Dta.InsertCommand.Transaction = Txn


                'データ更新
                Dta.Update(Dts, SelectTableName)

                'トランザクションをコミット
                Txn.Commit()

                MsgBox("適用しました",, "処理完了")
            End If

        Catch ex As Exception
            Txn.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            If (Not (Txn) Is Nothing) Then
                Txn.Dispose()
            End If

        End Try

    End Sub

    'DataErrorイベントハンドラ
    Private Sub DataGridView_DataError(ByVal sender As Object,
        ByVal e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        e.Cancel = False
    End Sub
    Private Sub SetDataSource()

        Try
            'USERテーブル選択時
            If SelectTableName = "USER" Then

                'Selectコマンドの作成
                Cmd.Connection = Cnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT * FROM [USER] ORDER BY ID"

                '追加コマンドの作成
                InsCmd.Connection = Cnn
                InsCmd.CommandType = CommandType.Text
                InsCmd.CommandText = "INSERT INTO [USER] (ID, USER_NAME, KADO_CODE) VALUES (@ID, @USER_NAME, @KADO_CODE)"
                InsCmd.Parameters.Clear()
                InsCmd.Parameters.Add("@ID", OleDbType.Integer, 5, "ID")
                InsCmd.Parameters.Add("@USER_NAME", OleDbType.VarChar, 20, "USER_NAME")
                InsCmd.Parameters.Add("@KADO_CODE", OleDbType.VarChar, 20, "KADO_CODE")

                '更新コマンドの作成
                UpdCmd.Connection = Cnn
                UpdCmd.CommandType = CommandType.Text
                UpdCmd.CommandText = "UPDATE [USER] SET USER_NAME = @USER_NAME, KADO_CODE = @KADO_CODE WHERE ID = @ID"
                UpdCmd.Parameters.Clear()
                UpdCmd.Parameters.Add("@USER_NAME", OleDbType.VarChar, 20, "USER_NAME")
                UpdCmd.Parameters.Add("@KADO_CODE", OleDbType.VarChar, 20, "KADO_CODE")
                UpdCmd.Parameters.Add("@ID", OleDbType.Integer, 5, "ID")

                '削除コマンドの作成
                DelCmd.Connection = Cnn
                DelCmd.CommandType = CommandType.Text
                DelCmd.CommandText = "DELETE FROM [USER] WHERE ID = @ID"
                DelCmd.Parameters.Clear()
                DelCmd.Parameters.Add("@ID", OleDbType.Integer, 5, "ID")

                'KADOテーブル選択時
            ElseIf SelectTableName = "KADO" Then

                'Selectコマンドの作成
                Cmd.Connection = Cnn
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "SELECT KADO_CODE,STATUS FROM [KADO] ORDER BY KADO_CODE"

                '追加コマンドの作成
                InsCmd.Connection = Cnn
                InsCmd.CommandType = CommandType.Text
                InsCmd.CommandText = "INSERT INTO [KADO] (KADO_CODE,STATUS) VALUES (@KADO_CODE, @STATUS)"
                InsCmd.Parameters.Clear()
                InsCmd.Parameters.Add("@KADO_CODE", OleDbType.VarChar, 20, "KADO_CODE")
                InsCmd.Parameters.Add("@STATUS", OleDbType.VarChar, 20, "STATUS")

                '更新コマンドの作成
                UpdCmd.Connection = Cnn
                UpdCmd.CommandType = CommandType.Text
                UpdCmd.CommandText = "UPDATE [KADO] SET KADO_CODE = @KADO_CODE,STATUS = @STATUS WHERE KADO_CODE = @KADO_CODE"
                UpdCmd.Parameters.Clear()

                '削除コマンドの作成
                DelCmd.Connection = Cnn
                DelCmd.CommandType = CommandType.Text
                DelCmd.CommandText = "DELETE FROM [KADO] WHERE KADO_CODE = @KADO_CODE"
                DelCmd.Parameters.Clear()
                DelCmd.Parameters.Add("@KADO_CODE", OleDbType.VarChar, 20, "KADO_CODE")

            End If

            'DataTableを追加するとき、既にDataSet内に
            '同じ名前のDataTableがあるとエラーになる？のでクリアする
            If Dts.Tables.Contains(SelectTableName) Then
                Dts.Tables(SelectTableName).Clear()
            End If

            '各コマンドの設定
            Dta.SelectCommand = Cmd
            Dta.InsertCommand = InsCmd
            Dta.UpdateCommand = UpdCmd
            Dta.DeleteCommand = DelCmd

            '抽出したデータをデータセットに格納
            Dta.Fill(Dts, SelectTableName)

            '列クリア
            Me.dgv.Columns.Clear()

            'DataGridViewのデータソースを設定
            Me.dgv.DataSource = Nothing
            Me.dgv.DataSource = Dts.Tables(SelectTableName)

            '適用ボタン非活性
            Me.buttonApply.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
