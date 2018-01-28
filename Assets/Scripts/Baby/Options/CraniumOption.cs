using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class CraniumOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> CraniumTypes; 

    private void Awake()
    {
        CraniumTypes = LoadBabyProperties("Cranium/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        if (CraniumTypes.Count > 1)
            return CraniumTypes[Random.Range(0, CraniumTypes.Count)];
        else
            return CraniumTypes[0]; 

    }
}
