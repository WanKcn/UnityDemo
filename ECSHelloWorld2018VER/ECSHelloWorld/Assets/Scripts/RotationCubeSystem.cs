/***
 *  使用Unity2018.4版本 开发ECS的HelloWorld
 *
 *  定义ECS的"系统" 只有方法没有数据
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities; // 引入命名空间

// 抽象方法
public class RotationCubeSystem : ComponentSystem
{
    struct Group
    {
        public RotationCubeComponent rotation;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
        // GetEntities 2018所有 2019被废弃
        foreach (var en in GetEntities<Group>())
        {
            // 进行旋转
            en.transform.Rotate(Vector3.down, en.rotation.speed * Time.deltaTime);
        }
    }
}