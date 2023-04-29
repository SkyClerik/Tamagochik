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

        EditorGUILayout.HelpBox("��� ���� ����������� �������������� �������������.\n" +
            "������������ ������������� ��� �������.\n" +
            "��� ��������� ����������� ����� Calculate ������ RecipesData", MessageType.Info);

        //TODO ��� ����� ��������� ��������� �����������. ����� ����������� ��������.
        // � � ��������� ����� ������ ����� ������������� id �������� ��� �� ��� �� ���������
        // � ������ ������� ���� ������� ������ ���������� �� ���� ��� ������ ������ � ���� ����� ��������.
        // �� � ���� ��� �� ������� �� ������� � ���� ��������������.

        base.OnInspectorGUI();
    }
}