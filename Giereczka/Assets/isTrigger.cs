using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("Witam!");
    }
    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Schodze!");
    }
}
