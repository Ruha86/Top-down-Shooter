using UnityEngine;

// ������� ����� �����������
public abstract class CharacterPart : MonoBehaviour
{
    // ���� ���������� ���������
    protected bool IsActive;

    // ����� ������������� (������ �� �����������)
    public void Init()
    {
        // ������ ��������� ��������
        IsActive = true;

        // �������� ����� OnInit()
        // ����������� ��� �������� ��������
        OnInit();
    }
    // ����� ��������� ���������
    public void Stop()
    {
        // ������ ��������� ����������
        IsActive = false;

        // �������� ����� OnStop()
        // ����������� ��� �������� ��������
        OnStop();
    }

    // ����������� ����� ������������� 
    protected virtual void OnInit() { }

    // ����������� ����� ���������
    protected virtual void OnStop() { }
}
