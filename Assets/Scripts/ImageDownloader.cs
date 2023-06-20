using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    public RawImage imageRenderer;
    public Sprite _sample;
    public string totalUrl;
    public int compressionQuality = 1;
    
    public IEnumerator DownloadImageJob()
    {
        if (imageRenderer.texture != null)
        {
            Debug.Log("imageRenderer.texture != null");
            yield break;
        }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(totalUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Failed to download image: " + www.error);
                yield break;
            }
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            imageRenderer.texture = texture;
        }
    }
}
