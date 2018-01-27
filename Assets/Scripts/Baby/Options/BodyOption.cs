using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class BodyOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> BodyTypes; 

    private void Start()
    {
        BodyTypes = LoadBabyProperties("Body/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        return BodyTypes[Random.Range(0, BodyTypes.Count)]; 
    }
}
