using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMngTest : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        // 文件存在
        LuaManager.GetInstance().DoString("require('Main')");
        // 不存在该文件
        LuaManager.GetInstance().DoString("require('Main_2')");
    }
    
}
