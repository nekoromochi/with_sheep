using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    Vector2 myPos = Vector2.zero;
    [SerializeField] float advSpeed = 0;

    void Awake()
    {
        myPos = transform.position;
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos = Vector2.zero;

        // �L�[����
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            pos.x = -1; 
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            pos.x = 1; 
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {
            pos.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
        {
            pos.y = -1; 
        }

        // ���̃��[�v���ɃL�[���͂��s��ꂽ�ꍇ�ʉ�
        if (pos.x != 0 || pos.y != 0)
        {
            // ���K��
            pos.Normalize();
            // �ړ�
            myPos += pos * advSpeed * Time.deltaTime;
            transform.position = myPos;
        }
    }
}
