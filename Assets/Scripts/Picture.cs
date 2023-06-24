using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Picture : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private RawImage _rawImage;
    
    private ImageDownloader _imageDownloader;
    private OnClickPictureHandler _onClickPictureHandler;

    public event Action<Texture> Clicked;

    public void Init(string url)
    {
        _imageDownloader = new ImageDownloader(_rawImage, url);
        _onClickPictureHandler = new OnClickPictureHandler(this);
    }

    public async Task DownloadImage()
    {
        await _imageDownloader.DownloadImage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_rawImage.texture == null)
            return;

        Clicked?.Invoke(_rawImage.texture);
    }

    private void OnDisable()
    {
        _onClickPictureHandler.OnDisable();
    }

}
