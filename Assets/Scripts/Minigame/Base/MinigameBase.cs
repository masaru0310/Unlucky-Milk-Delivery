using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBase : MonoBehaviour
{
    /// <summary>
    /// 発生確率
    /// </summary>
    protected int incidenceNum;

    /// <summary>
    /// true : ミニゲーム開始, false : ミニゲーム不発
    /// </summary>
    public bool isStartMinigame;

    void Start()
    {
        incidenceNum = 40;
        isStartMinigame = false;
    }




    /// <summary>
    /// ミニゲーム発生エリアに触れた後の処理
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("衝突");

        // ① 触れたのが、プレイヤー以外だったら処理を終了
        if (other.gameObject.tag != "Player") return;
        Debug.Log("触れたのがバイク");

        // ② ミニゲームの開始条件を達成していなかったら終了
        if (IsJudgeStart() == false) return;

        // ミニゲーム開始を決める乱数を出力
        int randomNum = Random.Range(1, 100);

        Debug.Log($"乱数 : {randomNum}");

        // ※ ここでプレイヤーの順位を確認し、順位によって確率を変更させる

        // ③ 発生させる確率を引き当てたら、不運ミニゲーム開始
        if (randomNum <= incidenceNum) isStartMinigame = true;
    }


    /// <summary>
    /// 触れた時と追加での発生条件
    /// </summary>
    /// <returns></returns>
    protected virtual bool IsJudgeStart()
    {
        if (true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// ミニゲーム発生時の処理
    /// </summary>
    protected virtual void FuncMinigame()
    {

    }
}
