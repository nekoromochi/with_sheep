using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    /* ----- �����d�v���� List��index�ɑΉ�����ʒu TOP:0, BOTTOM:1, LEFT:2, RIGHT:3 ----- */

    [SerializeField] private float bigWolfSpawnProbability = 50.0f; // Range:0 �` 100 default:50
    [SerializeField] private float attackDelayTimeLimit = 5.0f;
    [SerializeField] private float spawnIntervalLimit = 3.0f;
    [SerializeField] private float escapeTimeLimit = 2.0f;
    [SerializeField] private float wolfMoveSpeed = 0.01f;
    [SerializeField] private int wolfEscapeSheepAmount = 2;
    [SerializeField] private int bigWolfEscapeSheepAmount = 4;
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private GameObject bigWolfPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] escapePoints;
    [SerializeField] private Transform[] attackPoints;
    [SerializeField] private List<Vector3> translateDirections;
    private const int COUNT = 4;
    private float attackPointOffset = 0.5f;
    private int escapeSheepAmount = 0;
    private List<Wolf> wolfList = new List<Wolf>();

    // �v���p�e�B
    public float SpawnIntervalLimit {  get { return spawnIntervalLimit; } }

    private void Awake()
    {
        translateDirections.Clear();
        // class scope ���Ƃ��̋L�q���ł��Ȃ����߁AAwake Scope�ŋL�q���Ă���B
        translateDirections.Add(new Vector3(0, -(wolfMoveSpeed / 2.0f), 0)); // TOP
        translateDirections.Add(new Vector3(0, wolfMoveSpeed / 2.0f, 0));  // BOTTOM
        translateDirections.Add(new Vector3(wolfMoveSpeed, 0, 0));           // LEFT
        translateDirections.Add(new Vector3(-wolfMoveSpeed, 0, 0));          // RIGHT
    }

    public void WolfAttack(List<GameObject> sheepList)
    {
        foreach (Wolf wolf in wolfList)
        {
            if (wolf.State != Wolf.EWOLF_STATE_ID.ATTACK) { continue; }

            int count = sheepList.Count - 1;
            // ��x�̍U���ŕ����C�̗r�𓦂����B
            for (int i = 0; i < wolf.EscapeSheepAmount; i++)
            {
                if (count < 0) { break; }

                // todo:�r���X�g�ɗr�ȊO�������Ă��邩�m�F���Ă��邪�A�{���r���X�g�ɗr�ȊO���������ꍇ�͗r�R���g���[���[�̂ق��ō폜���Ă������������B
                if (!sheepList[count].GetComponent<Sheep>()) { continue; }

                wolf.Attack(sheepList[count].GetComponent<Sheep>());
                count--;
            }
            
            wolf.StateChange(Wolf.EWOLF_STATE_ID.INSIDE);
        }
    }

    public void Spawn()
    {
        // �o������ꏊ�𗐐��Ŏ擾
        int point = UnityEngine.Random.Range(0,COUNT);

        // �T���߂�ꂽ�ʒu�ɐ���
        GameObject wolfObj = Instantiate(SpawnWolfDrop(), spawnPoints[point].position, Quaternion.identity);

        // �ꉞWolf�����Ă��Ȃ�������폜����
        if (!wolfObj.GetComponent<Wolf>()) 
        {
            Destroy(wolfObj);
            return;
        }

        // �T�̏������Ȃ�
        Wolf wolf = wolfObj.GetComponent<Wolf>();
        wolfList.Add(wolf);
        bool flipFlag = point == 2; // LEFT�Ȃ�t���b�v
        wolf.Init(escapePoints[point], AdjustAttackpoint(point), translateDirections[point], flipFlag, attackDelayTimeLimit, escapeTimeLimit, escapeSheepAmount);
    }

    private GameObject SpawnWolfDrop()
    {
        float randomValue = UnityEngine.Random.value * 100.0f % 100.0f;
        if (randomValue < bigWolfSpawnProbability)
        {
            escapeSheepAmount = bigWolfEscapeSheepAmount;
            return bigWolfPrefab;
        }
        else
        {
            escapeSheepAmount = wolfEscapeSheepAmount;
            return wolfPrefab;
        }
    }
    
    private Vector3 AdjustAttackpoint(int point)
    {
        Vector3 retVec;

        if (point <= 1) // TOP or BOTTOM
        {
            float randomX = UnityEngine.Random.Range( attackPoints[point].position.x - attackPointOffset, attackPoints[point].position.x + attackPointOffset);
            retVec = new Vector3(randomX, attackPoints[point].position.y, attackPoints[point].position.z);
            return retVec;
        }
        else            // LEFT or RIGHT
        {
            float randomY = UnityEngine.Random.Range(attackPoints[point].position.y - attackPointOffset, attackPoints[point].position.y + attackPointOffset);
            retVec = new Vector3(attackPoints[point].position.x, randomY, attackPoints[point].position.z);
            return retVec;
        }
    }
}
