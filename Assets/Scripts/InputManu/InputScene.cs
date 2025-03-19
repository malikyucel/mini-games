using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputScene : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] SO playerData;
    [SerializeField] GameObject playerSavePanel;
    [SerializeField] TMP_InputField playerName;

    [Header("Button")]
    [SerializeField] Button loginButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button savePlayerButton;
    [SerializeField] Button exitPanelButton;
    
    private void Start() 
    {
        loginButton.onClick.AddListener(LoginButton);
        exitButton.onClick.AddListener(ExitButton);
        savePlayerButton.onClick.AddListener(SavePlayerButton);
        exitPanelButton.onClick.AddListener(ExitPanelButton);
    }
    private void LoginButton()
    {
        if(playerData.PlayerNameData == "")
        {
            playerSavePanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    private void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    private void SavePlayerButton()
    {
        Debug.Log("Çalıştı");
        playerData.PlayerNameData = playerName.text;
        playerSavePanel.SetActive(false);
    }
    private void ExitPanelButton()
    {
        playerSavePanel.SetActive(false);
    }
}
