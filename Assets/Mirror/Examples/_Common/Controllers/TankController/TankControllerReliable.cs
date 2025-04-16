using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.TankController
{
    [AddComponentMenu("Network/Tank Controller (Reliable)")]
    [RequireComponent(typeof(NetworkTransformReliable))]
    public class TankControllerReliable : TankControllerBase { } 
}
