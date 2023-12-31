using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float wolfSpawnCheckTime = 0; // 狼のスポーンを管理する時間


    [SerializeField] private WolfController wolfController;

    public SheepMeter sheepMeter;

    public float sheepSpawnTime = 0;
    public float cinderellaTime = 0;
    private bool isCinderellaTime = false;
    private bool isSheepPercentage = false;
    public SheepController sheepController;
    public float nightmareTime = 0;
    private bool isNightmareTime = false;
    public List<GameObject> outsideFenceSheeps = new List<GameObject>();
    public List<GameObject> insideFenceSheeps = new List<GameObject>();

    [SerializeField]
    private GameObject nightmareCutInPrefab;
    [SerializeField]
    private GameObject cinderellaCutInPrefab;


    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        sheepSpawnTime += Time.deltaTime;
        if (sheepSpawnTime > 1f && !isCinderellaTime)
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
        
        // シンデレラタイム突入処理
        if (cinderellaTime > 20f && !isCinderellaTime && !isNightmareTime)
        {
            cinderellaTime = 0;
            isCinderellaTime = true;
            EnterCinderellaMode();
        }
        if (cinderellaTime > 10f && isCinderellaTime)
        {
            cinderellaTime = 0;
            isCinderellaTime = false;
        }

        WolfUpdate();

        nightmareTime += Time.deltaTime;
        
        // 悪夢モード突入処理
        if (nightmareTime > 21f && !isNightmareTime && !isCinderellaTime)
        {
            nightmareTime = 0;
            isNightmareTime = true;
            EnterNightmareMode();

        }
        if (nightmareTime > 10.0f && isNightmareTime)
        {
            isNightmareTime = false;
            nightmareTime = 0;
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
            // 1回Escapeするか、インデックスが0未満になったらループを抜ける
            if (cnt == 1 || i < 0)
            {
                break;
            }
            Sheep targetSheep = insideFenceSheeps[i].GetComponent<Sheep>();
            if (!targetSheep.IsEscape)
            {
                targetSheep.IsInside = false;
                targetSheep.Escape();
                // 重要
                cnt++;
            }
            // 重要
            i--;
        }
    }

    private void WolfUpdate()
    {
        WolfSpawner();
        WolfsAttack();
    }

    private void WolfSpawner()
    {
        wolfSpawnCheckTime += Time.deltaTime;

        if (wolfSpawnCheckTime > wolfController.SpawnIntervalLimit / 2 && isNightmareTime)
        {
            wolfController.Spawn();
            wolfSpawnCheckTime = 0;
        }

        if (wolfSpawnCheckTime > wolfController.SpawnIntervalLimit && !isNightmareTime)

        {
            wolfController.Spawn();
            wolfSpawnCheckTime = 0;
        }
    }

    private void WolfsAttack()
    {
        wolfController.WolfAttack(insideFenceSheeps);
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

    private void EnterNightmareMode()
    {
        Instantiate(nightmareCutInPrefab);
    }
    private void EnterCinderellaMode()
    {
        Instantiate(cinderellaCutInPrefab);
    }

}
