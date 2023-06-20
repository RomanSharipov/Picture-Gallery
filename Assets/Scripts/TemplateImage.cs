using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TemplateImage : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    
    private ImageDownloader _imageDownloader;

    public void Init(string url)
    {
        _imageDownloader = new ImageDownloader(_rawImage, url);
    }

    public async Task DownloadImage()
    {
        await _imageDownloader.DownloadImage();
    }
}
