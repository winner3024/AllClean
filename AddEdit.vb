Imports System.Text.RegularExpressions
Public Class AddEdit

    Private Sub AddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '1回目の登録で稼働未操作時-1が返ってくるので0に設定
        'KadouStatus.SelectedIndex = 0
        '一覧から開くと0以外が入っていても0になってしまう

    End Sub

    Private Sub ReturnBtn_Click(sender As Object, e As EventArgs) Handles ReturnBtn.Click
        Me.Close()
    End Sub

    Private Sub InsertBtn_Click(sender As Object, e As EventArgs) Handles InsertBtn.Click

        '入力チェックほしい
        '既存チェックほしい

        'モード別処理
        If Me.InsertBtn.Text = "登録" Then
            '登録
            Call DataAcsess(0)

        Else
            '更新
            Call DataAcsess(1)

            '画面を終了する
            Me.Close()

        End If

    End Sub

    Private Sub DataAcsess(mode As Integer)

        Dim cn As OleDb.OleDbConnection
        Dim com As OleDb.OleDbCommand
        'Dim tran As OleDbTransaction = Nothing

        Dim dbCount As Integer
        Dim strSQL As String
        Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

        cn = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
            "DATA SOURCE=" & DbPath & ";" &
            "Persist Security Info = False")

        '起動から1回目の登録時、稼働欄未操作で-1が返ってくるので0に設定
        If KadouStatus.SelectedIndex = -1 Then
            KadouStatus.SelectedIndex = 0
        End If

        'モード別でクエリーを切り替え
        If mode = 1 Then
            '更新モード

            strSQL = "UPDATE [USER] SET "
            strSQL = strSQL & " USER_NAME = '" & NameText.Text & "' "
            strSQL = strSQL & ",KADO = '" & KadouStatus.SelectedIndex & "' "
            strSQL = strSQL & " WHERE ID = " & ShainNum.Text

        Else
            '登録モード
            strSQL = "INSERT INTO [USER] (ID,USER_NAME,KADO) VALUES ("
            strSQL = strSQL & ShainNum.Text & ","
            strSQL = strSQL & "'" & NameText.Text & "',"
            strSQL = strSQL & "'" & KadouStatus.SelectedIndex & "')"

            '検索 とできればついでに登録もしたかった
            'strSQL = " SELECT "
            'strSQL = strSQL & ShainNum.Text & ","
            'strSQL = strSQL & "'" & NameText.Text & "',"
            'strSQL = strSQL & "'" & KadouStatus.SelectedIndex & "'"
            'strSQL = strSQL & " FROM [USER] WHERE NOT EXISTS(SELECT * FROM [USER] WHERE ID = " & ShainNum.Text & ")"

        End If

        Try
            'SelectedID()

            cn.Open()
            ChkShainNum(ShainNum.Text)
            ChkKadouStatus(KadouStatus.SelectedIndex)


            com = New OleDb.OleDbCommand(strSQL, cn)
            MsgBox(strSQL)
            dbCount = com.ExecuteNonQuery()
            '登録できたら1が返ってくる
            MsgBox(dbCount)

            cn.Dispose()
            cn.Close()

            MsgBox(dbCount & "件登録しました",, "登録完了")
            ClearFrom()

        Catch ex As ShainNumException
            MessageBox.Show(ex.Message, "登録エラー")
            ShainNum.Focus()
            cn.Close()

        Catch ex As KadouException
            MessageBox.Show(ex.Message, "登録エラー")
            KadouStatus.Focus()
            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

            cn.Close()

        End Try

    End Sub
    'Private Sub SelectedID()
    '    Dim con As New OleDb.OleDbConnection
    '    Dim OLEDA As OleDb.OleDbDataAdapter
    '    Dim strSQL As String

    '    Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

    '    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
    '        "DATA SOURCE=" & DbPath & ";" &
    '        "Persist Security Info = False"

    '    strSQL = "SELECT ID,USER_NAME,STATUS FROM [USER] INNER JOIN [KADO] ON [USER].KADO = [KADO].CODE"
    '    OLEDA = New OleDb.OleDbDataAdapter(strSQL, con)


    'End Sub
    Private Sub ClearFrom()
        ShainNum.Clear()
        NameText.Clear()
        KadouStatus.SelectedIndex = 0
    End Sub
    Private Sub ChkShainNum(checkNum)
        ' 社員番号チェック
        'MsgBox(checkNum)
        If checkNum.Length = 0 Then
            Throw New ShainNumException("社員番号を入力してください")
        ElseIf Regex.IsMatch(checkNum, "[^0-9]\d*$") Then
            Throw New ShainNumException("社員番号に数字以外の文字があります")
        End If
        'DBアクセスしてIDが見つかったらFalseをTrueに切り替えて例外
        If False Then
            Throw New ShainNumException("登録済みの社員番号です")
        End If

    End Sub
    Private Sub ChkKadouStatus(checkKado)
        ' 稼働チェック
        'MsgBox(checkKado)
        If checkKado = -1 Then
            'Throw New KadouException("稼働状況を選択してください")
        End If
    End Sub
    'Focusしないとラベル避けてフォームクリックすることになり面倒
    Private Sub PHLabel1_Click(sender As Object, e As EventArgs) Handles PHLabel1.Click
        ShainNum.Focus()
    End Sub
    Private Sub PHLabel2_Click(sender As Object, e As EventArgs) Handles PHLabel2.Click
        NameText.Focus()
    End Sub
    ''' <summary>プレースホルダもどき</summary>
    ''' 空欄で表示、入力されると非表示に
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

End Class
''' <summary>社員番号独自例外クラス</summary>
Public Class ShainNumException
    Inherits ApplicationException
    Public Sub New(ByVal errorMessage As String)
        MyBase.New(errorMessage)
    End Sub

End Class
Public Class KadouException
    Inherits ApplicationException
    Public Sub New(ByVal errorMessage As String)
        MyBase.New(errorMessage)
    End Sub

End Class
