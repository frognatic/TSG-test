using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class SliderProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressValueText;

    public Slider ProgressSlider { get; set; }
    public bool IsFullyLoaded { get; private set; }

    private void Awake()
    {
        ProgressSlider = GetComponent<Slider>();
        ProgressSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        ValueChangeCheck();
    }

    private void ValueChangeCheck()
    {
        progressValueText.text = ((int)(ProgressSlider.value)).ToString();
        IsFullyLoaded = (int)ProgressSlider.value == 100;

        if (IsFullyLoaded)
        {
            EventManager.Instance.Dispatch(EventManager.ON_FULLY_LOAD_ROD_SLIDER);
        }
    }
}
