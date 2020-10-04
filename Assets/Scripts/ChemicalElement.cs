using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public Transform shellSphere;

    private int shells;
    private List<GameObject> electronsList = new List<GameObject>();
    private int nucleusRadius;

    void Start()
    {
        Generate();
        shellSphere.gameObject.SetActive(false);
    }

    void Generate()
    {
        int protons = number;
        int electrons = number;
        int neutrons = Mathf.RoundToInt(atomicMass) - protons; //N = Z - A
        nucleusRadius = 3; //TODO, should be lerped depending on particles in neutron

        for (var i = 0; i < protons; i++)
            Instantiate(protonPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, this.transform);

        for (var i = 0; i < neutrons; i++)
            Instantiate(neutronPrefab, Random.insideUnitSphere * nucleusRadius, Quaternion.identity, this.transform);

        int[] shells = new int[8]; //how many electrons on each shell

        electronConfiguration.Split(' ').ToList().ForEach(s =>
        {
            int shell = int.Parse(s[0].ToString()) - 1;
            int electronsOnShell = int.Parse(s.Substring(2));
            shells[shell] += electronsOnShell;
        });

        for (var i = 0; i < shells.Length; i++)
        {
            float thisShellRadius = nucleusRadius + (i + 1) * shellRadius;
            print(thisShellRadius);
            if (shells[i] > 0)
                this.shells++;
            for (var j = 0; j < shells[i]; j++)
            {
                GameObject e = Instantiate(electronPrefab, Random.onUnitSphere * thisShellRadius, Quaternion.identity,
                    this.transform).gameObject;
                e.tag = "Shell" + i;
                electronsList.Add(e);
            }
        }
    }

    private int activeShell = -1;

    public void ToggleShells()
    {
        activeShell++;

        //when reaching last shell, enable all the shells
        if (activeShell >= shells)
        {
            activeShell = -1;
            electronsList.ForEach(e => e.SetActive(true));
            shellSphere.gameObject.SetActive(false);
            return;
        }

        electronsList.ForEach(e =>
        {
            if (e.tag == "Shell" + activeShell)
            {
                e.gameObject.SetActive(true);
            }
            else
            {
                e.SetActive(false);
            }
        });

        shellSphere.gameObject.SetActive(true);
        float thisShellRadius = (nucleusRadius + (activeShell + 2) * shellRadius) * 2;
        shellSphere.transform.localScale = new Vector3(thisShellRadius, thisShellRadius, thisShellRadius);
    }
}