using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.PlayerController
{
    [AddComponentMenu("Network/Player Controller (Hybrid)")]
    [RequireComponent(typeof(NetworkTransformHybrid))]
    public class PlayerControllerHybrid : PlayerControllerBase { }
}
