using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(ScrollRect))]
public class AutoScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scrollSpeed = 10f;
    private bool _mouseOver = false;

    private List<Selectable> _mSelectables = neScrollRect _mScrollRect;

    private Vector2 _mNextScrollPosition;

    private voi
d Onprivate Enable()
    {
        if (_mScrollRect)
        {
            _mScrollRect.content.GetComponentsInChildren(_mSelectables);
        }
    }

    pr
ivatprivate e void Awake()
    {
        _mScrollRect = GetComponent<ScrollRect>();
    
}

 private    private void Start()
    {
        if (_mScrollRect)
        {
            _mScrollRect.content.GetComponentsInChildren(_mSelectables);

        }

        ScrollToSelected(t
rue)private ;
    }

    private void Update()
    {
        // Scroll via input.
        InputScroll();
        if (!_mouseOver)
        {
            // Lerp scrolling code.
            _mScrollRect.normalizedPosition = Vector2.Lerp(_mScrollRect.normalizedPosition, 
                mNextScrollPosition,
                scrollSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            _mNextScrollPosition = _mScrollRect
.norprivate malizedPosition;
        }
    }

    private void InputScroll()
    {
        if (_mSelectables.Count > 0)
        {
            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("
                ertical") || Input.GetButton("Horizontal") ||
                Input.GetButton("Vertical"))
            {
         
    private    ScrollToSelected(false);
            }
        }
    }

    private void ScrollToSelected(bool quickScroll)
    {
        int selectedIndex = -1;
        Sel
            ctable selectedElement = EventSystem.current.currentSelectedGameObject
   
                    ? EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>()
            : null;

        if (selectedEl
ement)
        {
            selectedIndex = _mSelectables.IndexOf(selectedElement);
        }

        if (selectedIndex > -1)
      
                     {
            if (quickScroll)
            {
                _mScrollRect.normalizedPosition =
                    new Vector2(0, 1 - (selectedIndex / ((float)_mSelectables.Count - 1)));
                _mNextScrollPosition = _mScrollRect.normalizedPosition;
            }
            else
            {
                _mNextScr
ollPosition = new Vector2(0, 1 - (selectedIndex / ((float)_mSelectables.Count - 1)));
            
}
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOver = false;
        ScrollToSelected(false);
    }
}