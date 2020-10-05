using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChemicalElement : MonoBehaviour
{
    [Header("Chemical element properties")]
    public int number;

    public float atomicMass;
    public string electronConfiguration;

    [Header("Particles prefabs")] public Transform electronPrefab;
    public Transform neutronPrefab;
    public Transform protonPrefab;

    [Header("Other")] [Tooltip("The bigger this is, the larger the space between shells")]
    public float shellRadius;

    public float nucleusMinRadius = 0.006f;
    public float nucleusMaxGrow = 0.1f;

    public Transform shellSphere;

    private int _shells;
    private readonly List<GameObject> _electronsList = new List<GameObject>();
    private float _nucleusRadius;
    private int _activeShell = -1;

    private void Start()
    {
        Generate();
        shellSphere.gameObject.SetActive(false);
    }

    private void Generate()
    {
        var protons = number;
        var electrons = number;
        var neutrons = Mathf.RoundToInt(atomicMass) - protons; //N = Z - A
        _nucleusRadius =
            Mathf.InverseLerp(0, 100, number) * nucleusMaxGrow + nucleusMinRadius; //calculated based on how many protons/neutron there are

        for (var i = 0; i < protons; i++)
            Instantiate(protonPrefab, Random.insideUnitSphere * _nucleusRadius, Quaternion.identity, transform);

        for (var i = 0; i < neutrons; i++)
            Instantiate(neutronPrefab, Random.insideUnitSphere * _nucleusRadius, Quaternion.identity, transform);

        var shells = new int[8]; //how many electrons on each shell

        electronConfiguration.Split(' ').ToList().ForEach(s =>
        {
            var shell = int.Parse(s[0].ToString()) - 1;
            var electronsOnShell = int.Parse(s.Substring(2));
            shells[shell] += electronsOnShell;
        });

        for (var i = 0; i < shells.Length; i++)
        {
            var thisShellRadius = _nucleusRadius + (i + 1) * shellRadius;
            if (shells[i] > 0)
                _shells++;
            for (var j = 0; j < shells[i]; j++)
            {
                var e = Instantiate(electronPrefab, Random.onUnitSphere * thisShellRadius, Quaternion.identity,
                    transform).gameObject;
                e.tag = "Shell" + i;
                _electronsList.Add(e);
            }
        }
    }

    public void ToggleShells()
    {
        _activeShell++;

        //when reaching last shell, enable all the shells
        if (_activeShell >= _shells)
        {
            _activeShell = -1;
            _electronsList.ForEach(e => e.SetActive(true));
            shellSphere.gameObject.SetActive(false);
            return;
        }

        _electronsList.ForEach(e =>
        {
            if (e.CompareTag($"Shell{_activeShell}"))
            {
                e.gameObject.SetActive(true);
            }
            else
            {
                e.SetActive(false);
            }
        });

        shellSphere.gameObject.SetActive(true);
        var thisShellRadius = (_nucleusRadius + (_activeShell + 1) * shellRadius) * 2;
        shellSphere.transform.localScale = new Vector3(thisShellRadius, thisShellRadius, thisShellRadius);
    }
}