using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

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
        Invoke(nameof(TimeScene),0.4f);
        menuPanel.transform.DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.OutBack);
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
    void TimeScene()
    {
        Time.timeScale = 0f;
    }
}
