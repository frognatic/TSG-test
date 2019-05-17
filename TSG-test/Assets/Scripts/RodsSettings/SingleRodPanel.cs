using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class SingleRodPanel : MonoBehaviour
{
    [SerializeField] private Image rodIconImage;
    [SerializeField] private Image rodFrameBackgroundImage;
    [SerializeField] private TextMeshProUGUI rodNameText;
    [SerializeField] private Transform selectedPanel;

    public void Create(Sprite icon, Sprite frameIcon, string rodName)
    {
        rodIconImage.sprite = icon;
        rodFrameBackgroundImage.sprite = frameIcon;
        rodNameText.text = rodName;
    }
}
