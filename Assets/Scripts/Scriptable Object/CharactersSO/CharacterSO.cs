using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Characters")]
public class CharacterSO : ScriptableObject
{
    public GameObject[] Characters;
    public float[] price;
}
