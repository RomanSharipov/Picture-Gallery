using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    [SerializeField] private Button _galleryButton;

    private void OnGalleryButtonClick()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.Gallery);
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
