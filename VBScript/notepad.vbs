Option Explicit
On Error Resume Next

Dim objWshShell     ' WshShell オブジェクト
Dim strCmdLine      ' 実行するコマンド

Set objWshShell = WScript.CreateObject("WScript.Shell")
If Err.Number = 0 Then
    strCmdLine = "notepad.exe"
    objWshShell.Exec(strCmdLine)
    If Err.Number = 0 Then
        'WScript.Echo strCmdLine & " を起動しました。"
    Else
        WScript.Echo "エラー: " & Err.Description
    End If
Else
    WScript.Echo "エラー: " & Err.Description
End If

Set objWshShell = Nothing