using UnityEngine;

[CreateAssetMenu(fileName = "PersonalSpace", menuName = "Data/PersonalSpace")]
public class PersonalSpace : ScriptableObject
{
    [SerializeField] private int _size;
    [SerializeField] private int _costMain;
    public int Size { get => _size; set => _size = value; }
    public int CostMain { get => _costMain; set => _costMain = value; }
}