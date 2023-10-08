using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float wolfSpawnCheckTime = 0; // �T�̃X�|�[�����Ǘ����鎞��

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
        
        if (wolfSpawnCheckTime > 0.2f && isNightmareTime)

        {
            wolfSpawnCheckTime = 0;
            wolfController.Spawn();
        }

        CheckoutInsideSheep();

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
    public void CheckoutInsideSheep()
    {
        for (int i = 0; i < insideFenceSheeps.Count; i++)
        {
            if (insideFenceSheeps[i].GetComponent<Sheep>() != null)
            {
                insideFenceSheeps[i].GetComponent<Sheep>().IsInside = true;
                InsideSheepMove(insideFenceSheeps[i].GetComponent<Sheep>());
            }
        }
    }
    public void InsideSheepMove(Sheep sheep)
    {
        sheep.InsideMove();
    }
}
