using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class PortalManager : MonoBehaviour
    {
        private Renderer _renderer;

        void Awake()
        {
            _renderer = GetComponentInChildren<Renderer>();
        }

        public Color GetPortalColor()
        {
            return _renderer.material.color;
        }
    }
}
