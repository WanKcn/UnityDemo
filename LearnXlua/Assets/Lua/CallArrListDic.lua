print("-------   调用数组 Array -------")

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

print("-------   调用字典 Dictionary-------")

