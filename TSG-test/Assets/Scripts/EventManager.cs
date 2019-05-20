using System;
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
                instance = GameObject.FindObjectOfType(typeof(EventManager)) as EventManager;
            }
            return instance;
        }
        set { instance = value; }
    }

    public Action<SingleRodPanel> OnSingleRodPanelClick;
    public UnityEvent OnFullyLoadRodSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DispatchOnSingleRodPanelClick(SingleRodPanel rodPanel)
    {
        if (OnSingleRodPanelClick != null)
        {
            OnSingleRodPanelClick.Invoke(rodPanel);
        }
    }

    public void DispatchOnFullyLoadRodSlider()
    {
        if (OnFullyLoadRodSlider != null)
        {
            OnFullyLoadRodSlider.Invoke();
        }
    }
}
