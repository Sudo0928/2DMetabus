using UnityEngine;

namespace Metabus2D
{
    public class StatHandler : MonoBehaviour
    {
        [Range(1f, 20f)][SerializeField] private float speed = 3f;
        public float Speed
        {
            get => speed;
            set => speed = Mathf.Clamp(value, 1, 20);
        }
    }
}