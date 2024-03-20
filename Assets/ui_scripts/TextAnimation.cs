using System.Collections;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] texts;
    public float characterDelay = 0.05f;

    private int currentIndex = 0;

    private void Start()
    {
        if (texts.Length == 0)
        {
            Debug.LogError("No texts provided. Please assign texts in the Inspector.");
            return;
        }

        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        while (true)
        {
            string targetText = texts[currentIndex];
            currentIndex = (currentIndex + 1) % texts.Length;

            yield return StartCoroutine(TypeText(targetText));
            yield return new WaitForSeconds(2.0f); // Pause between phrases
            yield return StartCoroutine(EraseText(targetText));
        }
    }

    private IEnumerator TypeText(string targetText)
    {
        textMeshPro.text = "";
        for (int i = 0; i < targetText.Length; i++)
        {
            textMeshPro.text += targetText[i];
            yield return new WaitForSeconds(characterDelay);
        }
    }

    private IEnumerator EraseText(string targetText)
    {
        for (int i = targetText.Length; i > 0; i--)
        {
            textMeshPro.text = targetText.Substring(0, i);
            yield return new WaitForSeconds(characterDelay);
        }
    }
}
