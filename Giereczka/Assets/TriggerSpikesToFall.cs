using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpikesToFall : MonoBehaviour
{
    public GameObject blocks;
    public float speedFalling;
    public float speedClimbing;
    public Transform posFall;
    public Transform posStart;
    bool isInAction;
    bool isGoingBack;
    Vector2 vec;

    void Start()
    {
        isInAction = false;
        isGoingBack = false;
    }
    void Update()
    {
        if(isInAction == true)
        {
            blocks.transform.position = Vector2.MoveTowards(blocks.transform.position, vec, speedFalling * Time.deltaTime);
            Vector3 temp = blocks.transform.position;
            Vector3 fall = posFall.position;
            if((temp.x < fall.x + 0.01 && temp.x > fall.x - 0.01) && (temp.y < fall.y + 0.01 && temp.y > fall.y - 0.01))
            {
                isGoingBack = true;
                isInAction = false;
                vec = posStart.position;
            }
        }
        else if(isGoingBack == true)
        {
            blocks.transform.position = Vector2.MoveTowards(blocks.transform.position, vec, speedClimbing * Time.deltaTime);
            Vector3 temp = blocks.transform.position;
            Vector3 fall = posStart.position;
            if ((temp.x < fall.x + 0.01 && temp.x > fall.x - 0.01) && (temp.y < fall.y + 0.01 && temp.y > fall.y - 0.01))
            {
                isGoingBack = false;
            }
        }
        else
        {
            vec = posFall.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && isInAction == false && isGoingBack == false)
        {
            isInAction = true;
            vec = posFall.position;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && isInAction == false && isGoingBack == false)
        {
            isInAction = true;
            vec = posFall.position;
        }
    }
}
