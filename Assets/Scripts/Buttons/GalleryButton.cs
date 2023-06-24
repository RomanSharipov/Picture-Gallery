using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    [SerializeField] private Button _galleryButton;

    private void OnGalleryButtonClick()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.Gallery,1.5f);
    }

    private void OnEnable()
    {
        _galleryButton.onClick.AddListener(OnGalleryButtonClick);
    }


    private void OnDisable()
    {
        _galleryButton.onClick.RemoveListener(OnGalleryButtonClick);
    }
}
