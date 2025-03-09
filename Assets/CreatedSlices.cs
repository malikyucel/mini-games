using System.Collections.Generic;
using UnityEngine;

public class CreatedSlices : MonoBehaviour
{
    [SerializeField] private GameObject slices;
    [SerializeField] private float sliceStartPosY = 10;
    [SerializeField] private int stepCount;
    [SerializeField] private int interactiveCount;
    [SerializeField] private Material red;
    [SerializeField] private Material black;
    [SerializeField] private GameObject parentObject;

    private void Start() 
    {
        float _step = stepCount * -2.5f;
        for (float i = 0; i > _step; i -= 2.5f)
        {
            GameObject sliceObject = Instantiate(slices, new Vector3(0, sliceStartPosY, 0), slices.transform.rotation);
            sliceObject.transform.SetParent(parentObject.transform);
            sliceStartPosY -= 2.5f;
            interactiveCount = Random.Range(1,4);
            SlicesSetActive(sliceObject);
        }
    }

    private void SlicesSetActive(GameObject sliceChild)
    {
        int childCount = sliceChild.transform.childCount;
        if (childCount == 0) return;

        List<GameObject> sliceChilds = new List<GameObject>();
        for (int i = 0; i < childCount; i++)
        {
            sliceChilds.Add(sliceChild.transform.GetChild(i).gameObject);
            Renderer objMatariel = sliceChilds[i].GetComponent<Renderer>();
            objMatariel.material = black;
        }

        for (int i = 0; i < interactiveCount; i++)
        {
            int randomIndex = Random.Range(0, sliceChilds.Count);
            MakeInteractive(sliceChilds[randomIndex]);
            sliceChilds.RemoveAt(randomIndex);
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
        objMatarial.material = red;
    }
}
