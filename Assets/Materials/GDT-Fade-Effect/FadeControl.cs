﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{

    public GameObject fadeEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "EnterArea")
        {
            fadeEffect.SetActive(true);
        }
    }
}
