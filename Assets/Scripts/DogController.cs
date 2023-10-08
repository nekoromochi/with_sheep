using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    Vector2 mySpeed = Vector2.zero;
    Rigidbody2D rigitBody = default;
    [SerializeField] float advSpeed = 0;
    [SerializeField] GameObject mySprite;

    void Awake()
    {
        rigitBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        Vector2 Speed = Vector2.zero;
        mySpeed = Vector2.zero;
        rigitBody.velocity = Vector2.zero;

        // キー入力
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Speed.x = -1;
            if(mySprite.GetComponent<SpriteRenderer>().flipX != false) { mySprite.GetComponent<SpriteRenderer>().flipX = false; }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Speed.x = 1;
            if (mySprite.GetComponent<SpriteRenderer>().flipX != true) { mySprite.GetComponent<SpriteRenderer>().flipX = true; }
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Speed.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Speed.y = -1;
        }

        // このループ中にキー入力が行われた場合通過
        if (Speed.x != 0 || Speed.y != 0)
        {
            // 正規化
            Speed.Normalize();
            // 移動
            mySpeed = Speed * advSpeed;
            rigitBody.velocity = mySpeed;
        }
        
    }
}
