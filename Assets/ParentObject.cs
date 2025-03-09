using UnityEngine;

public class ParentObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private float moveX;
    private void Update() 
    {
        moveX = Input.GetAxis("Mouse X");

         transform.Rotate(0,moveX * Time.deltaTime * speed,0);
    }
}
