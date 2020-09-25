using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalElement : MonoBehaviour
{
    [Header("Chemical element properties")]
    public int number;
    public float atomicMass;
    public string electronConfiguration;

    [Header("Particles prefabs")]
    public Transform electronPrefab;
    public Transform neutronPrefab;
    public Transform protonPrefab;

    void Start()
    {
        Generate();
    }

    void Generate()
    {
        int protons = number;
        int electrons = number;
        int neutrons = Mathf.RoundToInt(atomicMass) - protons;//N = Z - A
        int nucleusRadius = 3;//TODO, should be lerped depending on particles in neutron

        for (var i = 0; i < protons; i++)
            Instantiate(protonPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, this.transform);

        for (var i = 0; i < neutrons; i++)
            Instantiate(neutronPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, this.transform);


    }

    void Update()
    {

    }
}
