using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metabus2D
{
    public class Bound : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (layerMask.value == (layerMask.value | (1 << collision.gameObject.layer)))
            {
                spriteRenderer.sortingOrder = 200;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (layerMask.value == (layerMask.value | (1 << collision.gameObject.layer)))
            {
                spriteRenderer.sortingOrder = 100;
            }
        }
    }
}
