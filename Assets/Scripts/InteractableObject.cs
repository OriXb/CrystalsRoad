using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent onActStart;
    public UnityEvent onActFinished;
    public float duration = 2;
    public bool requireTool = false;
    public string requireToolID;

    public virtual void Act(string toolID)
    {
        if(requireTool)
        {
            if(requireToolID == toolID)
            {
                Actt();
            }
        }
        else
        {
            Actt();
        }
    }

    public virtual void Actt()
    {
        onActStart.Invoke();
        StartCoroutine(IE_Act());
    }

    public virtual IEnumerator IE_Act()
    {
        float timer = 0;
        while(timer < duration && Input.GetMouseButton(0))
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            onActFinished.Invoke();
        }
        
    }
}
