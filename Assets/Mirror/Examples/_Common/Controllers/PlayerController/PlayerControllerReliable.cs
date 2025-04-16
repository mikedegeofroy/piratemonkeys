using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.PlayerController
{
    [AddComponentMenu("Network/Player Controller (Reliable)")]
    [RequireComponent(typeof(NetworkTransformReliable))]
    public class PlayerControllerReliable : PlayerControllerBase { }
}
