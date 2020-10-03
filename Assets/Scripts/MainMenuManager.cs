using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;

    public TextAsset jsonFile;

    private void Start()
    {
        var elementsJson = JsonUtility.FromJson<ElementsJson>(jsonFile.text);
        foreach (var element in elementsJson.elements)
        {
            AddElementToScrollList(element);
        }

        scrollView.horizontalNormalizedPosition = 1;
        //scrollView.verticalNormalizedPosition = 1;
    }

    private void AddElementToScrollList(Element element)
    {
        var item = Instantiate(scrollItemPrefab, scrollContent.transform, false);
        item.GetComponent<MenuListItem>().Element = element;
    }
}
