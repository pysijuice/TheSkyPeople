using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    //visible parametres
    public int particlesCountPerLoop;
    public float yRange;
    public float zRange;
    public float xRange;
    public float howFarFromPlayer;
    public float timeDelay;
    public List <GameObject> winds = new List<GameObject>();
    public List <GameObject> stars = new List<GameObject>();
    
    private float timeInterval;
    void Start()
    {
        
    }
    void Update()
    {
        timeInterval+=Time.deltaTime;
        
        if (timeInterval >= timeDelay)
        {
            timeInterval = 0.0f;
            for (int i = 0; i < particlesCountPerLoop; i++){
                float randomPosY = Random.Range(0,yRange);
                float randomPosZ = Random.Range(transform.position.z-zRange,transform.position.z+zRange);
                float randomPosX = Random.Range(0,xRange);
                GameObject randomWind = winds[Random.Range(0,winds.Count)];
                // GameObject randomWind = winds[1];
                GameObject windObj = Instantiate(randomWind, new Vector3(transform.position.x-howFarFromPlayer-randomPosX,randomPosY, randomPosZ), new Quaternion(0,0,0,0));
                ParticleSystem windTest = windObj.GetComponent<ParticleSystem>();
                float totalDuration = windTest.duration + windTest.startLifetime;
                Destroy(windObj,totalDuration);
            }
        }
        
    }
}
