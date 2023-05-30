using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;
using InputDevice = UnityEngine.XR.InputDevice;

public class PlayerController : MonoBehaviour
{
    // Variables
    [Header("PLAYER PARAMS")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerHead;

    public void ResetPosition(Transform pos)
    {
        if (GameManager.instance.NameStand == "TunnelStand")
        {
            player.transform.SetParent(pos);
        }

        var rotationAngleY = pos.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = pos.position - playerHead.transform.position;
        player.transform.position += new Vector3(distanceDiff.x, player.transform.position.y, distanceDiff.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            ResetPosition(GameManager.instance.gamePlayerTransforms[4]);
        }
    }
}
