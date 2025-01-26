using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;

public class CatAttack : MonoBehaviour
{
    public GameObject objectToSpawn;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public float minTime = 2f;
    public float maxTime = 5f;

    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            Transform selectedSpawnPoint = Random.Range(0, 2) == 0 ? spawnPoint1 : spawnPoint2;

            Instantiate(objectToSpawn, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

            GameObject spawnedObject = Instantiate(objectToSpawn, selectedSpawnPoint.position, selectedSpawnPoint.rotation);

            StartCoroutine(DestroyObjectAfterTime(spawnedObject, 2f));
        }
    }

    private IEnumerator DestroyObjectAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}
