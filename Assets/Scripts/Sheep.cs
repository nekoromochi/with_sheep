using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Sheep : MonoBehaviour
{
    public int id;
    public MainController mainController;
    public float speed = 0.01f;
    //sheep���X�|�[�����Ă���ꏊ�̏���ǂݍ��ޏꏊ
    public int spawnPoint;

    /* -- h-sato Edit1/4  Start -- */
    private bool isInside = false;
    private bool isInsideMove = false;
    private bool isEscape = false;
    // �����I���܂ł̎���
    [SerializeField] float MovedEndTime = 5;
    private float insideMoveTime;
    [SerializeField] Transform rangeA = default;
    [SerializeField] Transform rangeB = default;
    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos = Vector3.zero;
    private Vector3 moveDistance = Vector3.zero;


    private Transform escapePoint;
    private Vector3 escapeDistance = Vector3.zero;
    private Vector3 escapeStartPos = Vector3.zero;
    private float escapeTime = 0;
    [SerializeField] private float escapeTimeLimit = 2.0f;

    // �v���p�e�B
    public Transform RangeA { set { rangeA = value; } }
    public Transform RangeB { set { rangeB = value; } }
    public Transform EscapePoint { set {  escapePoint = value; } }
    public bool IsInside
    {
        get { return isInside; }
        set { isInside = value; }
    }
    public bool IsEscape 
    { 
        get { return isEscape; }
        set { isEscape = value; }
    }
    /* -- h-sato Edit1/4  End   -- */

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /* -- h-sato Edit3/4  Start -- */
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
        /* -- h-sato Edit3/4  End   -- */
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
        if (isEscape) { return; }
        if (collision.tag == "FenceGate")
        {
            mainController.insideFenceSheeps.Add(this.gameObject);
            mainController.outsideFenceSheeps.Remove(this.gameObject);
        }
    }
    public void OnApplicationQuit()
    {
        mainController.insideFenceSheeps = new List<GameObject>();
        mainController.outsideFenceSheeps = new List<GameObject>();
    }


    /* -- h-sato Edit4/4  Start -- */  

    

    public void InsideMove()
    {
        if(!isInsideMove)
        {
            // �ŏ��̍��W�ۑ�
            startPos = transform.position;
            transform.position = startPos;

            // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
            float z = Random.Range(rangeA.position.z, rangeB.position.z);
            
            // �ŏI�n�_���W�ۑ�
            endPos = new Vector3(x, y, z);

            // �ړ������Z�o(�I�_ - �n�_)
            moveDistance = endPos - startPos;

            // �X�e�[�g�؂�ւ�
            isInsideMove = true;
        }

        if(isInsideMove)
        {
            insideMoveTime += Time.deltaTime;
            // �i�s����:�ŏI���� = �i�s����:�ŏI�n�_
            // �����̐ρ@�O���̐�
            // �i�s���� = �i�s���� * �ŏI�n�_ / �ŏI����
            Vector3 frameMove = insideMoveTime * moveDistance / MovedEndTime;
            transform.position = startPos + frameMove;
            
            if(insideMoveTime > MovedEndTime)
            {
                insideMoveTime = 0;
                isInsideMove = false;
            }
        }
    }

    public void Escape()
    {
        // �i�s�����Z�o
        escapeStartPos = transform.position;
        escapeDistance = escapePoint.position - startPos;
        this.IsEscape = true;
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
    /* -- h-sato Edit4/4  End   -- */

}
