using UnityEngine;
using UnityEngine.UI;

public class ItemSlotView : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Button button;
    [SerializeField] private Sprite emptySprite;

    public void SetIcon(Sprite icon)
    {
        iconImage.sprite = icon;
        iconImage.enabled = icon != null;
    }

    public void SetOnClick(System.Action callback)
    {
        button.onClick.RemoveAllListeners();
        if (callback != null)
            button.onClick.AddListener(() => callback());
    }

    public void Clear()
    {
        iconImage.sprite = emptySprite;
        button.onClick.RemoveAllListeners();
    }
}
