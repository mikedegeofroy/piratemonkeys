using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.FlyerController
{
    [AddComponentMenu("Network/Flyer Controller (Reliable)")]
    [RequireComponent(typeof(NetworkTransformReliable))]
    public class FlyerControllerReliable : FlyerControllerBase { }
}
