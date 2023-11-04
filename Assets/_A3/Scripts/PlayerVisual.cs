using Com.KheruSEmporium.A3.A3.Cloaks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class PlayerVisual : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer visual = null;
        [SerializeField] private TypeColor_SerializableDictionary colors = new TypeColor_SerializableDictionary();
        [SerializeField] private Color defaultColor = Color.white;

        public void SetVisual(List<Cloak> assimilatedCloaks) {
            if (assimilatedCloaks.Count <= 0) {
                visual.color= defaultColor;
                return;
            }

            Color bodyColor = colors[assimilatedCloaks[0].Type];

            for (int i = 1; i < assimilatedCloaks.Count; i++) {
                bodyColor = Color.Lerp(bodyColor, colors[assimilatedCloaks[i].Type], 0.5f);
            }

            visual.color = bodyColor;
        }
    }
}
