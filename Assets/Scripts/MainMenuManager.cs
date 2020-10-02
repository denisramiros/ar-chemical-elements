using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;

    public TextAsset jsonFile;

    // Start is called before the first frame update
    void Start()
    {
        ElementsJson elementsJson = JsonUtility.FromJson<ElementsJson>(jsonFile.text);
        for (int i = 0; i < elementsJson.elements.Count; i++)
        {
            addElementToScrollList(elementsJson.elements[i]);
        }
        scrollView.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addElementToScrollList(Element element)
    {
        GameObject item = Instantiate(scrollItemPrefab, scrollContent.transform, false);
        item.GetComponent<MenuListItem>().Element = element;
    }
}
