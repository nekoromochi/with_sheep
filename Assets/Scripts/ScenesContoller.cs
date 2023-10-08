using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesContoller : MonoBehaviour
{
    public MainController mainController;
    public SheepController sheepController;
    public SheepMeter sheepMeter;
    public float minGameTimeChecker = 0;
    private float deadGameOver = 0;
    private float sleeplessGameOver = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minGameTimeChecker += Time.deltaTime;
        float sheepPercentage = sheepMeter.sheepPercentage;
        if (sheepPercentage > 90 && minGameTimeChecker > 8f)
        {
            deadGameOver += Time.deltaTime;

        }
        else if (sheepPercentage < 10 && minGameTimeChecker > 8f)
        {
            sleeplessGameOver += Time.deltaTime;
        }
        else
        {
            deadGameOver = 0;
        }

        if (deadGameOver > 2.0f)
        {
            SceneManager.LoadScene("OversleepScene");
        }

        if (sleeplessGameOver > 2.0f)
        {
            SceneManager.LoadScene("SleepyScene");
        }


    }
}
