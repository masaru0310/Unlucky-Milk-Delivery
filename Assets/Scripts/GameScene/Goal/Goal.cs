using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    // 変数
    public bool _isTouchThePlayer;     // true : プレイヤーに触れている, false : プレイヤーに触れていない
    private GameObject _touchedObject;  // 触れたオブジェクト

    private UIManager _uiManagerObj;

    // Start is called before the first frame update
    void Start()
    {
        _isTouchThePlayer = false;

        // UIマネージャーを取得
        if (GameObject.FindWithTag("Canvas").GetComponent<UIManager>() != null)
        {
            _uiManagerObj = GameObject.FindWithTag("Canvas").GetComponent<UIManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isTouchThePlayer == true)
        {
            Debug.Log("Spaceボタンを押して、ミルクを減らす");

            // 宅配エリア内でSpaceキー入力 → ミルク宅配完了
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                // ミルクを配達完了
                _touchedObject.gameObject.GetComponent<PlayerParameter>().DeliveredMilk();
                // 触れたオブジェクトを空にする
                _touchedObject = null;
                // 触れていない状態に戻す
                _isTouchThePlayer = false;
                // ミルクお届けUIを非表示
                _uiManagerObj.IsDeliveredMilkImageActiveProp = false;

                // デリバリーポイントを削除
                Destroy(this.gameObject);
            }

        }
        else
        {
            // 触れたオブジェクトを空にする
            _touchedObject = null;
            // 触れていない状態に戻す
            _isTouchThePlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ゴールに触れている");

        // プレイヤーに衝突したら、
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        _isTouchThePlayer = true;

        _touchedObject = other.gameObject;

        // ミルクお届けUIを表示
        _uiManagerObj.IsDeliveredMilkImageActiveProp = true;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ゴールに触れている");

        // プレイヤーに衝突したら、
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        _isTouchThePlayer = false;

        _touchedObject = null;

        // ミルクお届けUIを非表示
        _uiManagerObj.IsDeliveredMilkImageActiveProp = false;
    }

}