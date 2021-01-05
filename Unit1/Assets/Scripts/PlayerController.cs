using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // 控制前后运动
    private float verticalInput;

    // 控制旋转y轴
    private float horizontalInput;

    // 旋转速度
    private float turnSpeed = 50;


    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical"); // 获得（-1，1）
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput); // 0,1,0 沿着y轴移动即旋转
    }
}