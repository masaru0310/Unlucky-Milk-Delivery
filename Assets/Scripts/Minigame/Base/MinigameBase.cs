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
    /// 注意!! ④つの条件を満たすと、ミニゲームが開始される
    /// </summary>
    /// <param name="other"></param>
    protected void OnCollisionEnter(Collision collision)
    {
        // ① 触れたのが、プレイヤー以外だったら処理を終了
        if (collision.gameObject.tag != "Player") return;

        // ② 各ミニゲームごとの開始条件を達成していなかったら終了
        // ※ 注意!! 条件は、継承先で定義される
        if (IsJudgeStart() == false) return;

        // ③ ミニゲーム発生するための方向に進行しているか
        if (IsJudgeInRightDirection(collision) == false) return;

        // ミニゲーム開始を決める乱数を出力
        int randomNum = Random.Range(1, 100);

        // ※ ここでプレイヤーの順位を確認し、順位によって確率を変更させる

        // ④ 発生させる確率を引き当てたら、継承先で不運ミニゲーム開始
        if (randomNum <= incidenceNum) isStartMinigame = true;
    }


    private bool IsJudgeInRightDirection(Collision collision)
    {
        // 大まかな衝突位置を検出
        Vector3 hitPos = collision.contacts[0].point;

        // キャラクター正面から見た衝突位置の角度を取得
        Vector3 diff = hitPos - transform.position;
        Vector3 axis = Vector3.Cross(transform.forward, diff);
        float angle = Vector3.Angle(transform.forward, diff) * (axis.y < 0 ? -1 : 1);

        Debug.Log($"角度 : {angle}");

        if ((angle <= 145.0f && angle >= 128.0f) || (angle >= -145.0f && angle <= -128.0f))
        {
            //// コリジョンから見て、プレイヤーがまっすぐ進んでいるかを確認
            //if (Mathf.Abs(angle) <= 90.0f)
            //{
            //    return true;
            //}
            //// 別の角度から衝突した場合は、ミニゲーム発生条件を満たさない
            //else return false;
            Debug.Log("正面から突進");
            return true;
        }
        else
        {
            Debug.Log("正面から突進していない");
            return false;
        }
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
