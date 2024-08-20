using UnityEngine;

public interface IPhysicHittable
{
    // Задаём пустой метод Hit()
    void Hit(Vector3 force, Vector3 position);
}
