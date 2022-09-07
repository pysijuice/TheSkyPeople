using UnityEngine;


public class ArenaSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] spawnMobCollection;
    [SerializeField] GameObject[] spawnMobTypeCollection;


    void Awake()
    {
        int rnd = Random.Range(0, 8);
        for (int i = 0; i <= rnd; i++)
        {
            spawnMobCollection[i].SetActive(false);
        }

    }

    public void SpawnMobs()
    {
        for (int i = 0; i <= spawnMobCollection.Length; i++)
        {
            if (spawnMobCollection[i].activeSelf)
            {
                int rnd = Random.Range(0, spawnMobTypeCollection.Length);
                Instantiate(spawnMobTypeCollection[rnd], spawnMobCollection[i].transform.position, Quaternion.identity);
            }

        }
    }
}
