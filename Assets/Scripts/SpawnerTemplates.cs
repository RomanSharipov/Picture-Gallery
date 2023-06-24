using UnityEngine;

public class SpawnerTemplates : MonoBehaviour
{
    [SerializeField] private Picture _pictureTemplate;
    [SerializeField] private RectTransform _containerPictures;
    [SerializeField] private int _countPictures = 66;
    [SerializeField] private Picture[] _allPictures;

    public int CountImages => _countPictures;
    public Picture[] AllImages  => _allPictures;

    public void CreateTemplates()
    {
        _allPictures = new Picture[_countPictures];

        for (int i = 0; i < _allPictures.Length; i++)
        {
            Picture newImage = Instantiate(_pictureTemplate);

            newImage.transform.SetParent(_containerPictures, false);
            int numberImage = i + 1;
            
            UrlProvider urlProvider = new UrlProvider(numberImage);
            newImage.Init(urlProvider.Url);
            
            _allPictures[i] = newImage;
        }
    }
}
