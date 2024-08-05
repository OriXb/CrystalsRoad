using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int health = 100;
    public int testLook;
    public float speed = 3f;
    public float shootingDaily = 1.5f;
    public float rotationSpeed = 1;
    public float moveSpeed = 2;
    public float accuracy = 0.5f;
    public float stopDistance = 5;
    public float lookDistance = 30;

    public Transform player;
    public Gun gun;
    public Vector3 shootingOffset;


    void Start()
    {
        StartCoroutine(DoShooting());
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(player.position, transform.position) < lookDistance)
        {
            Vector3 lookAtNoY = new Vector3(player.position.x + shootingOffset.x, transform.position.y, player.position.z + shootingOffset.z); // המיקום שעליו אמור הקפסול להסתכל
            Quaternion taregtRotation = Quaternion.LookRotation(((lookAtNoY) - transform.position).normalized); // הסיבוב שצריך לעשות בשביל להסתכל על לוקאטנווי
            transform.rotation = Quaternion.Lerp(transform.rotation, taregtRotation, rotationSpeed); // צעד לכיוון שצריך להסתובב אליו


            gun.transform.LookAt(player.position + new Vector3(0, shootingOffset.y, 0));
            gun.transform.localRotation = Quaternion.Euler(gun.transform.rotation.eulerAngles.x, 0, 0);
            if (Vector3.Distance(player.position, transform.position) > stopDistance)
            {
                this.GetComponent<Rigidbody>().velocity += transform.forward * speed;
            }

            testLook = 1;
        }
        else
        {
            testLook = 0;
        }

    }

    IEnumerator DoShooting()
    {
        while (true)
        {
            if (testLook == 1)
            {
               // gun.Shoot();
            }
            yield return new WaitForSeconds(shootingDaily);
        }
    }
}