using Data.Recipes;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RecipesData))]
public class RecipesDataEditor : Editor
{
    private RecipesData _recipesData;

    [SerializeField]
    private RecipeTextsData _recipeTextsData;
    [SerializeField]
    private RecipeIconsData _recipeIconsData;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("calculate"))
        {
            _recipesData = (RecipesData)target;
            _recipesData.Calculate(_recipeTextsData, _recipeIconsData);

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_recipesData);
        }

        EditorGUILayout.HelpBox("Все ниже приведенное просчитывается калькулятором.\n" +
            "Отображается исключительно для отладки.\n" +
            "Для настройки используйте метод Calculate класса RecipesData", MessageType.Info);

        //TODO Тут нужно полностью подменить отображение. Нужен полноценный редактор.
        // И в связанных базах данных нужно зафиксировать id объектов что бы они не смещались
        // В идеале конечно авто раздача должна обратиться ко всем кто держит ссылку и дать новое значение.
        // Но у меня нет ни времени ни желания с этим заморачиваться.

        base.OnInspectorGUI();
    }
}