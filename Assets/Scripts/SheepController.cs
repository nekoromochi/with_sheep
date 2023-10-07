using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public GameObject sheepPrefab;
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
        //Scenes‚Ì’†‚Ésheep‚ğ¶‚İo‚µ‚Ä‚¢‚éB
        GameObject go = Instantiate(sheepPrefab);

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
        //Gameobject‚Ìsheepscript‚ğæ“¾‚·‚é
        Sheep sheep = go.GetComponent<Sheep>();
        sheep.spawnPoint = rnd;
    }
}
