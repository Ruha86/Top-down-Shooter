using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : CharacterMovement
{
    // ��������� � ������ ��������������� ��������
    private const string MovementHorizontalKey = "Horizontal";

    // ��������� � ������ ������������� ��������
    private const string MovementVerticalKey = "Vertical";

    // �������� ����������
    private Animator _animator;

    // ������������� �����
    // ��������� ���������� � ����
    private NavMeshAgent _navMeshAgent;

    // ���������� �������� �����
    // ����� ����� ������ � ��� �������
    private Transform _playerTransform;

    // ���������� ������� �����
    private Vector3 _prevPosition;

    protected override void OnInit()
    {
        // ����������� _animator ��������� Animator �� �������� ��������
        _animator = GetComponentInChildren<Animator>();

        // ����������� _navMeshAgent ��������� NavMeshAgent
        _navMeshAgent = GetComponent<NavMeshAgent>();

        // ����������� _playerTransform ���������� �����
        // FindAnyObjectByType<Player>() ���� ������ �� ���� Player
        _playerTransform = FindAnyObjectByType<Player>().transform;

        // ����������� _prevPosition ������� ������� �����
        _prevPosition = transform.position;
    }

    private void Update()
    {

        // ���� ���� �� �������
        if (!IsActive)
        {
            // ������� �� ������
            return;
        }

        // ������������� ������� ������� �����
        SetTargetPosition(_playerTransform.position);

        // ��������� �������� �����
        RefreshAnimation();
    }

    private void SetTargetPosition(Vector3 position)
    {
        // ������������� ������� ������� �����
        _navMeshAgent.SetDestination(position);
    }

    private void RefreshAnimation()
    {
        // �������� ������� ������� �����
        Vector3 curPosition = transform.position;

        // ��������� ������� ����� ������� � ���������� ��������
        Vector3 deltaMove = curPosition - _prevPosition;

        // ��������� ������� ������� � _prevPosition
        // ��� ������������� ��� ��������� ���������� ��������
        _prevPosition = curPosition;

        // ����������� ������� �������, ����� ��� ����� ����� 1
        deltaMove.Normalize();

        // ��������� ������������� �������� �� ��� X
        float relatedX = Vector3.Dot(deltaMove, transform.right);

        // ��������� ������������� �������� �� ��� Y
        float relatedY = Vector3.Dot(deltaMove, transform.forward);

        // ������������� �������� ������������� �������� � ���������

        // ��� �������� �� �����������
        _animator.SetFloat(MovementHorizontalKey, relatedX);

        // ��� �������� �� ���������
        _animator.SetFloat(MovementVerticalKey, relatedY);
    }

    protected override void OnStop()
    {
        // ��������� ������������� �����
        _navMeshAgent.enabled = false;

        // ��������� �������� �����
        RefreshAnimation();
    }
}
