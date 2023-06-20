using UnityEngine;

public class SpawnerTemplates : MonoBehaviour
{
    [SerializeField] private ImageDownloader _imageDownloaderTemplate;
    [SerializeField] private RectTransform _containerImages;
    [SerializeField] private int _countImages = 66;
    [SerializeField] private ImageDownloader[] _allImages;

    public int CountImages => _countImages;
    public ImageDownloader[] AllImages  => _allImages;

    public void CreateTemplates()
    {
        _allImages = new ImageDownloader[_countImages];

        for (int i = 0; i < _allImages.Length; i++)
        {
            ImageDownloader newImage = Instantiate(_imageDownloaderTemplate);

            newImage.transform.SetParent(_containerImages, false);
            int numberImage = i + 1;
            
            UrlProvider urlProvider = new UrlProvider(numberImage);
            newImage.Init(urlProvider.Url);
            
            _allImages[i] = newImage;
        }
    }
}
