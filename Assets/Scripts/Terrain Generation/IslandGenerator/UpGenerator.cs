using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGenerator : MonoBehaviour
{
    public List<GameObject> upSpawn = new List<GameObject>();
    public List<GameObject> upPrefabs = new List<GameObject>();
    public int hillsCount = 1;
    void Start()
    {
        for (int i=0; i<hillsCount; i++){
            int spawnPlace = Random.Range(0, upSpawn.Count);
            GameObject newUp = upSpawn[spawnPlace];
            float rotateY = Random.Range(0,360);
            GameObject hill = Instantiate(upPrefabs[Random.Range(0, upPrefabs.Count)], newUp.transform.position, 
                Quaternion.identity);
            hill.transform.Rotate(0f,rotateY,0f);
            
            hill.transform.parent = gameObject.transform;
            // Instantiate(treePrefabs[Random.Range(0,treePrefabs.Count)], goToSpawn.transform.position, 
            // Quaternion.identity);
            upSpawn.Remove(newUp);
            Destroy(newUp);
        }
        
        for (int i = 0; i < upSpawn.Count; i++){
            GameObject newUp = upSpawn[i];
            Destroy(newUp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
