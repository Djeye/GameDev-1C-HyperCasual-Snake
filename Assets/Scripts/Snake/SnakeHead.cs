using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class SnakeHead : MonoBehaviour
    {
        private SnakePhysics _snakePhysics;

        void Awake()
        {
            _snakePhysics = GetComponentInParent<SnakePhysics>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Colorful component))
            {
                if (component.GetColor().Equals(_snakePhysics.GetColor()))
                _snakePhysics.AddSegment();
                Destroy(component.gameObject);
            }
            else if (other.TryGetComponent(out PortalManager portal))
            {
                _snakePhysics.ColorSegments(portal.GetPortalColor());
            }
        }
    }
}
