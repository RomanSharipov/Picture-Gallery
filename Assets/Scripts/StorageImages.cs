using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StorageImages : MonoBehaviour
{
    [SerializeField] private ImageDownloader _imageDownloader;
    [SerializeField] private RectTransform _containerImages;
    [SerializeField] private int _countImages = 66;
    [SerializeField] private string _urlPage = "http://data.ikppbb.com/test-task-unity-data/pics/";
    [SerializeField] private string _fileExtension = ".jpg";
    [SerializeField] private ScrollRect _scrollRect ;
    [SerializeField] private ImageDownloader[] _allImages;
    
    [SerializeField] private DownloadingPool _downloadingPool;
    [SerializeField] private int _startCountImage = 4;

    private int _currentIndexImage;

    private void Start()
    {
        CreateTemplates();
        _downloadingPool.Init(_allImages.ToList());

        for (int i = 0; i < _startCountImage; i++)
        {
            _downloadingPool.AddToQueue();
        }
    }
    public void CreateTemplates()
    {
        _allImages = new ImageDownloader[_countImages];

        for (int i = 0; i < _allImages.Length; i++)
        {
            ImageDownloader newImage = Instantiate(_imageDownloader);

            newImage.transform.SetParent(_containerImages,false);
            string numberImage = $"{i + 1}";
            newImage.name = $"{numberImage}.Image";

            string totalUrl = $"{_urlPage}{numberImage}{_fileExtension}";
            newImage.totalUrl = totalUrl;
            _allImages[i] = newImage;
        }
    }
    
    public int NormalizeValue(float ratio)
    {
        float floatValue = _countImages * (1 - ratio);

        return Mathf.RoundToInt(floatValue);
    }

    private void OnEnable()
    {
        _scrollRect.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _scrollRect.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(Vector2 vector2)
    {
        if (_currentIndexImage == NormalizeValue(vector2.y))
            return;

        _currentIndexImage = NormalizeValue(vector2.y);

        Debug.Log($"_currentIndexImage = {_currentIndexImage}");
        _downloadingPool.AddToQueue();
    }

}
