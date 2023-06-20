using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class DownloadingPool : MonoBehaviour
{
    [SerializeField] private int _startCountImage = 4;

    private Queue<TemplateImage> _waitingToBeLoadedImages = new Queue<TemplateImage>();
    private List<TemplateImage> _allTemplatesImages;
    private int _indexImage;
    private ScrollingHandler _scrollingHandler;
    
    public void Init(List<TemplateImage> allTemplatesImages, ScrollingHandler scrollingHandler)
    {
        _allTemplatesImages = allTemplatesImages;
        _scrollingHandler = scrollingHandler;
        _scrollingHandler.NeedDownloadImage += PutInDownloadNextImage;

        for (int i = 0; i < _startCountImage; i++)
        {
            PutInDownloadNextImage();
        }
    }

    private void PutInDownloadNextImage()
    {
        if (_indexImage >= _allTemplatesImages.Count)
            return;

        _waitingToBeLoadedImages.Enqueue(_allTemplatesImages[_indexImage]);

        StartDownloadImages();
        _indexImage++;
    }

    private async Task StartDownloadImages()
    {
        while (_waitingToBeLoadedImages.Count > 0)
        {
            TemplateImage downloader = _waitingToBeLoadedImages.Dequeue();
            await downloader.DownloadImage();
        }
    }

    private void OnDisable()
    {
        _scrollingHandler.NeedDownloadImage -= PutInDownloadNextImage;
    }
}
