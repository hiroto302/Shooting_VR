using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiController : MonoBehaviour
{
    Animator animator;
    GameObject player;
    public float rangeDistance = 2.0f;  //攻撃判定距離
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

        Vector3 playerPosition = player.transform.position;  //playerの位置
        Vector3 zombiPosition =transform.position;  //ゾンビの位置

        //playerの位置とゾンビの位置の距離が近くなったら攻撃
        float offset = Mathf.Abs(playerPosition.z - zombiPosition.z);  //絶対値で距離を取得
        if(offset <= rangeDistance)
        {
            Attack();
        }
    }

    void Attack()
    {
        //攻撃するアニメーション
        animator.SetTrigger("Attack");

        //ゲームオーバー画面に移動
    }
}
