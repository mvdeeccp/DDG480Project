using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBindingUI : MonoBehaviour
{
    [System.Serializable]
    public class KeyBindData
    {
        public string actionName;

        public TextMeshProUGUI keyText;

        [Header("Default Key")]
        public KeyCode defaultKey;

        [HideInInspector]
        public KeyCode currentKey;
    }

    [Header("Key Bindings")]
    public KeyBindData[] keyBindings;

    private int currentBindingIndex = -1;

    void Start()
    {
       
        for (int i = 0; i < keyBindings.Length; i++)
        {
            keyBindings[i].currentKey =
                keyBindings[i].defaultKey;

            keyBindings[i].keyText.text =
                keyBindings[i].defaultKey.ToString();
        }
    }

    void Update()
    {
        if (currentBindingIndex == -1)
            return;

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                SetKey(key);
                break;
            }
        }
    }

   
    public void StartRebind(int bindingIndex)
    {
        currentBindingIndex = bindingIndex;

        keyBindings[bindingIndex]
            .keyText.text = "...";
    }

    void SetKey(KeyCode newKey)
    {
        keyBindings[currentBindingIndex]
            .currentKey = newKey;

        keyBindings[currentBindingIndex]
            .keyText.text = newKey.ToString();

        currentBindingIndex = -1;
    }
}