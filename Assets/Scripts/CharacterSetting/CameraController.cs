using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float speed;
    [SerializeField] private float decemberMax = 5;
    [SerializeField] private float decemberMin = 0;

    [Header("Inpıt")]
    [SerializeField] private float verticalInput, horizontalInput;
    
    private void FixedUpdate(){
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(speed * Time.deltaTime * horizontalInput,speed * Time.deltaTime * verticalInput,0);
        if(transform.position.y < -2)
        {
            transform.position = new Vector3(transform.position.x,-2,transform.position.z);
        }
        else if(transform.position.y > 3)
        {
            transform.position = new Vector3(transform.position.x,3,transform.position.z);
        }

        if(transform.position.x < 0)
        {
            transform.position = new Vector3(0,transform.position.y,transform.position.z);
        }
        if(transform.position.x > 3.50)
        {
            transform.position = new Vector3(3.50f,transform.position.y,transform.position.z);
        }
    }
}
