using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessJump_DestroyObject : MonoBehaviour, IFunction
{
    [Header("Reference")]
    [SerializeField] private SO playerCoin;
    [SerializeField] private int deductCoin;

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
        StartCoroutine(SceneLoadTime());
    }

    IEnumerator SceneLoadTime()
    {
        EndlessJump_GroundManager.Instance.DropSound();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(Conts.Scenes.ENDLESS_JUMP_SCENE);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
