using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private SpriteRenderer sr;
    private SheepMeter sheepMeter;
    [SerializeField]
    private Sprite sleeplessGirl;
    [SerializeField]
    private Sprite sleepingGirl;
    [SerializeField]
    private Sprite dyingGirl;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sheepMeter = GameObject.Find("SheepMeter").GetComponent<SheepMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sheepMeter.sheepPercentage < 30)
        {
            sr.sprite = sleeplessGirl;
        } else if (sheepMeter.sheepPercentage >= 70){
            sr.sprite = dyingGirl;
        } else {
            sr.sprite = sleepingGirl;
        }
    }
}
