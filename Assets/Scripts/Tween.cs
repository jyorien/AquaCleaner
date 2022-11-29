using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    [SerializeField] Transform LowerBound;
    [SerializeField] Transform UpperBound;
    [SerializeField] GameObject Waves;
    [SerializeField] GameObject[] WastePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        bool isEnd = false;
        LeanTween.moveY(Waves, 2.6f, 3f).setOnComplete(() =>
        {
            if (!isEnd)
            {
                GenerateWaste();
            }
            isEnd = !isEnd;

        }).setLoopPingPong().setOnCompleteOnRepeat(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateWaste()
    {
        int totalNumberOfWaste = 0;
        GameObject[] totalEWaste = GameObject.FindGameObjectsWithTag("EWaste");
        GameObject[] totalTrash = GameObject.FindGameObjectsWithTag("Trash");
        GameObject[] totalRecyclable = GameObject.FindGameObjectsWithTag("Recyclable");
        totalNumberOfWaste = totalEWaste.Length + totalTrash.Length + totalRecyclable.Length;
        if (totalNumberOfWaste > 8) return;
        int numberOfTrashToSpawn = Random.Range(2, 5);
        for (int i = 0; i < numberOfTrashToSpawn; i++)
        {
            float spawnPositionX = Random.Range(LowerBound.position.x, UpperBound.position.x);
            float spawnPositionY = Random.Range(LowerBound.position.y, UpperBound.position.y);
            int trashIndex = Random.Range(0, WastePrefabs.Length);
            Vector3 position = new Vector3(spawnPositionX, spawnPositionY);
            float fadeTime = Random.Range(0.1f, 1.0f);
            GameObject newTrash = Instantiate(WastePrefabs[trashIndex], position, Quaternion.identity);
            newTrash.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            float trashMoveForwardDistance = Random.Range(-0.3f, -0.1f);
            float trashMoveForwardTime = Random.Range(0.5f, 0.8f);
            LeanTween.alpha(newTrash, 1f, fadeTime);
            LeanTween.moveY(newTrash, trashMoveForwardDistance, trashMoveForwardTime);
        }
    }
}
