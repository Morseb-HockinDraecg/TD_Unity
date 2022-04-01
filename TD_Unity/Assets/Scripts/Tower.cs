using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("Unity Setup field")]
    public Transform target;
    public GameObject bulletPrefab;
    public Transform firepoint;

    [Header("Attributes")]

    public float range = 5f;
    public float turnSpeed = 15f;
    public float fireRate = 1f;

    private string enemyTag = "Enemy";
    private float fireCountdown;


    void Start(){
        fireCountdown = 0f;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    void Update(){
        fireCountdown -= Time.deltaTime;
        if (target == null)
            return ;

        UpdateRotation();

        if (fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f/ fireRate;
        }
    }

    void Shoot(){
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    void UpdateRotation(){
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (target)
            Gizmos.DrawLine(transform.position, target.position);
    }
}
