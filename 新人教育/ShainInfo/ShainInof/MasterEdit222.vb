'Public Class MasterEdit222

'    Public SelectTableName As String

'    Private Sub MasterEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Call ListPreview()
'    End Sub

'    Private Sub RetrunBtn_Click(sender As Object, e As EventArgs) Handles RetrunBtn.Click
'        Me.Close()
'    End Sub

'    Private Sub ListPreview()

'        Dim cn As New OleDb.OleDbConnection
'        Dim OLEDA As OleDb.OleDbDataAdapter
'        Dim OLEDS As DataSet = New DataSet("ユーザ情報")
'        Dim strSQL As String

'        Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

'        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
'            "DATA SOURCE=" & DbPath & ";" &
'            "Persist Security Info = False"

'        strSQL = "SELECT * FROM [" & SelectTableName & "]"

'        OLEDA = New OleDb.OleDbDataAdapter(strSQL, cn)
'        Try

'            OLEDA.Fill(OLEDS, SelectTableName)
'            Me.MGDV.DataSource = OLEDS.Tables(SelectTableName)

'        Catch ex As Exception
'            MessageBox.Show(ex.Message)
'        End Try

'    End Sub

'    Private Sub DataEdit_Click(sender As Object, e As EventArgs) Handles DataEdit.Click

'        Dim cn As New OleDb.OleDbConnection
'        Dim dataTable = DirectCast(MGDV.DataSource, DataTable).GetChanges()


'        ' 変更無し
'        If dataTable Is Nothing Then Return

'        Dim DbPath As String = Configuration.ConfigurationManager.AppSettings("DbPath")

'        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
'                "DATA SOURCE=" & DbPath & ";" &
'                "Persist Security Info = False"

'        cn.Open()

'        'SQLによるトランザクション制御を行いたい。
'        'リストに表示されているデータに対して追加、更新、削除を行いたい


'        cn.Close()

'    End Sub
'End Class