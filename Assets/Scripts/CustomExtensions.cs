using UnityEngine;

public static class CustomExtensions 
{
    public static int NormalizeValue(this float ratio, int maxCount)
    {
        float floatValue = maxCount * (1 - ratio);

        return Mathf.RoundToInt(floatValue);
    }
}
