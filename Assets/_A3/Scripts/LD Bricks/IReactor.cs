using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public interface IReactor
    {
        public event Action onDoneReacting;
        public void React();
    }
}
