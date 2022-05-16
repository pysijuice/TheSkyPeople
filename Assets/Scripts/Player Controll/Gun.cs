using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    public Camera camera;
    private float time;
    [SerializeField] float fireRate;

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && time >= fireRate )
        {
            Shoot();
            time = 0;
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
        
    }
}
