using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(transform.parent.transform.position, transform.parent.transform.forward, out hit, 10))
        {
            if (hit.collider.tag == "Tree")
            {
                hit.collider.gameObject.GetComponent<TreeHp>().treeHp -= 15;
            }
        }
    }
}
