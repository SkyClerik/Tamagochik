using Data.Units;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsData", menuName = "Data/UnitsData")]
public class UnitsData : ScriptableObject
{
    [SerializeField] private List<Master> _masters = new();
    [SerializeField] private List<Humanoid> _humanoids = new();
    [SerializeField] private List<Animal> _animals = new();

    public List<Master> MasterList => _masters;
    public List<Humanoid> HumanoidList => _humanoids;
    public List<Animal> AnimalList => _animals;

    public Master GetMasterDeepCopy(int index)
    {
        return _masters[index].DeepCopy();
    }
}