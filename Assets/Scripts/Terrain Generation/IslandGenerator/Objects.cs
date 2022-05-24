using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{   
    
    private IEnumerator coroutine;
    public GameObject[] islandPrefabs;
    GameObject island;
    void Start()
    {
        coroutine = checkCollide(0.5f);
        StartCoroutine(coroutine);
    }
    IEnumerator checkCollide(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // float objectY = Random.Range(50,99);
        float coordY = Random.Range(30,450);
        transform.position = new Vector3(transform.position.x, coordY, transform.position.z);
        RaycastHit hit;
        // if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity) && !(Physics.Raycast(transform.position, -Vector3.up, out hit, 48.0f))
        // && !(Physics.Raycast(transform.position, -Vector3.right, out hit, 80.0f)) && !(Physics.Raycast(transform.position, Vector3.right, out hit, 80.0f))
        // &&  !(Physics.Raycast(transform.position, -Vector3.forward, out hit, 80.0f)) &&  !(Physics.Raycast(transform.position, Vector3.forward, out hit, 80.0f)))
        if (Random.Range(0,12) == 1 && Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity) && !(Physics.Raycast(transform.position, -Vector3.up, out hit, 50.0f))
        && !(Physics.Raycast(transform.position, -Vector3.right, out hit, 100.0f)) && !(Physics.Raycast(transform.position, Vector3.right, out hit, 100.0f))
        &&  !(Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f)) &&  !(Physics.Raycast(transform.position, Vector3.forward, out hit, 100.0f)))
        {
            // int spawnChance = Random.Range(0,8);
            // if (spawnChance==1){
            int rad = Random.Range(0,islandPrefabs.Length); 
            float rotateY = Random.Range(0,360);
            Quaternion rotation = Quaternion.Euler(0,rotateY,0);

            island = GameObject.Instantiate(islandPrefabs[rad],transform.position, rotation);
            // island.transform.parent = gameObject.transform.parent;
            // }
            Destroy(transform.gameObject);


            
            // Debug.Log("Did Hit " + transform.position);
        }
		else{
            Destroy(transform.gameObject);
			// Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.red,100);
			// Debug.Log("Didnt Hit " + transform.position);
		}

    }
}
