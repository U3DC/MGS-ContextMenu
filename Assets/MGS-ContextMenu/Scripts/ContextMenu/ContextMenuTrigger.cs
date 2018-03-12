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

namespace Developer.ContextMenu
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Developer/ContextMenu/ContextMenuTrigger")]
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
        protected ContextMenuUI currentMenu;

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

            if (Input.GetMouseButtonDown(1))
            {
                CloseCurrentMenu();

                var ray = rayCamera.ScreenPointToRay(Input.mousePosition);
                var hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
                {
                    var menuAgent = hitInfo.transform.GetComponent<ContextMenuAgent>();
                    if (menuAgent)
                    {
                        currentMenu = FindContextMenu(menuAgent.menuType);
                        if (currentMenu)
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
            if (currentMenu)
            {
                currentMenu.Close();
                currentMenu = null;
            }
        }

        /// <summary>
        /// Find context menu from menuList by menu type.
        /// </summary>
        /// <param name="menuType">Type of target context menu.</param>
        /// <returns>Context menu found.</returns>
        protected ContextMenuUI FindContextMenu(ContextMenuType menuType)
        {
            foreach (var menu in menuList)
            {
                if (menu.type == menuType)
                    return menu;
            }

            Debug.LogWarningFormat("Find context menu UI is failed : The context menu that type is {0} does not exist.", menuType);
            return null;
        }
        #endregion
    }
}