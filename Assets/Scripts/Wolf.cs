using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public float speed = 0.01f;
    public int startPosition;
    public MainController mainController;
    private float wolfLifeTime = 1.0f;
    private bool shouldDie = false;

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
        
        if (shouldDie)
        {
            wolfLifeTime -= Time.deltaTime;
        }

        if (wolfLifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FenceGate")
        {
            mainController.wolfAttack();
            shouldDie = true;
        }
    }
}
