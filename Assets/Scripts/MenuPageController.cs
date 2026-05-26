using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPageController : MonoBehaviour
{
    [Header("Panel")]
    public GameObject NewsPanel;

    [Header("Open Button")]
    public GameObject openPanelButton;

    [Header("Pages")]
    public GameObject[] pages;

    private int currentPage = 0;

    void Start()
    {
        ShowPage(currentPage);
        openPanelButton.SetActive(false);
    }

    void ShowPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }

        pages[index].SetActive(true);
    }

    public void NextPage()
    {
        currentPage++;

        if (currentPage >= pages.Length)
        {
            currentPage = 0;
        }

        ShowPage(currentPage);
    }

    public void PreviousPage()
    {
        currentPage--;

        if (currentPage < 0)
        {
            currentPage = pages.Length - 1;
        }

        ShowPage(currentPage);
    }

    public void OpenPanel()
    {
       
        NewsPanel.SetActive(true);

      
        openPanelButton.SetActive(false);

        currentPage = 0;
        ShowPage(currentPage);
    }

    public void ClosePanel()
    {
      
        NewsPanel.SetActive(false);

 
        openPanelButton.SetActive(true);
    }
}
