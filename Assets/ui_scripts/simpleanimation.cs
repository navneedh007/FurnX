using UnityEngine;
using TMPro;

public class ImageUIAnimator : MonoBehaviour
{
    public RectTransform imageElement; // Assign this in the Inspector
    public float animationDuration = 1.0f;
    public float upPositionY = 400.0f; // The Y position when moving up
    public float downPositionY = -400.0f; // The Y position when moving down

    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = imageElement.anchoredPosition;
    }

    public void MoveUp()
    {
        LeanTween.moveY(imageElement, upPositionY, animationDuration).setEase(LeanTweenType.easeOutQuad);
    }

    public void MoveDown()
    {
        LeanTween.moveY(imageElement, downPositionY, animationDuration).setEase(LeanTweenType.easeOutQuad);
    }

    public void ResetPosition()
    {
        LeanTween.move(imageElement, originalPosition, animationDuration).setEase(LeanTweenType.easeOutQuad);
    }
}
