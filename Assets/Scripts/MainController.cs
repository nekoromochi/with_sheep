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


    // Start is called before the first frame update
    public float sheepSpawnTime = 0;
    public float cinderellaTime = 0;
    private bool isCinderellaTime = false;
    public SheepController sheepController;

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
        if (sheepSpawnTime > 3 && !isCinderellaTime)
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

    public void OnDestroy()
    {
        insideFenceSheeps = new List<GameObject>();
        outsideFenceSheeps = new List<GameObject>();
    }

    public void wolfAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            int count = insideFenceSheeps.Count;
            if (count > 0)
            {
                Destroy(insideFenceSheeps[count - 1]);
                insideFenceSheeps.RemoveAt(count - 1);
            }
        }
    }
}
