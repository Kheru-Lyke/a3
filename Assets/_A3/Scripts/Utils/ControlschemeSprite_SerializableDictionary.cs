using RotaryHeart.Lib.SerializableDictionary;
using System;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	[Serializable]
	public class ControlschemeSprite_SerializableDictionary : SerializableDictionaryBase<ControllerType, Sprite> { }

	[Serializable]
	public class ButtonCSSpriteDictionary_SerializableDictionary : SerializableDictionaryBase<Control, ControlschemeSprite_SerializableDictionary> { }
}
