using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _pcPos;

    // ’è”
    private const float _POS_Z_DIST_TO_PC = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NormalMove();
    }


    /// <summary>
    /// ’Êí‚ÌƒJƒƒ‰‹““®
    /// </summary>
    public void NormalMove()
    {
        Vector3 pcPos = _pcPos.transform.position;
        transform.position = new Vector3(pcPos.x, pcPos.y, pcPos.z - _POS_Z_DIST_TO_PC);
    }
}
