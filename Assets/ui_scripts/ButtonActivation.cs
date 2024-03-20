using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour
{
    public Button activateButton; // The button to be activated
    public Button triggerButton; // The button to trigger activation

    private void Start()
    {
        // Disable the activateButton initially
        activateButton.interactable = false;

        // Attach the triggerButton click event
        triggerButton.onClick.AddListener(ActivateButton);
    }

    private void ActivateButton()
    {
        // Enable the activateButton when the triggerButton is pressed
        activateButton.interactable = true;
    }
}
