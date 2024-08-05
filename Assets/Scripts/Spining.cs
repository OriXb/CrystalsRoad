using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spining : MonoBehaviour
{

    public float rotationSpeed = 50f; // variable speed of rotation

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its y-axis by the rotation speed
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
