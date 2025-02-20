using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metabus2D
{
    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup.alpha = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canvasGroup.alpha = 1;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canvasGroup.alpha = 0;
            }
        }
    }
}
