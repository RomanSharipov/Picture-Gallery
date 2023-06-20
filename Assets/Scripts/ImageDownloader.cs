using System.Threading.Tasks;
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
    
    public async Task DownloadImageJob()
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
