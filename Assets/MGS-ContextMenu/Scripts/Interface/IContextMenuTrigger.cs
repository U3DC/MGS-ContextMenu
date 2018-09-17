/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuTrigger.cs
 *  Description  :  Define interface for context menu trigger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/17/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Interface for context menu trigger.
    /// </summary>
    public interface IContextMenuTrigger
    {
        #region Property
        /// <summary>
        ///  Layer of ray.
        /// </summary>
        LayerMask LayerMask { set; get; }

        /// <summary>
        /// Max distance of ray.
        /// </summary>
        float MaxDistance { set; get; }

        /// <summary>
        /// Current context menu of trigger.
        /// </summary>
        IContextMenuUI CurrentMenu { get; }

        /// <summary>
        /// Camera to ray.
        /// </summary>
        Camera RayCamera { get; }
        #endregion

        #region Method
        /// <summary>
        /// Add menu UI to trigger.
        /// </summary>
        /// <param name="menuUI">Context menu ui to add.</param>
        void AddMenuUI(ContextMenuUI menuUI);

        /// <summary>
        /// Remove menu UI from trigger.
        /// </summary>
        /// <param name="menuUI">Context menu ui to remove.</param>
        void RemoveMenuUI(ContextMenuUI menuUI);

        /// <summary>
        /// Clear all menu UI of trigger.
        /// </summary>
        void ClearMenuUI();
        #endregion
    }
}