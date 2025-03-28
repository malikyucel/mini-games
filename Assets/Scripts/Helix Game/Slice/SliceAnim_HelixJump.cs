using UnityEngine;
using DG.Tweening;

public class SliceAnim_HelixJump : MonoBehaviour
{
    [SerializeField] private Transform targetPos;

    private void Start() 
    {
        targetPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update() 
    {
        if(transform.position.y > targetPos.transform.position.y)
        {
            float rotate = Random.Range(0,180);
            float move = Random.Range(1,3);
            transform.DOMove(new Vector3(transform.position.x, transform.position.y + move), 2f);
        }
    }
}
