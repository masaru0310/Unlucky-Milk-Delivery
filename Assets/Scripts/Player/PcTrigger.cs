using UnityEngine;

public class PcTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMove _pcMoveObj;
    [SerializeField] private StartMinigame_Bike _minigamebikeObj;

    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BootUnlucky"))
        {
            Debug.Log("Trigger On!");
            _minigamebikeObj.StartMinigameProp = true;

            _pcMoveObj.StartMinigameProp = true;    // PC‚Ì’ÊíˆÚ“®ˆ—‚ğ’†~
        }
    }
}
