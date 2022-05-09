using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RayCastInteraction : MonoBehaviour
{
    private float maxDistance = 8f;
    [SerializeField] private TMP_Text pressFText;
    [SerializeField] private List<GameObject> gameObjectTypeArray = new();


    private GameObject gameObjectType;
    private bool isPlayerEnter = false;


    private void Start()
    {

    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.GetComponent<Interactable>() != null)
            {

                FText(true);
                TypeOfItem(hit);
                Interaction();
                gameObjectType = null;
            }
            else
            {
                FText(false);
            }
            

        }
        else if(hit.transform == null || hit.collider.gameObject.GetComponent<Interactable>() == null)
        {
            FText(false);

        }
    }

    void FText(bool isActive)
    {
        pressFText.gameObject.SetActive(isActive);
    }

    void TypeOfItem (RaycastHit hit)
    {
        foreach ( GameObject type in gameObjectTypeArray)
        {
            if (hit.collider.gameObject.name == type.name)
            {
                gameObjectType = hit.collider.gameObject;
                Debug.Log(gameObjectType.name);
            }
        }
    }
    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (gameObjectType.name)
            {
                case "Wheel":
                    TakeControll wheel = new TakeControll();
                    wheel.EnterInWheel(isPlayerEnter);
                    isPlayerEnter = !isPlayerEnter;
                    break;
                case "WoodLog":
                    GameObject ship = GameObject.Find("Ship Controller");
                    ship.GetComponent<ResourcesCount>().woodCount += 1;
                    Destroy(gameObjectType);
                    break;
                case "WheelToNewArea":
                    SceneManager.LoadScene("Scene");
                    break;
            }
        }
    }
}


