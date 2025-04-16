using UnityEngine;

namespace Camera
{
    public class Billboard : MonoBehaviour
    {
        private UnityEngine.Camera _cam;

        void Start()
        {
            _cam = UnityEngine.Camera.main;
        }

        void LateUpdate()
        {
            if (_cam != null)
            {
                transform.LookAt(transform.position + _cam.transform.rotation * Vector3.forward,
                    _cam.transform.rotation * Vector3.up);
            }
        }
    }
}