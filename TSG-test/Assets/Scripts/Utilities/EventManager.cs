using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(EventManager)) as EventManager;
            }
            return instance;
        }
        set { instance = value; }
    }
    
    private Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();

    public Action<SingleRodPanel> OnSingleRodPanelClick;
    public const string ON_FULLY_LOAD_ROD_SLIDER = "ON_FULLY_LOAD_ROD_SLIDER_EVENT";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Add(string eventName, UnityAction listener)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.AddListener(listener);
        }
        else
        {
            eventData = new UnityEvent();
            eventData.AddListener(listener);

            eventDictionary.Add(eventName, eventData);
        }
    }

    public void Dispatch(string eventName)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.Invoke();
        }
    }

    public void Remove(string eventName, UnityAction listener)
    {
        UnityEvent eventData = null;
        if (eventDictionary.TryGetValue(eventName, out eventData))
        {
            eventData.RemoveListener(listener);
        }
    }

    public void DispatchOnSingleRodPanelClick(SingleRodPanel rodPanel)
    {
        if (OnSingleRodPanelClick != null)
        {
            OnSingleRodPanelClick.Invoke(rodPanel);
        }
    }
}
