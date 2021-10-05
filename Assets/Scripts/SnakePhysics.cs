using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class SnakePhysics : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject head;
        [SerializeField] private GameObject lastSegment, tail;
        [SerializeField] private GameObject segment;

        private List<Transform> _snakeBody = new List<Transform>();

        private Camera _mainCamera;
        // Start is called before the first frame update
        void Start()
        {
            _mainCamera = Camera.main;
            _snakeBody.Add(head.transform);
            _snakeBody.Add(lastSegment.transform);
            _snakeBody.Add(tail.transform);
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            ApplySnakePhysics();
        }

        private void Movement()
        {
            if (Input.GetMouseButton(0))
            {
                var _horizontalInput = Mathf.SmoothStep(-3.6f, 3.6f, 1.2f * Input.mousePosition.x / _mainCamera.pixelWidth);
                head.transform.position = new Vector3(_horizontalInput, head.transform.position.y, head.transform.position.z);
            }
            if (Input.GetMouseButtonDown(1) && _snakeBody.Count < 7)
            {
                AddSegment();
            }
        }

        private void ApplySnakePhysics()
        {
            for (int i = 1; i < _snakeBody.Count; i++)
            {
                var vector = _snakeBody[i - 1].position - _snakeBody[i].position;
                _snakeBody[i].position += new Vector3(vector.x * speed * Time.deltaTime, 0, 0);
            }
        }

        private void AddSegment()
        {
            var seg = Instantiate(segment, head.transform.position + new Vector3(0, 0, -1.6f), Quaternion.identity, transform);
            _snakeBody.Insert(1, seg.transform);

            for (int i = 2; i < _snakeBody.Count; i++)
                _snakeBody[i].position += new Vector3(0, 0, -1.55f);
        }
    }
}