using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnemyBullet;
    public float dMG = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Shootable")
        { 
            Destroy(this.gameObject);
        }
    }
}
