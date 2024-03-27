using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWhereMinigame : MonoBehaviour
{
    // 外部ゲームクラス
    

    // 変数
    [SerializeField] private MinigameData.ID _minigameID;            // このIDに基づき、開始するミニゲームを決める

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<BikeController>() == true)
        {
            // ミニゲームスタート
        }
    }
}
