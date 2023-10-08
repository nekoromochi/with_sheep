using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheepGauge : MonoBehaviour
{
    [SerializeField] float time = 0;
    [SerializeField] float timeLimit = 60;
    [SerializeField] GameObject sheepIcon;
    [SerializeField] GameObject gauge;
    float startX = -4;
    float endX = 4;
    float moveDistance = 0;


    void Start()
    {
        time = 0;
        sheepIcon.transform.localPosition = new Vector2(startX, 0);
        moveDistance = endX - startX; // �I�_�@�[�@�n�_
    }

    void Update()
    {
       
        time += Time.deltaTime;
        
        if (time > timeLimit)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    private void FixedUpdate()
    {
        // �i�s����:�ŏI���� = �i�s����:�ŏI�n�_
        // �����̐ρ@�O���̐�
        // �i�s���� = �i�s���� * �ŏI�n�_ / �ŏI����
        float frameMove = time * moveDistance / timeLimit;
        sheepIcon.transform.localPosition = new Vector3(startX + frameMove, 0, 0);
    }
}
