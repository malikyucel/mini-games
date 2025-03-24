using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    [Header("ScriptableObject")] 
    [SerializeField] private SO playersCharacter;
    [SerializeField] private CharacterSO characterSO;

    [Header("UI Elements")]
    [SerializeField] private GameObject buyPanel;
    [SerializeField] private GameObject purchasedPanel;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button purchasedButton;

    [Header("Character Properties")]
    [SerializeField] private float price;
    [SerializeField] private float purchasePrice;
    [SerializeField] private string buyUpdate;

    [Header("Character Selection")]
    private GameObject _playersCharacter;
    private GameObject selectObject;
    [SerializeField] private GameObject selectionObjectPanelPos;
    [SerializeField] private GameObject _selectedCharacterIndex;

    [Header("Character Selection Setting")]
    private int _selecetObject;
    [SerializeField] private bool selectInActive = true;

    [Header("Shop Items")]
    List<ShopItem> shopItems = new List<ShopItem>();

    [SerializeField] private Transform camPos;

    [System.Serializable]
    public class ShopItem
    {
        public float price;
        public GameObject character;
        public ShopItem(GameObject character, float price)
        {
            this.price = price;
            this.character = character;
        }
    }

    private void Start() 
    {
        Time.timeScale = 1f;

        closeButton.onClick.AddListener(ClosePanelButton);
        buyButton.onClick.AddListener(BuyButton);
        purchasedButton.onClick.AddListener(Purchased);

        InstantiateCharacters();

        GameCharacters();

    }
    private void Update() 
    {

        if (Input.GetMouseButtonDown(0) && selectInActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag("Close"))
                {
                    selectInActive = false;
                    SceneManager.LoadScene(Conts.Scenes.GAMES_SELECTİON_SCENE);
                    return;
                }
                if(hit.transform.CompareTag("Character"))
                {
                    selectInActive = false;
                    buyPanel.transform.DOScale(Vector3.zero, 0.5f).From().SetEase(Ease.OutBack);
                    buyPanel.SetActive(true);

                    GameObject _selectCharacter = hit.transform.gameObject;

                    if(_selectedCharacterIndex != null)
                    {
                        Destroy(_selectedCharacterIndex);
                    }

                    _selectedCharacterIndex = Instantiate(_selectCharacter);
                    _selectedCharacterIndex.transform.SetParent(selectionObjectPanelPos.transform);
                    _selectedCharacterIndex.transform.localPosition = new Vector3(.1f,0,-1);

                    UpdatePriceText(hit.transform.gameObject);
                }
                else if(hit.transform.CompareTag("CharacterSlelect"))
                {
                    SelectedCharacterUpdate(hit.transform.gameObject);
                    GameCharacters();
                }
            }
        }
    }
    
    void UpdatePriceText(GameObject selectedCharacter)
    {
        for(int i = 0; i < shopItems.Count; i++)
        {
            GameObject selectObject = characterSO.Characters[i];
            if (selectObject.name == selectedCharacter.name.Replace("(Clone)", "").Trim())
            {
                this.selectObject = selectObject;
                purchasePrice = characterSO.price[i];
                _selecetObject = i;
                priceText.text = playersCharacter.PlayerCoinData + " Coin" + "\nPrice: " + purchasePrice;
                return;
            }
        }
    }
    
    // current character
    void GameCharacters()
    {
        if(_playersCharacter != null)
        {
            Destroy(_playersCharacter.gameObject);
        }
        _playersCharacter = Instantiate(playersCharacter.playersCharacter,new Vector3(0.5f,5.5f,-1),transform.rotation);
        _playersCharacter.AddComponent<RotateCharacter>();
    }
    
    // current character update
    void SelectedCharacterUpdate(GameObject selecetUpdate)
    {
        for(int i = 0; i < playersCharacter.availableCharacters.Count; i++)
        {
            if(playersCharacter.availableCharacters[i].name == selecetUpdate.name.Replace("(Clone)", "").Trim())
            {
                playersCharacter.playersCharacter = playersCharacter.availableCharacters[i];
            }
        }
    }
    
    #region ShopsCharacterAndPlayersCharacterSpawn
    void InstantiateCharacters()
    {
        float posX;
        float posY = 4.5f;
        for(int i = 0; i < characterSO.Characters.Length; i++)
        {
            shopItems.Add(new ShopItem(characterSO.Characters[i], characterSO.price[i]));
            if(i % 2 == 0)
            {
                posX = -0.5f;
                GameObject _character = Instantiate(shopItems[i].character, new Vector3(posX,posY,-1f),shopItems[i].character.transform.rotation);
                _character.AddComponent<BoxCollider>();
                _character.AddComponent<RotateCharacter>();
            }
            else
            {
                posX = 0.5f;
                GameObject _character = Instantiate(shopItems[i].character, new Vector3(posX,posY,-1f),shopItems[i].character.transform.rotation);
                _character.AddComponent<BoxCollider>();
                _character.AddComponent<RotateCharacter>();
                posY -= 1;
            }
        }
        float characterPosX;
        float characterPosY = 4.5f;
        for(int i = 0; i < playersCharacter.availableCharacters.Count; i++)
        {
            if(i % 2 == 0)
            {
                characterPosX = 3.75f;
                GameObject _character = Instantiate(playersCharacter.availableCharacters[i], 
                    new Vector3(characterPosX,characterPosY,-1f),playersCharacter.availableCharacters[i].transform.rotation);
                _character.AddComponent<BoxCollider>();
                _character.AddComponent<RotateCharacter>();
                _character.tag = "CharacterSlelect";
            }
            else
            {
                characterPosX = 2.50f;
                GameObject _character = Instantiate(playersCharacter.availableCharacters[i], 
                    new Vector3(characterPosX,characterPosY,-1f),playersCharacter.availableCharacters[i].transform.rotation);
                _character.AddComponent<BoxCollider>();
                _character.AddComponent<RotateCharacter>();
                _character.tag = "CharacterSlelect";
                characterPosY -= 1;
            }
        }
    }
    #endregion

    #region Buttons
    void ClosePanelButton()
    {
        buyPanel.SetActive(false);
        selectInActive = true;
    }
    void BuyButton()
    {
        if (playersCharacter.PlayerCoinData > purchasePrice)
        {
            bool notBuy = true;
            foreach (var character in playersCharacter.availableCharacters)
            {
                if (_selectedCharacterIndex.name.Replace("(Clone)", "").Trim() == character.name)
                {
                    notBuy = false;
                    break;
                }
            }

            if (notBuy)
            {
                playersCharacter.PlayerCoinData -= purchasePrice;
                playersCharacter.availableCharacters.Add(characterSO.Characters[_selecetObject]);
                priceText.text = playersCharacter.PlayerCoinData + " Coin" + "\nPrice: " + purchasePrice;
                playersCharacter.playersCharacter = characterSO.Characters[_selecetObject];
                
                buyPanel.SetActive(false);
                purchasedPanel.SetActive(true);
                purchasedPanel.transform.DOScale(Vector3.zero, 1f).From().SetEase(Ease.OutBack);
            }
        }
    }
    void Purchased()
    {
        purchasedPanel.SetActive(false);
        selectInActive = true;
    }
    #endregion
}
