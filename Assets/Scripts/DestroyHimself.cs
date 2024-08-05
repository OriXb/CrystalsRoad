using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHimself : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToDestroy = 40f;
    void Start()
    {
        
    }

    void Awake()
    {
        Invoke("DestroyMe", timeToDestroy);
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
        Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
