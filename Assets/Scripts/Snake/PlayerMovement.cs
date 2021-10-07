using System.Collections;
using UnityEngine;

namespace snake.Snake
{
    public class PlayerMovement : MonoBehaviour
    {

        private InputManager _inputManager;
        private SnakePhysics _snakePhysics;
        private Transform _snakeHead;
        private float _snakeSpeed, _startSnakeSpeed;
        
        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _snakePhysics = GetComponent<SnakePhysics>();
        }

        private void Start()
        {
            _snakeHead = _snakePhysics.GetSnakeHead();
            _startSnakeSpeed = _snakePhysics.GetSnakeSpeed();
            _snakeSpeed = _startSnakeSpeed;
            
            Core.feverEvent += EnterFever;
        }

        private void Update()
        {
            if (Core.IsGameEnded) return;
            ApplyMovement();
        }

        private void ApplyMovement()
        {
            var position = _snakeHead.position;
            
            var horizontalInput = _inputManager.GetPointerDown() && !Core.IsFever ? 
                Mathf.SmoothStep(-3.6f, 3.6f, _inputManager.GetPointerPosition()) : position.x;

            position = new Vector3(horizontalInput, position.y, position.z + _snakeSpeed * Time.deltaTime);
            
            _snakeHead.position = position;
        }
        
        private void EnterFever()
        {
            StartCoroutine(FeverCoroutine());
        }

        private IEnumerator FeverCoroutine()
        {
            _snakeHead.position = new Vector3(0, _snakeHead.position.y, _snakeHead.position.z);
            _snakeSpeed = 3 * _startSnakeSpeed;
            _snakePhysics.SetSnakeSpeed(_snakeSpeed);
            
            yield return new WaitForSeconds(3f);

            _snakeSpeed = _startSnakeSpeed;
            _snakePhysics.SetSnakeSpeed(_snakeSpeed);
            Core.ExitFever();
        }

        private void OnDisable()
        {
            Core.feverEvent -= EnterFever;
        }
    }
}
