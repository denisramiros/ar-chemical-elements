using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuListItem : MonoBehaviour, IPointerClickHandler
{
    [Header("UI references")]
    public Text nameText;
    public Text atomicMassText;
    public Text numberText;

    private Element _element;
    public Element Element 
    {
        get => _element;
        set
        {
            _element = value;
            nameText.text = value.name;
            atomicMassText.text = "Atomic mass: " + value.atomic_mass;
            numberText.text = "Number: " + value.number;
        } 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("ElementSpawner").GetComponent<ChemicalElementSpawner>().Spawn(Element.number, Element.atomic_mass, Element.electron_configuration);
        //GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>().ElementToPlace = _element;
        Debug.Log("Assigned");
    }
}
