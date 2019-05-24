Public Class Panel
    Private Img As Image             'パネル画像 
    Private Board As Board
    Public Position As Point        '論理位置
    Public Rectangle As Rectangle   '物理位置
    Public PanelStatus As Status
    Public Focused As Boolean
    Public Now As Integer           '現在の画像番号
    Public TrueNow As Boolean       '現在位置があっているかどうか
    Public TrueHint As Boolean
    'コンストラクタ
    Public Sub New(ByVal Board As Board, ByVal Position As Point)

        Me.Board = Board
        Me.Position = Position

        Dim Rect As New Rectangle

        '論理位置から物理位置を求める
        Rect.X = Board.Size * Position.X
        Rect.Y = Board.Size * Position.Y
        Rect.Width = Board.Size
        Rect.Height = Board.Size

        Me.Rectangle = Rect

        Init()

    End Sub
    '初期化
    Public Sub Init()

        Dim bmp As Bitmap = New Bitmap(150, 150)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(Brushes.Black, 0, 0, 150, 150)
            Img = bmp
        End Using

    End Sub
    ''' <summary>描画処理</summary>
    ''' <param name="g">グラフィックオブジェクト</param>
    Public Sub Draw(ByVal g As Graphics)

        Try

            Dim Rect As Rectangle = Me.Rectangle
            g.DrawImage(Me.Img, Rect)

            Dim pens As Pen

            If Me.Focused Then
                pens = New Pen(Brushes.Orange, 2)
                g.DrawRectangle(pens, Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1)
            End If

            Dim font As Font = New Font("MSゴシック", 48)

            If Me.TrueNow Then
                pens = New Pen(Brushes.Red, 2)
                g.DrawRectangle(pens, Rect.X + 1, Rect.Y + 1, Rect.Width - 2, Rect.Height - 2)
            End If

            If Me.TrueHint Then
                If (Now + 1) = 16 Then
                    pens = New Pen(Brushes.GreenYellow, 2)
                    g.DrawRectangle(pens, Rect.X + 1, Rect.Y + 1, Rect.Width - 2, Rect.Height - 2)
                ElseIf (Now + 1) >= 10 Then
                    g.DrawString((Now + 1).ToString, font, Brushes.Orange, Rect.X + 25, Rect.Y + 37)
                Else
                    g.DrawString((Now + 1).ToString, font, Brushes.Orange, Rect.X + 45, Rect.Y + 37)
                End If

            End If

        Catch e As Exception

            MsgBox(e.ToString, MsgBoxStyle.Critical, "画像が設定されていません" & vbCrLf & "画像フォルダが実行ファイルと同じパスにあるか確認してください")

        End Try

    End Sub

    ''' <summary>パネルの画像プロパティ</summary>
    Public Property Image() As Image
        Get
            Return Me.Img
        End Get
        Set(value As Image)
            Me.Img = value
        End Set
    End Property

    ''' <summary>パネルにフォーカスを設定する</summary>
    Public Sub Focus()

        For X As Integer = 0 To Board.Count - 1
            For Y As Integer = 0 To Board.Count - 1
                Board.Panels(X, Y).Focused = False
            Next
        Next

        Me.Focused = True

    End Sub

    Public Sub Hint()

        Me.TrueNow = True
        Me.TrueHint = True

    End Sub

    Public Sub unHint()

        Me.TrueNow = False
        Me.TrueHint = False

    End Sub

End Class
Public Enum Status
    TruePanel = 0
    FalsePanel = 1
End Enum
