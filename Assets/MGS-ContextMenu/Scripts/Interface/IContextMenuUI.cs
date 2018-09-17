/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuUI.cs
 *  Description  :  Define interface for context menu UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Interface for context menu UI.
    /// </summary>
    public interface IContextMenuUI
    {
        #region Property
        /// <summary>
        ///  Name of context menu.
        /// </summary>
        string MenuName { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Show context menu.
        /// </summary>
        /// <param name="agent">Agent of menu.</param>
        /// <param name="mousePosition">Screen position of mouse pointer.</param>
        void Show(IContextMenuAgent agent, Vector2 mousePosition);

        /// <summary>
        /// Close context menu.
        /// </summary>
        void Close();
        #endregion
    }
}