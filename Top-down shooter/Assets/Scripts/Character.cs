using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Части персонажа
    private CharacterPart[] _parts;

    private void Start()
    {
        // Вызываем метод Init()
        Init();
    }

    private void Init()
    {
        // Получаем компоненты частей персонажа
        _parts = GetComponents<CharacterPart>();

        // Проходим по всем частям
        for (int i = 0; i < _parts.Length; i++)
        {
            // Вызываем метод Init() для каждой части
            _parts[i].Init();
        }
        // Вызываем метод InitDeath()
        InitDeath();
    }

    private void InitDeath()
    {
        // Проходим по всем частям
        for (int i = 0; i < _parts.Length; i++)
        {
            // Если часть — экземпляр класса CharacterHealth
            if (_parts[i] is CharacterHealth health)
            {
                // Подписываемся на событие OnDie объекта health
                // Указываем, что при возникновении события должен выполниться метод Stop()
                health.OnDie += Stop;
            }
        }
    }

    private void Stop()
    {
        // Проходим по всем частям
        for (int i = 0; i < _parts.Length; i++)
        {
            // Вызываем метод Stop() для каждой части
            _parts[i].Stop();
        }
    }
}
