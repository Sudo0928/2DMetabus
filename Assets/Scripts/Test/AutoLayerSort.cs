using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Metabus2D
{
    public class AutoLayerSort : MonoBehaviour
    {
        [SerializeField] private string tagName;
        [SerializeField] private int layerIndex = 200;

        public GameObject[] GetObjectsWithTag(string tag)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

            objects = objects.Where(obj => obj.tag == tag).OrderBy(x => -x.transform.position.y).ToArray();

            return objects;
        }

        public void Sort()
        {
            GameObject[] objects = GetObjectsWithTag("Obstacle");

            int maxIndex = Mathf.RoundToInt(objects[0].transform.position.y);

            for (int i = 0; i < objects.Length; i++)
            {
                SpriteRenderer spriteRenderer = objects[i].GetComponentInChildren<SpriteRenderer>();

                Vector3Int pos = GetIntPosition(objects[i].transform.position);
                objects[i].transform.position = pos;
                spriteRenderer.sortingOrder = (layerIndex + maxIndex - pos.y) * 100;
            }

            GameManager.Instance.maxSortingOrder = maxIndex;
        }

        public Vector3Int GetIntPosition(Vector3 pos)
        {
            return new Vector3Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), Mathf.RoundToInt(pos.z));
        }
    }
}
