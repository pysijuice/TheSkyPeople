using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBase : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            SceneManager.LoadScene("Base");
        }
        
    }
}

