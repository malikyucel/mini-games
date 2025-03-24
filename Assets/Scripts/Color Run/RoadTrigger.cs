using UnityEngine;

public class RoadTrigger : MonoBehaviour, IFunction
{
    public void Function()
    {
        RoadSpawnManager.Instance.ColorPanelSpawn();
        RoadSpawnManager.Instance.RoadSpawn();
    }
}
