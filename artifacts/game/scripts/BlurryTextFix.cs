using UnityEngine;
using System.Collections;
using UnityEngine.UI;
      
    [ExecuteInEditMode]
    public class BlurryTextFix : MonoBehaviour
    {
        void Start ()
        {
            // forces text to render in point mode, usually reserved only for sprites
            GetComponent<Text>().font.material.mainTexture.filterMode = FilterMode.Point;
        }
    }
