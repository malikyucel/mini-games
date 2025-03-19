using System.Collections;
using UnityEngine;
public class EndlessJump_Ground : MonoBehaviour,IFunction
{
    [Header("Reference")]

    [SerializeField] SO PlayerData;
    private Transform target;

    [Header("Setting")]
    [SerializeField] private float jumpForce; 
    [SerializeField] private bool IsTrigger;
    
    [Header("Direction X")]
    [SerializeField] private int[] values = {-1,1};
    [SerializeField] private int moveX;
    private void Start() 
    {
        target = GameObject.Find("Player").GetComponent<Transform>();  
        moveX = values[Random.Range(0,2)]; 
    }

    private void FixedUpdate() 
    {
        UpdateMovementWithDepth();
        MoveDirection();
    }
    
    void UpdateMovementWithDepth()
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
        transform.Translate(moveX * EndlessJump_GroundManager.Instance.groundSpeed * Time.deltaTime,0,0);
    }
    void MoveDirection()
    {
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
        if(!IsTrigger)
        {
            EndlessJump_GroundManager.Instance.GroundSpawnManager();
            IsTrigger = true;
            PlayerData.PlayerCoinData++;
        }
    }
}
