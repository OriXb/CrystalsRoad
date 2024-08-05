using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : Gun
{

    public override void Shoot()
    {

        StartCoroutine(Shoot3());
    }

    IEnumerator Shoot3()
    {
        if (canShoot == true)
        {
            canShoot = false;
            Player.allowShoot = false;
            base.Shoot();
            yield return new WaitForSeconds(0.1f);
            canShoot = true;
            base.Shoot();
            yield return new WaitForSeconds(0.1f);
            canShoot = true;
            base.Shoot();
            Player.allowShoot = true;
            canShoot = true;
        }
    }
}
