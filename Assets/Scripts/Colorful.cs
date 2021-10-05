using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class Colorful : MonoBehaviour
    {
        private Renderer _renderer;
        void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        public Color GetColor()
        {
            return _renderer.material.color;
        }
    }
}
