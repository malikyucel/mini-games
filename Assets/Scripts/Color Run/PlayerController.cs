using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private SO playerData;

    [Header("Setting")]
    [SerializeField] private float jumpForce;
    [SerializeField] public float speed;
    [SerializeField] private float speedIncrease;
    [SerializeField] private float speedIncreaseTime;
    [SerializeField] float transitionSpeed;
    [SerializeField] private float[] PosX = {-2.25f, -0.75f, 0.75f, 2.25f};
    [SerializeField] private int currentPath;
    
    [Header("UI")]
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    private void Start() 
    {
        GameObject playerCharacter = Instantiate(playerData.playersCharacter,transform.position,transform.rotation);
        playerCharacter.transform.SetParent(transform);

        currentPath = 1;
        StartCoroutine(SpeedIncrease());

        leftButton.onClick.AddListener(LeftButton);
        rightButton.onClick.AddListener(RightButton);
    }
    private void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            KeyboradController();
        
        Vector3 targetPos = new Vector3(PosX[currentPath],transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos + Vector3.forward * Time.deltaTime * speed, transitionSpeed * Time.deltaTime);
    }
    
    void MiniJump()
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.VelocityChange);
    }
    void LeftButton()
    {
        if(currentPath > 0)
            currentPath--;
    }
    void RightButton()
    {
        if(currentPath < PosX.Length - 1)
            currentPath++;
    }
    void KeyboradController()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(currentPath > 0)
                currentPath--;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(currentPath < PosX.Length - 1)
                currentPath++;
        }
    }
    IEnumerator SpeedIncrease()
    {
        while(true)
        {
            yield return new WaitForSeconds(speedIncreaseTime);
            speed += speedIncrease;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<IFunction>(out var function))
        {
            function.Function();
        }
    }
    private void OnCollisionStay(Collision other) 
    {
        Invoke(nameof(MiniJump),0);
    }
}
