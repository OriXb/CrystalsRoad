using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCrystal : Crystal
{
    public GameObject wallPlace;
    public GameObject wallPre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject wall = Instantiate(wallPre.gameObject, wallPlace.transform.position, wallPlace.transform.rotation);
            GameObject go = Instantiate(crystalPre.gameObject, crystalHold.transform.position, crystalHold.transform.rotation);
            go.GetComponent<Rigidbody>().isKinematic = false;
            Transform[] childrens = go.transform.GetComponentsInChildren<Transform>();
            Destroy(crystalHold);
            for (int i = 0; i < childrens.Length; i++)
            {
                go.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                go.transform.GetChild(i).SetParent(null);
            }
            
        }
    }

}
