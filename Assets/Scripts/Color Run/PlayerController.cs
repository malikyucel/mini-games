using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float jumpForce;
    [SerializeField] public float speed;
    [SerializeField] private float speedIncrease;
    [SerializeField] private float speedIncreaseTime;
    [SerializeField] float transitionSpeed;
    [SerializeField] private float[] PosX = {-2.25f, -0.75f, 0.75f, 2.25f};
    [SerializeField] private int currentPath;
    [SerializeField] private SO playerData;

    private void Start() 
    {
        GameObject playerCharacter = Instantiate(playerData.playersCharacter,transform.position,transform.rotation);
        playerCharacter.transform.SetParent(transform);

        currentPath = 1;
        StartCoroutine(SpeedIncrease());
    }
    private void Update() 
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

        Vector3 targetPos = new Vector3(PosX[currentPath],transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos + Vector3.forward * Time.deltaTime * speed, transitionSpeed * Time.deltaTime);
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
        Invoke(nameof(miniJump),0);
    }
    void miniJump()
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.VelocityChange);
    }
    IEnumerator SpeedIncrease()
    {
        while(true)
        {
            yield return new WaitForSeconds(speedIncreaseTime);
            speed += speedIncrease;
        }
    }
}
