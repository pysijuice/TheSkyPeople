using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShipSync : MonoBehaviourPunCallbacks
{
    private PhotonView photonView;
    // Start is called before the first frame update

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
 

    // Update is called once per frame
    void Update()
    {
        
    }
}
