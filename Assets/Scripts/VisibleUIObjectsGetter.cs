using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleUIObjectsGetter : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _containerObjects;

    public List<ImageDownloader> GetVisibleUIObjects()
    {
        List<ImageDownloader> imageDownloaders = new List<ImageDownloader>();

        RectTransform[] allChildren = _containerObjects.GetComponentsInChildren<RectTransform>(true);

        // Iterate through the child objects and check if they are visible
        foreach (RectTransform child in allChildren)
        {
            if (child != null && IsObjectVisible(child, _rectTransform))
            {
                // The UI object is visible, do something with it

                if (child.TryGetComponent(out ImageDownloader imageDownloader))
                {
                    imageDownloaders.Add(imageDownloader);
                }
            }
        }

        return imageDownloaders;
    }

    private bool IsObjectVisible(RectTransform childRect, RectTransform maskRect)
    {
        // Convert the corners of the child object to screen coordinates
        Vector3[] childCorners = new Vector3[4];
        childRect.GetWorldCorners(childCorners);

        // Check if any of the corners are outside the screen boundaries
        for (int i = 0; i < 4; i++)
        {
            Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(null, childCorners[i]);
            if (!RectTransformUtility.RectangleContainsScreenPoint(maskRect, screenPoint))
            {
                return false; // At least one corner is outside the screen boundaries
            }
        }

        return true; // All corners are within the screen boundaries
    }
}
