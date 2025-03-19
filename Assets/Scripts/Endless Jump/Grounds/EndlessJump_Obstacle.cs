using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessJump_Obstacle : MonoBehaviour,IFunction
{
    [Header("Reference")]
    private Transform target;
    [SerializeField] private SO playerCoin;

    [Header("Setting")]
    [SerializeField] float speed;
    [SerializeField] private int deductCoin;

    [Header("Direction X")]
    private int moveX;
    int[] values = {-1,1};
    private void Start() 
    {
        target = GameObject.Find("Player").GetComponent<Transform>();  
        moveX = values[Random.Range(0,2)]; 
    }
    private void FixedUpdate() 
    {
        if(target.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            StartCoroutine(PosUpdateTime());
        }
        else
        {
            Vector3 currentPos = transform.position;
            currentPos.z = 1;
            transform.position = currentPos;
        }
        transform.Translate(moveX * speed * Time.deltaTime,0,0);

        if(transform.position.x < -2)
        {
            moveX *= -1;
        }
        else if(transform.position.x > 2)
        {
            moveX *= -1;
        }
    }
    IEnumerator PosUpdateTime()
    {
        yield return new WaitForSeconds(0.3f);
        Vector3 currentPos = transform.position;
        currentPos.z = 0;
        transform.position = currentPos;
    }

    public void Function()
    {
        if(playerCoin.PlayerCoinData < deductCoin)
        {
            playerCoin.PlayerCoinData = 0;
        }
        else
        {
            playerCoin.PlayerCoinData -= deductCoin;
        }
        SceneManager.LoadScene(Conts.Scenes.ENDLESS_JUMP_SCENE);
    }
}
