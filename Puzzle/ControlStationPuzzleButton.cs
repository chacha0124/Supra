using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlStationPuzzleButton : MonoBehaviour
{
    public GameObject controlStationPuzzleSpaceship;

    public void _ButtonClick()
    {
        controlStationPuzzleSpaceship.GetComponent<NavMeshAgent>().enabled = true;
    }
}