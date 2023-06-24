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

    private int _index;

    public int Index => _index;

    public Texture Texture => _rawImage.texture;

    public event Action<Picture> Clicked;

    public void Init(string url,int index)
    {
        _index = index;
        _imageDownloader = new ImageDownloader(this, url);
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

        Clicked?.Invoke(this);
    }

    private void OnDisable()
    {
        _onClickPictureHandler.OnDisable();
    }

    public void SetTexture(Texture texture)
    {
        _rawImage.texture = texture;
    }
}
