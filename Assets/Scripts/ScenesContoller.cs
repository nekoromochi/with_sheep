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
    float gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minGameTimeChecker += Time.deltaTime;
        float sheepPercentage = sheepMeter.sheepPercentage;
        if ((sheepPercentage > 90 || sheepPercentage < 10) && minGameTimeChecker > 8f)
        {
            gameOver += Time.deltaTime;
            Debug.Log("count now");

        }
        else
        {
            gameOver = 0;
        }
        if (gameOver > 2.0f)
        {
            SceneManager.LoadScene("SleepyScene");
            gameOver = 0;
        }
    }
}
