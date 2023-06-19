using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image iconImage;
    public Sprite[] icons;

    private int currentIconIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentIconIndex = 0;
            UpdateIcon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentIconIndex = 1;
            UpdateIcon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentIconIndex = 2;
            UpdateIcon();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentIconIndex = 3;
            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        if (currentIconIndex >= 0 && currentIconIndex < icons.Length)
        {
            iconImage.sprite = icons[currentIconIndex];
        }
    }
}