using Unity.VisualScripting;
using UnityEngine;

public class OnClickPictureHandler 
{
    private Picture _picture;

    public OnClickPictureHandler(Picture picture)
    {
        _picture = picture;
        _picture.Clicked += OnClick;
    }

    private void OnClick(Picture picture)
    {
        TextureData.Instance.current—lickedPicture = picture;
        SceneLoader.Instance.LoadScene(SceneConstants.FullScreenView, 0.5f);
    }

    public void OnDisable()
    {
        _picture.Clicked -= OnClick;
    }
}
