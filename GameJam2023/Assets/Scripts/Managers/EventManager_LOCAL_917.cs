using System.Collections.Generic;
using UnityEngine.Events;

namespace Utilities
{
	public enum GameEventType
	{
		NONE = -1,
		LIGHT_LIT,
		ANIM_OVER,
		HOTEL_PRAYED,
		UPDATED_UI_POINT,
        HOTEL_LOST,
        START_GAME
	}

	public static class EventManager
	{
		private static readonly IDictionary<GameEventType, UnityEvent> events =
			new Dictionary<GameEventType, UnityEvent>();

		public static void Subscribe(GameEventType type, UnityAction listener)
		{
			if (events.TryGetValue(type, out UnityEvent myEvent))
			{
				myEvent.AddListener(listener);
			}
			else
			{
				myEvent = new UnityEvent();
				myEvent.AddListener(listener);
				events.Add(type, myEvent);
			}
		}

		public static void Unsubscribe(GameEventType type, UnityAction listener)
		{
			if (events.TryGetValue(type, out UnityEvent myEvent))
			{
				myEvent.RemoveListener(listener);
			}
		}

		public static void Publish(GameEventType type)
		{
			if (events.TryGetValue(type, out UnityEvent myEvent))
			{
				myEvent.Invoke();
			}
		}
	}

	public static class EventManager<T>
	{
		private static readonly IDictionary<GameEventType, UnityEvent<T>> paramEvents =
			new Dictionary<GameEventType, UnityEvent<T>>();

		public static void SubscribeParam(GameEventType type, UnityAction<T> listener)
		{
			if (paramEvents.TryGetValue(type, out UnityEvent<T> myEvent))
			{
				myEvent.AddListener(listener);
			}
			else
			{
				myEvent = new UnityEvent<T>();
				myEvent.AddListener(listener);
				paramEvents.Add(type, myEvent);
			}
		}

		public static void UnsubscribeParam(GameEventType type, UnityAction<T> listener)
		{
			if (paramEvents.TryGetValue(type, out UnityEvent<T> myEvent))
			{
				myEvent.RemoveListener(listener);
			}
		}

		public static void PublishParam(GameEventType type, T param)
		{
			if (paramEvents.TryGetValue(type, out UnityEvent<T> myEvent))
			{
				myEvent.Invoke(param);
			}
		}
	}
	
	public static class OtherEventManager
	{
		private static readonly IDictionary<GameEventType, UnityEvent<EventInfo>> events =
			new Dictionary<GameEventType, UnityEvent<EventInfo>>();

		public static void Subscribe(GameEventType type, UnityAction<EventInfo> listener)
		{
			if (events.TryGetValue(type, out UnityEvent<EventInfo> myEvent))
			{
				myEvent.AddListener(listener);
			}
			else
			{
				myEvent = new UnityEvent<EventInfo>();
				myEvent.AddListener(listener);
				events.Add(type, myEvent);
			}
		}

		public static void Unsubscribe(GameEventType type, UnityAction<EventInfo> listener)
		{
			if (events.TryGetValue(type, out UnityEvent<EventInfo> myEvent))
			{
				myEvent.RemoveListener(listener);
			}
		}

		public static void Publish(GameEventType type, EventInfo info)
		{
			if (events.TryGetValue(type, out UnityEvent<EventInfo> myEvent))
			{
				myEvent.Invoke(info);
			}
		}
	}

	public interface EventInfo
	{
		
	}

	public struct GameOverEInfo : EventInfo
	{
		public bool success;

		public GameOverEInfo(bool success)
		{
			this.success = success;
		}
	}
}
