using UnityEngine;

public class NativeBackButtonHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneLoader.Instance.LoadPreviousScene();
        }
    }
}
