Option Explicit

Dim lngYear     ' �N

lngYear = Year(Date())
If Day(DateSerial(lngYear, 3, 1) - 1) = 29 Then
    WScript.Echo lngYear & "�N�͂��邤�N�ł��B"
Else
    WScript.Echo lngYear & "�N�͂��邤�N�ł͂���܂���B"
End If