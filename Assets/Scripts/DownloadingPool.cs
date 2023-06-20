using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DownloadingPool : MonoBehaviour
{
    [SerializeField] private Queue<ImageDownloader> _waitingToBeLoadedImages = new Queue<ImageDownloader>();

    [SerializeField] private List<ImageDownloader> _allImages;

    int _indexImage;
    
    public void Init(List<ImageDownloader> allImages)
    {
        _allImages = allImages;
    }

    public void AddToQueue()
    {
        if (_indexImage >= _allImages.Count)
            return;

        _waitingToBeLoadedImages.Enqueue(_allImages[_indexImage]);

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

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        AddToQueue(_allImages[index]);
    //        index++;
    //    }
    //}
}
