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

    // •Ï”
    [Header("‘JˆÚæ‚ÌƒV[ƒ“ID‚ğİ’è")]
    [SerializeField] private SceneID _destinationNumber;

    void Start()
    {
        
    }

    public void OnClickSceneMoveButton()
    {
        SceneManager.LoadScene((int)_destinationNumber);
    }
}
