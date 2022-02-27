using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] RectTransform scrollMask;
    public Position position;
    public float scrollSpeed = 1f;
    public int activePlayers = 0;
    public Vector2 boxSize;
    public bool isSingleRect = false;
    
    [SerializeField] ScrollRect[] container;

    private Vector2 m_NextScrollPosition;
    public bool isMouseOver = false;

    private void Update()
    {
        if (isMouseOver == true)
        {
            // Lerp scrolling code.

            if (position == Position.Left || position == Position.Right)
            {
                for (int i = 0; i < container.Length; i++)
                {
                    container[i].horizontalNormalizedPosition = Mathf.Lerp(container[i].horizontalNormalizedPosition, m_NextScrollPosition.x, scrollSpeed * Time.unscaledDeltaTime);
                }
            }

            if (position == Position.Top || position == Position.Bottom)
            {
                for (int i = 0; i < container.Length; i++)
                {
                    container[i].verticalNormalizedPosition = Mathf.Lerp(container[i].verticalNormalizedPosition, m_NextScrollPosition.y, scrollSpeed * Time.unscaledDeltaTime);
                }
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        activePlayers = 0;

        for (int i = 0; i < container.Length; i++)
        {
            if (container[i].gameObject.activeInHierarchy == true) activePlayers++;
        }

        if (position == Position.Left || position == Position.Right)
        {
            if (!isSingleRect)
            {
                scrollMask.sizeDelta = new Vector2(scrollMask.sizeDelta.x, boxSize.y * activePlayers);
            }

            else if (isSingleRect)
            {
                scrollMask.sizeDelta = new Vector2(scrollMask.sizeDelta.x, boxSize.y);
            }
        }

        else if (position == Position.Top || position == Position.Bottom)
        {

            if (!isSingleRect)
            {
                scrollMask.sizeDelta = new Vector2(boxSize.x * activePlayers, scrollMask.sizeDelta.y);
            }
            else if (isSingleRect)
            {
                scrollMask.sizeDelta = new Vector2(boxSize.x, scrollMask.sizeDelta.y);
            }
        }

        ScrollToSelected();
        isMouseOver = true;
        Debug.Log($"Active players: {activePlayers}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        Debug.Log($"Mouse over on exit: {isMouseOver}");
    }

    public void ScrollToSelected()
    {
        if (position == Position.Left)
        {
            m_NextScrollPosition = new Vector2(-1, 0);
            Debug.Log("Do left stuff");
        }
        else if (position == Position.Right)
        {
            m_NextScrollPosition = new Vector2(1.5f, 0);
            Debug.Log("Do right stuff");
        }
        else if (position == Position.Bottom)
        {
            m_NextScrollPosition = new Vector2(0, -1f);
            Debug.Log("Do bottom stuff");
        }
        else if (position == Position.Top)
        {
            m_NextScrollPosition = new Vector2(0, 1.5f);
            Debug.Log("Do top stuff");
        }

    }



}