using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//MSAA Must be 2x or loweer to allow FFR to be enabled. FFR is not compatible with MSAA 4x or higher.
//ONLY WORKS ON STANDALONE

namespace UnityEngine.XR.OpenXR.CodeSamples.Editor.Tests
{
    // Requires Unity 6.0.0 or newer.
    public class FixedFovRendering : MonoBehaviour
    {
        List<XRDisplaySubsystem> xrDisplays = new List<XRDisplaySubsystem>();

        public float fovStrength = 1.0f; // Full strength

        void Start()
        {

            SubsystemManager.GetSubsystems(xrDisplays);
            if (xrDisplays.Count == 1)
            {
                xrDisplays[0].foveatedRenderingLevel = fovStrength; // Full strength
                //xrDisplays[0].foveatedRenderingFlags =  XRDisplaySubsystem.FoveatedRenderingFlags.GazeAllowed;
            }
        }

        
    }
}
