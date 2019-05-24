''' <summary>マスに使う画像を扱うクラス</summary>
Public Class CellImages

    Dim _Images(Stage.CellCount) As Image
    ''' <summary>マスに使う画像</summary>
    Public Property Images(ByVal n As Integer) As Image
        Get
            Return _Images(n)
        End Get
        Set(ByVal value As Image)
            _Images(n) = value
        End Set
    End Property

    Dim _SelectedImages(Stage.CellCount) As Image
    ''' <summary>マスを選択したときのマスの画像</summary>
    Public Property SelectedImages(ByVal n As Integer) As Image
        Get
            Return _SelectedImages(n)
        End Get
        Set(ByVal value As Image)
            _SelectedImages(n) = value
        End Set
    End Property

    ''' <summary>マスを選択したときのマスの画像を作る</summary>
    ''' <param name="Source">元となる画像ファイル</param>
    ''' <param name="c">選択の色。元の画像に半透明で重ねる</param>
    Public Function MakeSelectedImage(ByVal Source As Image, ByVal c As Color) As Bitmap

        '新しい空の画像を作成
        Dim SourceImage As New Bitmap(Source.Width, Source.Height)
        Dim g As Graphics = Graphics.FromImage(SourceImage)

        '最初に、その画像に色をつける
        g.FillRectangle(New SolidBrush(c), Source.GetBounds(GraphicsUnit.Pixel))


        '透明度を設定
        Dim Attr As New Imaging.ImageAttributes
        Dim M As New Imaging.ColorMatrix
        M.Matrix00 = 1.0F
        M.Matrix11 = 1.0F
        M.Matrix22 = 1.0F
        M.Matrix33 = 0.5F
        M.Matrix44 = 1.0F
        Attr.SetColorMatrix(M)

        'その画像に元の画像を半透明で重ねる
        g.DrawImage(Source, New Rectangle(New Point, SourceImage.Size), _
                    0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel, Attr)

        Return SourceImage

    End Function

End Class
