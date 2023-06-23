using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private ProgressView _progressView;

    public static SceneLoader Instance;
    private float _timeBeforeNextScene = 2.0f;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(SceneConstants.Menu);
    }
    
    public void LoadScene(string name)
    {
        _progressView.FillForSeconds(_timeBeforeNextScene);
        SceneManager.LoadScene(name);
    }
}
