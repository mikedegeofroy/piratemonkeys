using Mirror;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : NetworkBehaviour
    {
        public Vector3 offset = new(0f, 10f, -5f);
        private UnityEngine.Camera _mainCam;

        void Start()
        {
            if (!isLocalPlayer) return;

            _mainCam = UnityEngine.Camera.main;
        }

        void LateUpdate()
        {
            if (!isLocalPlayer || !_mainCam) return;

            Vector3 targetPos = transform.position + offset;
            _mainCam.transform.position = Vector3.Lerp(_mainCam.transform.position, targetPos, 10f * Time.deltaTime);
            _mainCam.transform.LookAt(transform.position);
        }
    }
}