using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puckTeleporter : MonoBehaviour
{
    private GameObject teleport;
    [SerializeField]
    private int cooldown = 1;
    private bool canTeleport;

    private void Update()
    {
        if (canTeleport)
        {
            if (teleport != null)
            {
                transform.position = teleport.GetComponent<TeleprotingPortal>().GetTeleport().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "portal1")
        {
            teleport = other.gameObject;
            canTeleport = false;
            Invoke("ResetTeleportCooldown", cooldown);
        }
        if (other.tag == "portal2")
        {
            teleport = other.gameObject;
            canTeleport = false;
            Invoke("ResetTeleportCooldown", cooldown);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "portal1" || collision.tag == "portal2")
        {
            if (collision.gameObject == teleport)
            {
                teleport = null;
            }
        }
    }
    private void ResetTeleportCooldown()
    {
        canTeleport = true;

    }
}
