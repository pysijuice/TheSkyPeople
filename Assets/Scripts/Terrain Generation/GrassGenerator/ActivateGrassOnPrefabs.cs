using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGrassOnPrefabs : MonoBehaviour
{
    public GameObject grass;
    void Start()
    {
        grass = transform.Find("Grass").gameObject;
        grass.SetActive(false);
        grass.SetActive(true);
        Mesh grassMesh = grass.GetComponent<MeshFilter>().sharedMesh;
        var col = gameObject.AddComponent<MeshCollider>();
        col.sharedMesh = grassMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
