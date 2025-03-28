using UnityEngine;

public class EndlessJump_PlayerController : MonoBehaviour
{
    [Header("Reference")]
    private Rigidbody playerRb;
    [SerializeField] private SO characterRenderer;

    [Header("Setting")]
    [SerializeField] private GameObject playerCharacters;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float touchSpeed;

    [Header("Input")]
    [SerializeField] private float horizontalValue;
    
    private void Start() 
    {
        playerRb = gameObject.GetComponent<Rigidbody>();    
        playerCharacters = Instantiate(characterRenderer.playersCharacter,transform.position,transform.rotation);
        playerCharacters.transform.SetParent(transform);
    }
    private void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            KeyboardControl();


        TouchController();

        // Teleport to the other side
        if(transform.position.x < -2.5f)
        {
            Vector3 targetPos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            transform.position = targetPos;
        }
        if(transform.position.x > 2.5f)
        {
            Vector3 targetPos = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            transform.position = targetPos;
        }
    }
    void TouchController()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                float xPosition = touch.deltaPosition.x * touchSpeed * Time.deltaTime * -1;
                transform.Translate(Time.deltaTime * speed * xPosition, 0, 0);
            }
        }
    }
    void KeyboardControl()
    {
        if(Input.GetKey(KeyCode.D))
        {
            horizontalValue = Input.GetAxis("Horizontal");
            transform.Translate(-1 * Time.deltaTime * speed * horizontalValue,0,0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            horizontalValue = Input.GetAxis("Horizontal");
            transform.Translate(-1 * Time.deltaTime * speed * horizontalValue,0,0);
        }

        if(transform.position.x < -2.25f)
        {
            transform.Translate(4.25f,0,0);
        }
        if(transform.position.x > 2.25f)
        {
            transform.Translate(-4.25f,0,0);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            float randum = Random.Range(0,90);
            Quaternion randumRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            playerCharacters.transform.rotation = Quaternion.Slerp(transform.rotation,randumRotation,.1f);

            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if(other.gameObject.TryGetComponent<IFunction>(out var function))
        {
            function.Function();
        }
    }
}
