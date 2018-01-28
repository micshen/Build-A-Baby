using System;
using Baby.Interfaces;
using UnityEngine;
using TMPro;

namespace Baby
{
	public class BabyProperty : MonoBehaviour
	{
        public string PropertyName; 

		public bool IsAttached;

		public IOption Option;

		public BabyEvents BabyEvents = new BabyEvents();

        public TextMeshProUGUI DisplayText; 

	}
}
