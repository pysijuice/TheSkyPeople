using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    // 0 - axe, 1 - graplingGun, 2 - hammer
    [SerializeField] GameObject[] weaponType;
    [SerializeField] private Image Weapon1;
    [SerializeField] private Image Weapon2;
    [SerializeField] private Image Weapon3;
    [SerializeField] private Image Weapon4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);

        }
        else if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            SwitchWeapon(2);

        }
        else if ((Input.GetKeyDown(KeyCode.Alpha4)))
        {
            SwitchWeapon(3);

        }else if (Input.GetKeyDown(KeyCode.Z)) // Kostil' dlya ybiraniya orygia
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

