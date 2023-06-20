using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader 
{
    private readonly RawImage _imageRenderer;
    private readonly string _totalUrl;
    
    public ImageDownloader(RawImage imageRenderer, string totalUrl)
    {
        _imageRenderer = imageRenderer;
        _totalUrl = totalUrl;
    }

    public async Task DownloadImage()
    {
        if (_imageRenderer.texture != null)
        {
            Debug.Log("imageRenderer.texture != null");
            return;
        }

        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(_totalUrl))
        {
            UnityWebRequestAsyncOperation asyncOperation = www.SendWebRequest();
            TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();

            asyncOperation.completed += operation =>
            {
                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log("Failed to download image: " + www.error);
                    completionSource.SetResult(false);
                    return;
                }

                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                _imageRenderer.texture = texture;
                completionSource.SetResult(true);
            };

            await completionSource.Task;
        }
    }
}
