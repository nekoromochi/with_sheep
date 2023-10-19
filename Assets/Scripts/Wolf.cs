using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    // ----- 状態変数sta ----- //
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

    /* ----- InitでWolfControllerから値をもらう ----- */
    private Transform escapePoint;
    private Vector3 attackPoint;
    private Vector3 translateDirection;
    private float attackDelayTimeLimit = 5.0f;
    private float escapeTimeLimit = 2.0f;

    /* ----- Escape用 ----- */
    private Vector3 escapeDistance = Vector3.zero;
    private Vector3 escapeStartPos = Vector3.zero;
    private float escapeTime = 0;
    private int escapeSheepAmount = 1;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float attackDelayTime = 0f;

    /* ----- プロパティ ----- */
    public int EscapeSheepAmount { get { return escapeSheepAmount; } }

    /* ----- イベント関数 ----- */
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

    // Moveはしていないのだが、他と統一したいためMoveとなずけた。
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
        // 外向の積内向の積
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
        // 攻撃場所に移動
        this.gameObject.transform.position = attackPoint;
        AnimChange("Thread", true);
        StateChange(EWOLF_STATE_ID.INSIDE);
    }

    // SetBool以外の変更はオーバーロードしよう。
    private void AnimChange(string paramName, bool flag)
    {
        animator.SetBool(paramName, flag);
    }

    /* ---------- 他で使うからpublicですよ(さらに言えば個別スクリプト化するべき) ---------- */
    public void StateChange(EWOLF_STATE_ID state)
    {
        // ESCAPEからDIEDに変更する命令は通す。
        if (State == EWOLF_STATE_ID.ESCAPE && state == EWOLF_STATE_ID.DIED)
        {
            this.state = state;
            return;
        }
        // 逃げている時、死んでいる時の状態変更は許されない。
        if (State == EWOLF_STATE_ID.ESCAPE || State == EWOLF_STATE_ID.DIED) { return; }
        this.state = state;
    }

    public void Escape()
    {
        if (State == EWOLF_STATE_ID.ESCAPE) { return; }
        // 進行距離算出
        escapeStartPos = transform.position;
        escapeDistance = escapePoint.position - escapeStartPos;

        // 逃げる方向が今の場所よりプラスか否か
        FlipX(escapeStartPos.x < escapePoint.position.x);

        AnimChange("Thread", false);
        StateChange(EWOLF_STATE_ID.ESCAPE);
    }

    public void Attack(Sheep sheep)
    {
        // 本当はこの一行なくしたいよね(羊側でやってほしい)
        sheep.IsInside = false;
        sheep.Escape();
    }
}
