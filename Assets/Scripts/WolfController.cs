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
    [SerializeField] Transform topLeftEscapePoint = default;
    [SerializeField] Transform topRightEscapePoint = default;
    [SerializeField] Transform bottomLeftEscapePoint = default;
    [SerializeField] Transform bottomRightEscapePoint = default;

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
        Wolf w = wolf.GetComponent<Wolf>();
        switch (position)
        {
            case 0:
                wolf.transform.position = topSpawnPoint;
                w.EscapePoint = topLeftEscapePoint;
                break;
            case 1:
                wolf.transform.position = rightSpawnPoint;
                w.EscapePoint = topRightEscapePoint;
                break;
            case 2:
                wolf.transform.position = bottomSpawnPoint;
                w.EscapePoint = bottomRightEscapePoint;
                break;
            case 3:
                wolf.transform.position = leftSpawnPoint;
                w.EscapePoint = bottomLeftEscapePoint;
                break;
        }

        Wolf wolfScript = wolf.GetComponent<Wolf>();
        wolfScript.startPosition = position;
        wolfScript.mainController = mainController;
    }
}
