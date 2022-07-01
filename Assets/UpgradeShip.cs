using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShip : MonoBehaviour
{
    [SerializeField] GameObject[] arrayUpgrades;
    // Update is called once per frame
    public void BackRotorBodyUpgrade()
    {
        arrayUpgrades[0].SetActive(true);
    }
    public void BodyUpgrade()
    {
        if (!arrayUpgrades[2].activeSelf && !arrayUpgrades[3].activeSelf && !arrayUpgrades[1].activeSelf)
        {
            arrayUpgrades[1].SetActive(true);
        }else if (arrayUpgrades[1].activeSelf)
        {
            arrayUpgrades[2].SetActive(true);
            arrayUpgrades[1].SetActive(false);
        }else if (arrayUpgrades[2].activeSelf)
        {
            arrayUpgrades[3].SetActive(true);
            arrayUpgrades[2].SetActive(false);
        }
    }

    public void CanonBodyUpgrade1()
    {
        arrayUpgrades[4].SetActive(true);
    }
    public void CanonBodyUpgrade2And3()
    {
        arrayUpgrades[5].SetActive(true);
        arrayUpgrades[6].SetActive(true);

    }
    public void ShipDownBackWingUpgrade()
    {
        arrayUpgrades[7].SetActive(true);
        arrayUpgrades[8].SetActive(true);
        arrayUpgrades[9].SetActive(true);
        arrayUpgrades[10].SetActive(true);
    }

    public void TaranUpgrade()
    {
        arrayUpgrades[11].SetActive(true);
    }

    public void WingUpgrade()
    {
        arrayUpgrades[12].SetActive(true);
        arrayUpgrades[13].SetActive(true);
    }
}
