using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileMap : MonoBehaviour
{
    public Color hoverColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    public TurretShop turretShop;

    public int i = 0;

    private SpriteRenderer rend;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
        buildManager = BuildManager.instance;
    }

    public Vector2 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (turret != null)
        {
            buildManager.SelectedTile(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretShop useTurret)
    {
        if (PlayerStats.Money < useTurret.cost)
        {
            Debug.Log("Brak hajsu sorka");
            return;
        }

        PlayerStats.Money -= useTurret.cost;

        GameObject t =
            (GameObject)
            Instantiate(useTurret.prefab,
            GetBuildPosition(),
            Quaternion.identity);
        turret = t;

        GameObject effect =
            (GameObject)
            Instantiate(buildManager.buildEffect,
            GetBuildPosition(),
            Quaternion.identity);
        Destroy(effect, 5f);

        turretShop = useTurret;
    }

    public void UpgradeTurret()
    {
        if (i == turretShop.upgrade.Length) return;

        if (PlayerStats.Money < turretShop.upgrade[i].upgradeCost)
        {
            Debug.Log("Brak hajsu na upgrade");
            return;
        }
        PlayerStats.Money -= turretShop.upgrade[i].upgradeCost;
        Destroy (turret);
        GameObject t =
            (GameObject)
            Instantiate(turretShop.upgrade[i].upgradedPrefab,
            GetBuildPosition(),
            Quaternion.identity);
        turret = t;

        i++;
        GameObject effect =
            (GameObject)
            Instantiate(buildManager.buildEffectUpgrade,
            GetBuildPosition(),
            Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void SellTurret()
    {
        GameObject effect =
            (GameObject)
            Instantiate(buildManager.sellEffect,
            GetBuildPosition(),
            Quaternion.identity);
        PlayerStats.Money += turretShop.GetSellCost(i);
        i = 0;
        Destroy(turret, 0.25f);
        Destroy(effect, 5f);
        turretShop = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = startColor;
    }
}
