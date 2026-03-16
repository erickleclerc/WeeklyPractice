using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

//ONLY WORKS ON STANDALONE

public class EnableFFR : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForNextFrameUnit();
        OVRPlugin.foveatedRenderingLevel = OVRPlugin.FoveatedRenderingLevel.High;
        OVRPlugin.useDynamicFoveatedRendering = false;

    }
}