using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // プレイヤーに衝突したら、
        if (other.gameObject.GetComponent<PlayerParameter>() == false) return;

        // 宅配エリア内でSpaceキー入力 → ミルク宅配完了
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            // ミルクを配達完了
            other.gameObject.GetComponent<PlayerParameter>().DeliveredMilk();
        }
    }

}
