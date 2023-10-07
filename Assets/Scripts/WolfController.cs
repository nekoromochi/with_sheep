using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject WolfPrefab;
    public MainController mainController;

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
                wolf.transform.position = new Vector2(0, (float) 4.5);
                break;
            case 1:
                wolf.transform.position = new Vector2(8, 0);
                break;
            case 2:
                wolf.transform.position = new Vector2(0, (float) -4.5);
                break;
            case 3:
                wolf.transform.position = new Vector2(-8, 0);
                break;
        }
        Wolf wolfScript = wolf.GetComponent<Wolf>();
        wolfScript.startPosition = position;
        wolfScript.mainController = mainController;
    }
}
