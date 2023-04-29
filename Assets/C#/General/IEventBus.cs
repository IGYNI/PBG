using UnityEngine.Events;

namespace General
{
    public interface IEventBus
    {
        void Dispatch(GameEventType eventType);
        void Subscribe(GameEventType eventType, params UnityAction[] action);
        void UnSubscribe(GameEventType eventType, params UnityAction[] action);
    }
}