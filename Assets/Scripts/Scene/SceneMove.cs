using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private enum SceneID
    {
        Title,
        ModeSelect,
        GameScene
    }

    // 変数
    [Header("遷移先のシーンIDを設定")]
    [SerializeField] private SceneID _destinationNumber;

    void Start()
    {
        
    }

    public void OnClickSceneMoveButton()
    {
        SceneManager.LoadScene((int)_destinationNumber);
    }
}
