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
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(SceneConstants.Menu);
    }
    public void LoadScene(string name,float timeFakeLoading)
    {
        _progressView.FillForSeconds(timeFakeLoading);
        SceneManager.LoadScene(name);
    }
}
