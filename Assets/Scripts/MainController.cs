using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public float sheepSpawnTime = 0;
    public SheepController sheepController;
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        sheepSpawnTime += Time.deltaTime;
        if(sheepSpawnTime > 3) {
            sheepSpawnTime = 0;
            sheepController.Spawn();
        }

    }
}
