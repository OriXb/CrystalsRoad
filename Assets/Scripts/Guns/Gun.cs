using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Rigidbody ammoPrefab;
    public GameObject shootingPoint;

    public bool reloadWait = false;
    public int maxAmmos;
    public bool reloading;
    public Text ammoAmount;
    public int shottingPower;
    public float delay;
    public float reload;
    public bool canShoot = true;
    public int ammos;
    public bool isPlayerGun = false;
    Animator animator;
    public bool isAiming = false;
    public string toolID;

    public AudioSource audioSource;
    public AudioClip reloadSound;
    public AudioClip shotSound;

    private void Awake()
    {
        if (isPlayerGun)
        {
            ammoAmount = GameObject.FindGameObjectWithTag("AmmoAmount").GetComponent<Text>();
            ammoAmount.color = Color.yellow;
            ammoAmount.text = "Press E To Reload!";
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void DoDelay()
    {
        canShoot = true;
    }

    private void OnEnable()
    {
        if (ammoAmount != null && isPlayerGun)
        {
            ammoAmount.color = Color.green;
            ammoAmount.text = ammos + "/" + maxAmmos;
        }
        reloadWait = false;
    }

    public void StopShootAnimation()
    {
        if(animator != null) animator.SetBool("IsShooting", false);

    }

    public void ToggleAim()
    {
        isAiming = !isAiming;
        if (animator != null)  animator.SetBool("IsAiming", isAiming);
       
    }

    public virtual void Shoot()
    {
        if (canShoot)
        {
            if (ammos > 0)
            {
                if (animator != null) animator.SetBool("IsShooting", true);
                audioSource.PlayOneShot(shotSound);
                Invoke("StopShootAnimation", 0.1f);
                GameObject go = Instantiate(ammoPrefab.gameObject, shootingPoint.transform.position, transform.rotation);
                go.GetComponent<Bullet>().isEnemyBullet = !isPlayerGun;
                go.name = "Bullet";
                go.GetComponent<Rigidbody>().velocity = transform.forward * shottingPower;
                Destroy(go, 10f);
                canShoot = false;
                ammos = ammos - 1;
                if (ammoAmount != null)
                {
                    ammoAmount.color = Color.green;
                    ammoAmount.text = ammos + "/" + maxAmmos;
                }
                Invoke("DoDelay", delay);
            }
            else
            {
                if (!reloadWait)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    IEnumerator Reload()
    {
        reloadWait = true;
        audioSource.PlayOneShot(reloadSound);
        if (ammoAmount != null && isPlayerGun)
        {
            ammoAmount.color = Color.red;
            ammoAmount.text = "Reloading...";
        }
        yield return new WaitForSeconds(reload);
        ammos = maxAmmos;
        reloadWait = false;
        if (ammoAmount != null && isPlayerGun)
        {
            ammoAmount.color = Color.green;
            ammoAmount.text = ammos + "/" + maxAmmos;
        }
    }
}
