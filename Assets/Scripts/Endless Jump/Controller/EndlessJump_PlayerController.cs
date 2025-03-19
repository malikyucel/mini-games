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
