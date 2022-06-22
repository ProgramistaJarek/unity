using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Turrets to buy")]
    public TurretShop archerTurret;

    public TurretShop wizardTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcherTurret()
    {
        buildManager.SelectTurretToBuild (archerTurret);
    }

    public void SelectWizardTurret()
    {
        buildManager.SelectTurretToBuild (wizardTurret);
    }
}
