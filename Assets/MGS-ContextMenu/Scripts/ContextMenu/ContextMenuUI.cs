/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuUI.cs
 *  Description  :  Control context menu UI(UGUI).
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/14/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/12/2018
 *  Description  :  Protected agent.
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
        /// Type of context menu.
        /// </summary>
        public ContextMenuType type = ContextMenuType.Undefined;

        /// <summary>
        /// Agent of context menu.
        /// </summary>
        protected ContextMenuAgent agent;

        /// <summary>
        /// Root RectTransform of context menu.
        /// </summary>
        protected RectTransform rootRect;
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rootRect = GetComponent<RectTransform>();
        }

        /// <summary>
        /// Get screen position of menu UI base on mouse pointer position.
        /// </summary>
        /// <param name="mousePosition">Screen position of mouse pointer.</param>
        /// <returns>Screen position of menu UI.</returns>
        protected virtual Vector2 GetMenuUIPosition(Vector2 mousePosition)
        {
            var halfWidth = rootRect.rect.width * 0.5f;
            var halfHeight = rootRect.rect.height * 0.5f;
            var newX = mousePosition.x < Screen.width - rootRect.rect.width ? mousePosition.x + halfWidth : Screen.width - halfWidth;
            var newY = mousePosition.y < rootRect.rect.height ? mousePosition.y + halfHeight : mousePosition.y - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Show context menu.
        /// </summary>
        /// <param name="agent">Agent of menu.</param>
        /// <param name="mousePosition">Screen position of mouse pointer.</param>
        public virtual void Show(ContextMenuAgent agent, Vector2 mousePosition)
        {
            this.agent = agent;
            gameObject.SetActive(true);
            transform.position = GetMenuUIPosition(mousePosition);
        }

        /// <summary>
        /// Menu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public virtual void MenuItemClick(int itemIndex)
        {
            agent.OnMenuItemClick(itemIndex);
            Close();
        }

        /// <summary>
        /// Close context menu.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}