using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject WolfPrefab;
    public MainController mainController;

    [SerializeField] Vector2 topSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 bottomSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 leftSpawnPoint = Vector2.zero;
    [SerializeField] Vector2 rightSpawnPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int position = Random.Range(0, 4); // èoåªÇ∑ÇÈèÍèäÇóêêîÇ≈éÊìæ
        GameObject wolf = Instantiate(WolfPrefab);

        switch (position)
        {
            case 0:
                wolf.transform.position = topSpawnPoint;
                break;
            case 1:
                wolf.transform.position = rightSpawnPoint;
                break;
            case 2:
                wolf.transform.position = bottomSpawnPoint;
                break;
            case 3:
                wolf.transform.position = leftSpawnPoint;
                break;
        }

        Wolf wolfScript = wolf.GetComponent<Wolf>();
        wolfScript.startPosition = position;
        wolfScript.mainController = mainController;
    }
}
