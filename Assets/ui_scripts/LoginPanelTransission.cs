using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanelTransission : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Button transitionButton;
    public float transitionDuration = 1.0f;

    public Image fadeOutImage; // Reference to the image to fade out
    public float fadeOutDuration = 0.5f; // Duration of the fade out effect

    private bool isTransitioning = false;

    private void Start()
    {
        transitionButton.onClick.AddListener(TransitionPanels);
    }

    private void TransitionPanels()
    {
        if (!isTransitioning)
        {
            StartCoroutine(TransitionCoroutine());
        }
    }

    private IEnumerator TransitionCoroutine()
    {
        isTransitioning = true;

        float elapsedTime = 0f;

        // Disable the CanvasGroup on panel2 initially
        SetCanvasGroupInteractable(panel2, false);

        // Calculate the starting alpha of the fade-out image
        float startAlpha = fadeOutImage.color.a;

        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;

            // Calculate alpha values for the panels
            float panel1Alpha = Mathf.Lerp(1.0f, 0.0f, t);
            float panel2Alpha = Mathf.Lerp(0.0f, 1.0f, t);

            // Set the alpha values for the panels
            SetPanelAlpha(panel1, panel1Alpha);
            SetPanelAlpha(panel2, panel2Alpha);

            // Fade out the image
            float fadeOutAlpha = Mathf.Lerp(startAlpha, 0.0f, (elapsedTime / fadeOutDuration));
            Color imageColor = fadeOutImage.color;
            imageColor.a = fadeOutAlpha;
            fadeOutImage.color = imageColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Enable the CanvasGroup on panel2
        SetCanvasGroupInteractable(panel2, true);

        // Ensure that both panels are fully faded in/out

        SetPanelAlpha(panel1, 0.0f);
        SetPanelAlpha(panel2, 1.0f);

        // Hide or set panel1 inactive
        panel1.SetActive(false);

        isTransitioning = false;
    }

    private void SetPanelAlpha(GameObject panel, float alpha)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = panel.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = alpha;
    }

    private void SetCanvasGroupInteractable(GameObject panel, bool interactable)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = interactable;
            canvasGroup.blocksRaycasts = interactable;
        }
    }
}
