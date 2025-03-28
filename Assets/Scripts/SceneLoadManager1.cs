using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager1 : MonoBehaviour
{
    public static SceneLoadManager1 Instante;

    private void Awake() 
    {
        if(Instante == null)
            Instante = this;

        DontDestroyOnLoad(this);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
