/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: ColorExample.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/15/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.         ColorExample             Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/15/2017       0.1.0        Create this file.
 *************************************************************************/

namespace Developer.ContextMenu
{
    using UnityEngine;

    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Developer/ContextMenu/ColorExample")]
    public class ColorExample : ContextMenuAgent
    {
        #region Property and Field
        public Color[] colors = new Color[3];
        #endregion

        #region Public Method
        public override void OnMenuItemClick(int itemIndex)
        {
            GetComponent<Renderer>().material.color = colors[itemIndex];
        }
        #endregion
    }
}