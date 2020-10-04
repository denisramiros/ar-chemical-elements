using UnityEngine;

public class ChemicalElementSpawner : MonoBehaviour
{
    public Transform chemicalElementPrefab;

    private ChemicalElement _currentElement;

    /// <summary>
    /// Will spawn the chemical element
    /// </summary>
    /// <param name="number">"number" field in the JSON</param>
    /// <param name="atomicMass">"atomic_mass" field in the json</param>
    /// <param name="electronConfiguration">"electron_configuration" field in the JSON</param>
    public void Spawn(int number, float atomicMass, string electronConfiguration)
    {
        if (_currentElement != null)
            Destroy(_currentElement.gameObject);
        
        _currentElement = Instantiate(chemicalElementPrefab).GetComponent<ChemicalElement>();
        _currentElement.number = number;
        _currentElement.atomicMass = atomicMass;
        _currentElement.electronConfiguration = electronConfiguration;
    }

    public void ToggleShells()
    {
        _currentElement.ToggleShells();
    }
}