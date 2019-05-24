Option Explicit

Dim lngYear     ' 年

lngYear = Year(Date())
If Day(DateSerial(lngYear, 3, 1) - 1) = 29 Then
    WScript.Echo lngYear & "年はうるう年です。"
Else
    WScript.Echo lngYear & "年はうるう年ではありません。"
End If