using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public float speed = 0.05f;
    public int startPosition;
    public MainController mainController;
    private float wolfLifeTime = 1.0f;
    [SerializeField] private float wolfLifeTimeLimit = 10f;

    /* -- h-sato Edit1/4  Start -- */
    private Vector3 startPos = Vector3.zero;
    private bool isEscape = false;
    private bool isInside = false;
    [SerializeField] private Transform escapePoint;
    private Vector3 escapeDistance = Vector3.zero;
    private Vector3 escapeStartPos = Vector3.zero;
    private float escapeTime = 0;
    [SerializeField] private float escapeTimeLimit = 2.0f;
    // プロパティ
    public Transform EscapePoint { set {  escapePoint = value; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isEscape)
        {
            EscapeMove();
            return;
        }
        if (isInside)
        {
            InsideMove();
            return;
        }

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

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FenceGate")
        {
            mainController.wolfAttack();
            isInside = true;
        }
    }

    public void Escape()
    {

        // 進行距離算出
        escapeStartPos = transform.position;
        escapeDistance = escapePoint.position - startPos;
        isEscape = true;
        mainController.insideFenceSheeps.Remove(this.gameObject);
        Debug.Log("SheepEscape Now");
    }
    public void EscapeMove()
    {
        escapeTime += Time.deltaTime;
        Vector3 frameMove = escapeTime * escapeDistance / escapeTimeLimit;
        transform.position = escapeStartPos + frameMove;
        if (escapeTime > escapeTimeLimit)
        {

            Destroy(this.gameObject);
        }
    }
    public void InsideMove() 
    {
        // その場で止まる
        wolfLifeTime += Time.deltaTime;
        if (wolfLifeTime > wolfLifeTimeLimit)
        {
            wolfLifeTime = 0;
            mainController.wolfAttack();
        }
    }
}
