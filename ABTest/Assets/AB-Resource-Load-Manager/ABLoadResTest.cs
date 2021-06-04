using System;
using UnityEngine;
using Object = System.Object;


public class ABLoadResTest : MonoBehaviour
{
    private void Start()
    {
        // 测试同步加载
        GameObject obj1 = ABManager.GetInstance().LoadResource("model", "Cube") as GameObject;
        obj1.transform.position = -Vector3.up;
        GameObject obj2 = ABManager.GetInstance().LoadResource("model", "Cube", typeof(GameObject)) as GameObject;
        obj2.transform.position = -Vector3.down;
        GameObject obj3 = ABManager.GetInstance().LoadResource<GameObject>("model", "Cube");
        obj3.transform.position = -Vector3.left;


        // 测试异步加载
        ABManager.GetInstance().LoadResourceAsync("model", "Cube",
            ob1 => { (ob1 as GameObject).transform.position = Vector3.up * 3; });
        ABManager.GetInstance().LoadResourceAsync("model", "Cube", typeof(GameObject),
            ob2 => { (ob2 as GameObject).transform.position = Vector3.down * 3; });
        ABManager.GetInstance().LoadResourceAsync<GameObject>("model", "Cube",
            ob3 => { ob3.transform.position = Vector3.right * 3; });
    }
}