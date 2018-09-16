/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuItem.cs
 *  Description  :  Define interface for context menu item.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine.Events;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Interface for context menu item.
    /// </summary>
    public interface IContextMenuItem
    {
        #region Property
        /// <summary>
        /// Name of menu item.
        /// </summary>
        string ItemName { set; get; }

        /// <summary>
        /// Interactable of menu item.
        /// </summary>
        bool Interactable { set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Add listener to menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        void AddListener(UnityAction callback);

        /// <summary>
        /// Remove listener from menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        void RemoveListener(UnityAction callback);
        #endregion
    }
}