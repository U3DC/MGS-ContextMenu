/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuUI.cs
 *  Description  :  Control context menu UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/14/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.ContextMenu
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("Developer/ContextMenu/ContextMenuUI")]
    public class ContextMenuUI : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Type of ContextMenu UI.
        /// </summary>
        public ContextMenuType menuType = ContextMenuType.Untyped;

        /// <summary>
        /// Agent of ContextMenu UI.
        /// </summary>
        public ContextMenuAgent menuAgent { set; get; }

        /// <summary>
        /// Root RectTransform of ContextMenu UI.
        /// </summary>
        protected RectTransform rootRect;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rootRect = GetComponent<RectTransform>();
        }

        /// <summary>
        /// Get screen position of Menu UI base on pointer position.
        /// </summary>
        /// <param name="pointerPos">Mouse pointer screen position.</param>
        /// <returns>Screen position of Menu UI.</returns>
        protected virtual Vector2 GetMenuUIPosition(Vector2 pointerPos)
        {
            //Calculate position of ContextMenu UI.
            var halfWidth = rootRect.rect.width * 0.5f;
            var halfHeight = rootRect.rect.height * 0.5f;
            var newX = pointerPos.x < Screen.width - rootRect.rect.width ? pointerPos.x + halfWidth : Screen.width - halfWidth;
            var newY = pointerPos.y < rootRect.rect.height ? pointerPos.y + halfHeight : pointerPos.y - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Show ContextMenu UI.
        /// </summary>
        /// <param name="pointerPos">Mouse pointer screen position.</param>
        public virtual void Show(Vector2 pointerPos)
        {
            //Axtive ContextMenu UI.
            gameObject.SetActive(true);

            //Update Menu UI position.
            transform.position = GetMenuUIPosition(pointerPos);
        }

        /// <summary>
        /// Close ContextMenu UI.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Menu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public virtual void MenuItemClick(int itemIndex)
        {
            menuAgent.OnMenuItemClick(itemIndex);
            Close();
        }
        #endregion
    }
}