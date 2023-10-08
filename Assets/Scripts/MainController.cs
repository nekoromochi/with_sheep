using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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


    void Start()
    {
        Application.targetFrameRate = 30;

    }

    // Update is called once per frame
    void Update()
    {
        sheepSpawnTime += Time.deltaTime;
        if (sheepSpawnTime > 2 && !isCinderellaTime)
        {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        if (sheepSpawnTime > 0.4f && isCinderellaTime)
        {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

        cinderellaTime += Time.deltaTime;
        float sheepPercentage = sheepMeter.sheepPercentage;
        
        if (cinderellaTime < 5 && !isCinderellaTime)
        {
            cinderellaTime = 0;
            isCinderellaTime = true;
        }
        if (cinderellaTime > 10 && isCinderellaTime)
        {
            cinderellaTime = 0;
            isCinderellaTime = false;
        }

        wolfSpawnCheckTime += Time.deltaTime;
        
        if (wolfSpawnCheckTime > 10.0f && isNightmareTime)

        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }

        if (wolfSpawnCheckTime > 1 && !isNightmareTime)

        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }

            nightmareTime += Time.deltaTime;
        
        if (sheepPercentage < 20 && !isNightmareTime)
        {
            nightmareTime = 0;
            isNightmareTime = true;

        }
        if(nightmareTime > 10 && isNightmareTime)
        {
            nightmareTime = 0;
            isNightmareTime = false;
        }

        CheckoutInsideSheep();
    }

    public void OnDestroy()
    {
        insideFenceSheeps = new List<GameObject>();
        outsideFenceSheeps = new List<GameObject>();
    }

    public void wolfAttack()
    {
        int count = insideFenceSheeps.Count;
        int cnt = 0;
        int i = insideFenceSheeps.Count - 1;
        while (true)
        {
            // 10回Escapeするか、インデックスが0未満になったらループを抜ける
            if (cnt == 10 || i < 0)
            {
                break;
            }
            if (!insideFenceSheeps[i].GetComponent<Sheep>().IsEscape)
            {
                insideFenceSheeps[i].GetComponent<Sheep>().IsInside = false;
                insideFenceSheeps[i].GetComponent<Sheep>().Escape();
                // 重要
                cnt++;
            }
            // 重要
            i--;
        }
    }
    public void CheckoutInsideSheep()
    {
        for (int i = 0; i < insideFenceSheeps.Count; i++)
        {
            if (insideFenceSheeps[i].GetComponent<Sheep>() != null)
            {
                insideFenceSheeps[i].GetComponent<Sheep>().IsInside = true;
            }
        }
    }
    
}
