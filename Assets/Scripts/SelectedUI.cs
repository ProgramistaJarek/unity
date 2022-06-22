using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUI : MonoBehaviour
{
    public GameObject ui;

    [Header("Unity stuff")]
    public Text upgradeCost;

    public Text sellCost;

    private TileMap target;

    public void SetTarget(TileMap t)
    {
        target = t;
        transform.position = target.GetBuildPosition();
        if (target.i == target.turretShop.upgrade.Length)
        {
            upgradeCost.text = "Done";
            sellCost.text = "$" + target.turretShop.GetSellCost(target.i);
        }
        else
        {
            upgradeCost.text =
                "$" + target.turretShop.upgrade[target.i].upgradeCost;
            sellCost.text = "$" + target.turretShop.GetSellCost(target.i);
        }
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectTileMap();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectTileMap();
    }
}
