using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // ����� ���������
    private CharacterPart[] _parts;

    private void Start()
    {
        // �������� ����� Init()
        Init();
    }

    private void Init()
    {
        // �������� ���������� ������ ���������
        _parts = GetComponents<CharacterPart>();

        // �������� �� ���� ������
        for (int i = 0; i < _parts.Length; i++)
        {
            // �������� ����� Init() ��� ������ �����
            _parts[i].Init();
        }
        // �������� ����� InitDeath()
        InitDeath();
    }

    private void InitDeath()
    {
        // �������� �� ���� ������
        for (int i = 0; i < _parts.Length; i++)
        {
            // ���� ����� � ��������� ������ CharacterHealth
            if (_parts[i] is CharacterHealth health)
            {
                // ������������� �� ������� OnDie ������� health
                // ���������, ��� ��� ������������� ������� ������ ����������� ����� Stop()
                health.OnDie += Stop;
            }
        }
    }

    private void Stop()
    {
        // �������� �� ���� ������
        for (int i = 0; i < _parts.Length; i++)
        {
            // �������� ����� Stop() ��� ������ �����
            _parts[i].Stop();
        }
    }
}
