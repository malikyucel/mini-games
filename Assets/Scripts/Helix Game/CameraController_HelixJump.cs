using UnityEngine;

public class CameraController_HelixJump : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offSet;
    [Header("Setting")]
    [SerializeField] private float followSpeed;

    private void Update() 
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offSet, followSpeed * Time.deltaTime); 
    }
}
