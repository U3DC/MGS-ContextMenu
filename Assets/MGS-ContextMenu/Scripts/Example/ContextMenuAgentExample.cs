/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: ContextMenuAgentExample.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/15/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.    ContextMenuAgentExample       Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/15/2017       0.1.0        Create this file.
 *************************************************************************/

using UnityEngine;

namespace Developer.ContextMenu
{
    [AddComponentMenu("Developer/ContextMenu/ContextMenuAgentExample")]
    public class ContextMenuAgentExample : ContextMenuAgent
    {
        #region Property and Field
        public Vector3 positionSnap = new Vector3(1, 0, 0);
        public Vector3 rotationSnap = new Vector3(0, 0, 30);
        public Color[] colors = new Color[] { Color.red, Color.blue, Color.green };
        #endregion

        #region Public Method
        public override void OnMenuItemClick(int itemIndex)
        {
            if (menuType == ContextMenuType.TransformMenu)
            {
                switch (itemIndex)
                {
                    case 0:
                        transform.position += positionSnap;
                        break;
                    case 1:
                        transform.position -= positionSnap;
                        break;
                    case 2:
                        transform.eulerAngles += rotationSnap;
                        break;
                    case 3:
                        transform.eulerAngles -= rotationSnap;
                        break;
                }
                menuType = ContextMenuType.ColorMenu;
            }
            else if (menuType == ContextMenuType.ColorMenu)
            {
                GetComponent<Renderer>().material.color = colors[itemIndex];
                menuType = ContextMenuType.TransformMenu;
            }
        }
        #endregion
    }
}