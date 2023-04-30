namespace Data.Recipes
{
    using System.Collections.Generic;
    using UnityEngine;
    using Data.Item;

    [CreateAssetMenu(fileName = "RecipesData", menuName = "Data/Recipes/RecipesData")]
    public class RecipesData : ScriptableObject
    {
        [SerializeField]
        private List<RecipeBase> _recipeBase;
        public List<RecipeBase> Recipes { get => _recipeBase; set => _recipeBase = value; }
    }
}
