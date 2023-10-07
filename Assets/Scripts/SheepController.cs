using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private int sheepNum = 0;
    public GameObject sheepPrefab;
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
        int rnd = Random.Range(0, 4);
        //Scenes�̒���sheep�𐶂ݏo���Ă���B
        GameObject go = Instantiate(sheepPrefab);
        mainController.outsideFenceSheeps.Add(go);
        if (rnd == 0)
        {
            go.transform.position = new Vector2(-9,0);
        }else if(rnd == 1)
        {
            go.transform.position= new Vector2(0,-4);
        }else if (rnd == 2)
        {
            go.transform.position = new Vector2(9,0);
        }
        else
        {
            go.transform.position = new Vector2(0,5);
        }
        //Gameobject��sheepscript���擾����
        Sheep sheep = go.GetComponent<Sheep>();
        sheep.mainController = mainController;
        sheep.spawnPoint = rnd;
        sheep.id = sheepNum++;
    }
}
