using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIElementAnimator : MonoBehaviour
{
    public Vector2 targetSize = new Vector2(200f, 200f);
    public Vector2 targetPosition = new Vector2(100f, 100f);
    public float animationDuration = 0.5f;
    public float elasticIntensity = 0.2f;

    private RectTransform rectTransform;
    private Vector2 originalSize;
    private Vector2 originalPosition;

    private Button button; // Reference to the Button component

    private bool isAnimating = false; // Flag to track whether the animation is in progress

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        originalPosition = rectTransform.anchoredPosition;

        button = GetComponent<Button>(); // Get the Button component
        button.onClick.AddListener(AnimateUIElement);
    }

    public void AnimateUIElement()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateSizeAndPosition());
            isAnimating = true;

            // Remove the click event script component to prevent further clicks
            Destroy(button);
        }
    }

    private IEnumerator AnimateSizeAndPosition()
    {
        float timeElapsed = 0f;

        while (timeElapsed < animationDuration)
        {
            float t = timeElapsed / animationDuration;
            t = 1.0f - Mathf.Pow(1.0f - t, elasticIntensity);

            rectTransform.sizeDelta = Vector2.Lerp(originalSize, targetSize, t);
            rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, targetPosition, t);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        rectTransform.sizeDelta = targetSize;
        rectTransform.anchoredPosition = targetPosition;
    }
}
