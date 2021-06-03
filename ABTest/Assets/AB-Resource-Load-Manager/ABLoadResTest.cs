using System;
using UnityEngine;
using Object = System.Object;


public class ABLoadResTest : MonoBehaviour
{
    private void Start()
    {
       
        GameObject obj1 = ABManager.GetInstance().LoadResource("model", "Cube") as GameObject;
        obj1.transform.position = -Vector3.up;
        GameObject obj2 = ABManager.GetInstance().LoadResource("model", "Cube", typeof(GameObject)) as GameObject;
        obj2.transform.position = Vector3.up;
        GameObject obj3 = ABManager.GetInstance().LoadResource<GameObject>("model", "Cube");
        obj3.transform.position = Vector3.left;
    }
}