using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public GameObject plataforma;

    public float minTime = 5f;
    public float maxTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    IEnumerator SpawnCoRoutine(float waitTime){
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }
}
