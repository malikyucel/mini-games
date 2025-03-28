using System.Collections;
using UnityEngine;

public class EndlessJump_GroundManager : MonoBehaviour
{
    [Header("Refenence")]
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private AudioSource audioSource;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip dropSound;

    [Header("Setting")]
    [SerializeField] private int difficulity;
    [SerializeField] private int difficulityTime;
    [SerializeField] public float groundSpeed;

    [Header("Object Spawn Pos")]
    private float PosX_ground;
    private float PosX_obstacle;
    [SerializeField] private float spawnPosY;

    public static EndlessJump_GroundManager Instance;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }
    private void Start() 
    {
        for(int i = 0; i < 15; i++)
        {
            GroundSpawnManager();
        }
        StartCoroutine(nameof(DifficulityIncrease));
    }
    public void GroundSpawnManager()
    {
        int obstacleRandInst = Random.Range(0,difficulity);
        if(obstacleRandInst <= 1)
        {
            float Randum_posY = Random.Range(spawnPosY -1,spawnPosY + 1);
            GameObject _obstacle = Instantiate(obstacle,new Vector3(PosX_obstacle,Randum_posY,0),transform.rotation);
            _obstacle.name = "Obstacle";
        }
        Instantiate(ground, new Vector3(PosX_ground,spawnPosY,0),transform.rotation);
        spawnPosY += 1.5f;
    }
    IEnumerator DifficulityIncrease()
    {
        while(difficulity > 0)
        {
            groundSpeed += 0.1f;
            yield return new WaitForSeconds(difficulityTime);
            difficulity--;
        }
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void DropSound()
    {
        audioSource.PlayOneShot(dropSound);
    }
    
}
