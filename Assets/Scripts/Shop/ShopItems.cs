using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shoping", order = 0)]
    [Serializable]
    public class ShopItems : ScriptableObject
    {
        [FormerlySerializedAs("_items")] 
        public List<ShopItem> items;
        
    }
}