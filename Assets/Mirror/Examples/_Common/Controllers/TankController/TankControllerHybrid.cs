using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.TankController
{
    [AddComponentMenu("Network/Tank Controller (Hybrid)")]
    [RequireComponent(typeof(NetworkTransformHybrid))]
    public class TankControllerHybrid : TankControllerBase { } 
}
