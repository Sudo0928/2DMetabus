using UnityEngine;

namespace Metabus2D
{
    public abstract class BaseController : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody;

        [SerializeField] private SpriteRenderer characterRenderer;

        protected Vector2 movementDirection = Vector2.zero;
        public Vector2 MovementDirection { get { return movementDirection; } }

        protected Vector2 lookDirectoin = Vector2.zero;
        public Vector2 LookDirection { get { return lookDirectoin; } }

        protected StatHandler statHandler;

        protected AnimationHandler animationHandler;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            statHandler = GetComponent<StatHandler>();
            animationHandler = GetComponent<AnimationHandler>();
        }

        protected virtual void Start()
        {

        }

        protected virtual void Update()
        {
            Rotate(LookDirection);
        }

        protected virtual void FixedUpdate()
        {
            Movement(movementDirection);
        }

        private void Movement(Vector2 direction)
        {
            direction = direction * statHandler.Speed;

            _rigidbody.velocity = direction;

            animationHandler.Move(direction);
        }

        private void Rotate(Vector2 direction)
        {
            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(rotZ) > 90f;

            characterRenderer.flipX = isLeft;
        }
    }
}

