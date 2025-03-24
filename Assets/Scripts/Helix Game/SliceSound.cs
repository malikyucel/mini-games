using UnityEngine;

public class SliceSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip  slice;
    [SerializeField] private AudioClip redSlice;
    [SerializeField] private AudioClip finihSlice;

    public static SliceSound Instanse;
    private void Awake() 
    {
        if(Instanse == null)
            Instanse = this;
    }
    public void Slice()
    {
        audioSource.PlayOneShot(slice);
    }
    public void RedSlice()
    {
        audioSource.PlayOneShot(redSlice);
    }
    public void FinishSlice()
    {
        audioSource.PlayOneShot(finihSlice);
    }
}
