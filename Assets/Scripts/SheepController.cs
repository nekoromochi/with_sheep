using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private int sheepNum = 0;
    public GameObject sheepPrefab;
    public MainController mainController;
    /* -- h-sato Edit1/3  Start -- */
    [SerializeField] Vector2 topSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 bottomSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 leftSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 rightSpawnPoint = Vector2.zero;
    [SerializeField] Transform rangeA = default;
    [SerializeField] Transform rangeB = default;
    [SerializeField] Transform topLeftEscapePoint = default;
    [SerializeField] Transform topRightEscapePoint = default;
    [SerializeField] Transform bottomLeftEscapePoint = default;
    [SerializeField] Transform bottomRightEscapePoint = default;
    /* -- h-sato Edit1/3  End -- */

    // Start is called before the first frame update
    void Start()
    {
        /* -- h-sato Edit2/3  Start -- */
        // 通常
        /*
        topSpawnPoint = new Vector2(0, 5);
        bottomSpawnPoint = new Vector2(0, -4);
        leftSpawnPoint = new Vector2(-9, 0);
        rightSpawnPoint = new Vector2(9, 0);
        /*
        /* -- h-sato Edit2/3  End -- */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int rnd = Random.Range(0, 4);
        //Scenesの中にsheepを生み出している。
        GameObject go = Instantiate(sheepPrefab);
        mainController.outsideFenceSheeps.Add(go);
        /* -- h-sato Edit3/3  Start -- */
        Sheep sheep = go.GetComponent<Sheep>();
        if (rnd == 0)
        {
            go.transform.position = leftSpawnPoint;
            sheep.EscapePoint = bottomLeftEscapePoint;
        }else if(rnd == 1)
        {
            go.transform.position= bottomSpawnPoint;
            sheep.EscapePoint = bottomRightEscapePoint;
        }else if (rnd == 2)
        {
            go.transform.position = rightSpawnPoint;
            sheep.EscapePoint = topRightEscapePoint;
        }
        else
        {
            go.transform.position = topSpawnPoint;
            sheep.EscapePoint = topLeftEscapePoint;
        }
        /* -- h-sato Edit3/3  End -- */
        //Gameobjectのsheepscriptを取得する
        sheep.mainController = mainController;
        sheep.RangeA = rangeA;
        sheep.RangeB = rangeB;
        sheep.spawnPoint = rnd;
        sheep.id = sheepNum++;
    }
}
