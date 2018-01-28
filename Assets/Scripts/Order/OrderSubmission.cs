using System;
using System.Collections;
using System.Collections.Generic;
using Baby;
using UnityEngine;

public class OrderSubmission : MonoBehaviour {

    private Baby.Baby baby;
    private OrderGenerator orderGenerator;

    public int Score; 

	// Use this for initialization
	void Start ()
    {
        orderGenerator = FindObjectOfType<OrderGenerator>(); 

        baby.BabyEvents.OnSubmitBaby += CompareToActiveOrders; 
	}

    //this will most likely have to be some sort of collider check, to get this baby 
    public Baby.Baby GetActiveBaby(Baby.Baby baby)
    {
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
                        if (orderBabyProperty.DisplayText == babyProperty.DisplayText)
                        {
                            Score += 100; 
                        }

                    }
                }
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}


}
