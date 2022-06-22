using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public float range = 2f;

    public float fireRate = 1f;

    private float fireCountDown = 0;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    private Transform partToRotate;

    public GameObject arrowPrefab;

    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy =
                Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortesDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null) return;

        //tutaj pokombinowac z rotacja strzal
        Vector2 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector2 rotation = lookRotation.eulerAngles;

        //partToRotate.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullets =
            (GameObject)
            Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Shot bullet = bullets.GetComponent<Shot>();
        if (bullet != null)
        {
            bullet.Look (target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
