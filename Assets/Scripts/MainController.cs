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
    public SheepController sheepController;

    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        sheepSpawnTime += Time.deltaTime;
        if(sheepSpawnTime > 3) {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        wolfSpawnCheckTime += Time.deltaTime;
        
        if (wolfSpawnCheckTime > wolfSpawnSeconds)
        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }
    }
}
