using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenImageInitializer : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;

    private void OnEnable()
    {
        _rawImage.texture = TextureData.Instance.current—lickedPicture.Texture;
    }
}
