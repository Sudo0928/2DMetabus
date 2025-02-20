using UnityEngine;
using UnityEngine.InputSystem;

namespace Metabus2D
{
    public class PlayerController : BaseController
    {
        private GameManager gameManager;
        private Camera camera;

        internal void Init(GameManager gameManager)
        {
            this.gameManager = gameManager;
            camera = Camera.main;
        }

        private void OnMove(InputValue inputValue)
        {
            movementDirection = inputValue.Get<Vector2>();
            movementDirection = movementDirection.normalized;
        }

        private void OnLook(InputValue inputValue)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirectoin = (worldPos - (Vector2)transform.position);

            if (lookDirectoin.magnitude < 0.9f)
            {
                lookDirectoin = Vector2.zero;
            }
            else
            {
                lookDirectoin = lookDirectoin.normalized;
            }
        }
    }
}