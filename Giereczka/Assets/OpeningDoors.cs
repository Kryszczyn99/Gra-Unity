using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public GameObject doorOpened;
    public GameObject doorClosed;
    public Transform posOutOfVision;
    public Transform posForDoorsClosed;
    public Transform posForDoorsOpened;
    
    Vector2 vec;
    bool isAbleToOpen;
    bool isAbleToDoSth;

    // Start is called before the first frame update
    void Start()
    {
        isAbleToOpen = true;
        isAbleToDoSth = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isAbleToOpen && isAbleToDoSth)
        {
            doorOpened.transform.position = posForDoorsOpened.position;
            doorClosed.transform.position = posOutOfVision.position;
            SoundManagerScript.PlaySound("open_door");
            isAbleToOpen = false;
        }
        else if(Input.GetKeyDown(KeyCode.E) && !isAbleToOpen && isAbleToDoSth)
        {
            doorClosed.transform.position = posForDoorsClosed.position;
            doorOpened.transform.position = posOutOfVision.position;
            SoundManagerScript.PlaySound("close_door");
            isAbleToOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.transform.tag == "Player")
        {

            isAbleToDoSth = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isAbleToDoSth = false;
        }
    }
}
