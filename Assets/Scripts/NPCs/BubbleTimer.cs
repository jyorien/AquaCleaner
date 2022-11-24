using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTimer : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        StartCoroutine(ShowBubbleInIntervals());
    }

    IEnumerator ShowBubbleInIntervals()
    {
        float spawnInterval = Random.Range(2f, 5f);
        float showInterval = Random.Range(2f, 4f);
        Debug.Log($"{gameObject.name} Spawn Interval: {spawnInterval}, Show Interval: {showInterval}");
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(showInterval);
            spriteRenderer.enabled = false;

        }
    }
}
