using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    PhotonView view;

    public GameObject Camera;

    public PlayerController scriptPlayerController;
    public PlayerMovement scriptPlayerMovement;
    public MouseLook scriptMouseLook;

    private float hp = 1;
    public Scrollbar ScrollbarHP;
    public Scrollbar ScrollbarFood;
    public Scrollbar ScrollbarWater;

    private float timeFood = 0;
    private float timeWater = 0;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        ScrollbarFood.gameObject.SetActive(false);
        ScrollbarWater.gameObject.SetActive(false);

        /* if (!view.IsMine)
         {
             Camera.SetActive(false);
             scriptPlayerMovement.enabled = false;
             scriptMouseLook.enabled = false;
             scriptPlayerController.enabled = false;
         }*/
    }
    public void Update()
    {
        Hunger();
        Dehydration();
      
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hp -= 0.2f;

            ScrollbarHP.size = hp;

            if (hp <= 0f)
            {
                Death();
            }
        }
    }*/

    

    /*private void Death()
    {
        Destroy(gameObject);
    }*/

    private void Hunger()
    {
        timeFood += Time.deltaTime / 10000;
        ScrollbarFood.size -= timeFood;

        if (ScrollbarFood.size <= 0.5) {
            ScrollbarFood.gameObject.SetActive(true);
        }else
        {
            ScrollbarWater.gameObject.SetActive(false);
        }
        
    }

    private void Dehydration()
    {
        timeWater += Time.deltaTime / 10000;
        ScrollbarWater.size -= timeWater;
        if (ScrollbarFood.size <= 0.5)
        {
            ScrollbarWater.gameObject.SetActive(true);
        } else
        {
            ScrollbarWater.gameObject.SetActive(false);
        }
    }
}
