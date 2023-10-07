using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public float speed = 0.05f;
    public int startPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        switch (startPosition)
        {
            case 0:
                position.y -= speed;
                break;
            case 1:
                position.x -= speed;
                break;
            case 2:
                position.y += speed;
                break;
            case 3:
                position.x += speed;
                break;
        }
        transform.position = position;
    }
}
