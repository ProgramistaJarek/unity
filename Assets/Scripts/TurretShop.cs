using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretShop
{
    public GameObject prefab;

    public int cost;

    public TurretDetails[] upgrade;

    public int GetSellCost(int index)
    {
        if (index == 0)
            return cost / 2;
        else
            return upgrade[index - 1].upgradeCost / 2;
    }
}
