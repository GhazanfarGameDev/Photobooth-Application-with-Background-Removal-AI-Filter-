using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{


    public static UIManager Instance;


    [Header("Pages")]
    public GameObject homePage;
    public GameObject registrationPage;
    public GameObject capturePage;
    public GameObject processingPage;
    public GameObject previewPage;
    public GameObject sharePage;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    void Start()
    {
        ShowHome();
    }

    public void HideAllPages()
    {
        homePage.SetActive(false);
        registrationPage.SetActive(false);
        capturePage.SetActive(false);
        processingPage.SetActive(false);
        previewPage.SetActive(false);
        sharePage.SetActive(false);
    }

    public void ShowHome()
    {
        HideAllPages();
        homePage.SetActive(true);

        GameManager.Instance.ResetSession();
    }

    public void ShowRegistration()
    {
        HideAllPages();
        registrationPage.SetActive(true);
    }

    public void ShowCapture()
    {
        HideAllPages();
        capturePage.SetActive(true);
    }

    public void ShowProcessing()
    {
        //HideAllPages();
        processingPage.SetActive(true);
    }

    public void ShowPreview()
    {
        HideAllPages();
        previewPage.SetActive(true);
    }

    public void ShowShare()
    {
        ShowProcessing();
        //UnSaved
        //FileManager.Instance.SavePhoto(photo);
        //Unprocessed
        previewPage.GetComponent<AIProcessor>().ProcessImage();

        //HideAllPages();
        //sharePage.SetActive(true);
    }



}
