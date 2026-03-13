using System.IO;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static FileManager Instance;

    string outputFolder;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        outputFolder = Path.Combine(Application.persistentDataPath, "Outputs");

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }
    }

    public string SavePhoto(Texture2D photo)
    {
        string fileName = "photo_" + System.DateTime.Now.Ticks + ".png";

        string path = Path.Combine(outputFolder, fileName);

        byte[] bytes = photo.EncodeToPNG();

        File.WriteAllBytes(path, bytes);

        Debug.Log("Saved photo at: " + path);

        return path;
    }
}