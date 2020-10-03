using System.Linq;
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

    [Header("Other")]
    [Tooltip("The bigger this is, the larger the space between shells")]
    public float shellRadius;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        var protons = number;
        var electrons = number;
        var neutrons = Mathf.RoundToInt(atomicMass) - protons; //N = Z - A
        const int nucleusRadius = 3; //TODO, should be lerped depending on particles in neutron

        for (var i = 0; i < protons; i++)
            Instantiate(protonPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, transform);

        for (var i = 0; i < neutrons; i++)
            Instantiate(neutronPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, transform);

        var shells = new int[8]; //how many electrons on each shell

        electronConfiguration.Split(' ').ToList().ForEach(s =>
        {
            var shell = int.Parse(s[0].ToString()) - 1;
            var electronsOnShell = int.Parse(s.Substring(2));
            shells[shell] += electronsOnShell;
        });

        for (var i = 0; i < shells.Length; i++)
        {
            var thisShellRadius = nucleusRadius + (i + 1) * shellRadius;
            for (var j = 0; j < shells[i]; j++)
            {
                Instantiate(electronPrefab, Random.onUnitSphere * thisShellRadius, Quaternion.identity, transform);
            }
        }
    }
}
