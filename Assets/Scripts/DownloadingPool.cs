using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DownloadingPool : MonoBehaviour
{
    [SerializeField] private int _startCountImage = 4;

    private Queue<ImageDownloader> _waitingToBeLoadedImages = new Queue<ImageDownloader>();
    private List<ImageDownloader> _allTemplatesImages;
    private int _indexImage;
    private ScrollingHandler _scrollingHandler;
    
    public void Init(List<ImageDownloader> allTemplatesImages, ScrollingHandler scrollingHandler)
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

        StartCoroutine(StartDownloadImages());
        _indexImage++;
    }

    private IEnumerator StartDownloadImages()
    {
        for (int i = 0; i < _waitingToBeLoadedImages.Count; i++)
        {
            yield return _waitingToBeLoadedImages.Dequeue().DownloadImageJob();
        }
    }

    private void OnDisable()
    {
        _scrollingHandler.NeedDownloadImage -= PutInDownloadNextImage;
    }
}
