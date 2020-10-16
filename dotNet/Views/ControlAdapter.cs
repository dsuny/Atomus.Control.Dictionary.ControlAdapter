using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atomus.Service;
using Atomus.Diagnostics;

namespace Atomus.Control.Dictionary
{
    public class ControlAdapter : IDictionary, IAction
    {
        IDictionary dictionary;
        bool autoComplete;
        bool waterMark;
        bool searchAll;
        bool startsWith;

        string IDictionary.Code {
            get
            {
                return this.dictionary.Code;
                }
            set
            {
                this.dictionary.Code = value;
            }
        }
        System.Windows.Forms.Control[] IDictionary.Controls
        {
            get
            {
                return this.dictionary.Controls;
            }
            set
            {
                this.dictionary.Controls = value;
            }
        }
        System.Windows.Forms.Control IDictionary.CurrentControl
        {
            get
            {
                return this.dictionary.CurrentControl;
            }
            set
            {
                this.dictionary.CurrentControl = value;
            }
        }

        bool IDictionary.AutoComplete
        {
            get
            {
                if (this.dictionary == null)
                    return this.autoComplete;
                else
                    return this.dictionary.AutoComplete;
            }
            set
            {
                if (this.dictionary == null)
                    this.autoComplete = value;
                else
                    this.dictionary.AutoComplete = value;
            }
        }
        BeforeAction IDictionary.BeforeAction
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.BeforeAction;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.BeforeAction = value;
            }
        }
        AfterAction IDictionary.AfterAction
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.AfterAction;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.AfterAction = value;
            }
        }
        bool IDictionary.WaterMark
        {
            get
            {
                if (this.dictionary == null)
                    return this.waterMark;
                else
                    return this.dictionary.WaterMark;
            }
            set
            {
                if (this.dictionary == null)
                    this.waterMark = value;
                else
                    this.dictionary.WaterMark = value;
            }
        }
        IDictionaryForm IDictionary.DictionaryForm
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.DictionaryForm;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.DictionaryForm = value;
            }
        }

        Size IDictionary.DictionaryFormSize
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.DictionaryFormSize;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.DictionaryFormSize = value;
            }
        }

        string IBeforeEventArgs.Where
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.Where;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.Where = value;
            }
        }
        bool IBeforeEventArgs.SearchAll
        {
            get
            {
                if (this.dictionary == null)
                    return this.searchAll;
                else
                    return this.dictionary.SearchAll;
            }
            set
            {
                if (this.dictionary == null)
                    this.searchAll = value;
                else
                    this.dictionary.SearchAll = value;
            }
        }
        bool IBeforeEventArgs.StartsWith
        {
            get
            {
                if (this.dictionary == null)
                    return this.startsWith;
                else
                    return this.dictionary.StartsWith;
            }
            set
            {
                if (this.dictionary == null)
                    this.startsWith = value;
                else
                    this.dictionary.StartsWith = value;
            }
        }

        DataRow IAfterEventArgs.DataRow
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.DataRow;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.DataRow = value;
            }
        }
        DataTable IAfterEventArgs.DataTable
        {
            get
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    return this.dictionary.DataTable;
            }
            set
            {
                if (this.dictionary == null)
                    throw new AtomusException("Not Support.");
                else
                    this.dictionary.DataTable = value;
            }
        }

        private AtomusControlEventHandler beforeActionEventHandler;
        private AtomusControlEventHandler afterActionEventHandler;

        private ICore ParentCore { get; set; }

        #region Init
        public ControlAdapter() { }
        public ControlAdapter(object Object) : this()
        {
            if (Object != null && Object is ICore)
                this.ParentCore = (ICore)Object;
        }
        #endregion

        #region Dictionary
        #endregion

        #region Spread
        #endregion

        #region IO
        object IAction.ControlAction(ICore sender, AtomusControlArgs e)
        {
            try
            {
                //this.MessageBoxShow("1");

                if (this.dictionary != null)
                    return ((IAction)this.dictionary).ControlAction(sender, e);
                else
                    return false;
            }
            catch (Exception ex)
            {

                this.MessageBoxShow(ex);
                return false;
            }
        }
        #endregion

        #region Event
        event AtomusControlEventHandler IAction.BeforeActionEventHandler
        {
            add
            {
                if (this.dictionary == null)
                    this.beforeActionEventHandler += value;
                else
                    ((IAction)this.dictionary).BeforeActionEventHandler += value;
            }
            remove
            {
                if (this.dictionary == null)
                    this.beforeActionEventHandler -= value;
                else
                    ((IAction)this.dictionary).BeforeActionEventHandler -= value;
            }
        }
        event AtomusControlEventHandler IAction.AfterActionEventHandler
        {
            add
            {
                if (this.dictionary == null)
                    this.afterActionEventHandler += value;
                else
                    ((IAction)this.dictionary).AfterActionEventHandler += value;
            }
            remove
            {
                if (this.dictionary == null)
                    this.afterActionEventHandler -= value;
                else
                    ((IAction)this.dictionary).AfterActionEventHandler -= value;
            }
        }
        #endregion

        #region "ETC"
        void IDictionary.Add(string code, BeforeAction beforeAction, AfterAction afterAction, params System.Windows.Forms.Control[] controls)
        {
            foreach (System.Windows.Forms.Control _TmpControl in controls)
            {
                if (_TmpControl != null)
                {
                    try
                    {
                        this.dictionary = (IDictionary)Factory.CreateInstance(this.GetAttribute(_TmpControl.GetType().FullName), false, true, this.ParentCore);

                        this.dictionary.AutoComplete = this.autoComplete;
                        this.dictionary.WaterMark = this.waterMark;
                        this.dictionary.SearchAll = this.searchAll;
                        this.dictionary.StartsWith = this.startsWith;

                        this.dictionary.Add(code, beforeAction, afterAction, controls);

                        break;
                    }
                    catch (Exception ex)
                    {
                        DiagnosticsTool.MyTrace(ex);
                    }
                }
            }
        }

        void IDictionary.Remove(params System.Windows.Forms.Control[] controls)
        {
            foreach (System.Windows.Forms.Control _TmpControl in controls)
            {
                if (_TmpControl != null)
                {
                    try
                    {
                        this.dictionary = (IDictionary)Factory.CreateInstance(this.GetAttribute(_TmpControl.GetType().FullName), false, true);
                        this.dictionary.Remove(controls);

                        break;
                    }
                    catch (Exception ex)
                    {
                        DiagnosticsTool.MyTrace(ex);
                    }
                }
            }
        }
        #endregion
    }
}
