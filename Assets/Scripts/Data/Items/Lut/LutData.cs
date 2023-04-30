namespace Data.Item
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "LutData", menuName = "Data/Lut/LutData")]
    public class LutData : ScriptableObject
    {
        [SerializeField]
        private List<Lut> _lut;
        public List<Lut> GetLut => _lut;
    }
}