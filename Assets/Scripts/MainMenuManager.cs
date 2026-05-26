using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;

    public GameObject playPanel;
    public GameObject optionPanel;
    public GameObject creditPanel;
    public GameObject quitPanel;

    void Start()
    {
        ShowMainMenu();
    }

    void CloseAllPanels()
    {
        mainMenuPanel.SetActive(false);

        playPanel.SetActive(false);
        optionPanel.SetActive(false);
        creditPanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    public void ShowMainMenu()
    {
        CloseAllPanels();

        mainMenuPanel.SetActive(true);
    }

    public void OpenPlayPanel()
    {
        CloseAllPanels();

        playPanel.SetActive(true);
    }

    public void OpenOptionPanel()
    {
        CloseAllPanels();

        optionPanel.SetActive(true);
    }

    public void OpenCreditPanel()
    {
        CloseAllPanels();

        creditPanel.SetActive(true);
    }

    public void OpenQuitPanel()
    {
        CloseAllPanels();

        quitPanel.SetActive(true);
    }

    // CONFIRM EXIT
    public void ConfirmExit()
    {
        Application.Quit();

        Debug.Log("Game Closed");
    }

    // CANCEL EXIT
    public void CancelExit()
    {
        ShowMainMenu();
    }
}