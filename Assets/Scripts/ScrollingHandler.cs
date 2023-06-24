using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingHandler : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;

    private int _currentIndexImage;
    private int _countImages;

    public event Action NeedImage;

    public void Init(int countImages)
    {
        _countImages = countImages;
    }

    private void OnEnable()
    {
        _scrollRect.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _scrollRect.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(Vector2 vector2)
    {
        if (_currentIndexImage == vector2.y.NormalizeValue(_countImages))
            return;

        _currentIndexImage = vector2.y.NormalizeValue(_countImages);
        NeedImage?.Invoke();
    }
}
