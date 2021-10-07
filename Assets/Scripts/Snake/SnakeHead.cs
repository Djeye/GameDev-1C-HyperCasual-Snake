using UnityEngine;

namespace snake.Snake
{
    public class SnakeHead : MonoBehaviour
    {
        private SnakePhysics _snakePhysics;

        private void Awake()
        {
            _snakePhysics = GetComponentInParent<SnakePhysics>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Colorful component))
            {
                if (component.GetColor().Equals(_snakePhysics.GetColor()) || Core.IsFever)
                {
                    _snakePhysics.AddSegment();
                    Core.AddDeathScore();
                    Destroy(component.gameObject);
                } else
                {
                    Core.EndGame();
                }
            }
            else if (other.TryGetComponent(out PortalManager portal))
            {
                _snakePhysics.ColorSegments(portal.GetPortalColor());
            }
            else if (other.TryGetComponent(out Spikes spikes))
            {
                if (Core.IsFever) 
                    Destroy(spikes.gameObject);
                else 
                    Core.EndGame();
            }
            else if (other.TryGetComponent(out Crystal crystal))
            {
                Core.AddCrystalScore();
                Destroy(crystal.gameObject);
            }
            else if (other.TryGetComponent(out EndLevel endLevel)) Core.EndGame();
        }   
    }
}