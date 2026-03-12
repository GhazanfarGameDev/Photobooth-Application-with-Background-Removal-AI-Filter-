using UnityEngine;
using UnityEngine.UI;

public class WebcamManager : MonoBehaviour
{
    public RawImage cameraPreview;

    private WebCamTexture webcamTexture;

    void Start()
    {
        StartCamera();
    }

    void StartCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            return;
        }

        webcamTexture = new WebCamTexture(devices[0].name);

        cameraPreview.texture = webcamTexture;
        cameraPreview.material.mainTexture = webcamTexture;

        webcamTexture.Play();
    }

    public Texture2D CapturePhoto()
    {
        Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        return photo;
    }
}
