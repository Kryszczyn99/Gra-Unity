using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public GameObject player;
    public float speed;
    bool canClimb;
    bool wantToClimb;
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        canClimb = false;
        wantToClimb = false;
        vec = new Vector3(1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(canClimb && Input.GetKeyDown(KeyCode.E))
        {
            wantToClimb = true;
        }
        if(wantToClimb)
        {
            Debug.Log("Wchodze!");
            if(Input.GetKeyDown(KeyCode.W))
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position + vec, speed * Time.deltaTime);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Wchodze po drabinie!");
        canClimb = true;
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Juz nie wchodze!");
        canClimb = false;
    }
}
