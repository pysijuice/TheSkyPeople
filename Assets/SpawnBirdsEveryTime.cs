using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirdsEveryTime : MonoBehaviour
{

    [SerializeField] private GameObject SpawnerBirds;

    [SerializeField] private float timeSpawnBirds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBirds());
    }

    IEnumerator SpawnBirds()
    {
        while (true)
        {
            Instantiate(SpawnerBirds, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeSpawnBirds);
        }
        
    }
}
