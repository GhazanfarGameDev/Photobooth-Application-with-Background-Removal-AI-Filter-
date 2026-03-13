using UnityEngine;
using UnityEngine.UI;

public class SharePageUI : MonoBehaviour
{
    public RawImage finalImage;
    public QRManager qrManager;

    void OnEnable()
    {
        finalImage.texture = GameManager.Instance.capturedPhoto;

        string path = FileManager.Instance.lastSavedPath;

        qrManager.GenerateQR(path);
    }
}