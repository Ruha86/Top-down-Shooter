using UnityEngine;

// ����� ������������ �� IPhysicHittable
// ������ ������������ �� MonoBehaviour
public class PhysicObject : MonoBehaviour, IPhysicHittable

{
    // ��������� Rigidbody �� ���������� �������
    private Rigidbody _rigidbody;

    // ��������� ����� Hit() �� ����������
    public void Hit(Vector3 force, Vector3 position)
    {
        // �������� ����� CheckRigidbody()
        CheckRigidbody();

        // ��������� � Rigidbody ���� force � ������� position
        _rigidbody.AddForceAtPosition(force, position, ForceMode.Impulse);
    }
    // ��������� ������� Rigidbody
    private void CheckRigidbody()
    {
        // ���� ���������� _rigidbody �� ������
        if (!_rigidbody)
        {
            // ����������� �� Rigidbody �������� �������
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
