using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour
{
    int sheepLayerNum = 7;
    int wolfLayerNum = 8;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == sheepLayerNum)
        {
            
            collision.GetComponent<Sheep>().Escape();
            Debug.Log("SheepEscape!!");
        }

        if (collision.gameObject.layer == wolfLayerNum)
        {
            // collision.GetComponent<Wolf>().EsCape();
            Debug.Log("WolfEscape!!");
        }
    }
}
