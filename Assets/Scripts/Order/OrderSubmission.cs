﻿using System;
using System.Collections;
using System.Collections.Generic;
using Baby;
using UnityEngine;
using VRTK;

public class OrderSubmission : MonoBehaviour {

    private Baby.Baby baby;
    private OrderGenerator orderGenerator;

    public int Score;

    public VRTK_SnapDropZone[] SnapZones;

    public int SnappedObjectCount; 

	// Use this for initialization
	void Awake()
    {
        orderGenerator = FindObjectOfType<OrderGenerator>();

       SnapZones = FindObjectsOfType<VRTK_SnapDropZone>();

        foreach (var snapZone in SnapZones)
        {
            snapZone.ObjectSnappedToDropZone += GetSnappedObjects;
        }
	}

    private void GetSnappedObjects(object sender, SnapDropZoneEventArgs e)
    {
        SnappedObjectCount++;   
    }

    public void OnSubmit()
    {
        foreach (var snapZone in SnapZones)
        {
            var snappedObj = snapZone.GetCurrentSnappedObject();
            Destroy(snappedObj); 
        }
    }



    //this will most likely have to be some sort of collider check, to get this baby 
    public Baby.Baby GetActiveBaby(Baby.Baby baby)
    {
        baby.OnSubmitBaby += CompareToActiveOrders; 
        return baby;
    }

    private void CompareToActiveOrders(List<BabyProperty> babyProperties)
    {
        for (int i = 0; i < orderGenerator.Orders.Count; i++)
        {
            //get oldest order as active order
            if (orderGenerator.Orders[i].IsActive)
            {
                foreach (var orderBabyProperty in orderGenerator.Orders[i].BabyProperties)
                {
                    foreach (var babyProperty in babyProperties)
                    {
                        Debug.Log("baby property name: " + babyProperty.PropertyName + " orderBabyProperty: " + orderBabyProperty.PropertyName); 
                        if (orderBabyProperty.PropertyName.Contains(babyProperty.PropertyName))
                        {
                            Score += 100; 
                        }

                        orderGenerator.Orders[i].DestroyOrder(); 
                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}


}
