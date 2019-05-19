using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public Action<SingleRodPanel> OnSingleRodPanelClick;
    public UnityEvent OnFullyLoadRodSlider;

    private void Awake()
    {
        Instance = this;
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
