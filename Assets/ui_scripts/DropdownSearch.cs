using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class DropdownController : MonoBehaviour
{
    public TMP_InputField searchInput;
    public TMP_Dropdown dropdown;
    public int maxSuggestions = 5;

    // Public field for your dropdown options list in the Inspector.
    public List<string> allOptions = new List<string> { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6", "Option 7" };

    private List<string> filteredOptions;

    private void Start()
    {
        // Attach a listener to your search input field.
        searchInput.onValueChanged.AddListener(FilterDropdown);

        // Attach a listener to the dropdown's onValueChanged event.
        dropdown.onValueChanged.AddListener(SelectDropdownOption);

        // Initialize the filtered options.
        filteredOptions = allOptions;

        // Update the dropdown options initially.
        UpdateDropdownOptions();
    }

    void FilterDropdown(string searchText)
    {
        // Filter options based on the search text.
        filteredOptions = allOptions.FindAll(option => option.ToLower().Contains(searchText.ToLower())).Take(maxSuggestions).ToList();

        // Update the dropdown options.
        UpdateDropdownOptions();

        // Show or hide the dropdown based on whether there are filtered options.
        if (filteredOptions.Count > 0)
        {
            dropdown.Show();
        }
        else
        {
            dropdown.Hide();
        }
    }

    void UpdateDropdownOptions()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(filteredOptions);
    }

    void SelectDropdownOption(int selectedIndex)
    {
        // Get the selected option from the dropdown and set it as the input field's text.
        if (selectedIndex >= 0 && selectedIndex < filteredOptions.Count)
        {
            searchInput.text = filteredOptions[selectedIndex];
        }
    }
}

