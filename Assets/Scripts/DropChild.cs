using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChild : MonoBehaviour
{
    public void Drop()
    {
        transform.GetChild(0).GetComponent<CrystalItem>().pickable = true;
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).SetParent(null);
    }
}
