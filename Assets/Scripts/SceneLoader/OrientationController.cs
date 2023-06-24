using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OrientationController : MonoBehaviour
{
    [SerializeField] private Button _galleryButton;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private void OnEnable()
    {
        _galleryButton.onClick.AddListener(ChangeOrientationToPortrait);
    }

    private void OnDisable()
    {
        _galleryButton.onClick.RemoveListener(ChangeOrientationToPortrait);
    }

    private void ChangeOrientationToPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Debug.Log("Portrait");
    }

}
