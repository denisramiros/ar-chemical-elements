﻿using System.Collections;
using System.Collections.Generic;
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
            atomicMassText.text = "Atomic mass: \n" + value.atomic_mass;
            numberText.text = "Number: \n" + value.number;
        } 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("ElementSpawner").GetComponent<ChemicalElementSpawner>().Spawn(Element.number, Element.atomic_mass, Element.electron_configuration);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
