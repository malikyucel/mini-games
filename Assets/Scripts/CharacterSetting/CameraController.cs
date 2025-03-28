using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float speed;
    [SerializeField] private float decemberMax = 5;
    [SerializeField] private float decemberMin = 0;

    [Header("Input")]
    [SerializeField] private float verticalInput, horizontalInput;

    [Header("Buttons")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;


    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            KeyboardController();


        leftButton.onClick.AddListener(LeftButton);
        rightButton.onClick.AddListener(RightButton);
        upButton.onClick.AddListener(UpButton);
        downButton.onClick.AddListener(DownButton);
    }

    void KeyboardController()
    {
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


    #region Buttons
    void LeftButton()
    {
        Vector3 targetPos = new Vector3(0f,  transform.position.y, -6.25f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
    }
    void RightButton()
    {
        Vector3 targetPos = new Vector3(3.25f, transform.position.y, -6.25f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
    }
    void UpButton()
    {
        Vector3 targetPos = new Vector3(transform.position.x, 3f, -6.25f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
    }
    void DownButton()
    {
        Vector3 targetPos = new Vector3(transform.position.x, -2f, -6.25f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);
    }
    #endregion
}
