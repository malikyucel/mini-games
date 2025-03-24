using UnityEngine;

public class Game_Over : MonoBehaviour, IFunction
{
    public void Function()
    {
        RoadSpawnManager.Instance.GameOver();
    }
}
