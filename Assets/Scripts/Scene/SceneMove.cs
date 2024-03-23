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

    // �ϐ�
    [Header("�J�ڐ�̃V�[��ID��ݒ�")]
    [SerializeField] private SceneID _destinationNumber;

    void Start()
    {
        
    }

    public void OnClickSceneMoveButton()
    {
        SceneManager.LoadScene((int)_destinationNumber);
    }
}
