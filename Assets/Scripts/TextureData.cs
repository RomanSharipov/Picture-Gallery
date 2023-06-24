using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextureData : MonoBehaviour
{
    [SerializeField] private Texture[] _textures;
    
    public Picture current—lickedPicture;
    
    public static TextureData Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(SceneConstants.Menu);
        _textures = new Texture[66];
    }
    
    public void AddTexture(Texture texture,int index)
    {
        _textures[index] = texture;
    }
    
    public Texture GetTexture(int index)
    {
        return _textures[index];
    }

}
