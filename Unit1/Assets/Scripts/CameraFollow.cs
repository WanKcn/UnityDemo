using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    // 相机到汽车坐标的距离
    private Vector3 offset = new Vector3(0, 5, -7);

    void LateUpdate()
    {
        // 相机视野跟随player  在Player坐标基础上 + 位移
        transform.position = player.transform.position + offset;
    }
}