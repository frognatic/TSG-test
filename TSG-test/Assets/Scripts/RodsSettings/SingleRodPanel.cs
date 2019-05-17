using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class SingleRodPanel : MonoBehaviour
{
    [SerializeField] private Image rodIconImage;
    [SerializeField] private TextMeshProUGUI rodNameText;
    [SerializeField] private Transform selectedPanel;

    public void Create(Sprite icon, string rodName)
    {
        rodIconImage.sprite = icon;
        rodNameText.text = rodName;
    }
}
