using Input;
using Mirror;
using Mirror.Core;
using TMPro;
using UnityEngine;

namespace Ship
{
    public class ShipController : NetworkBehaviour
    {
        public float baseMoveSpeed = 1f;
        public float rotationSpeedFactor = 180f;

        private FullscreenJoystick _joystick;
        
        [SyncVar]
        public string username;
        public TextMeshProUGUI label;


        void Start()
        {
            if (!isLocalPlayer)
            {
                enabled = false;
                return;
            }

            _joystick = FindFirstObjectByType<FullscreenJoystick>();
        }
        
        public override void OnStartClient()
        {
            Debug.Log($"[{netId}] Spawned on client. Username: {username}");

            if (label != null)
            {
                label.text = username;
            }
        }

        void Update()
        {
            if (!isLocalPlayer) return;

            Vector2 input = _joystick.Direction;
            Vector3 lookDirection = new Vector3(-input.x, 0, -input.y);

            float inputStrength = Mathf.Clamp01(lookDirection.magnitude);

            if (inputStrength > 0.1f)
            {
                float currentMoveSpeed = baseMoveSpeed * inputStrength * 5f;

                transform.Translate(Vector3.forward * (currentMoveSpeed * Time.deltaTime), Space.Self);

                float rotationSpeed = rotationSpeedFactor * inputStrength;
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}