using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour

{

    [SerializeField] GameObject[] trashPrefabs;
    [SerializeField] Transform lowerBound, upperBound;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTrash()
    {
        while (true)
        {
            // random spawn interval and number of objects spawned at the time at different positions 
            float spawnInterval = Random.Range(0.1f, 5f);
            int numberOfObjects = Random.Range(1, 3);
            for (int i = 0; i < numberOfObjects; i++)
            {
                float spawnPositionX = Random.Range(lowerBound.position.x, upperBound.position.x);
                int trashIndex = Random.Range(0, trashPrefabs.Length);
                Vector3 position = new Vector3(spawnPositionX, lowerBound.position.y);
                GameObject gameObject = Instantiate(trashPrefabs[trashIndex], position, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);

        
        }
    }
}
