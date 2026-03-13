using UnityEngine;
using TMPro;

public class RegistrationPageUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField emailInput;
    public TMP_InputField phoneInput;

    public TextMeshProUGUI errorText;

    public void OnNextPressed()
    {
        if (GameManager.Instance.skipValidation)
        {
            ContinueFlow();
            return;
        }

        string name = nameInput.text;
        string email = emailInput.text;
        string phone = phoneInput.text;

        if (string.IsNullOrEmpty(name))
        {
            ShowError("Name is required");
            return;
        }

        if (!email.Contains("@"))
        {
            ShowError("Invalid email");
            return;
        }

        if (phone.Length < 6)
        {
            ShowError("Phone must be at least 6 digits");
            return;
        }

        ContinueFlow();
    }

    void ContinueFlow()
    {
        string name = nameInput.text;
        string email = emailInput.text;
        string phone = phoneInput.text;

        GameManager.Instance.SetUserData(name, email, phone);

        CSVManager.Instance.SaveRegistration(name, email, phone);

        UIManager.Instance.ShowCapture();
    }

    void ShowError(string message)
    {
        errorText.text = message;
    }
}