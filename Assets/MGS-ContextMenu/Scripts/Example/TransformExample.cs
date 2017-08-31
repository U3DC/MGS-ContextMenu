/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: TransformExample.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/15/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.       TransformExample           Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/15/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.ContextMenu
{
    using UnityEngine;

    [AddComponentMenu("Developer/ContextMenu/TransformExample")]
    public class TransformExample : ContextMenuAgent
    {
        #region Property and Field
        public Vector3 positionSnap = new Vector3(1, 0, 0);
        public Vector3 rotationSnap = new Vector3(0, 0, 30);
        #endregion

        #region Public Method
        public override void OnMenuItemClick(int itemIndex)
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
        }
        #endregion
    }
}