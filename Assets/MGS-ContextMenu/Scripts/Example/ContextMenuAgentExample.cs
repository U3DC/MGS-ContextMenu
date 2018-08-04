/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuAgentExample.cs
 *  Description  :  Example of context menu agent.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.ContextMenu
{
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuAgentExample")]
    public class ContextMenuAgentExample : ContextMenuAgent
    {
        #region Field and Property
        public Vector3 positionSnap = new Vector3(1, 0, 0);
        public Vector3 rotationSnap = new Vector3(0, 0, 30);
        public Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

        private const string TransformMenu = "TransformMenu";
        private const string ColorMenu = "ColorMenu";
        #endregion

        #region Public Method
        public override void OnMenuItemClick(int itemIndex)
        {
            if (menuName == TransformMenu)
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
                menuName = ColorMenu;
            }
            else if (menuName == ColorMenu)
            {
                GetComponent<Renderer>().material.color = colors[itemIndex];
                menuName = TransformMenu;
            }
        }
        #endregion
    }
}