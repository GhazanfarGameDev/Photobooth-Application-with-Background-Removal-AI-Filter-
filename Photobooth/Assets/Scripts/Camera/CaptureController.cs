using System.Collections;
using TMPro;
using UnityEngine;

public class CaptureController : MonoBehaviour
{
    public WebcamManager webcamManager;
    public TextMeshProUGUI countdownText;

    public void StartCapture()
    {
        StartCoroutine(CaptureRoutine());
    }

    IEnumerator CaptureRoutine()
    {
        int countdown = GameManager.Instance.captureCountdown;

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        countdownText.text = "";

        Texture2D photo = webcamManager.CapturePhoto();

        GameManager.Instance.SetCapturedPhoto(photo);
        UIManager.Instance.ShowPreview();
        //UnSaved
        //FileManager.Instance.SavePhoto(photo);
        //Unprocessed
        //GetComponent<AIProcessor>().ProcessImage();        
    }
}