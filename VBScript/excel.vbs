' Microsoft Excel�N��
Set oXlsApp = CreateObject("Excel.Application")
If oXlsApp Is Nothing Then
    ' Microsoft Excel�N�����s
    MsgBox "Microsoft Excel�N�����s�@"

Else
    ' Microsoft Excel�N������
    ' �G�N�Z����\��
    oXlsApp.Application.Visible = False
    oXlsApp.Application.DisplayAlerts = False

    ' �u�b�N�ǉ�
    oXlsApp.Application.Workbooks.Add

    ' �V�[�g�I��
    Set oSheet = oXlsApp.Worksheets(1)

    ' �J�������ݒ�
    oSheet.Columns("C").ColumnWidth = 20

    ' �J�����̏����ݒ�̕\���`���𕶎���ɂ���
    oSheet.Columns("C").NumberFormatLocal = "@"

    ' �Z���I��
    Set oRange = oSheet.Range("C10")

    ' �Z���̃t�H���g�ݒ�
    oRange.Font.Size = 9
    oRange.Font.Name = "�l�r �S�V�b�N"

    ' �Z���Ƀf�[�^������
    oRange.Value = "C10�̃f�[�^"

    ' �Z���̔w�i�F�ݒ�
    oRange.Interior.Color = &H44FFFF

    ' �Z���̕����F�ݒ�
    oRange.Font.Color = &HFF0000

    ' �G�N�Z���\��
    oXlsApp.Application.Visible = True

    ' �G�N�Z�������
    'If oXlsApp Is Nothing = False Then oXlsApp.Quit
    'Set oRange = Nothing
    'Set oSheet = Nothing
    'Set oXlsApp = Nothing
End If