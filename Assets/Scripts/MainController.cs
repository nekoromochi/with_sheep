using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float wolfSpawnCheckTime = 0; // 狼のスポーンを管理する時間

    public float wolfSpawnSeconds = 2;

    public WolfController wolfController;


    // Start is called before the first frame update
    public float sheepSpawnTime = 0;
    public float cinderellaTime = 0;
    private bool isCinderellaTime = false;
    public SheepController sheepController;

    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (sheepSpawnTime > 1 && !isCinderellaTime)
        {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        cinderellaTime += Time.deltaTime;
        if (cinderellaTime > 5 && !isCinderellaTime)
        {
            Debug.Log("シンデレラタイムスタート");
            cinderellaTime = 0;
            isCinderellaTime = true;
        }
        if (cinderellaTime > 10 && isCinderellaTime)
        {
            Debug.Log("シンデレラタイムend");
            cinderellaTime = 0;
            isCinderellaTime = false;
        }

        wolfSpawnCheckTime += Time.deltaTime;
        
        if (wolfSpawnCheckTime > wolfSpawnSeconds)
        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }
    }
}
