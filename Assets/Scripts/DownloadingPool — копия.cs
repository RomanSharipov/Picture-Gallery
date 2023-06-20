using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadingPoolCopy : MonoBehaviour
{
    [SerializeField] private Queue<ImageDownloader> _waitingToBeLoadedImages = new Queue<ImageDownloader>();

    [SerializeField] private List<ImageDownloader> _allImages;

    int index;
    
    public void Init(List<ImageDownloader> allImages)
    {
        _allImages = allImages;
    }

    public void AddToQueue(ImageDownloader imageDownloader)
    {
        if (_waitingToBeLoadedImages.Contains(imageDownloader))
            return;

        _waitingToBeLoadedImages.Enqueue(imageDownloader);

        StartCoroutine(StartDownloadImages());
    }

    private IEnumerator StartDownloadImages()
    {
        for (int i = 0; i < _waitingToBeLoadedImages.Count; i++)
        {
            yield return _waitingToBeLoadedImages.Dequeue().DownloadImageJob();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            AddToQueue(_allImages[index]);
            index++;
        }
    }
}
