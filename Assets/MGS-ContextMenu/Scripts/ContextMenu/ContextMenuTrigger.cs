/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTrigger.cs
 *  Description  :  Trigger of context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Trigger of context menu.
    /// </summary>
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuTrigger")]
    [RequireComponent(typeof(Camera))]
    public class ContextMenuTrigger : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Layer of ray.
        /// </summary>
        public LayerMask layerMask = 1;

        /// <summary>
        /// Max distance of ray.
        /// </summary>
        public float maxDistance = 100;

        /// <summary>
        /// List of context menu.
        /// </summary>
        public List<ContextMenuUI> menuList = new List<ContextMenuUI>();

        /// <summary>
        /// Current context menu of trigger.
        /// </summary>
        protected IContextMenuUI currentMenu;

        /// <summary>
        /// Camera to ray.
        /// </summary>
        protected Camera rayCamera;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            rayCamera = GetComponent<Camera>();
        }

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                CloseCurrentMenu();
            else if (Input.GetMouseButtonDown(1))
            {
                CloseCurrentMenu();

                var ray = rayCamera.ScreenPointToRay(Input.mousePosition);
                var hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
                {
                    var menuAgent = hitInfo.transform.GetComponent<IContextMenuAgent>();
                    if (menuAgent != null)
                    {
                        currentMenu = FindContextMenu(menuAgent.MenuName);
                        if (currentMenu != null)
                            currentMenu.Show(menuAgent, Input.mousePosition);
                    }
                }
            }
        }

        /// <summary>
        /// Close current context menu.
        /// </summary>
        protected void CloseCurrentMenu()
        {
            if (currentMenu != null)
            {
                currentMenu.Close();
                currentMenu = null;
            }
        }

        /// <summary>
        /// Find context menu from menuList by menu type.
        /// </summary>
        /// <param name="menuName">Name of target context menu.</param>
        /// <returns>Context menu found.</returns>
        protected IContextMenuUI FindContextMenu(string menuName)
        {
            foreach (var menu in menuList)
            {
                if (menu.MenuName == menuName)
                    return menu;
            }

            Debug.LogWarningFormat("Find context menu UI is failed : The context menu that name is {0} does not exist.", menuName);
            return null;
        }
        #endregion
    }
}