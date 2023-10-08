using System.Collections;
using System.Collections.Generic;
/*using System.Diagnostics;*/
using UnityEngine;

public class BigWolf : MonoBehaviour
{
    public SheepMeter sheepMeter;
    private bool isNightmareTime;
    public GameObject BigWolfPrefab;
    public MainController mainController;
    public float speed = 0.05f;
    public int position;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        float nightmareTime = mainController.nightmareTime;
        Debug.Log(nightmareTime);
        if (nightmareTime < 80 && !isNightmareTime)
        {
            Debug.Log("BigWlof");
            int position = Random.Range(0, 4);
            GameObject bigWolf = Instantiate(BigWolfPrefab);
            
            switch (position)
            {

                case 0:
                    bigWolf.transform.position = new Vector2(0, (float)4.5);
                    break;
                case 1:
                    bigWolf.transform.position = new Vector2(8, 0);
                    break;
                case 2:
                    bigWolf.transform.position = new Vector2(0, (float)-4.5);
                    break;
                case 3:
                    bigWolf.transform.position = new Vector2(-8, 0);
                    break;
            }
        }
        else
        {
            isNightmareTime = false;
        }
    }
}
