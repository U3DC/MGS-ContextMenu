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

using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.ContextMenu
{
    public static class TransformMenu
    {
        public const string Name = "TransformMenu";

        public const string PositionI = "Position+";
        public const string PositionD = "Position-";
        public const string RotationI = "Rotation+";
        public const string RotationD = "Rotation-";
    }

    public static class ColorMenu
    {
        public const string Name = "ColorMenu";

        public const string ColorA = "ColorA";
        public const string ColorB = "ColorB";
        public const string ColorC = "ColorC";
    }

    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuAgentExample")]
    public class ContextMenuAgentExample : ContextMenuAgent
    {
        #region Field and Property
        public Vector3 positionSnap = new Vector3(1, 0, 0);
        public Vector3 rotationSnap = new Vector3(0, 0, 30);
        public Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

        public override IEnumerable<string> DisableItems
        {
            get
            {
                disableItems.Clear();
                if (menuName == TransformMenu.Name)
                {
                    if (transform.localPosition.x <= -3)
                    {
                        disableItems.Add(TransformMenu.PositionD);
                    }
                    else if (transform.localPosition.x >= 3)
                    {
                        disableItems.Add(TransformMenu.PositionI);
                    }
                }
                return disableItems;
            }
        }
        private List<string> disableItems = new List<string>();
        #endregion

        #region Public Method
        public override void OnMenuItemClick(string itemName)
        {
            if (menuName == TransformMenu.Name)
            {
                switch (itemName)
                {
                    case TransformMenu.PositionI:
                        transform.localPosition += positionSnap;
                        break;

                    case TransformMenu.PositionD:
                        transform.localPosition -= positionSnap;
                        break;

                    case TransformMenu.RotationI:
                        transform.localEulerAngles += rotationSnap;
                        break;

                    case TransformMenu.RotationD:
                        transform.localEulerAngles -= rotationSnap;
                        break;
                }
                menuName = ColorMenu.Name;
            }
            else if (menuName == ColorMenu.Name)
            {
                var index = 0;
                switch (itemName)
                {
                    case ColorMenu.ColorA:
                        index = 0;
                        break;

                    case ColorMenu.ColorB:
                        index = 1;
                        break;

                    case ColorMenu.ColorC:
                        index = 2;
                        break;
                }
                GetComponent<Renderer>().material.color = colors[index];
                menuName = TransformMenu.Name;
            }
        }
        #endregion
    }
}