using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
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
}
