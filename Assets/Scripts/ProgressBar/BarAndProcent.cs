using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarAndProcent : ProgressView
{
    [SerializeField] private Image _bar;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _background;

    private float _targetFillAmount = 1f;

    public override void ChangeValue(float value)
    {
        _bar.fillAmount = value;
        _text.text = $"{Mathf.RoundToInt(value * 100)}%";
    }

    public override void FillForSeconds(float fillDuration)
    {
        SwitchOnProgressBar();
        FillingProgressBar(fillDuration);
    }

    private async void FillingProgressBar(float fillDuration)
    {
        ChangeValue(0.0f);
        float timer = 0f;
        float initialFillAmount = _bar.fillAmount;

        while (timer < fillDuration)
        {
            timer += Time.deltaTime;
            float fillPercentage = Mathf.Lerp(initialFillAmount, _targetFillAmount, timer / fillDuration);
            ChangeValue(fillPercentage);
            await Task.Yield();
        }
        ChangeValue(_targetFillAmount);
        SwitchOffProgressBar();
    }

    private void SwitchOffProgressBar()
    {
        gameObject.SetActive(false);
        _background.gameObject.SetActive(false);
    }

    private void SwitchOnProgressBar()
    {
        gameObject.SetActive(true);
        _background.gameObject.SetActive(true);
    }
}
