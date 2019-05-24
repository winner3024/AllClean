' Microsoft Excel起動
Set oXlsApp = CreateObject("Excel.Application")
If oXlsApp Is Nothing Then
    ' Microsoft Excel起動失敗
    MsgBox "Microsoft Excel起動失敗　"

Else
    ' Microsoft Excel起動成功
    ' エクセル非表示
    oXlsApp.Application.Visible = False
    oXlsApp.Application.DisplayAlerts = False

    ' ブック追加
    oXlsApp.Application.Workbooks.Add

    ' シート選択
    Set oSheet = oXlsApp.Worksheets(1)

    ' カラム幅設定
    oSheet.Columns("C").ColumnWidth = 20

    ' カラムの書式設定の表示形式を文字列にする
    oSheet.Columns("C").NumberFormatLocal = "@"

    ' セル選択
    Set oRange = oSheet.Range("C10")

    ' セルのフォント設定
    oRange.Font.Size = 9
    oRange.Font.Name = "ＭＳ ゴシック"

    ' セルにデータ書込み
    oRange.Value = "C10のデータ"

    ' セルの背景色設定
    oRange.Interior.Color = &H44FFFF

    ' セルの文字色設定
    oRange.Font.Color = &HFF0000

    ' エクセル表示
    oXlsApp.Application.Visible = True

    ' エクセルを閉じる
    'If oXlsApp Is Nothing = False Then oXlsApp.Quit
    'Set oRange = Nothing
    'Set oSheet = Nothing
    'Set oXlsApp = Nothing
End If