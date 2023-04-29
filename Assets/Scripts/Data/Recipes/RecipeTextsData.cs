namespace Data.Recipes
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "RecipeTextsData", menuName = "Data/Recipes/TextsData")]
    public class RecipeTextsData : ScriptableObject
    {
        [SerializeField] private string _recipe_1_name = "1Рецепту тоже не нужно наверное имя1";
        [SerializeField] private string _recipe_2_name = "2Рецепту тоже не нужно наверное имя2";
        [SerializeField] private string _recipe_3_name = "3Рецепту тоже не нужно наверное имя3";
        [SerializeField] private string _recipe_4_name = "4Рецепту тоже не нужно наверное имя4";
        public string Recipe_1_name => _recipe_1_name;
        public string Recipe_2_name => _recipe_2_name;
        public string Recipe_3_name => _recipe_3_name;
        public string Recipe_4_name => _recipe_4_name;
    }
}
