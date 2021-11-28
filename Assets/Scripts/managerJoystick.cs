using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class managerJoystick : MonoBehaviour, IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    private Image imgJoystickBg;
    private Image imgJoystick;
    private Vector2 postInput;
    // Start is called before the first frame update
    void Start()
    {
        imgJoystickBg = GetComponent<Image>();
        imgJoystick = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgJoystickBg.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out postInput))
        {
            postInput.x = postInput.x / (imgJoystickBg.rectTransform.sizeDelta.x);
            postInput.y = postInput.y / (imgJoystickBg.rectTransform.sizeDelta.y);
            Debug.Log(postInput.x.ToString() + " /" + postInput.y.ToString());

            if(postInput.magnitude > 1f)
            {
                postInput = postInput.normalized;
            }

            imgJoystick.rectTransform.anchoredPosition = new Vector2(
                postInput.x * (imgJoystickBg.rectTransform.sizeDelta.x / 2), 
                postInput.y * (imgJoystickBg.rectTransform.sizeDelta.y /2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
        if (transform.parent.name == "Shooter Area")
        {
            FindObjectOfType<managerCharacter>().startShoot();
            FindObjectOfType<PlayerWeapon>().tembak = true;
        }
            
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        postInput = Vector2.zero;
        imgJoystick.rectTransform.anchoredPosition = Vector2.zero;
        if(transform.parent.name== "Shooter Area")
        {
            FindObjectOfType<managerCharacter>().endShoot();
            FindObjectOfType<PlayerWeapon>().tembak = false;
        }
        
    }

    public float inputHorizontal()
    {
        if (postInput.x != 0)
        {
            return postInput.x;
        }
        else
            return Input.GetAxis("Horizontal");
    }

    public float inputVertical()
    {
        if (postInput.y != 0)
        {
            return postInput.y;
        }
        else
            return Input.GetAxis("Vertical");
    }

    public float inputMouseX()
    {
        if (postInput.x != 0)
        {
            return postInput.x;
        }
        else
            return Input.GetAxis("Mouse X");
    }

    public float inputMouseY()
    {
        if (postInput.y != 0)
        {
            return postInput.y;
        }
        else
            return Input.GetAxis("Mouse Y");
    }

}
