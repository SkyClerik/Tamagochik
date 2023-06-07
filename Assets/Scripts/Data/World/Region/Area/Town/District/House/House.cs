using Hud.Buttons;
using System;
using UnityEngine;

namespace Data.World
{
    [CreateAssetMenu(fileName = "House", menuName = "Data/World/House")]
    public class House : NodeBase, IInside, IOutside
    {
        [SerializeField]
        private District _owner;
        [SerializeField]
        private int _privce;
        [SerializeField]
        //[HideInInspector]
        private int _id;

        public District Owner { get => _owner; set => _owner = value; }
        public int Price => _privce;
        public int GetID => _id;

        private void OnValidate()
        {
            _id = GetInstanceID();
        }

        public void BuyForce()
        {
            //TODO �������������� ������� ��� �������� ���������� � ��������
            GameDataContainer dataContainer = GameDataContainer.Instance;
            dataContainer.GetGameData.PlayerHouses.Add(this.Clone());
        }

        public void Inside()
        {
            Debug.Log($"��� {base.ButtonText}");

            WorldData worldData = GameDataContainer.Instance.GetWorldData;
            if (worldData.IsEquilsCurSelect(this))
            {
                StartForced();
            }
            else
            {
                new StartLocationInfo(houseNode: this, callback: StartForced);
            }
        }

        public void Outside()
        {
            new CreateDistrictUI(district: _owner);
        }

        public void StartForced()
        {
            Debug.Log($"������ {base.ButtonText}");
            new CreateHouseUI(house: this);
            new CreateRightUI();
        }
    }
}