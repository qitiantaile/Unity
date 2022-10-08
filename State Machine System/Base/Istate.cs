using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Istate 作为一个接口使用
//通过接口定义状态必有的方法
public interface Istate 
{
    //状态进入
    void Enter();
    //状态退出
    void Exit();
    //状态逻辑更新
    void LogicUpdate();
    //角色移动依靠刚体，加入物理更新
    void PhysicUpdate();
}
