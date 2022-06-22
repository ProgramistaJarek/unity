using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 5f;

    public int healthStart;

    public int moneyGained;

    private float health;

    private Transform target;

    private int wavepointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        target = Waypoints.waypoints[0];
        health = healthStart;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / healthStart;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += moneyGained;
        WaveSpawner.EnemyAlive--;
        Destroy (gameObject);
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform
            .Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndWaypoint();
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndWaypoint()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemyAlive--;
        Destroy (gameObject);
    }
}
