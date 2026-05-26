using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionPageController : MonoBehaviour
{
    [System.Serializable]
    public class SliderData
    {
        public Slider slider;
        public TextMeshProUGUI valueText;
    }

    [Header("Sliders")]
    public SliderData[] sliders;

  

    [System.Serializable]
    public class OptionGroup
    {
        public string groupName;

        public GameObject[] optionImages;

        [HideInInspector]
        public int currentIndex;
    }

    [Header("Option Groups")]
    public OptionGroup[] optionGroups;

    [Header("Sub Panels")]
    public GameObject[] subPanels;

    private int currentPanel = 0;
    public void OpenSubPanel(int panelIndex)
    {

        for (int i = 0; i < subPanels.Length; i++)
        {
            subPanels[i].SetActive(false);
        }


        subPanels[panelIndex].SetActive(true);

        currentPanel = panelIndex;
    }

    void Start()
    {
       
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].slider.minValue = 0;
            sliders[i].slider.maxValue = 100;
            sliders[i].slider.wholeNumbers = true;

            UpdateSliderText(i);
        }


        for (int i = 0; i < optionGroups.Length; i++)
        {
            UpdateOptionGroup(i);
        }

        if (subPanels.Length > 0)
        {
            OpenSubPanel(0);
        }
    }


    public void UpdateSliderText(int index)
    {
        int value = Mathf.RoundToInt(sliders[index].slider.value);

        sliders[index].valueText.text =
            value.ToString() + "%";
    }

    public void NextOption(int groupIndex)
    {
        OptionGroup group = optionGroups[groupIndex];

        group.currentIndex++;

        if (group.currentIndex >= group.optionImages.Length)
        {
            group.currentIndex = 0;
        }

        UpdateOptionGroup(groupIndex);
    }

    public void PreviousOption(int groupIndex)
    {
        OptionGroup group = optionGroups[groupIndex];

        group.currentIndex--;

        if (group.currentIndex < 0)
        {
            group.currentIndex =
                group.optionImages.Length - 1;
        }

        UpdateOptionGroup(groupIndex);
    }

    void UpdateOptionGroup(int groupIndex)
    {
        OptionGroup group = optionGroups[groupIndex];

        for (int i = 0; i < group.optionImages.Length; i++)
        {
            group.optionImages[i].SetActive(false);
        }

        group.optionImages[group.currentIndex]
            .SetActive(true);
    }
}