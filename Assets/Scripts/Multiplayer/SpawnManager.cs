using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Spawns;

    public GameObject Player;

    private void Awake()
    {
        Vector3 randomPosition = Spawns[Random.Range(0, Spawns.Length)].transform.position;

        PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
    }
}
