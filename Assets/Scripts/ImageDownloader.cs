using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownloader 
{
    private readonly Picture _picture;
    private readonly string _totalUrl;
    
    public ImageDownloader(Picture picture, string totalUrl)
    {
        _picture = picture;
        _totalUrl = totalUrl;
    }

    public async Task DownloadImage()
    {
        if (_picture.Texture != null)
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
                _picture.SetTexture(texture);
                TextureData.Instance.AddTexture(texture, _picture.Index);
                completionSource.SetResult(true);
            };

            await completionSource.Task;
        }
    }
}
