using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject elementToMove;
    public float speed;
    public Transform posOpen;
    public Transform posClose;
    Vector3 vec;
    void Start()
    {
        vec = posClose.position;
    }
    void Update()
    {
        elementToMove.transform.position = Vector3.MoveTowards(elementToMove.transform.position, vec, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Box"))
        {
            vec = posOpen.position;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Box"))
        {
            vec = posClose.position;
        }
    }
}
