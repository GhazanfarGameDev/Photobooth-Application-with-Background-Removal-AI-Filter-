using System.Collections;
using UnityEngine;

public class AIProcessor : MonoBehaviour
{
    public void ProcessImage()
    {
        UIManager.Instance.ShowProcessing();

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
                UIManager.Instance.ShowPreview();
            }
            else
            {
                Debug.Log("Processing failed");
                UIManager.Instance.ShowPreview();
            }
        });
    }
}