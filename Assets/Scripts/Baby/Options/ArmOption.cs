using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class ArmOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> ArmTypes;

    private void Awake()
    {
        ArmTypes = LoadBabyProperties("Arm/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        if (ArmTypes.Count > 1)
            return ArmTypes[Random.Range(0, ArmTypes.Count)];
        else
            return ArmTypes[0]; 

    }
}
