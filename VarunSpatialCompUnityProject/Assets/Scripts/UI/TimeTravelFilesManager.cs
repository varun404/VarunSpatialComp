using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelFilesManager : MonoBehaviour
{
    //public UISelection uISelectionBox;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        uISelectionBox.selectionBoxStartPos = Input.mousePosition;

    //    if (Input.GetMouseButton(0))
    //        uISelectionBox.UpdateSelectionBox(Input.mousePosition);

    //    //if (Input.GetMouseButtonUp(0))
    //    //    uISelectionBox.ReleaseSelectionBox();
    //}
}

//[System.Serializable]
//public class UISelection
//{
//    [SerializeField]
//    RectTransform selectionBox;


//    public Vector2 selectionBoxStartPos;


//    float height, width;
//    public void UpdateSelectionBox(Vector2 mousePositionOnScreen)
//    {
//        width = mousePositionOnScreen.x - selectionBoxStartPos.x;
//        height = mousePositionOnScreen.y - selectionBoxStartPos.y;

//        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
//        selectionBox.anchoredPosition = selectionBoxStartPos + new Vector2(width / 2, height / 2);
//    }


//    public void ReleaseSelectionBox()
//    {
//        selectionBox.gameObject.SetActive(false);


//        //Check selection
//    }
//}
