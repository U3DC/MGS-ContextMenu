/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuButton.cs
 *  Description  :  Define button item of context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/17/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Button item of context menu.
    /// </summary>
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuButton")]
    [RequireComponent(typeof(Button))]
    public class ContextMenuButton : ContextMenuItem
    {
        #region Field and Property
        /// <summary>
        /// Button of menu item.
        /// </summary>
        [SerializeField]
        protected Button button;

        /// <summary>
        /// Interactable of menu item.
        /// </summary>
        public override bool Interactable
        {
            set { button.interactable = value; }
            get { return button.interactable; }
        }
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            button = GetComponent<Button>();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add listener to menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        public override void AddListener(UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }

        /// <summary>
        /// Remove listener from menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        public override void RemoveListener(UnityAction callback)
        {
            button.onClick.RemoveListener(callback);
        }
        #endregion
    }
}