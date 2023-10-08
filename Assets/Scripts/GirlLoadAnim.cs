using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirlLoadAnim : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] float moveTime = 0;
    [SerializeField] float timeLimit = 5.0f;
    Vector3 moveDistance = Vector3.zero;
    Animator animator;
    int cnt = 0;
    [SerializeField] int cntLimit = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        transform.position = startPos.position;
        moveDistance = endPos.position - startPos.position;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        // �i�s����:�ŏI���� = �i�s����:�ŏI�n�_
        // �����̐ρ@�O���̐�
        // �i�s���� = �i�s���� * �ŏI�n�_ / �ŏI����
        Vector3 frameMove = moveTime * moveDistance / timeLimit;
        transform.position = startPos.position + frameMove;

        if (moveTime > timeLimit)
        {
            moveTime = 0;
            animator.SetTrigger("MoveStart");
            cnt++;
        }

        if (cnt == cntLimit)
        {
            SceneManager.LoadScene("InGameScene");
        }
    }
}
