using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect ;
    [SerializeField] private SpawnerTemplates _spawnerTemplates;
    [SerializeField] private DownloadingPool _downloadingPool;
    [SerializeField] private ScrollingHandler _scrollingHandler;
    
    private void Start()
    {
        _spawnerTemplates.CreateTemplates();
        _scrollingHandler.Init(_spawnerTemplates.CountImages);
        _downloadingPool.Init(_spawnerTemplates.AllImages.ToList(), _scrollingHandler);
    }
}
