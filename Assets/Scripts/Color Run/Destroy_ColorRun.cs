using UnityEngine;

public class Destroy_ColorRun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(other.gameObject);    
    }
}
