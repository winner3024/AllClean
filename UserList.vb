Imports Microsoft.VisualBasic.ControlChars

Public Class UserList
    Private Sub UserList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ListPreview()
    End Sub
    Private Sub ReturnBtn_Click(sender As Object, e As EventArgs) Handles ReturnBtn.Click
        Me.Close()
    End Sub

    Private Sub UDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles UDGV.CellClick

        'クリック行のデータを次画面に渡す
        AddEdit.ShainNum.Text = UDGV.Item(0, UDGV.CurrentCell.RowIndex).Value
        AddEdit.NameText.Text = UDGV.Item(1, UDGV.CurrentCell.RowIndex).Value
        'AddEdit.KadouStatus.SelectedIndex = UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value

        'DBNullだった時の処理と
        If UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value Is DBNull.Value Then
            AddEdit.KadouStatus.SelectedIndex = 0
        ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "稼働" Then
            AddEdit.KadouStatus.SelectedIndex = 1
        ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "非稼働" Then
            AddEdit.KadouStatus.SelectedIndex = 2
        ElseIf UDGV.Item(2, UDGV.CurrentCell.RowIndex).Value = "休職" Then
            AddEdit.KadouStatus.SelectedIndex = 3
        End If

        '更新モードのため、社員番号は編集不可にする
        AddEdit.ShainNum.Enabled = False

        'ボタンのキャプションを「更新」に変更する
        AddEdit.InsertBtn.Text = "更新"

        AddEdit.ShowDialog(Me)

        AddEdit.Dispose()

        '画面のデータを再表示
        Call ListPreview()

    End Sub

    Private Sub ListPreview()

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
        strSQL = "SELECT ID,USER_NAME,STATUS FROM [USER] INNER JOIN [KADO] ON [USER].KADO = [KADO].CODE"

        OLEDA = New OleDb.OleDbDataAdapter(strSQL, cn)
        Try
            'cn.Open()
            'MessageBox.Show("接続しました。", "通知")

            OLEDA.Fill(OLEDS, "USER")
            Me.UDGV.DataSource = OLEDS.Tables("USER")

            ' 新規行を追加できないようにする
            Me.UDGV.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles UDGV.CellContentClick

    End Sub
End Class