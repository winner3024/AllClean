Public Class UserList
    Private Sub UserList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ListPreview()
    End Sub
    Private Sub ReturnBtn_Click(sender As Object, e As EventArgs) Handles ReturnBtn.Click
        Close()
    End Sub

    Private Sub UDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles UDGV.CellClick
        Dim itemCount As Integer = 0
        'クリック行のデータを次画面に渡す
        AddEdit.ShainNum.Text = UDGV.Item(0, UDGV.CurrentCell.RowIndex).Value
        If UDGV.Item(1, UDGV.CurrentCell.RowIndex).Value Is DBNull.Value Then
            AddEdit.NameText.Text = Nothing
        Else
            AddEdit.NameText.Text = UDGV.Item(1, UDGV.CurrentCell.RowIndex).Value
        End If
        'KADOが数値表記でしか使えないので一覧から稼働状況が把握できない
        'AddEdit.KadouStatus.SelectedIndex = UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value

        '稼働欄がDBNullだった時の処理と設定
        '保守性がない
        If UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value Is DBNull.Value Then
            AddEdit.KadouStatus.SelectedIndex = 0
            'ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "稼働" Then
            '    AddEdit.KadouStatus.SelectedIndex = 1
            'ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "非稼働" Then
            '    AddEdit.KadouStatus.SelectedIndex = 2
            'ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "休職" Then
            '    AddEdit.KadouStatus.SelectedIndex = 3
        Else
            'これなら稼働状況の変更にも対応できる
            For Each itemStr As String In AddEdit.KadouStatus.Items
                If itemStr = UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value Then
                    'MsgBox(itemStr,, itemCount & "番目で見つかった")
                    AddEdit.KadouStatus.SelectedIndex = itemCount
                    Exit For
                End If
                itemCount += 1
            Next
        End If

        '更新モードのため、社員番号は編集不可にする
        AddEdit.ShainNum.Enabled = False
        'フォーカス時に文字列が全選択されてしまうので末尾にカーソルを付ける
        AddEdit.NameText.Select(AddEdit.NameText.Text.Length, 0)

        'ボタン・フォームのキャプションを変更する
        AddEdit.InsertBtn.Text = "更新"
        AddEdit.Text = "更新・削除"

        AddEdit.ShowDialog(Me)

        AddEdit.Dispose()

        '画面のデータを再表示
        Call ListPreview()

    End Sub

    Friend Sub ListPreview()

        Dim cn As New OleDb.OleDbConnection
        Dim OLEDA As OleDb.OleDbDataAdapter
        Dim OLEDS As DataSet = New DataSet("ユーザ情報")
        Dim strSQL As String

        Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "DATA SOURCE=" & DbPath & ";" &
            "Persist Security Info = False"

        'strSQL = "SELECT * FROM [USER]"
        '稼働欄を漢字で表示
        strSQL = "SELECT ID,USER_NAME,STATUS FROM [USER] INNER JOIN [KADO] ON [USER].KADO_CODE = [KADO].KADO_CODE ORDER BY ID"

        OLEDA = New OleDb.OleDbDataAdapter(strSQL, cn)

        Try

            'STATUSがNullだとその行は表示されない
            OLEDA.Fill(OLEDS, "USER")
            UDGV.DataSource = OLEDS.Tables("USER")

            ' 新規行を追加できないようにする
            UDGV.AllowUserToAddRows = False
            '社員番号5桁0埋め
            UDGV.Columns(0).DefaultCellStyle.Format = "00000"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
