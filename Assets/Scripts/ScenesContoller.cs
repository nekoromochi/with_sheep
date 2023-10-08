using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesContoller : MonoBehaviour
{
    public MainController mainController;
    public SheepController sheepController;
    public SheepMeter sheepMeter;
    float gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sheepPercentage = sheepMeter.sheepPercentage;
        if (sheepPercentage > 90 || sheepPercentage < 10)
        {
            gameOver += Time.deltaTime;

        }
        else
        {
            gameOver = 0;
        }
        if (gameOver > 2.0f)
        {
            gameOver = 0;
        }

    }
}
