using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.PlayerController
{
    [AddComponentMenu("Network/Player Controller (Unreliable)")]
    [RequireComponent(typeof(NetworkTransformUnreliable))]
    public class PlayerControllerUnreliable : PlayerControllerBase { }
}
