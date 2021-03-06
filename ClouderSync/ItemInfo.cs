﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClouderSync
{
    public class ItemInfo 
    {
        protected string m_FilePath = string.Empty;
        protected string m_Name = string.Empty;
        protected bool m_IsSelected = false;
        protected object m_Object;
        protected bool m_HasPath = false;
        protected Guid m_Kind = Guid.Empty;
        protected bool m_bIncludedInProject = true;
        protected bool m_bHidden = false;

        public ItemInfo(string Name, string filePath, Guid itemType)
        {
            m_Object = null;
            m_FilePath = filePath;
            m_Name = Name;
            m_IsSelected = true;
            m_HasPath = true;
            m_Kind = itemType;
            m_Object = null;
            m_bIncludedInProject = true;
        }
#if false
        public ItemInfo(EnvDTE.UIHierarchyItem selItem)
        {
            m_FilePath = string.Empty;
            m_HasPath = false;
            m_Name = selItem.Name;
            m_IsSelected = selItem.IsSelected;
            m_Object = selItem.Object;

        }
        public ItemInfo(EnvDTE.SelectedItem selItem)
        {
            m_FilePath = string.Empty;
            m_HasPath = false;
            m_Name = selItem.Name;
            m_IsSelected = true;
            if (selItem is EnvDTE.UIHierarchyItem)
            {
                m_Object = (selItem as EnvDTE.UIHierarchyItem).Object;
                
            }

        }
#endif
        public bool IsEqual(string _fullPath)
        {
            return string.Equals(m_FilePath, _fullPath, StringComparison.OrdinalIgnoreCase);
        }
        public static bool Exists(List<ItemInfo> arrInfo, string fullPath)
        {
            return arrInfo.Exists(cm => cm.IsEqual(fullPath));
        }
        virtual public object Object
        {
            get
            {
                return this.m_Object;
            }
            set
            {
                this.m_Object = value;
            }
        }

        virtual public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }
        virtual public string FilePath
        {
            get
            {
                return this.m_FilePath;
            }
            set
            {
                this.m_FilePath = value;
                this.m_HasPath = true;
            }
        }
        virtual public bool IsSelected
        {
            get
            {
                return this.m_IsSelected;
            }
            set
            {
                this.m_IsSelected = value;
            }
        }
        virtual public bool HasPath
        {
            get
            {
                return this.m_HasPath;
            }
        }
        virtual public bool IncludedInProject
        {
            get
            {
                return this.m_bIncludedInProject;
            }
            set
            {
                this.m_bIncludedInProject=value;
            }

        }
        virtual public bool IsHidden
        {
            get
            {
                return this.m_bHidden;
            }
            set
            {
                this.m_bHidden = value;
            }

        }

    }
}
