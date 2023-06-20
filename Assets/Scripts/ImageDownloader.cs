using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    [SerializeField] private RawImage _imageRenderer;

    private string _totalUrl;
    
    public void Init(string totalUrl)
    {
        _totalUrl = totalUrl;
    }

    public IEnumerator DownloadImageJob()
    {
        if (_imageRenderer.texture != null)
        {
            Debug.Log("imageRenderer.texture != null");
            yield break;
        }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(_totalUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Failed to download image: " + www.error);
                yield break;
            }
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            _imageRenderer.texture = texture;
        }
    }
}
