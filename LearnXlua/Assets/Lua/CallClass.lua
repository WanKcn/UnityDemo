print("----------   Lua调用C#中的 类   ----------")


-- 定义全局变量
-- 方便使用，节约性能 定义全局变量存储C#中的类，相当于取了一个别名
GameObject = CS.UnityEngine.GameObject
Debug = CS.UnityEngine.Debug
Vector3 = CS.UnityEngine.Vector3


-- 通过C#作为主入口调用Lua
-- Lua中使用C#的类固定写法  CS.命名空间.类名

-- Unity中的类 如GameObject Transform等 CS.UnityEngine.使用的类名
-- 通过C#中的类，实例化一个对象，lua中没有new，使用类名() 默认调用的相当于无参构造
local obj1 = CS.UnityEngine.GameObject()
local obj2 = CS.UnityEngine.GameObject("文若")
local obj3 = GameObject("全局变量实例的物体")

-- 类中的静态对象，可以直接使用 .来调用
local obj4 = GameObject.Find("文若")
-- 得到对象中的成员变量 对象.成员变量
print(obj4.transform.position)
Debug.Log(obj4.transform.position)

-- 如果使用对象中的成员方法，一定要加：冒号！！！
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position)


-- 调用自定义类 使用方法同上，只是命名空间不同
-- Test没有继承任何类，不再任何命名空间中 直接new
local test = CS.Test()
test:outPut("调用自定义类，不再命名空间中的类")

local test2 = CS.WRTest.TestInSpace()
test2:outPut("在命名空间中")


-- 继承了Mono的类不能直接new 这些类都是依附于GameObject上 通过AddCompent添加
-- 在C#里给对象加脚本有两种方式 通过泛型或者Type  Lua不支持无参泛型函数
-- 给对象加一个脚本 Xlua提供一个重要方法 typeof 可以得到类的Type
local obj5 = GameObject("加脚本测试")
obj5:AddComponent(typeof(CS.LuaCallCsharp))

