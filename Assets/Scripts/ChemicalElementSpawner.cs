using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalElementSpawner : MonoBehaviour
{
    public Transform chemicalElementPrefab;

    private ChemicalElement currentElement;

    /// <summary>
    /// Will spawn the chemical element
    /// </summary>
    /// <param name="number">"number" field in the JSON</param>
    /// <param name="atomicMass">"atomic_mass" field in the json</param>
    /// <param name="electronConfiguration">"electron_configuration" field in the JSON</param>
    public void Spawn(int number, float atomicMass, string electronConfiguration)
    {
        if (currentElement != null)
            Destroy(currentElement.gameObject);
        currentElement = Instantiate(chemicalElementPrefab).GetComponent<ChemicalElement>();
        currentElement.number = number;
        currentElement.atomicMass = atomicMass;
        currentElement.electronConfiguration = electronConfiguration;
    }

    public void ToggleShells()
    {
        currentElement.ToggleShells();
    }
}