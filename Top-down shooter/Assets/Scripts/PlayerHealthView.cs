using UnityEngine;

// ������ ������������ �� CharacterHealthView
public class PlayerHealthView : CharacterHealthView
{
    private void Start()
    {
        // ����������� playerHealth ��������
        // ������ ������� ���� PlayerHealth
        CharacterHealth playerHealth = FindAnyObjectByType<PlayerHealth>();

        // �������������� ������ playerHealth
        Init(playerHealth);
    }
}
