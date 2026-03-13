using System.IO;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    public static CSVManager Instance;

    string filePath;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        filePath = Path.Combine(Application.persistentDataPath, "registrations.csv");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Name,Email,Phone,Timestamp\n");
        }
    }

    public void SaveRegistration(string name, string email, string phone)
    {
        string line = name + "," + email + "," + phone + "," + System.DateTime.Now;

        File.AppendAllText(filePath, line + "\n");

        Debug.Log("Saved registration: " + line);
    }
}