using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Rigidbody ammoPrefab;
    public GameObject shootingPoint1;
    public GameObject shootingPoint2;
    public GameObject shootingPoint3;
    public GameObject shootingPoint4;
    public GameObject shootingPoint5;
    public int random1;
    public int random2;
    public int random3;
    public float shootingPower = 20;

    public void Shoot()
    {
        random1 = Random.Range(1, 6);
        random2 = Random.Range(1, 6);
        random3 = Random.Range(1, 6);

        if (random1 == 1)
        {
            GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint1.transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
            Destroy(go, 10f);
        }
        else if (random1 == 2)
        {
            GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint2.transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
            Destroy(go, 10f);
        }
        else if (random1 == 3)
        {
            GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint3.transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
            Destroy(go, 10f);
        }
        else if (random1 == 4)
        {
            GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint4.transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
            Destroy(go, 10f);
        }
        else if (random1 == 5)
        {
            GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint5.transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
            Destroy(go, 10f);
        }
        //////////////////////////////////////////////////////////////
        
    }

    public void Update()
    {

    }
}
