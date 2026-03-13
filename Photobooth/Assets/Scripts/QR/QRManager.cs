using UnityEngine;
using ZXing;
using UnityEngine.UI;

public class QRManager : MonoBehaviour
{
    public RawImage qrImage;

    public void GenerateQR(string text)
    {

        int size = 256;

        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = size,
                Height = size
            }
        };

        Color32[] pixels = writer.Write(text);

        Texture2D texture = new Texture2D(size, size);
        texture.SetPixels32(pixels);
        texture.Apply();

        qrImage.texture = texture;


        //Texture2D qrTexture = GenerateQRCode(text);
        //qrImage.texture = qrTexture;
    }

    //Texture2D GenerateQRCode(string text)
    //{
    //    BarcodeWriter writer = new BarcodeWriter();
    //    writer.Format = BarcodeFormat.QR_CODE;

    //    var matrix = writer.Write(text);

    //    int width = matrix.Width;
    //    int height = matrix.Height;

    //    Texture2D texture = new Texture2D(width, height);

    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            texture.SetPixel(x, y, matrix[x, y] ? Color.black : Color.white);
    //        }
    //    }

    //    texture.Apply();

    //    return texture;
    //}
}