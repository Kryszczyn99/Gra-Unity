using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMob : MonoBehaviour
{
    public GameObject mob;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Destroy(mob);
        }
    }
}
