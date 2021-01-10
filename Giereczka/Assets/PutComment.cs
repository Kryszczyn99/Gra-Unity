using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutComment : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        Text.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Text.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Text.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Text.SetActive(true);
        }
    }
    void OnCollisionExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Text.SetActive(false);
        }
    }
}
