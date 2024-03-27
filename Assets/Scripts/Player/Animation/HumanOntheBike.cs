using UnityEngine;

public class HumanOntheBike : MonoBehaviour
{
    public Animator Animator { get { return GetComponent<Animator>(); } }

    [SerializeField]
    private Transform _leftHandIkTarget;
    [SerializeField, Range(0, 1)]
    private float _ikWeight;

    private void OnAnimatorIK(int layerIndex)
    {
        if (_leftHandIkTarget != null)
        {
            Debug.Log("左ハンドルあり");
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _ikWeight);
            Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _ikWeight);
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandIkTarget.position);
            Animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandIkTarget.rotation);
        }

        Debug.Log("左ハンドル無");
    }
}