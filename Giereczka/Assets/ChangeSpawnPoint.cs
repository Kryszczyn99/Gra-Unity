using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpawnPoint : MonoBehaviour
{

    [SerializeField] Transform newSpawn;
    [SerializeField] GameObject spawn;

    public void OnTriggerEnter2D()
    {
        Vector2 pos = newSpawn.position;
        spawn.transform.position = pos;
    }
}
