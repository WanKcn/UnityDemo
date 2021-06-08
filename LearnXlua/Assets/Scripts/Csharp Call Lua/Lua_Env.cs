using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class Lua_Env : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Lua解析器，能够在Unity中执行lua
        // 一般情况下保持唯一性
        LuaEnv env = new LuaEnv();
        // 执行Lua语言 (语言，报错的文件名，哪个解析器)
        env.DoString("print('helloworld')");

        // 执行一个lua脚本 多脚本执行 require 默认路径 resources
        // 通过Resource.load加载Lua脚本 需要添加txt
        env.DoString("require('Main')");
        // 垃圾回收，清除没有手动释放的对象，帧更新中定时执行 时间可以自己来定  或者切换场景时执行
        env.Tick();
        
        // 保持唯一性很少销毁lua解析器
        env.Dispose();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
