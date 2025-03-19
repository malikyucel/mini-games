using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    public string scene;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }
    private void Start() 
    {
        scene = SceneManager.GetActiveScene().name;    
    }
    private void Update() 
    {
        if(scene != SceneManager.GetActiveScene().name)
        {
            scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scene);
        }    
    }
}
