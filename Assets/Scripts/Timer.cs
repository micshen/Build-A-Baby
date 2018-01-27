using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float seconds;

	public void StartTimer(float s)
	{

		seconds = s;

	}

	public void TimerComplete()
	{

		Debug.Log("Time's up!");

	}

	// Update is called once per frame
	void Update () {
		seconds -= Time.deltaTime;
		if(seconds <=0){
			TimerComplete();
		}
	}
}
