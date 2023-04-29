namespace Data.Resources
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "ResourceTextsData", menuName = "Data/Resources/TextsData")]
    public class ResourceTextsData : ScriptableObject
    {
        [SerializeField] private string _iron_name = "Сталь";
        [SerializeField] private string _iron_Description = "_iron_Description";
        [SerializeField] private string _wood_name = "Дерево";
        [SerializeField] private string _wood_Description = "_wood_Description";
        [SerializeField] private string _gold_name = "Золото";
        [SerializeField] private string _gold_Description = "_gold_Description";
        [SerializeField] private string _stone_name = "Камень";
        [SerializeField] private string _stone_Description = "_stone_Description";

        public string Iron_name => _iron_name;
        public string Iron_Description => _iron_Description;
        public string Wood_name => _wood_name;
        public string Wood_Description => _wood_Description;
        public string Gold_name => _gold_name;
        public string Gold_Description => _gold_Description;
        public string Stone_name => _stone_name;
        public string Stone_Description => _stone_Description;
    }
}