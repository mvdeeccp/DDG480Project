using UnityEngine;
using System.Collections;

public class VerticalVariantSwipe : MonoBehaviour
{
    [Header("Variants")]
    public RectTransform[] variants;

    [Header("Slide Settings")]
    public float slideDistance = 1000f;

    public float slideSpeed = 10f;

    private int currentIndex = 0;

    private bool isAnimating = false;

    void Start()
    {
        SetupVariants();
    }

    // =========================
    // NEXT
    // =========================

    public void NextVariant()
    {
        if (isAnimating) return;

        int nextIndex = currentIndex + 1;

        if (nextIndex >= variants.Length)
        {
            nextIndex = 0;
        }

        StartCoroutine(
            SlideVariant(currentIndex, nextIndex, true)
        );

        currentIndex = nextIndex;
    }

    // =========================
    // PREVIOUS
    // =========================

    public void PreviousVariant()
    {
        if (isAnimating) return;

        int nextIndex = currentIndex - 1;

        if (nextIndex < 0)
        {
            nextIndex = variants.Length - 1;
        }

        StartCoroutine(
            SlideVariant(currentIndex, nextIndex, false)
        );

        currentIndex = nextIndex;
    }

    // =========================
    // SLIDE ANIMATION
    // =========================

    IEnumerator SlideVariant(
        int oldIndex,
        int newIndex,
        bool moveUp)
    {
        isAnimating = true;

        RectTransform oldVariant =
            variants[oldIndex];

        RectTransform newVariant =
            variants[newIndex];

        Vector2 oldStart =
            Vector2.zero;

        Vector2 oldEnd =
            moveUp ?
            new Vector2(0, slideDistance) :
            new Vector2(0, -slideDistance);

        Vector2 newStart =
            moveUp ?
            new Vector2(0, -slideDistance) :
            new Vector2(0, slideDistance);

        Vector2 newEnd =
            Vector2.zero;

        newVariant.gameObject.SetActive(true);

        oldVariant.anchoredPosition = oldStart;
        newVariant.anchoredPosition = newStart;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * slideSpeed;

            oldVariant.anchoredPosition =
                Vector2.Lerp(oldStart, oldEnd, t);

            newVariant.anchoredPosition =
                Vector2.Lerp(newStart, newEnd, t);

            yield return null;
        }

        oldVariant.gameObject.SetActive(false);

        isAnimating = false;
    }

    // =========================
    // START SETUP
    // =========================

    void SetupVariants()
    {
        for (int i = 0; i < variants.Length; i++)
        {
            variants[i].gameObject.SetActive(false);

            variants[i].anchoredPosition =
                Vector2.zero;
        }

        variants[currentIndex]
            .gameObject.SetActive(true);
    }
}