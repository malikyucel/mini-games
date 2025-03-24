using System.Collections.Generic;
using UnityEngine;

public class SliceCreate_HelixJump : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject slices;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Material[] collers;
    [SerializeField] private Material breakColler;

    [Header("Settings")]
    [SerializeField] private float sliceStartPosY;
    [SerializeField] private int stepCount;
    [SerializeField] private int interactiveCount;
    [SerializeField] private float decembe;

    private void Start() 
    {
        float _step = stepCount * -decembe;
        int randumColler = Random.Range(0,collers.Length);
        for (float i = 0; i > _step; i -= decembe)
        {
            GameObject sliceObject = Instantiate(slices, new Vector3(0, sliceStartPosY, 0), slices.transform.rotation);
            sliceObject.AddComponent<SliceAnim_HelixJump>();
            sliceObject.transform.SetParent(parentObject.transform);
            sliceStartPosY -= decembe;
            interactiveCount = Random.Range(1,4);
            SlicesSetActive(sliceObject,randumColler);
        }
    }

    private void SlicesSetActive(GameObject sliceChild, int randumColler)
    {
        int childCount = sliceChild.transform.childCount;
        if (childCount == 0) return;

        List<GameObject> sliceChilds = new List<GameObject>();

        for (int i = 0; i < childCount; i++)
        {
            sliceChilds.Add(sliceChild.transform.GetChild(i).gameObject);
            Renderer objMatariel = sliceChilds[i].GetComponent<Renderer>();
            objMatariel.material = collers[randumColler];
        }

        for (int i = 0; i < interactiveCount; i++)
        {
            int randomIndex = Random.Range(0, sliceChilds.Count);
            MakeInteractive(sliceChilds[randomIndex]);
            sliceChilds.RemoveAt(randomIndex); // Not: Her adımda engel olması sağlıyor. Zorluk arttırıyor 
        }

        foreach (var child in sliceChilds)
        {
            int trueFalse = Random.Range(0, 2);
            child.SetActive(trueFalse == 1);
        }
    }

    private void MakeInteractive(GameObject obj)
    {
        obj.SetActive(true);
        obj.tag = "Interactive";
        Renderer objMatarial = obj.GetComponent<Renderer>();
        objMatarial.material = breakColler;
    }
}
