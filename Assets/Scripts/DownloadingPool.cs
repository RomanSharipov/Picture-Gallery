using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DownloadingPool 
{
    private readonly List<TemplateImage> _allTemplatesImages;
    private readonly ScrollingHandler _scrollingHandler;
    private readonly int _startCountImage = 4;
    private readonly Queue<TemplateImage> _waitingToBeLoadedImages = new Queue<TemplateImage>();
    private int _indexImage;
    
    public DownloadingPool(List<TemplateImage> allTemplatesImages, ScrollingHandler scrollingHandler)
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
    
    public void OnDisable()
    {
        _scrollingHandler.NeedDownloadImage -= PutInDownloadNextImage;
    }
}
