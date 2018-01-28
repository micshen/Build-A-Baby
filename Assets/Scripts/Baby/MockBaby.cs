using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockBaby : Baby.Baby {

 
    // Use this for initialization
    void Start () {

        BabyProperties = new List<Baby.BabyProperty>();

        var babyProperty = gameObject.AddComponent<Baby.BabyProperty>();
        babyProperty.PropertyName = "Fat Body";
        AddBabyProperty(babyProperty);

       
	}
	
	// Update is called once per frame
	void Update () {
       // RaiseSubmitEvent();
    }
}
