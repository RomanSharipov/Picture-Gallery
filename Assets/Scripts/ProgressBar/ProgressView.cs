using UnityEngine;

public abstract class ProgressView : MonoBehaviour
{
    public abstract void ChangeValue(float value);
    public abstract void FillForSeconds(float seconds);
}
