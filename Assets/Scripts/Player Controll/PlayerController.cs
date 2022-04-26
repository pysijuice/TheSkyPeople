using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    PhotonView view;

    public GameObject Camera;

    public PlayerController scriptPlayerController;
    public PlayerMovement scriptPlayerMovement;
    public MouseLook scriptMouseLook;

    private void Awake()
    {
        view = GetComponent<PhotonView>();

        if (!view.IsMine)
        {
            Camera.SetActive(false);
            scriptPlayerMovement.enabled = false;
            scriptMouseLook.enabled = false;
            scriptPlayerController.enabled = false;
        }
    }
}
