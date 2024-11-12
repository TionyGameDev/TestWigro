using System;
using UnityEngine;

namespace Shop
{
    [Serializable]
    public class ShopItem
    {
        public string name;
        public string description;
        public Sprite sprite;

        [HideInInspector]
        public Action<ShopItem> action;
    }
}