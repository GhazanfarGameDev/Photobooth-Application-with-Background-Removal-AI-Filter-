using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Transform galleryParent;
    public GameObject photoPrefab;

    void OnEnable()
    {
        LoadGallery();
    }

    void LoadGallery()
    {
        string folder = Path.Combine(Application.persistentDataPath, "Outputs");

        if (!Directory.Exists(folder))
            return;

        string[] files = Directory.GetFiles(folder, "*.png");

        foreach (string file in files)
        {
            byte[] bytes = File.ReadAllBytes(file);

            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);

            GameObject item = Instantiate(photoPrefab, galleryParent);

            RawImage img = item.GetComponent<RawImage>();
            img.texture = tex;
        }
    }
}