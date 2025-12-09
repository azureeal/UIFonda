using UnityEngine;
using UnityEngine.UI;

public class ScrollBarScript : MonoBehaviour
{
    [SerializeField] RectTransform content;
    [SerializeField] float scrollRange = 500;

    [SerializeField] private Scrollbar bar;

    void Start()
    {
    }

    void Update()
    {
        float y = Mathf.Lerp(0, scrollRange, bar.value);
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, y);
    }
}
