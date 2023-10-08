using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float wolfSpawnCheckTime = 0; // 狼のスポーンを管理する時間

    public float wolfSpawnSeconds = 2;

    public WolfController wolfController;

    public SheepMeter sheepMeter;


    // Start is called before the first frame update
    public float sheepSpawnTime = 0;
    public float cinderellaTime = 0;
    private bool isCinderellaTime = false;
    private bool isSheepPercentage = false;
    public SheepController sheepController;
    public float nightmareTime = 0;
    private bool isNightmareTime = false;
    public List<GameObject> outsideFenceSheeps = new List<GameObject>();
    public List<GameObject> insideFenceSheeps = new List<GameObject>();
    public BigWolf bigWolf;


    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        sheepSpawnTime += Time.deltaTime;
        if (sheepSpawnTime > 1 && !isCinderellaTime)
        {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        if (sheepSpawnTime > 0.2f && isCinderellaTime)
        {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        cinderellaTime += Time.deltaTime;
        float sheepPercentage = sheepMeter.sheepPercentage;
        
        if (sheepPercentage > 80 && !isCinderellaTime)
        {
            Debug.Log("シンデレラタイムstart");
            cinderellaTime = 0;
            isCinderellaTime = true;
        }
        if (cinderellaTime > 10 && isCinderellaTime)
        {
            cinderellaTime = 0;
            isCinderellaTime = false;
            Debug.Log("シンデレラタイムend");

        }

        wolfSpawnCheckTime += Time.deltaTime;
        
        if (wolfSpawnCheckTime > 0.2f && isNightmareTime)

        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
            bigWolf.Spawn();
        }
        if (wolfSpawnCheckTime > 1 && !isNightmareTime)

        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }

            nightmareTime += Time.deltaTime;
        
        if (sheepPercentage < 20 && !isNightmareTime)
        {
            Debug.Log("悪夢タイムstart");
                nightmareTime = 0;
            isNightmareTime = true;

        }
        if(nightmareTime > 10 && isNightmareTime)
        {
            nightmareTime = 0;
            isNightmareTime = false;
            Debug.Log("悪夢タイムend");
        }

    }

    public void OnDestroy()
    {
        insideFenceSheeps = new List<GameObject>();
        outsideFenceSheeps = new List<GameObject>();
    }
}
