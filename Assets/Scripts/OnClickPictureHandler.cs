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

    private void OnClick(Texture texture)
    {
        TextureData.texture = texture;
        SceneLoader.Instance.LoadScene(SceneConstants.FullScreenView, 0.5f);
    }

    public void OnDisable()
    {
        _picture.Clicked -= OnClick;
    }
}
