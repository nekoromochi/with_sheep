using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMeter : MonoBehaviour
{
    public GameObject cursor;
    private const float maxLength = 4.0f;
    private const int maxSheepNum = 50; 
    public MainController mainController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = mainController.insideFenceSheeps.Count;
        if (count > 50)
        {
            cursor.transform.position = new Vector2(-6.5f, -1 + maxLength);
            return;
        }
        float length = maxLength * count / maxSheepNum;
        cursor.transform.position = new Vector2(-6.5f, -1 + length);

    }

}
