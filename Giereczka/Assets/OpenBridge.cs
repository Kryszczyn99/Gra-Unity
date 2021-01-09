using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBridge : MonoBehaviour
{
    public Transform pos;
    public float speed;
    public GameObject BridgeElements;
    Vector3 posDST;
    bool isInObject;
    bool buildBridge;
    // Update is called once per frame
    void Start()
    {
        buildBridge = false;
        isInObject = false;
    }
    void Update()
    {
     
        if(isInObject && Input.GetKeyDown(KeyCode.E))
        {
            buildBridge = true;
        }
        if(buildBridge)
        {
            posDST = pos.position;
            BridgeElements.transform.position = Vector3.MoveTowards(BridgeElements.transform.position, posDST, speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D()
    {
        isInObject = true;
    }
    public void OnTriggerExit2D()
    {
        isInObject = false;
    }
}
