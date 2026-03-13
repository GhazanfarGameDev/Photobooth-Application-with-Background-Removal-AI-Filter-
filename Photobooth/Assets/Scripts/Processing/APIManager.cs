using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public static APIManager Instance;

    public string apiKey = "pL2nWdespJtJ6x9HygoUMdhz";

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public IEnumerator RemoveBackground(Texture2D image, System.Action<Texture2D> callback)
    {
        byte[] imageBytes = image.EncodeToPNG();

        WWWForm form = new WWWForm();
        form.AddBinaryData("image_file", imageBytes, "photo.png", "image/png");

        UnityWebRequest request = UnityWebRequest.Post("https://api.remove.bg/v1.0/removebg", form);

        request.SetRequestHeader("X-Api-Key", apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Remove.bg Error: " + request.error);
            Debug.LogError(request.downloadHandler.text);
            callback(null);
        }
        else
        {
            byte[] resultBytes = request.downloadHandler.data;

            Texture2D resultTexture = new Texture2D(2, 2);
            resultTexture.LoadImage(resultBytes);

            callback(resultTexture);
        }
    }

    //public IEnumerator RemoveBackground(Texture2D image, System.Action<Texture2D> callback)
    //{
    //    byte[] imageBytes = image.EncodeToPNG();

    //    WWWForm form = new WWWForm();
    //    form.AddBinaryData("image", imageBytes, "photo.png", "image/png");

    //    UnityWebRequest request = UnityWebRequest.Post("https://api.deepai.org/api/background-removal", form);

    //    request.SetRequestHeader("api-key", apiKey);

    //    yield return request.SendWebRequest();

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.LogError("DeepAI Error: " + request.error);
    //        Debug.LogError("Server Response: " + request.downloadHandler.text);
    //        callback(null);
    //        yield break;
    //    }
    //    //else
    //    //{
    //    //    string json = request.downloadHandler.text;

    //    //    Debug.Log(json);

    //    //    string imageUrl = JsonUtility.FromJson<DeepAIResponse>(json).output_url;

    //    //    StartCoroutine(DownloadImage(imageUrl, callback));
    //    //}

    //    string json = request.downloadHandler.text;

    //    Debug.Log("DeepAI Response: " + json);

    //    DeepAIResponse response = JsonUtility.FromJson<DeepAIResponse>(json);

    //    StartCoroutine(DownloadImage(response.output_url, callback));
    //}

    

    IEnumerator DownloadImage(string url, System.Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            callback(null);
        }
        else
        {
            Texture2D tex = DownloadHandlerTexture.GetContent(request);
            callback(tex);
        }
    }
}

[System.Serializable]
public class DeepAIResponse
{
    public string output_url;
}