using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayCastInteraction : MonoBehaviour
{
    private float maxDistance = 8f;
    public TMP_Text pressFText;


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                pressFText.gameObject.SetActive(true);

            }
            else
            {
                pressFText.gameObject.SetActive(false);
            }
            

        }
        else if(hit.transform == null || hit.collider.gameObject.GetComponent<Interactable>() == null)
        {
            pressFText.gameObject.SetActive(false);

        }
    }
}
