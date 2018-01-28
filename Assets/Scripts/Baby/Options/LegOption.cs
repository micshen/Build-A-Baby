using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class LegOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> LegTypes; 

    private void Awake()
    {
        LegTypes = LoadBabyProperties("Leg/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        if (LegTypes.Count > 1)
            return LegTypes[Random.Range(0, LegTypes.Count)];
        else
            return LegTypes[0]; 

    }
}
