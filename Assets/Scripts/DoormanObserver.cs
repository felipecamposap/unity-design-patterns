using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorman : MonoBehaviour
{
    [SerializeField] private Door[] doors;

    private void OnTriggerEnter2D()
    {
        NotifyChildren();
    }

    private void NotifyChildren()
    {
        foreach(Door door in doors)
        {
            door.dm = this;
            door.enabled = true;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ResetChildren()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Invoke("ResetCollider", 0.1f);
        foreach(Door door in doors)
        {
            door.Reset();
        }
    }

    public void ResetCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
