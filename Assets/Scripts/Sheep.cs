using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sheep : MonoBehaviour
{
    public int id;
    public MainController mainController;
    public float speed = 0.05f;
    //sheepがスポーンしている場所の情報を読み込む場所
    public int spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        switch (spawnPoint)
        {
            case 0:
                position.x += speed;
                break;
            case 1:
                position.y += speed;
                break;
            case 2:
                position.x -= speed;
                break;
            case 3:
                position.y -= speed;
                break;
        }
        transform.position = position;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FenceGate")
        {
            Debug.Log(collision);
            mainController.insideFenceSheeps.Add(this.gameObject);
            mainController.outsideFenceSheeps.Remove(this.gameObject);
        }
    }
    public void OnApplicationQuit()
    {
        mainController.insideFenceSheeps = new List<GameObject>();
        mainController.outsideFenceSheeps = new List<GameObject>();
    }
}
