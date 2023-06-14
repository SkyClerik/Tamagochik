using System.Collections.Generic;
using UnityEngine;

namespace Data.Units
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Master", menuName = "Data/Units/Master")]
    public class Master : Humanoid
    {
        public List<Humanoid> Humanoids = new List<Humanoid>();
    }
}