using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class EndlessJump_UI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SO playerData;
    [SerializeField] private TextMeshProUGUI playerCoinName;
    [SerializeField] private GameObject menuPanel;

    [Header("UI Button")]
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
    public void MenuPanelButton()
    {
        menuPanel.transform.DOScale(Vector3.zero, 0.5F).From().SetEase(Ease.OutBack);
        menuPanel.SetActive(true);
        Invoke(nameof(timeScene),0.4f);
    }
    void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menuPanel.SetActive(false);
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
    void timeScene()
    {
        Time.timeScale = 0f;
    }
}
