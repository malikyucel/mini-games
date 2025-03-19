using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSlectionScene : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private SO NameCoinData;

    [Header("Buttons")]
    [SerializeField] private Button backButton;
    [SerializeField] private Button helixJump;
    [SerializeField] private Button endlessJump;
    [SerializeField] private Button characterSetting;
    
    [SerializeField] private TextMeshProUGUI playerNameCoinText;
    
    private void Start() 
    {
        characterSetting.onClick.AddListener(CharacterSetting);
        backButton.onClick.AddListener(LoadScene);

        helixJump.onClick.AddListener(Games1);
        endlessJump.onClick.AddListener(Games2);

        playerNameCoinText.text = "Name: " + NameCoinData.PlayerNameData + "\nCoin: " + NameCoinData.PlayerCoinData;
    }

    private void CharacterSetting()
    {
        SceneManager.LoadScene(Conts.Scenes.CHARACTER_SETTİNG);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(Conts.Scenes.LOGİN_SCENE);
    }

    private void Games1()
    {
        SceneManager.LoadScene(Conts.Scenes.HELİX_JUMP_SCENE);
        Invoke(nameof(SceneLoad),0.1f);
    }
    private void Games2()
    {
        SceneManager.LoadScene(Conts.Scenes.ENDLESS_JUMP_SCENE);
        Invoke(nameof(SceneLoad),0.1f);
    }
    void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
