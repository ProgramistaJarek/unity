using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float speed = 5f;

    public float range = 0f;

    public int damage = 50;

    [Header("Unity effect")]
    public GameObject shotEffect;

    public void Look(Transform t)
    {
        target = t;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy (gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        if (range > 0f)
        {
            Explode();
        }
        else
        {
            Damage (target);
        }

        Destroy (gameObject);
    }

    void Explode()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        GameObject effect =
            (GameObject)
            Instantiate(shotEffect, enemy.position, Quaternion.identity);
        Destroy(effect, 5f);
        e.TakeDamage (damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
