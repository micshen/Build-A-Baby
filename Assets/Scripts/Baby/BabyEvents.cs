using System;
using JetBrains.Annotations;

namespace Baby
{
    public class BabyEvents
    {
        
        public delegate void AttachHandler(BabyProperty babyProperty);

        public event AttachHandler OnAttach;

        public delegate void DetachHandler(BabyProperty babyProperty);

        public event DetachHandler OnDetach; 
    }

   

}