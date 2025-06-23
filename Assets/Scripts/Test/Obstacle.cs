using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metabus2D
{
    public class Obstacle : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        protected const int baseOrderInLayer = 200;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
}
