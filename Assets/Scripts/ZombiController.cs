using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombiController : MonoBehaviour
{
    Animator animator;
    GameObject player;
    public float rangeDistance = 2.0f;  //攻撃判定距離
    public bool CanWalk {get; private set;}  //ゾンビの歩行判定フラグ
    public GameObject explosionPrefab;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        CanWalk = true;
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

    //銃でゾンビを撃った後の処理
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //ゾンビが倒れるメソッドの呼び出し
            FallDown();
        }
    }

    void FallDown()
    {
        //動きを止める
        CanWalk = false;
        //倒れるアニメーション
        animator.SetTrigger("FallDown");
        //ゾンビを消す
        Invoke("DestroyZombi", 1.0f);
    }

    void DestroyZombi()
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
    }

    void Attack()
    {
        //攻撃するアニメーション
        animator.SetTrigger("Attack");

        //ゲームオーバー画面に移動
        Invoke("GameOver", 1.0f);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
