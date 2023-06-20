using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SpawnerTemplates _spawnerTemplates;
    [SerializeField] private ScrollingHandler _scrollingHandler;

    private DownloadingPool _downloadingPool;
    
    private void Start()
    {
        _spawnerTemplates.CreateTemplates();
        _scrollingHandler.Init(_spawnerTemplates.CountImages);
        _downloadingPool = new DownloadingPool(_spawnerTemplates.AllImages.ToList(), _scrollingHandler);
    }

    private void OnDisable()
    {
        _downloadingPool.OnDisable();
    }
}
