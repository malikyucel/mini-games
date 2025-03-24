using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ColorRun : MonoBehaviour
{
    [SerializeField] private List<Material> rendererMatariels;
    [SerializeField] private List<Material> selectColor;
    [SerializeField] private Renderer selectedObjectMatariel;
    [SerializeField] private List<GameObject> doorObjects;
    [SerializeField] private int selectedIndexRenderer;
    [SerializeField] private int selcetedIndexObject;
    [SerializeField] private TMP_Text ColorText;
    [SerializeField] private string[] colorNames = {"Pink", "Orange", "Green", "Gray", "Black", "Red"};
    private void Start()
    {
        selectedIndexRenderer = Random.Range(0,rendererMatariels.Count);
        selcetedIndexObject = Random.Range(0,4);

        ColorText.text = colorNames[selectedIndexRenderer];

        selectedObjectMatariel = doorObjects[selcetedIndexObject].GetComponent<Renderer>();
        selectedObjectMatariel.material = rendererMatariels[selectedIndexRenderer];
        selectedObjectMatariel.gameObject.AddComponent<TrueDoor>();
        selectedObjectMatariel.gameObject.tag = "TrueDoor";

        rendererMatariels.RemoveAt(selectedIndexRenderer);
        doorObjects.RemoveAt(selcetedIndexObject);

        for(int i = 0; i < doorObjects.Count; i++)
        {
            int randumMatIndex = Random.Range(0,rendererMatariels.Count);
            Renderer ObjRenderer = doorObjects[i].GetComponent<Renderer>();
            ObjRenderer.material = rendererMatariels[randumMatIndex];

            doorObjects[i].AddComponent<Game_Over>();

            selectColor.Add(rendererMatariels[randumMatIndex]);
            rendererMatariels.RemoveAt(randumMatIndex);
        }

        int randumQuadAndTextColorIndex = Random.Range(0,selectColor.Count);
        ColorText.color = selectColor[randumQuadAndTextColorIndex].color;
        ColorText.transform.DOScale(1.2F, 1F)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutBack);
    }
}
