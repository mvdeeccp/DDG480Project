using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    [Header("Target")]
    public RectTransform creditObject;

    [Header("Movement")]
    public float scrollSpeed = 100f;

    [Header("Stop Position")]
    public float stopYPosition = 1000f;

    private bool isScrolling = true;

    void Update()
    {
        if (!isScrolling)
            return;

     
        creditObject.anchoredPosition +=
            Vector2.up * scrollSpeed * Time.deltaTime;

      
        if (creditObject.anchoredPosition.y >= stopYPosition)
        {
            creditObject.anchoredPosition =
                new Vector2(
                    creditObject.anchoredPosition.x,
                    stopYPosition
                );

            isScrolling = false;
        }
    }
}
