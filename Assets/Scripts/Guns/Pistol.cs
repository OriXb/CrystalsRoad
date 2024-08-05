using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Rigidbody ammoPrefab;
    public GameObject shootingPoint;
    public float shootingPower = 20;

    public void Shoot()
    {
        GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint.transform.position, transform.rotation);
        go.name = "Bullet";
        go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
        Destroy(go, 10f);
    }

    public void Update()
    {

    }
}
