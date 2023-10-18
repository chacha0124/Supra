using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlStationPuzzleSocket : MonoBehaviour
{
    public GameObject controlStationPuzzleSocket;

    public void Rotation()
    {
        controlStationPuzzleSocket.transform.Rotate(new Vector3(0, 90, 0));
    }
}
