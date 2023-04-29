using UnityEngine;

[CreateAssetMenu(fileName = "HudTextData", menuName = "Data/HudTextData")]
public class HudTextData : ScriptableObject
{
    #region UpHud

    [Header("UpHud")]
    [SerializeField] private string _day = "День";
    [SerializeField] private string _month = "Месяц";
    [SerializeField] private string _cash = "Серебро";
    public string Day => _day;
    public string Month => _month;
    public string Cash => _cash;

    #endregion UpHud

    #region Описание цветов
    [Header("COLORS")]

    [SerializeField]
    private CustomColor[] _colorArray = new[]
    {
      new CustomColor(Color.red, "Красный"),// Red
      new(new Color(0.7803922f, 0.08235294f, 0.5215687f), "Розовый"), // Pink
      new(new Color(0.2941177f, 0f, 0.509804f), "Пурпурный"), // Purple
      new(Color.blue, "Синий"), // Blue
      new(new Color(0f, 0.5019608f, 0.5019608f), "Светло-зелёный"), // Light green
      new(Color.green, "Зелёный"), // Green
      new(new Color(0.3333333f, 0.4078431f, 0.1960784f), "Тёмно - оливковый"), // Dark Olive
    };

    public CustomColor[] ColorArray => _colorArray;

    #endregion Описание цветов

    #region Характеристики

    [Header("Characteristics")]

    [SerializeField]
    [Tooltip("СИЛА")]
    private CharacteristicsData _force = new()
    {
        Title = "Сила",
        Help = null,
        Advice = "[СОВЕТЫ ПО СИЛЕ]",
        Value = new string[] { "Беспомощен", "Задохлик", "Слабак", "Крепкий", "Атлетичный", "Могучий" },
    };

    public CharacteristicsData Force => _force;

    #endregion Характеристики

    public Color GetColorNormalize(byte enumNum, int enumLenght)
    {
        float r = (float)enumLenght / ColorArray.Length;
        var result = 0;

        if (enumNum < r)
            return ColorArray[result].GetColor;

        for (int i = 1; i < ColorArray.Length + 1; i++)
        {
            if (enumNum < (r * i))
            {
                result = i - 1;
                break;
            }
        }

        return ColorArray[result].GetColor;
    }
}


[System.Serializable]
public class CustomColor
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private Color _color;

    public Color GetColor => _color;
    public string GetName => _name;

    public CustomColor(Color color, string name)
    {
        _color = color;
        _name = name;
    }
}

[System.Serializable]
public class CharacteristicsData
{
    [SerializeField] private string _title;
    [SerializeField] private string _help;
    [SerializeField] private string _advice;
    [SerializeField] private string[] _array;
    public string Title { get => _title; set => _title = value; }
    public string Help { get => _help; set => _help = value; }
    public string Advice { get => _advice; set => _advice = value; }
    public string[] Value { get => _array; set => _array = value; }
}