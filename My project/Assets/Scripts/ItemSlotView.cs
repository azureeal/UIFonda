using UnityEngine;
using UnityEngine.UI;

public class ItemSlotView : MonoBehaviour
{
    [SerializeField] Image iconImage;
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetIcon(Sprite icon)
    {
        iconImage.sprite = icon;
    }

    public void SetOnClick(System.Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => action());
    }
    public void Clear()
    {
        iconImage.sprite = null;
        button.onClick.RemoveAllListeners();
    }

}
