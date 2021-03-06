﻿using UnityEngine;
using System.Collections.Generic; 
using Baby.Interfaces;
using Baby;

public class BodyOption : MonoBehaviour, IOption
{
    public IList<BabyProperty> BodyTypes; 

    private void Awake()
    {
        BodyTypes = LoadBabyProperties("Body/");
    }

    private IList<BabyProperty> LoadBabyProperties(string path)
    {
        return Resources.LoadAll<BabyProperty>(path); 
    }


    public BabyProperty GetRandomProperty()
    {
        if (BodyTypes.Count > 1)
            return BodyTypes[Random.Range(0, BodyTypes.Count)];
        else
            return BodyTypes[0]; 

    }
}
