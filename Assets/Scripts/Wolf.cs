using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    // ----- ��ԕϐ�sta ----- //
    public enum EWOLF_STATE_ID
    {
        NORMAL,
        INSIDE,
        ATTACK,
        ESCAPE,
        DIED
    }
    [SerializeField] private EWOLF_STATE_ID state;
    public EWOLF_STATE_ID State {  get { return state; } }

    /* ----- Init��WolfController����l�����炤 ----- */
    private Transform escapePoint;
    private Vector3 attackPoint;
    private Vector3 translateDirection;
    private float attackDelayTimeLimit = 5.0f;
    private float escapeTimeLimit = 2.0f;

    /* ----- Escape�p ----- */
    private Vector3 escapeDistance = Vector3.zero;
    private Vector3 escapeStartPos = Vector3.zero;
    private float escapeTime = 0;
    private int escapeSheepAmount = 1;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float attackDelayTime = 0f;

    /* ----- �v���p�e�B ----- */
    public int EscapeSheepAmount { get { return escapeSheepAmount; } }

    /* ----- �C�x���g�֐� ----- */
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (State == EWOLF_STATE_ID.NORMAL) { NomalMove(); }
        if (State == EWOLF_STATE_ID.INSIDE) { InsideMove(); }
        if (State == EWOLF_STATE_ID.ESCAPE) { EscapeMove(); }
        if (State == EWOLF_STATE_ID.DIED)   { Destroy(this.gameObject); }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (State == EWOLF_STATE_ID.ESCAPE || State == EWOLF_STATE_ID.DIED) { return; }
        if (collision.tag == "FenceGate")
        {
            Inside();
        }
    }

    public void Init(Transform escapePoint, Vector3 attackPoint, Vector3 translateDirection, bool flipFlag, float attackDelayTimeLimit, float escapeTimeLimit, int escapeSheepAmount)
    {
        this.escapePoint = escapePoint;
        this.attackPoint = attackPoint;
        this.translateDirection = translateDirection;
        this.attackDelayTimeLimit = attackDelayTimeLimit;
        this.escapeTimeLimit = escapeTimeLimit;
        this.escapeSheepAmount = escapeSheepAmount;
        attackDelayTime = attackDelayTimeLimit;
        FlipX(flipFlag);
        state = EWOLF_STATE_ID.NORMAL;
    }

    private void NomalMove()
    {
        transform.Translate(this.translateDirection);
    }

    // Move�͂��Ă��Ȃ��̂����A���Ɠ��ꂵ��������Move�ƂȂ������B
    private void InsideMove() 
    {
        attackDelayTime += Time.deltaTime;
        if (attackDelayTime > attackDelayTimeLimit)
        {
            StateChange(EWOLF_STATE_ID.ATTACK);
            attackDelayTime = 0;
        }
    }

    private void EscapeMove()
    {
        escapeTime += Time.deltaTime;
        // �O���̐ϓ����̐�
        Vector3 frameMove = escapeTime * escapeDistance / escapeTimeLimit;
        transform.position = escapeStartPos + frameMove;
        if (escapeTime > escapeTimeLimit)
        {
            state = EWOLF_STATE_ID.DIED;
        }
    }

    private void FlipX(bool flipFlag)
    {
        spriteRenderer.flipX = flipFlag;
    }

    private void Inside()
    {
        // �U���ꏊ�Ɉړ�
        this.gameObject.transform.position = attackPoint;
        AnimChange("Thread", true);
        StateChange(EWOLF_STATE_ID.INSIDE);
    }

    // SetBool�ȊO�̕ύX�̓I�[�o�[���[�h���悤�B
    private void AnimChange(string paramName, bool flag)
    {
        animator.SetBool(paramName, flag);
    }

    /* ---------- ���Ŏg������public�ł���(����Ɍ����ΌʃX�N���v�g������ׂ�) ---------- */
    public void StateChange(EWOLF_STATE_ID state)
    {
        // ESCAPE����DIED�ɕύX���閽�߂͒ʂ��B
        if (State == EWOLF_STATE_ID.ESCAPE && state == EWOLF_STATE_ID.DIED)
        {
            this.state = state;
            return;
        }
        // �����Ă��鎞�A����ł��鎞�̏�ԕύX�͋�����Ȃ��B
        if (State == EWOLF_STATE_ID.ESCAPE || State == EWOLF_STATE_ID.DIED) { return; }
        this.state = state;
    }

    public void Escape()
    {
        if (State == EWOLF_STATE_ID.ESCAPE) { return; }
        // �i�s�����Z�o
        escapeStartPos = transform.position;
        escapeDistance = escapePoint.position - escapeStartPos;

        // ��������������̏ꏊ���v���X���ۂ�
        FlipX(escapeStartPos.x < escapePoint.position.x);

        AnimChange("Thread", false);
        StateChange(EWOLF_STATE_ID.ESCAPE);
    }

    public void Attack(Sheep sheep)
    {
        // �{���͂��̈�s�Ȃ����������(�r���ł���Ăق���)
        sheep.IsInside = false;
        sheep.Escape();
    }
}
