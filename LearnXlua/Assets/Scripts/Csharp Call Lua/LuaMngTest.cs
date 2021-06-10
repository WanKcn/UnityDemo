using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMngTest : MonoBehaviour
{
    void Start()
    {
        LuaManager.GetInstance().Init();
        // 文件存在
        LuaManager.GetInstance().DoLuaFile("Main");
        // // 存在AB包中的文件
        // LuaManager.GetInstance().DoLuaFile("Main");
        // // 不存在该文件
        // LuaManager.GetInstance().DoLuaFile("Mian_2");
    }
    
}
