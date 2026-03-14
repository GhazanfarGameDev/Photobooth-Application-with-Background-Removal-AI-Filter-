using System.Collections;
using UnityEngine;

public class AIProcessor : MonoBehaviour
{
    public void ProcessImage()
    {

        Texture2D photo = GameManager.Instance.capturedPhoto;

        StartCoroutine(Process(photo));
    }

    IEnumerator Process(Texture2D photo)
    {
        yield return APIManager.Instance.RemoveBackground(photo, (Texture2D result) =>
        {
            if (result != null)
            {
                GameManager.Instance.capturedPhoto = result;
                FileManager.Instance.SavePhoto(result);

                byte[] bytes = result.EncodeToPNG();
                StartCoroutine(
    CloudinaryUploader.Instance.UploadImage(bytes, (url) =>
    {
        if (url != null)
        {
            GameManager.Instance.imageURL = url;
            UIManager.Instance.HideAllPages();
            UIManager.Instance.sharePage.SetActive(true);
            //UIManager.Instance.ShowShare();
        }
        else
        {
            Debug.Log("URL is Null");
        }
    })
);
                //UIManager.Instance.HideAllPages();
                //UIManager.Instance.sharePage.SetActive(true);
                //UIManager.Instance.ShowShare();
            }
            else
            {
                UIManager.Instance.HideAllPages();
                Debug.Log("Processing failed");
                UIManager.Instance.ShowCapture();
            }
        });
    }
}