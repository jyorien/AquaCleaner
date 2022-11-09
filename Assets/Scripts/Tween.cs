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
        LeanTween.moveY(Waves, 2.6f, 4f).setOnComplete(() =>
        {
            if (!isEnd)
            {
                Debug.Log(isEnd);
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
        Debug.Log($"total waste: {totalNumberOfWaste}");
        for (int i = 0; i < 5; i++)
        {
            float spawnPositionX = Random.Range(LowerBound.position.x, UpperBound.position.x);
            float spawnPositionY = Random.Range(LowerBound.position.y, UpperBound.position.y);
            int trashIndex = Random.Range(0, WastePrefabs.Length);
            Vector3 position = new Vector3(spawnPositionX, spawnPositionY);
            GameObject gameObject = Instantiate(WastePrefabs[trashIndex], position, Quaternion.identity);
        }
    }
}
