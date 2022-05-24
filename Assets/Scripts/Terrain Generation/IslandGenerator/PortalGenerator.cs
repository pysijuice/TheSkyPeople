using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGenerator : MonoBehaviour
{
    public GameObject[] islands;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PortalSpawn());
    }

    IEnumerator PortalSpawn()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        islands = GameObject.FindGameObjectsWithTag("Island");
        Debug.Log(islands.Length);

        int number = Random.Range(0, islands.Length);
        Instantiate(portal, islands[number].transform.position, islands[number].transform.rotation);;
        Destroy(islands[number]);
        // Debug.Log(islands[number].transform.position);
    }
}
