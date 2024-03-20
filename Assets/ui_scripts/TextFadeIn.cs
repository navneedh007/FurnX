using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TextFadeIn : MonoBehaviour
{
    public List<TextMeshProUGUI> textElements = new List<TextMeshProUGUI>();
    public List<Image> imageElements = new List<Image>();
    public List<Button> buttonElements = new List<Button>();
    public Button startButton;
    public float fadeInDuration = 1.0f;
    public float startDelay = 2.0f;

    private bool isAnimating = false;

    private void Start()
    {
        // Hide all UI elements initially
        foreach (var textElement in textElements)
        {
            textElement.alpha = 0;
        }

        foreach (var imageElement in imageElements)
        {
            Color color = imageElement.color;
            color.a = 0;
            imageElement.color = color;
        }

        foreach (var button in buttonElements)
        {
            Color buttonColor = button.image.color;
            buttonColor.a = 0;
            button.image.color = buttonColor;
        }

        // Attach the button click event
        startButton.onClick.AddListener(StartFadeIn);
    }

    private void StartFadeIn()
    {
        if (!isAnimating)
        {
            StartCoroutine(FadeInUIElements());
        }
    }

    private IEnumerator FadeInUIElements()
    {
        isAnimating = true;

        yield return new WaitForSeconds(startDelay);

        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float t = elapsedTime / fadeInDuration;

            // Fade in the Text elements
            foreach (var textElement in textElements)
            {
                textElement.alpha = Mathf.Lerp(0, 1, t);
            }

            // Fade in the Image elements
            foreach (var imageElement in imageElements)
            {
                Color color = imageElement.color;
                color.a = Mathf.Lerp(0, 1, t);
                imageElement.color = color;
            }

            // Fade in the Button images
            foreach (var button in buttonElements)
            {
                Color buttonColor = button.image.color;
                buttonColor.a = Mathf.Lerp(0, 1, t);
                button.image.color = buttonColor;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that all elements are fully faded in
        foreach (var textElement in textElements)
        {
            textElement.alpha = 1;
        }

        foreach (var imageElement in imageElements)
        {
            Color color = imageElement.color;
            color.a = 1;
            imageElement.color = color;
        }

        foreach (var button in buttonElements)
        {
            Color buttonColor = button.image.color;
            buttonColor.a = 1;
            button.image.color = buttonColor;
        }

        isAnimating = false;
    }
}
