using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    [CreateAssetMenu(fileName ="Button Sprite Localisation Settings", menuName ="A3/Button Sprite Loc")]
    public class ButtonLocalisation : ScriptableObject
    {
        [SerializeField] private ButtonCSSpriteDictionary_SerializableDictionary buttonList = new ButtonCSSpriteDictionary_SerializableDictionary();

        public ButtonCSSpriteDictionary_SerializableDictionary ButtonList => buttonList;
    }
}
