using System;
using Baby.Interfaces;
using UnityEngine;

namespace Baby
{
	public class BabyProperty : MonoBehaviour
	{
		public GameObject BabyPropertyGameObject;

		public bool IsAttached;

		public IOption Option;

		public BabyEvents BabyEvents = new BabyEvents();


	}
}
