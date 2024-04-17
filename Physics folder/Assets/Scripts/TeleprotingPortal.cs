using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TeleprotingPortal : MonoBehaviour
{
    [SerializeField]
    private Transform teleport;

    public Transform GetTeleport()
    {
        return teleport;
    }
}



