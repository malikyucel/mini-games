using System.Collections;
using UnityEngine;

public class RoadSpawnManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform startPos;
    [SerializeField] private GameObject ColorPanel;
    [SerializeField] private GameObject[] roadObject;
    [SerializeField] private SO playerData;

    [Header("Setting")]
    [SerializeField] private float PosZColorPanel;
    [SerializeField] private float PosZColorPanel_2 = 28;
    [SerializeField] private float PosZRoad;
    [SerializeField] private float distance = 14;
    [SerializeField] private int coinPlus;
    [SerializeField] private int reduceCoin;
    
    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip trueAudioClip;
    [SerializeField] AudioClip falseAudioClip;
    

    public static RoadSpawnManager Instance;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        PosZColorPanel = startPos.rotation.z;

        Time.timeScale = 1f;
    }

    private void Start() 
    {
        for(int i = 0; i < 15; i++)
        {
            RoadSpawn();
        }

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void ColorPanelSpawn()
    {
        GameObject spawnColorPanel = Instantiate(ColorPanel, new Vector3(0,0,PosZColorPanel + PosZColorPanel_2), ColorPanel.transform.rotation);
        PosZColorPanel_2 = spawnColorPanel.transform.position.z + distance;
    }
    public void RoadSpawn()
    {
        float[] rottation = {0, 180};
        Quaternion rastRotation = Quaternion.Euler(transform.rotation.x, rottation[Random.Range(0,2)], transform.rotation.z);
        GameObject spawnRoad = Instantiate(roadObject[Random.Range(0,roadObject.Length)],new Vector3(0,0, PosZRoad + PosZColorPanel), rastRotation);
        PosZRoad = spawnRoad.transform.position.z + distance;
    }
    public void CoinPlus()
    {
        playerData.PlayerCoinData += coinPlus;
    }
    public void GameOver()
    {
        playerController.speed = 0;
        Vector3 playerPos = new Vector3(playerController.transform.position.x,playerController.transform.position.y, playerController.transform.position.z - 2f);
        playerController.transform.position = Vector3.Lerp(playerController.transform.position, playerPos, 0.3f);
        StartCoroutine(ScneLoadTime());
    }
    public void TrueSound()
    {
        audioSource.PlayOneShot(trueAudioClip);
    }

    IEnumerator ScneLoadTime()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.COLOR_RUN);
        audioSource.PlayOneShot(falseAudioClip);
        yield return new WaitForSeconds(2);
        if(playerData.PlayerCoinData > reduceCoin)
            playerData.PlayerCoinData -= reduceCoin;
        else
            playerData.PlayerCoinData = 0;
    }
}
