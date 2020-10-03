using UnityEngine;

public class ChemicalElementSpawner : MonoBehaviour
{
    /// <summary>
    /// Will spawn the chemical element
    /// </summary>
    /// <param name="number">"number" field in the JSON</param>
    /// <param name="atomicMass">"atomic_mass" field in the json</param>
    /// <param name="electronConfiguration">"electron_configuration" field in the JSON</param>
    public void Spawn(int number, float atomicMass, string electronConfiguration)
    {
        Debug.Log("Spawn element: " + number + " " + atomicMass + " " + electronConfiguration);
    }
}
