using UnityEngine;
using UnityEngine.UI;

public class PreviewPageUI : MonoBehaviour
{
    public RawImage previewImage;

    void OnEnable()
    {
        previewImage.texture = GameManager.Instance.capturedPhoto;
    }
}