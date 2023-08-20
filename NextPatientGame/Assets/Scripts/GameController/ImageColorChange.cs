using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChange : MonoBehaviour
{
    public Image[] images;
    public Color targetColor = Color.red;
    public float colorChangeInterval = 1.0f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(ChangeColors());
    }

    IEnumerator ChangeColors()
    {
        while (currentIndex < images.Length)
        {
            yield return new WaitForSeconds(colorChangeInterval);
            images[currentIndex].color = targetColor;
            // Move to the next image
            currentIndex++;
        }
    }
}
