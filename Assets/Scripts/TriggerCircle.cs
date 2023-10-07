using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sheep" || collision.tag == "Wolf")
        {
            /*
            if (collision == Sheep)
            {
                collision.GetComponent<Sheep>().EsCape();
            }
            if (collision == Wolf)
            {
                collision.GetComponent<Wolf>().EsCape();
            }*/
            Debug.Log("Escape!!");
        }
    }
}
