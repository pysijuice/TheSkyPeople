using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    [Header("Draw delay NavMesh")]
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartNavMesh());
    }

    IEnumerator StartNavMesh()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}

