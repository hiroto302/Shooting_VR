using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FolowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;  //プレイヤー視点のカメラを指す
    ZombiController zombi;  //ゾンビコントロラー型のzombi変数 他のクラスを参照できる
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");  //タグ識別によるオブジェクト検索
        zombi = GetComponent<ZombiController>();  //スクリプト取得
    }

    void Update()
    {
        if(zombi.CanWalk == true)
        {
            agent.destination = player.transform.position;  //playerの位置にゾンビが向かっていく
        }
    }
}
