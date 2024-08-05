using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickaxe : Gun
{
    public Text ammoAmountPick;
    public Animator pickaxe;
    public bool isMining;
    private void Awake()
    {
        ammoAmountPick.text = "";
    }
        public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            pickaxe.SetBool("IsMining", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            pickaxe.SetBool("IsMining", false);
        }
    }
    public override void Shoot()
    {
        
    }
}
