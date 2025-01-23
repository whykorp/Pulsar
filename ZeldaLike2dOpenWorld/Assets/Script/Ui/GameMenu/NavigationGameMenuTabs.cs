using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NavigationGameMenuTabs : MonoBehaviour
{
    public GameObject[] tabs;
    public Button[] tabButtons;
    private int currentTabIndex = 0;

    void Start()
    {
        ShowTab(currentTabIndex);

        for (int i = 0; i < tabButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            tabButtons[i].onClick.AddListener(() => OnTabButtonClicked(index));
        }
    }

    void NavigateToNextTab()
    {
        currentTabIndex = (currentTabIndex + 1) % tabs.Length;
        ShowTab(currentTabIndex);
    }

    void NavigateToPreviousTab()
    {
        currentTabIndex = (currentTabIndex - 1 + tabs.Length) % tabs.Length;
        ShowTab(currentTabIndex);
    }

    void ShowTab(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive(i == tabIndex);
        }
    }

    public void OnTabButtonClicked(int tabIndex)
    {
        currentTabIndex = tabIndex;
        ShowTab(currentTabIndex);
    }
}
