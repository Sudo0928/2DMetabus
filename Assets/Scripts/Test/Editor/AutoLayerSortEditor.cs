using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Metabus2D
{
    [CustomEditor(typeof(AutoLayerSort))]
    public class AutoLayerSortEditor : Editor
    {
        private void OnEnable()
        {
            
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AutoLayerSort autoLayerSort = (AutoLayerSort)target;

            if (GUILayout.Button("AutoLayerSorting"))
            {
                autoLayerSort.Sort();
            }
        }
    }
}
