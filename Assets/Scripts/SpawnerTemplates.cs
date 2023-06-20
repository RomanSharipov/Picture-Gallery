using UnityEngine;

public class SpawnerTemplates : MonoBehaviour
{
    [SerializeField] private TemplateImage _imageDownloaderTemplate;
    [SerializeField] private RectTransform _containerImages;
    [SerializeField] private int _countImages = 66;
    [SerializeField] private TemplateImage[] _allImages;

    public int CountImages => _countImages;
    public TemplateImage[] AllImages  => _allImages;

    public void CreateTemplates()
    {
        _allImages = new TemplateImage[_countImages];

        for (int i = 0; i < _allImages.Length; i++)
        {
            TemplateImage newImage = Instantiate(_imageDownloaderTemplate);

            newImage.transform.SetParent(_containerImages, false);
            int numberImage = i + 1;
            
            UrlProvider urlProvider = new UrlProvider(numberImage);
            newImage.Init(urlProvider.Url);
            
            _allImages[i] = newImage;
        }
    }
}
