using TopDown_Project;
using UnityEngine;

namespace Metabus2D
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public PlayerController player { get; private set; }

        public static bool isFirstLoading = true;

        private void Awake()
        {
            instance = this;
            player = FindObjectOfType<PlayerController>();
            player.Init(this);
        }

        private void Start()
        {
            if (!isFirstLoading)
            {
                
            }
            else
            {
                isFirstLoading = false;
            }
        }
    }
}
