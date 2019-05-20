using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class SingleRodPanel : MonoBehaviour
{
    [SerializeField] private Image rodIconImage;
    [SerializeField] private Image rodFrameBackgroundImage;
    [SerializeField] private TextMeshProUGUI rodNameText;
    [SerializeField] private Button selectButton;
    [SerializeField] private SliderProgress sliderProgress;
    [SerializeField] private Transform upgradeArrow;

    public Transform SelectedPanel;

    public bool IsRodSelected { get; set; }
    public int SelectedRodModel { get; set; }

    private void OnEnable()
    {
        EventManager.Instance.Add(EventManager.ON_FULLY_LOAD_ROD_SLIDER, OnFullyLoadRodSliderResponseReceived);
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.Remove(EventManager.ON_FULLY_LOAD_ROD_SLIDER, OnFullyLoadRodSliderResponseReceived);
        }
    }

    private void Awake()
    {
        selectButton.onClick.AddListener(OnClickRodIcon);
    }

    public void Create(Sprite icon, Sprite frameIcon, string rodName, int rodModel, int sliderValue)
    {
        rodIconImage.sprite = icon;
        rodFrameBackgroundImage.sprite = frameIcon;
        rodNameText.text = rodName;
        SelectedPanel.gameObject.SetActive(IsRodSelected);
        SelectedRodModel = rodModel;
        sliderProgress.ProgressSlider.value = sliderValue;
        upgradeArrow.gameObject.SetActive(false);
    }

    private void OnClickRodIcon()
    {
        EventManager.Instance.DispatchOnSingleRodPanelClick(this);
    }

    private void OnFullyLoadRodSliderResponseReceived()
    {
        upgradeArrow.gameObject.SetActive((int)sliderProgress.ProgressSlider.value == 100);
    }
}
