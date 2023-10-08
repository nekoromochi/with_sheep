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
        moveDistance = endX - startX; // 終点　ー　始点
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
        // 進行時間:最終時間 = 進行距離:最終地点
        // 内向の積　外向の積
        // 進行距離 = 進行時間 * 最終地点 / 最終時間
        float frameMove = time * moveDistance / timeLimit;
        sheepIcon.transform.localPosition = new Vector3(startX + frameMove, 0, 0);
    }
}
