using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public List<GameObject> enemysList = new List<GameObject>();
    bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        check = true;
        for(int i = 0; i < enemysList.Count; i++)
        {
            if(enemysList[i] != null)
            {
                check = false;
            }
        }
        if(check)
        {
            Destroy(this.gameObject);
        }
    }
}
