using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_HelixJump : MonoBehaviour
{
    [Header("Reference")]
    private Rigidbody playerRb;
    [SerializeField] private int playerCoinPuls;
    [SerializeField] private int playerCoinReduce;
    [SerializeField] private SO playerCoinNameSO;
    [SerializeField] private CharacterSO characterRenderer;

    [Header("Setting")]
    [SerializeField] private GameObject playerCharacters;
    [SerializeField] private float jumpForce;
    private bool IsJumping = true;
    
    private void Start() 
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerCharacters = Instantiate(playerCoinNameSO.playersCharacter,transform.position,transform.rotation);
        playerCharacters.transform.SetParent(transform);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground") && IsJumping)
        {
            SliceSound.Instanse.Slice();
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce);
            Invoke(nameof(RessetJump), 0.2f);
            IsJumping = false;
        }
        else if(other.gameObject.CompareTag("Interactive"))
        {
            SliceSound.Instanse.RedSlice();
            if(playerCoinNameSO.PlayerCoinData < playerCoinReduce)
            {
                playerCoinNameSO.PlayerCoinData = 0;
            }
            else
            {
                playerCoinNameSO.PlayerCoinData -= playerCoinReduce;
            }
            SceneLoadManager1.Instante.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(other.gameObject.CompareTag("Reset"))
        {
            SliceSound.Instanse.FinishSlice();
            playerCoinNameSO.PlayerCoinData += playerCoinPuls;
            SceneLoadManager1.Instante.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }

    void RessetJump()
    {
        IsJumping = true;
    }
}
