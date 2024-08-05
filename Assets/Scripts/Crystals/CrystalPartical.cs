using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPartical : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
        GetComponent<Rigidbody>().velocity += Vector3.up * 4 + Random.insideUnitSphere;
    }
}
