using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Baby
{
    public class BabyEvents
    {
        
        public delegate void AttachHandler(BabyProperty babyProperty);

        public event AttachHandler OnAttach;

        public delegate void DetachHandler(BabyProperty babyProperty);

        public event DetachHandler OnDetach;

        public delegate void SubmitBabyHandler(List<BabyProperty> babyProperties);

        public event SubmitBabyHandler OnSubmitBaby; 
    }

   

}