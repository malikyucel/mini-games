using UnityEngine;

public class EndlessJump_CameraController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject target;
    [Header("Setting")]
    [SerializeField] private float followSpeed;
    [SerializeField] private float Y_PlusPos;

    private void Update() 
    {
        if(Y_PlusPos <= target.transform.position.y)
        {
            Y_PlusPos = target.transform.position.y;
        }
        transform.position = Vector3.Lerp(transform.position, new Vector3(0,Y_PlusPos + 1.0f,10), followSpeed * Time.deltaTime);     
    }
}
