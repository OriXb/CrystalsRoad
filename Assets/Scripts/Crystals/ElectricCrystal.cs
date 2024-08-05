using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCrystal : Crystal
{
    public AudioSource audioSource;
    public AudioClip electricSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.PlayOneShot(electricSound);

            int index = 0;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Shootable");
            foreach (GameObject enem in enemies)
            {
                if (enem.name != "player")
                {
                    Destroy(enem);
                    index++;
                }
                if (index == 3) { break; }
            }

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
