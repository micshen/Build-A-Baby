using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class TeethOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> TeethTypes; 

    private void Awake()
    {
        TeethTypes = LoadBabyProperties("Teeth/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        if (TeethTypes.Count > 1)
            return TeethTypes[Random.Range(0, TeethTypes.Count)];
        else
            return TeethTypes[0]; 

    }
}
