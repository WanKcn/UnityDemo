print("-------   调用数组 Array -------")

Vector3 = CS.UnityEngine.Vector3
-- C#调用数组
local obj = CS.ArrListDic()
-- 数组长度
print(obj.arr.Length)

-- 访问元素
print(obj.arr[1])

-- 遍历数组
-- 从0开始，Lua可以读到最大值 需要长度-1
for i=0,obj.arr.Length-1 do
	print(obj.arr[i])
end

-- 创建数组
local arr2 = CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)
for i=0,arr2.Length-1 do
	arr2[i]=i
end
-- 打印数组最后一个数
print(arr2[arr2.Length-1])


print("-------   调用列表 List -------")
-- 为列表添加元素 CS.ArrListDic().list 调用到列表
-- 调用成员方法 一定用冒号！！！
obj.list:Add(1)
obj.list:Add(2)
print(obj.list.Count)

-- 遍历列表
for i=0,obj.list.Count-1 do
	print(obj.list[i])
end
 
-- 自定义列表 先得到一个指定类型的列表类 通过类new列表
local List_String = CS.System.Collections.Generic.List(CS.System.String)
local list2 = List_String()
list2:Add("number1")
list2:Add("number2")
list2:Add("number2")

for i=0,list2.Count-1 do
	print(list2[i])
end

print("-------   调用字典 Dictionary-------")
obj.dic:Add(1,"111")
obj.dic:Add(2,"222")
print(obj.dic[1])

-- 遍历字典
for k,v in pairs(obj.dic) do
	print(k.."-"..v)
end

-- 自定义字典 先得到一个指定类型的列表类 通过类new列表
local Dic_String_Vector3 = CS.System.Collections.Generic.Dictionary(CS.System.String,Vector3)
local dic2 = Dic_String_Vector3()
-- 录入
dic2:Add("111",Vector3.right)
dic2:Add("222",Vector3.left)
dic2:Add("333",Vector3.up)
-- 打印 使用get_Item
print(dic2:get_Item("111"))
print(dic2:get_Item("222"))
print(dic2:get_Item("333"))
-- 遍历 字符串不可与vector连接
for k,v in pairs(dic2) do
	print(k,v)
end
-- 修改 set_Item
dic2:set_Item("333",Vector3.down)
print(dic2:get_Item("333"))

-- 通过TryGetValue获得 返回两个值，在C#中返回bool，通过out返回出来
print(dic2:TryGetValue("111")) 










