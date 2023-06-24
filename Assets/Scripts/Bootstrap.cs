using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SpawnerTemplates _spawnerTemplates;
    [SerializeField] private ScrollingHandler _scrollingHandler;

    private DownloadingPool _downloadingPool;
    
    private void Start()
    {
        _spawnerTemplates.CreateTemplates();
        _spawnerTemplates.TryGetTexturesFromTextureData();
        _scrollingHandler.Init(_spawnerTemplates.CountImages);
        _downloadingPool = new DownloadingPool(_spawnerTemplates.AllImages.ToList(), _scrollingHandler);
        _downloadingPool.DownloadFirstImages();
        
    }

    private void OnDisable()
    {
        _downloadingPool.OnDisable();
    }
}
