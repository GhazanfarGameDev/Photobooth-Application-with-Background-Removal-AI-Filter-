using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CloudinaryUploader : MonoBehaviour
{
    public static CloudinaryUploader Instance;

    public string cloudName = "djzlriynn";
    public string uploadPreset = "photobooth_upload";

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public IEnumerator UploadImage(byte[] imageBytes, Action<string> callback)
    {
        string url = "https://api.cloudinary.com/v1_1/" + cloudName + "/image/upload";

        WWWForm form = new WWWForm();
        form.AddBinaryData("file", imageBytes, "photo.png", "image/png");
        form.AddField("upload_preset", uploadPreset);

        UnityWebRequest request = UnityWebRequest.Post(url, form);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Upload failed: " + request.error);
            callback(null);
        }
        else
        {
            string json = request.downloadHandler.text;

            CloudinaryResponse response = JsonUtility.FromJson<CloudinaryResponse>(json);

            callback(response.secure_url);
        }
    }
}

[Serializable]
public class CloudinaryResponse
{
    public string secure_url;
}
