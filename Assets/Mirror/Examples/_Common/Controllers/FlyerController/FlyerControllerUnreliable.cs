using Mirror.Components.NetworkTransform;
using UnityEngine;

namespace Mirror.Examples._Common.Controllers.FlyerController
{
    [AddComponentMenu("Network/Flyer Controller (Unreliable)")]
    [RequireComponent(typeof(NetworkTransformUnreliable))]
    public class FlyerControllerUnreliable : FlyerControllerBase { }
}
