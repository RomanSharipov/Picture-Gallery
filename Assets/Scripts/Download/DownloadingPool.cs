using System.Collections.Generic;
public class DownloadingPool 
{
    private readonly List<Picture> _allTemplatesPictures;
    private readonly ScrollingHandler _scrollingHandler;
    private readonly int _startCountImage = 4;
    private readonly Queue<Picture> _waitingToBeLoadedPicture = new Queue<Picture>();
    private int _indexImage;
    
    public DownloadingPool(List<Picture> allTemplatesImages, ScrollingHandler scrollingHandler)
    {
        _allTemplatesPictures = allTemplatesImages;
        _scrollingHandler = scrollingHandler;
        _scrollingHandler.NeedImage += PutInDownloadNextImage;
    }

    private void PutInDownloadNextImage()
    {
        if (_indexImage >= _allTemplatesPictures.Count)
            return;
        
        _waitingToBeLoadedPicture.Enqueue(_allTemplatesPictures[_indexImage]);

        StartDownloadImages();
        _indexImage++;
    }

    private async void StartDownloadImages()
    {
        while (_waitingToBeLoadedPicture.Count > 0)
        {
            Picture downloader = _waitingToBeLoadedPicture.Dequeue();
            await downloader.DownloadImage();
            
        }
    }
    
    public void OnDisable()
    {
        _scrollingHandler.NeedImage -= PutInDownloadNextImage;
    }

    public void DownloadFirstImages()
    {
        
        for (int i = 0; i < _startCountImage; i++)
        {
            PutInDownloadNextImage();
        }
    }
}
