Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Public Class AddEdit
    Private Sub AddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If InsertBtn.Text = "更新" Then
            DeleteBtn.Visible = True
        Else
            DeleteBtn.Visible = False
        End If
    End Sub

    Private Sub ReturnBtn_Click(sender As Object, e As EventArgs) Handles ReturnBtn.Click
        Me.Close()
    End Sub

    Private Sub InsertBtn_Click(sender As Object, e As EventArgs) Handles InsertBtn.Click

        'モード別処理
        If Me.InsertBtn.Text = "登録" Then
            '登録
            Call DataAccess(0)

        ElseIf Me.InsertBtn.Text = "更新" Then
            '更新
            Call DataAccess(1)
            Me.Close()

        End If

    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Call DataAccess(2)
        Me.Close()
    End Sub

    Private Sub DataAccess(mode As Integer)

        Dim cn As OleDbConnection
        Dim com As OleDbCommand

        Dim numValue As String  'ID検索判定
        Dim addCount As Integer '処理実行判定
        Dim strSQL As String    'SQL文
        Dim strMsg As String    '処理後メッセージ
        Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

        cn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
            "DATA SOURCE=" & DbPath & ";" &
            "Persist Security Info = False")

        'ID検索用
        Dim SQLCm As OleDbCommand = cn.CreateCommand
        SQLCm.CommandText = "SELECT ID FROM [USER] WHERE ID = " & ShainNum.Text

        '起動から1回目の登録時、稼働欄未操作で-1が返ってくるので0に設定
        If KadouStatus.SelectedIndex = -1 Then
            KadouStatus.SelectedIndex = 0
        End If

        'モード別でクエリーを切り替え
        If mode = 1 Then
            '更新モード
            strSQL = "UPDATE [USER] SET "
            strSQL = strSQL & " USER_NAME = '" & NameText.Text & "', "
            strSQL = strSQL & " KADO_CODE = '" & KadouStatus.SelectedIndex & "' "
            strSQL = strSQL & " WHERE ID = " & ShainNum.Text

            strMsg = "件更新しました"
        ElseIf mode = 2 Then
            '削除モード
            strSQL = "DELETE FROM [USER] WHERE ID = " & ShainNum.Text

            strMsg = "件削除しました"
        Else
            '登録モード mode = 0
            strSQL = "INSERT INTO [USER] (ID,USER_NAME,KADO_CODE) VALUES ("
            strSQL = strSQL & ShainNum.Text & ","
            strSQL = strSQL & "'" & NameText.Text & "',"
            strSQL = strSQL & "'" & KadouStatus.SelectedIndex & "')"

            strMsg = "件登録しました"
        End If

        Try

            cn.Open()
            '入力チェック(登録時のみ)
            If mode = 0 Then
                ChkShainNum(ShainNum.Text)
                'ChkName(NameText.Text)
                ChkKadouStatus(KadouStatus.SelectedIndex)

                '既存チェック(ID検索,DBに入っていた場合予め登録できないようにする)
                numValue = SQLCm.ExecuteScalar
                If numValue IsNot Nothing Then
                    Throw New ShainInfoException("登録済みの社員番号です")
                End If

            End If

            com = New OleDbCommand(strSQL, cn)
            '実行するSQL文の表示
            'MsgBox(strSQL,, "実行するSQL")

            '登録・更新・削除の実行
            addCount = com.ExecuteNonQuery()

            '処理成功で1、失敗で0が返ってくる
            If addCount = 0 Then
                Throw New ShainInfoException("処理に失敗しました")
            End If

            MsgBox(addCount & strMsg,, "処理完了")
            ClearFrom()

        Catch ex As ShainInfoException
            MessageBox.Show(ex.Message, "登録エラー")

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            cn.Dispose()
            cn.Close()
        End Try

    End Sub
    Private Sub ClearFrom()
        ShainNum.Clear()
        NameText.Clear()
        KadouStatus.SelectedIndex = 0
    End Sub
    Private Sub ChkShainNum(checkNum)
        ' 社員番号チェック
        'MsgBox(checkNum)
        If checkNum.Length = 0 Then
            Throw New ShainInfoException("社員番号を入力してください")
        ElseIf Regex.IsMatch(checkNum, "[^0-9]\d*$") Then
            Throw New ShainInfoException("社員番号に数字以外の文字があります")
        ElseIf checkNum = 0 Then
            Throw New ShainInfoException("登録できない社員番号です")
        End If
    End Sub
    Private Sub ChkName(checkName)
        '未入力チェックのみ
        If checkName.Length = 0 Then
            Throw New ShainInfoException("氏名を入力してください")
        End If
    End Sub
    Private Sub ChkKadouStatus(checkKado)
        ' 稼働チェック,無くても問題ないはず
        If checkKado = -1 Then
            Throw New ShainInfoException("稼働状況を選択してください")
        End If
    End Sub
    'プレースホルダもどき,空欄で表示、入力されると非表示に
    Private Sub ShainNum_TextChanged(sender As Object, e As EventArgs) Handles ShainNum.TextChanged
        If ShainNum.Text = String.Empty Then
            PHLabel1.Visible = True
        Else
            PHLabel1.Visible = False
        End If
    End Sub
    Private Sub NameText_TextChanged(sender As Object, e As EventArgs) Handles NameText.TextChanged
        If NameText.Text = String.Empty Then
            PHLabel2.Visible = True
        Else
            PHLabel2.Visible = False
        End If
    End Sub
    'Focusしないとラベル避けてフォームクリックすることになり面倒
    Private Sub PHLabel1_Click(sender As Object, e As EventArgs) Handles PHLabel1.Click
        ShainNum.Focus()
    End Sub
    Private Sub PHLabel2_Click(sender As Object, e As EventArgs) Handles PHLabel2.Click
        NameText.Focus()
    End Sub

End Class
'社員情報独自例外クラス
Public Class ShainInfoException
    Inherits ApplicationException
    Public Sub New(ByVal errorMessage As String)
        MyBase.New(errorMessage)
    End Sub
End Class