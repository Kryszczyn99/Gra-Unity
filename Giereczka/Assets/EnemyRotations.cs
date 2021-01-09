﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotations : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
