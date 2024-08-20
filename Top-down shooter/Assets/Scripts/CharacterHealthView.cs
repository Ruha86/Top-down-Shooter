using UnityEngine;

public abstract class CharacterHealthView : MonoBehaviour
{
    // ���������� ����� ��������� ��������
    [SerializeField] private Transform _percentsImageTransform;

    // ���� �������� ���������
    private CharacterHealth _characterHealth;

    public void Init(CharacterHealth characterHealth)
    {
        // ����� �������� ����� �������� ���������
        _characterHealth = characterHealth;

        // ������������� �� ������� OnAddHealthPoints
        // ���������, ��� ��� ������������� ������� ������ ����������� ����� Refresh()
        _characterHealth.OnAddHealthPoints += Refresh;
    }

    private void Refresh()
    {
        // ��������� �������� ����� �������� ��������� � ���������:
        // ����� ��� ������� ���� �������� �� ���������
        float percents = (float)_characterHealth.GetHealthPoints() / _characterHealth.GetStartHealthPoints();

        // ���������� ������� Mathf.Clamp01()
        // ����� ���������� �������� � ��������� �� 0 �� 1
        percents = Mathf.Clamp01(percents);

        // ������������� �������� ����� ��������
        SetPercents(percents);
    }

    private void SetPercents(float value)
    {
        // ����� ������� ���������� ������� � ����������
        _percentsImageTransform.localScale = new Vector3(value, 1, 1);
    }

    private void OnDestroy()
    {
        // ������������ �� ������� OnAddHealthPoints
        // ��� ����������� ���������
        _characterHealth.OnAddHealthPoints -= Refresh;
    }
}
