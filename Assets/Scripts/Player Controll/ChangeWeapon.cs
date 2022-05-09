using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    // 0 - axe, 1 - graplingGun
    [SerializeField] GameObject[] weaponType;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        } else if (Input.GetKeyDown(KeyCode.Z)) // Kostil' dlya ybiraniya orygia
        {
            for (int i = 0; i < weaponType.Length; i++)
            {
                weaponType[i].SetActive(false);
            }
        }
    }

    void SwitchWeapon(int indexWeapon)
    {
        for(int i = 0; i < weaponType.Length; i++)
        {
            if (i != indexWeapon)
            {
                weaponType[i].SetActive(false);
            }
            else
            {
                weaponType[i].SetActive(true);
            }
        }
    }
}

