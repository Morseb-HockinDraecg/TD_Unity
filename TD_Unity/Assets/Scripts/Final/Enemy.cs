using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int maxHealth;
    private float health;
    public string resistType;
    public float resistPercentage;
    public string weakType;
    public float weaknessPercentage;
    public float speed;
    // path ?


    private void Awake (){
        health = maxHealth;
    }

    public void TakeDamage (float damage, string damageType){
        float damageReceived;

        if (damageType == resistType)
            damageReceived = damage * (1 - resistPercentage);
        else if (damageType == weakType)
            damageReceived = damage * (1 + weaknessPercentage);
        else
            damageReceived  = damage;

        health -= damageReceived;
        if (health <= 0 )
            Destroy(gameObject);
    }
    
}
