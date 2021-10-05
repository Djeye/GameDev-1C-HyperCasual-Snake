using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class PlayerMovement : MonoBehaviour
    {

        private InputManager _inputManager;
        private SnakePhysics _snakePhysics;
        private Transform _snakeHead;

        private void Awake()
        {
            _inputManager = GetComponent<InputManager>();
            _snakePhysics = GetComponent<SnakePhysics>();
        }

        void Start()
        {
            _snakeHead = _snakePhysics.GetSnakeHead();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            _snakeHead.position += new Vector3(0, 0, _snakePhysics.GetSnakeSpeed() * Time.deltaTime);

            if (_inputManager.GetPointerDown())
            {
                var _horizontalInput = Mathf.SmoothStep(-3.6f, 3.6f, _inputManager.GetPointerPosition());
                _snakeHead.position = new Vector3(_horizontalInput, _snakeHead.position.y, _snakeHead.position.z);
            }
        }
    }
}
