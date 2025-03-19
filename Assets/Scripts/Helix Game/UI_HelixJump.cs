using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_HelixJump : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SO playerData;
    [SerializeField] private TextMeshProUGUI playerCoinName;
    [SerializeField] private GameObject menuPanel;

    [Header("Buttons")]
    [SerializeField] private Button MenuButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button exetButton;

    private void Start() 
    {
        Time.timeScale = 1f;
        MenuButton.onClick.AddListener(MenuPanelButton);
        resetButton.onClick.AddListener(ResetButton);
        continueButton.onClick.AddListener(ContinueButton);
        exetButton.onClick.AddListener(ExetButton);    
    }
    private void FixedUpdate() 
    {
        playerCoinName.text = "Name: " + playerData.PlayerNameData + "\nCoin: " + playerData.PlayerCoinData;
    }
    void MenuPanelButton()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }
    void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    void ContinueButton()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }
    void ExetButton()
    {
        SceneManager.LoadScene(Conts.Scenes.GAMES_SELECTİON_SCENE);
    }
}
