using System;
using System.Collections.Generic;
using UnityEngine;

namespace Baby
{
    public class Baby : MonoBehaviour
    {
        public List<BabyProperty> BabyProperties;

        public Action OnFinished;

        public int TotalScore;


        public void Start()
        {
            BabyProperties = new List<BabyProperty>();            
        }


        public int CompareBabyProperty(BabyProperty OrderBabyProperty, BabyProperty ActualBabyProperty)
        {
            int score = 0;
            
            return score; 
        }


        public void AddBabyProperty(BabyProperty babyProperty)
        {
            BabyProperties.Add(babyProperty);
            babyProperty.IsAttached = true; 
        }

        public void RemoveBabyProperty(BabyProperty babyProperty)
        {
            BabyProperties.Remove(babyProperty);
            babyProperty.IsAttached = false; 
        }

    }
}