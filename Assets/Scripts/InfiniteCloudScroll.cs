using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCloudScroll : MonoBehaviour
{
    [System.Serializable]
    public class CloudData
    {
        public RectTransform cloud;

        public float speed = 50f;

     
        public bool moveLeft = true;
    }

    [Header("Clouds")]
    public CloudData[] clouds;

    [Header("Screen Limit")]
    public float leftLimit = -1400f;

    public float rightLimit = 1400f;

    [Header("Reset Offset")]
    public float randomOffsetMin = 200f;
    public float randomOffsetMax = 600f;

    void Update()
    {
        foreach (CloudData data in clouds)
        {
            MoveCloud(data);
        }
    }

    void MoveCloud(CloudData data)
    {
        float direction = data.moveLeft ? -1 : 1;

        data.cloud.anchoredPosition +=
            Vector2.right * direction *
            data.speed * Time.deltaTime;

        
        if (data.moveLeft &&
            data.cloud.anchoredPosition.x < leftLimit)
        {
            float randomOffset =
                Random.Range(randomOffsetMin, randomOffsetMax);

            data.cloud.anchoredPosition =
                new Vector2(
                    rightLimit + randomOffset,
                    data.cloud.anchoredPosition.y
                );
        }

        
        if (!data.moveLeft &&
            data.cloud.anchoredPosition.x > rightLimit)
        {
            float randomOffset =
                Random.Range(randomOffsetMin, randomOffsetMax);

            data.cloud.anchoredPosition =
                new Vector2(
                    leftLimit - randomOffset,
                    data.cloud.anchoredPosition.y
                );
        }
    }
}