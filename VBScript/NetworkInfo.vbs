Option Explicit
On Error Resume Next

Dim objWshNetwork   ' WshNetwork �I�u�W�F�N�g

Set objWshNetwork = WScript.CreateObject("WScript.Network")
If Err.Number = 0 Then
    WScript.Echo "�h���C���F" & objWshNetwork.UserDomain
    WScript.Echo "�R���s���[�^�F" & objWshNetwork.ComputerName
    WScript.Echo "���[�U�[�F" & objWshNetwork.UserName
Else
    WScript.Echo "�G���[: " & Err.Description
End If

Set objWshNetwork = Nothing