Option Explicit
On Error Resume Next

Dim objWshShell     ' WshShell �I�u�W�F�N�g
Dim strCmdLine      ' ���s����R�}���h

Set objWshShell = WScript.CreateObject("WScript.Shell")
If Err.Number = 0 Then
    strCmdLine = "notepad.exe"
    objWshShell.Exec(strCmdLine)
    If Err.Number = 0 Then
        'WScript.Echo strCmdLine & " ���N�����܂����B"
    Else
        WScript.Echo "�G���[: " & Err.Description
    End If
Else
    WScript.Echo "�G���[: " & Err.Description
End If

Set objWshShell = Nothing