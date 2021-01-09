using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryPicker : MonoBehaviour
{
    private static float cherry = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Cherry")
        {
            cherry = cherry + 1;
            Destroy(other.gameObject);
        }
    }
    static public float getNumberOfCherries()
    {
        return cherry;
    }
}
