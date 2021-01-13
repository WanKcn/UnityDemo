# UnityDemo
Unity3D学习制作的Demo





## Unit1

控制玩家移动

```C#
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
```

相机视野跟随

```c#
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
```

