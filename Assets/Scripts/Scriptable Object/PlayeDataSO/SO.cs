using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Data/Player Data")]
public class SO : ScriptableObject
{
    public float PlayerCoinData;
    public string PlayerNameData;
    public GameObject playersCharacter;
    public List<GameObject> availableCharacters = new List<GameObject>();
}
