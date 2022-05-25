using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewHedhedogToBoid : MonoBehaviour
{
    private HedheBoid hedhedog;
    private HedheBoidManager hedheManager;
    public void newHedhedog()
    {
        hedheManager = FindObjectOfType<HedheBoidManager>();
        hedhedog = GetComponent<HedheBoid>();
        hedheManager.addHedhedog(hedhedog);
    }

    
}
