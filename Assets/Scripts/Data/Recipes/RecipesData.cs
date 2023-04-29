namespace Data.Recipes
{
    using System.Collections.Generic;
    using UnityEngine;
    using Behaviours;

    [CreateAssetMenu(fileName = "RecipesData", menuName = "Data/Recipes/RecipesData")]
    public class RecipesData : ScriptableObject
    {
        [SerializeField]
        private List<RecipeBase> _recipeBase;
        public List<RecipeBase> Recipes { get => _recipeBase; set => _recipeBase = value; }

        public void Calculate(RecipeTextsData recipeTextsData, RecipeIconsData recipeIconsData)
        {
            Debug.Log($"Calculate");
            _recipeBase = new List<RecipeBase>()
            {
                new RecipeBase(
                    recipeTextsData.Recipe_1_name,
                    recipeIconsData.Recipe_1,
                    visible: true,
                    coast: 101,
                    demands: new List<Demand>(){new (index: 0, amount: 1, DataTypes.Item), new (index: 0, amount: 1, DataTypes.Item)}),

                new RecipeBase(
                    recipeTextsData.Recipe_2_name,
                    recipeIconsData.Recipe_2,
                    visible: true,
                    coast: 101,
                    demands: null),

                new RecipeBase(
                    recipeTextsData.Recipe_3_name,
                    recipeIconsData.Recipe_3,
                    visible: true,
                    coast: 101,
                    demands: null),

                new RecipeBase(
                    recipeTextsData.Recipe_4_name,
                    recipeIconsData.Recipe_4,
                    visible: true,
                    coast: 101,
                    demands: null),
            };
        }
    }
}
