using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic
{
    public class PlayerCameraFollow : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            var cameraPosition = _camera.transform.position;
            cameraPosition.x = Player.Instance.transform.position.x;
            cameraPosition.y = Player.Instance.transform.position.y;
            _camera.transform.position = cameraPosition;
        }
    }
}