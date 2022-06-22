using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Header("Turrets")]
    public GameObject archerTurretPrefab;

    public GameObject wizardTurretPrefab;

    [Header("UI to show when click")]
    public SelectedUI selectedUI;

    [Header("Unity effects")]
    public GameObject buildEffect;

    public GameObject sellEffect;

    public GameObject buildEffectUpgrade;

    private TurretShop turretToBuild;

    private TileMap selectedTile;

    void Awake()
    {
        instance = this;
    }

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public void SelectedTile(TileMap tileMap)
    {
        if (selectedTile == tileMap)
        {
            DeselectTileMap();
            return;
        }

        selectedTile = tileMap;
        turretToBuild = null;
        selectedUI.SetTarget (tileMap);
    }

    public void DeselectTileMap()
    {
        selectedTile = null;
        selectedUI.Hide();
    }

    public void SelectTurretToBuild(TurretShop turret)
    {
        turretToBuild = turret;
        DeselectTileMap();
    }

    public TurretShop GetTurretToBuild()
    {
        return turretToBuild;
    }
}
