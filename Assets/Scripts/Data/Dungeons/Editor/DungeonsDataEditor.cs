using UnityEditor;
using UnityEngine;
using Data.Dungeon;
using Data.Resources;

[CustomEditor(typeof(DungeonsData))]
public class DungeonsDataEditor : Editor
{
    private DungeonsData _dungeonsData;

    [SerializeField]
    private DungeonTextsData _dungeonTexts;
    [SerializeField]
    private DungeonIconsData _dungeonIcons;
    [SerializeField]
    private ResourcesData _resourcesData;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("calculate"))
        {
            _dungeonsData = (DungeonsData)target;
            _dungeonsData.Calculate(_dungeonTexts, _dungeonIcons, _resourcesData);

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_dungeonsData);
        }

        EditorGUILayout.HelpBox("Все ниже приведенное просчитывается калькулятором.\n" +
            "Отображается исключительно для отладки.\n" +
            "Для настройки используйте метод Calculate класса DungeonsData", MessageType.Info);

        base.OnInspectorGUI();
    }
}