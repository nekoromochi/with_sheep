using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sheep : MonoBehaviour
{
    public float speed = 0.05f;
    //sheep‚ªƒXƒ|[ƒ“‚µ‚Ä‚¢‚éêŠ‚Ìî•ñ‚ğ“Ç‚İ‚ŞêŠ
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
                Debug.Log(position);
                position.x += speed;
                break;
            case 1:
                Debug.Log(position);
                position.y += speed;
                break;
            case 2:
                position.x -= speed;
                Debug.Log(position);
                break;
            case 3:
                Debug.Log(position);
                position.y -= speed;
                break;
        }
        transform.position = position;
    }
}
