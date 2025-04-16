using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.TankController
{
    [AddComponentMenu("Network/Tank Controller (Unreliable)")]
    [RequireComponent(typeof(NetworkTransformUnreliable))]
    public class TankControllerUnreliable : TankControllerBase { } 
}
