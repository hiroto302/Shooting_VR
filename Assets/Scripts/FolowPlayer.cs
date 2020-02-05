using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FolowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;  //プレイヤー視点のカメラを指す
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");  //タグ識別によるオブジェクト検索
    }

    void Update()
    {
        agent.destination = player.transform.position;  //playerの位置にゾンビが向かっていく
    }
}
