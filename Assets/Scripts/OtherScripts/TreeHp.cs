using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHp : MonoBehaviour
{
    public float treeHp;
    [SerializeField] GameObject[] SpawnWoods;

    void Update()
    {
        if (treeHp <= 0)
        {
            for(int i = 0; i< SpawnWoods.Length; i++)
            {
                //this vector is changing position of woods when player destroying tree
                Vector3 vector = new Vector3(transform.position.x, transform.position.y + (SpawnWoods[i].transform.localScale.y + i + i), transform.position.z);
                GameObject newWood = Instantiate(SpawnWoods[i], vector, Quaternion.identity);
                newWood.name = "WoodLog";
            }
            Destroy(this.gameObject);
        }
    }
}
