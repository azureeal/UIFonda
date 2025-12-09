using UnityEngine;
using UnityEngine.UI;

public class ScrollBarScript : MonoBehaviour
{
    [SerializeField] RectTransform content;   // The object with the VerticalLayoutGroup
    [SerializeField] float scrollRange = 500; // How far content can move (adjust this!)

    private Scrollbar bar;

    void Start()
    {
        bar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        // map scrollbar.value (0 to 1) to content position
        float y = Mathf.Lerp(0, scrollRange, bar.value);

        content.anchoredPosition = new Vector2(content.anchoredPosition.x, y);
    }
}
