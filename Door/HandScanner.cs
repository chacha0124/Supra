using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScanner : MonoBehaviour
{
    public DoorControl door;
    public bool isLock;
    public int handScannerIndex;

    public void UnLock()
    {
        isLock = false;
    }
    public void DoorOpen()
    {
        switch(handScannerIndex)
        {
            // Repair to Electric
            case 0:
                if (isLock)
                {

                }
                else
                {
                    EventManager.Instance.RepairElectricDoorOpen();
                    door.Open();
                }
                break;
            // Electric to Repair
            case 1:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Electric to Oxyzen
            case 2:
                if (isLock)
                {
                    EventManager.Instance.ElectricOxyzenLockDoorOpen();
                }
                else
                {
                    EventManager.Instance.ElectricOxyzenDoorOpen();
                    door.Open();
                }
                break;
            // Oxyzen to Electric
            case 3:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Oxyzen to Lift
            case 4:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Lift to Oxyzen
            case 5:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Lift to Controll
            case 6:
                if (isLock)
                {

                }
                else
                {
                    EventManager.Instance.LiftControlStationDoorOpen();
                    door.Open();
                }
                break;
            // Controll to Lift
            case 7:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Electric to Lift
            case 8:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;
            // Lift to Electric
            case 9:
                if (isLock)
                {

                }
                else
                {
                    door.Open();
                }
                break;

        }
    }
}
