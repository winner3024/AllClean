Public Class MasterDataEdit
    Private Sub MasterDataEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TableListPreview()
    End Sub

    Private Sub RetrunBtn_Click(sender As Object, e As EventArgs) Handles RetrunBtn.Click
        Me.Close()
    End Sub

    Private Sub TableListPreview()

        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim dtTableName As DataTable
        Dim textColumn As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()

        Dim DbPath As String = System.Configuration.ConfigurationManager.AppSettings("DbPath")

        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "DATA SOURCE=" & DbPath & ";" &
            "Persist Security Info = False"

        ' 一覧の初期化
        Me.MGDV.Rows.Clear()
        Me.MGDV.Columns.Clear()

        ' 列定義
        textColumn.DataPropertyName = "TableName"
        textColumn.HeaderText = "テーブル名"
        textColumn.Visible = True
        textColumn.Width = 200
        textColumn.ReadOnly = True
        textColumn.Resizable = DataGridViewTriState.True

        ' 列生成
        Me.MGDV.Columns.Add(textColumn)

        Try
            cn.Open()

            ' GetSchemaの使い方は　http://eashortcircuit.blogspot.com/2016/04/getschema.html　参照
            dtTableName = cn.GetSchema("Tables", New String() {Nothing, Nothing, Nothing, "TABLE"})

            For i As Integer = 0 To dtTableName.Rows.Count - 1

                Me.MGDV.Rows.Add()

                Dim idx As Integer = Me.MGDV.Rows.Count - 1
                Me.MGDV.Rows(i).Cells(0).Value = dtTableName.Rows(i)("TABLE_NAME").ToString()

            Next i

            ' 新規行を追加できないようにする
            Me.MGDV.AllowUserToAddRows = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            ' DB接続を閉じる
            If Not cn Is Nothing Then
                cn.Close()
            End If

        End Try

    End Sub

    Private Sub MGDV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MGDV.CellDoubleClick

        'ダブルクリック行のテーブル名を次画面に渡す
        MasterEdit.SelectTableName = MGDV.Item(0, MGDV.CurrentCell.RowIndex).Value

        MasterEdit.ShowDialog(Me)

        MasterEdit.Dispose()

    End Sub

    Private Sub MGDV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MGDV.CellContentClick

    End Sub
End Class