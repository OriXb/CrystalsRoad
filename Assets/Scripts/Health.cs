using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float shield;
    public bool isEnemy = true;
    public Slider healthBar;
    public UnityEvent onKill;

    public void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }

    }

    void OnCollisionEnter(Collision other)
    { 
        if (other.transform.tag == "Bullet")
        {
            Damage(other.transform.GetComponent<Bullet>().dMG);
            Destroy(other.gameObject);
        }
    }
 
    public void Damage(float dMG)
    {
        health = health - dMG;

        if (healthBar != null)
            healthBar.value = health;   

        if(health <= 0)
        {
            KillMe();
        }
    }

    public void KillMe()
    {
        onKill.Invoke();
    }

    
    
}
