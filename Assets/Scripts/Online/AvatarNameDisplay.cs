using Photon.Pun;
using TMPro;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
public class AvatarNameDisplay : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        TextMeshPro nameLabel = this.GetComponent<TextMeshPro>();

        Debug.Log(nameLabel);
        // �v���C���[���ƃv���C���[ID��\������
        nameLabel.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
    }
}