using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBox : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Box")
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
