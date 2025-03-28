using System;
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
    [SerializeField] private Button colorRun;
    [SerializeField] private Button characterSetting;
    
    [SerializeField] private TextMeshProUGUI playerNameCoinText;
    
    private void Start() 
    {
        characterSetting.onClick.AddListener(CharacterSetting);
        backButton.onClick.AddListener(LoadScene);

        helixJump.onClick.AddListener(Game1);
        endlessJump.onClick.AddListener(Game2);
        colorRun.onClick.AddListener(Game3);

        playerNameCoinText.text = "Name: " + NameCoinData.PlayerNameData + "\nCoin: " + NameCoinData.PlayerCoinData;
    }

    private void CharacterSetting()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.CHARACTER_SETTİNG);
    }
    private void LoadScene()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.LOGİN_SCENE);
    }

    #region Games
    private void Game1()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.HELİX_JUMP_SCENE);

    }
    private void Game2()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.ENDLESS_JUMP_SCENE);

    }
    private void Game3()
    {
        SceneLoadManager1.Instante.LoadScene(Conts.Scenes.COLOR_RUN);
    }
    #endregion
}
