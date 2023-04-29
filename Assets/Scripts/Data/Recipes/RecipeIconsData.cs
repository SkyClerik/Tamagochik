namespace Data.Recipes
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "RecipeIconsData", menuName = "Data/Recipes/IconsData")]
    public class RecipeIconsData : ScriptableObject
    {
        [SerializeField] private Sprite _recipe_1;
        [SerializeField] private Sprite _recipe_2;
        [SerializeField] private Sprite _recipe_3;
        [SerializeField] private Sprite _recipe_4;
        public Sprite Recipe_1 => _recipe_1;
        public Sprite Recipe_2 => _recipe_2;
        public Sprite Recipe_3 => _recipe_3;
        public Sprite Recipe_4 => _recipe_4;
    }
}