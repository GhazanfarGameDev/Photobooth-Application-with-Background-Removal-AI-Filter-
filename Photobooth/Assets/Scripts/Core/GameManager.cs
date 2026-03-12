using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("User Data")]
    public string userName;
    public string userEmail;
    public string userPhone;

    [Header("Captured Image")]
    public Texture2D capturedPhoto;

    [Header("Settings")]
    public bool skipValidation = false;
    public int captureCountdown = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void SetUserData(string name, string email, string phone)
    {
        userName = name;
        userEmail = email;
        userPhone = phone;
    }

    public void SetCapturedPhoto(Texture2D photo)
    {
        capturedPhoto = photo;
    }

    public void ResetSession()
    {
        userName = "";
        userEmail = "";
        userPhone = "";
        capturedPhoto = null;
    }
}
