using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Istate ��Ϊһ���ӿ�ʹ��
//ͨ���ӿڶ���״̬���еķ���
public interface Istate 
{
    //״̬����
    void Enter();
    //״̬�˳�
    void Exit();
    //״̬�߼�����
    void LogicUpdate();
    //��ɫ�ƶ��������壬�����������
    void PhysicUpdate();
}
