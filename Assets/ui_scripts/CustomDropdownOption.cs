using UnityEngine;

[System.Serializable]
public class CustomDropdownOption
{
    public string optionText;
    public Sprite optionImage;
    public UnityEngine.Events.UnityEvent onOptionSelected;
}
