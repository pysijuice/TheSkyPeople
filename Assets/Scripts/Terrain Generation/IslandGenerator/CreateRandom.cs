using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandom : MonoBehaviour
{
    public float raycastDistance = 500f;
    public List<GameObject> treeSpawn = new List<GameObject>();
    public List<GameObject> treePrefabs = new List<GameObject>();

    private Vector3 scaleChange;
    void Start()
    {   
        // PositionRaycast();

        for (int i = 0; i < treeSpawn.Count; i++){
            GameObject goToSpawn = treeSpawn[i];
            // int randomTree = Random.Range(0,treePrefabs.Count);

            // PositionRaycast(treePrefabs[Random.Range(0,treePrefabs.Count)]);
            PositionRaycast(goToSpawn);
            // Instantiate(treePrefabs[Random.Range(0,treePrefabs.Count)], goToSpawn.transform.position, 
            // Quaternion.identity);
            Destroy(goToSpawn);
        }
    }

    void PositionRaycast(GameObject treeSpawn){
        RaycastHit hit; 
        
        if (Physics.Raycast(treeSpawn.transform.position, Vector3.down, out hit, raycastDistance))
        {
            float randomScale = Random.Range(0.9f, 1.3f);
            scaleChange = new Vector3(randomScale, randomScale, randomScale);
            float rotateY = Random.Range(0,360);
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject tree = Instantiate(treePrefabs[Random.Range(0,treePrefabs.Count)], hit.point,spawnRotation);
            tree.transform.Rotate(0f,rotateY,0f);
            tree.transform.localScale = scaleChange;
            tree.transform.parent = gameObject.transform;
            
        }
    }
}
