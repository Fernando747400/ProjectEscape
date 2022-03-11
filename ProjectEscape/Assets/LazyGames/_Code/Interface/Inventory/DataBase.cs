using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database", menuName = "Items/List", order = 1)]
public class DataBase : MonoBehaviour
{
    [System.Serializable]
    public struct InventoryObject
    {
        public string name;
        public int id;
        public Sprite icon;
        public Type type;
        public bool collection;
        public string description;
    }

    public enum Type
    {
        consuble,
        equipable
    }

    public InventoryObject[] itemsDataBase;
}
