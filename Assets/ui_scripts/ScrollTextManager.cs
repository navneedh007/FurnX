using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace.
using TMPro;

public class ScrollTextManager : MonoBehaviour
{
    public TextMeshProUGUI textPrefab; // The TMP Text prefab for the text elements.
    public Transform contentContainer; // Reference to the Content GameObject.

    public void AddText(string newText)
    {
        // Create a new TMP Text element from the prefab.
        TextMeshProUGUI newTextElement = Instantiate(textPrefab, contentContainer);

        // Set the text content of the new element.
        newTextElement.text = newText;

        // Trigger a layout update to adjust the content's size.
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentContainer.GetComponent<RectTransform>());
    }
}
