using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachine : MonoBehaviour
{
    public Rigidbody ammoPrefab;
    public GameObject shootingPointMG;
    public float shootingPower = 30;
    public Transform player;
    public Vector3 shootingOffset;
    public float rotationSpeed = 0.1F;

    public void Shoot()
    {
        GameObject go = Instantiate(ammoPrefab.gameObject, shootingPointMG.transform.position, transform.rotation);
        go.name = "Bullet";
        go.GetComponent<Rigidbody>().velocity = transform.forward * shootingPower;
        Destroy(go, 10f);
    }
    void Start()
    {
        InvokeRepeating("Shoot", 0, 0.001f);
        InvokeRepeating("Shoot", 0, 0.002f);
        InvokeRepeating("Shoot", 0, 0.003f);
    }

    private void FixedUpdate()
    {
        Vector3 lookAtNoY = new Vector3(player.position.x + shootingOffset.x, transform.position.y, player.position.z + shootingOffset.z); // המיקום שעליו אמור הקפסול להסתכל
        Quaternion taregtRotation = Quaternion.LookRotation(((lookAtNoY) - transform.position).normalized); // הסיבוב שצריך לעשות בשביל להסתכל על לוקאטנווי
        transform.rotation = Quaternion.Lerp(transform.rotation, taregtRotation, rotationSpeed); // צעד לכיוון שצריך להסתובב אליו
    }
    // Update is called once per frame
    void Update()
    {
    }
}
