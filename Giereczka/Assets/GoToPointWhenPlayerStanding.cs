using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPointWhenPlayerStanding : MonoBehaviour
{

    public Transform posStart;
    public Transform posEnd;
    public float speed;
    public GameObject elementToMove;
    Vector2 vec;
    // Start is called before the first frame update
    void Start()
    {
        vec = posStart.position;
    }

    // Update is called once per frame
    void Update()
    {
        elementToMove.transform.position = Vector2.MoveTowards(elementToMove.transform.position, vec, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            vec = posEnd.position;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            vec = posStart.position;
        }
    }
}
