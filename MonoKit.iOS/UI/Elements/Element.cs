namespace MonoKit.UI.Elements
{
    using System;
    using MonoTouch.UIKit;
    using MonoTouch.Foundation;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using MonoKit.DataBinding;
    
    
    // todo: we need an editor for date's now, 
    // 
    
    public class Element : IElement, INotifyPropertyChanged, ICommand, IEdit
    {
        private string text;
        
        public Element(string text)
        {
            this.text = text;
        }
        
        public Element(object data, Binding binding)
        {    
            this.Data = data;
            
            if (binding != null)
            {
                this.SetBinding("Text", data, binding);
            }
        }
        
        ~Element()
        {
        }
        
        public object Data
        {
            get;
            private set;
        }
        
        public Action<Element> Command
        {
            get;
            set;
        }
        
        public Func<Element, bool> CanExecute
        {
            get;
            set;
        }
        
        public Action<Element> Edit
        {
            get;
            set;
        }
        
        public Func<Element, bool> CanEdit
        {
            get;
            set;
        }
        
        public string Text
        {
            get
            {
                return this.text;
            }
            
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Execute()
        {
            if (this.Command != null)
            {
                this.Command(this);
            }
        }
        
        public virtual bool GetCanExecute()
        {
            if (this.CanExecute != null)
            {
                return this.CanExecute(this);
            }
            
            return true;
        }

        public virtual void ExecuteEdit()
        {
            if (this.Edit != null)
            {
                this.Edit(this);
            }
        }
        
        public virtual bool GetCanEdit()
        {
            if (this.CanEdit != null)
            {
                return this.CanEdit(this);
            }
            
            return true;
        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            var changed = this.PropertyChanged;
            if (changed != null)
            {
                changed(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    public class Element<T> : Element, IElement<T>
    {
        private T value;

        public Element(string caption) : base(caption)
        {
        }

        public Element(string caption, T value) : base(caption)
        {
            this.value = value;
        }
        
        public Element(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public Element(object data, Binding binding, Binding valueBinding) : base(data, binding)
        {    
            if (valueBinding != null)
            {
                this.SetBinding("Value", data, valueBinding);
            }
        }
        
        public T Value
        {
            get
            {
                return this.value;
            }
            
            set
            {
                if (!object.Equals(this.value, value))
                {
                    this.value = value;
                    this.OnPropertyChanged("Value");
                }   
            }
        }
    }
    
    public class StringElement : Element<string>
    {
        public StringElement(string caption) : base(caption)
        {           
        }
        
        public StringElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public StringElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
    
    public class SubtitleStringElement : Element<string>
    {
        public SubtitleStringElement(string caption) : base(caption)
        {
        }
        
        public SubtitleStringElement(string caption, string subtitle) : base(caption, subtitle)
        {
        }
        
        public SubtitleStringElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public SubtitleStringElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
    
    public class Value1StringElement : Element<string>
    {
        public Value1StringElement(string caption) : base(caption)
        {
        }
        
        public Value1StringElement(string caption, string detail) : base(caption, detail)
        {
        }
        
        public Value1StringElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public Value1StringElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
    
    public class Value2StringElement : Element<string>
    {
        public Value2StringElement(string caption) : base(caption)
        {
        }
        
        public Value2StringElement(string caption, string detail) : base(caption, detail)
        {
        }
        
        public Value2StringElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public Value2StringElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
        
    public class DisclosureElement : Element<string>
    {
        public DisclosureElement(string caption) : base(caption)
        {
        }
        
        public DisclosureElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public DisclosureElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }

    public class BooleanElement : Element<bool>
    {
        public BooleanElement(string caption) : base(caption)
        {
        }
        
        public BooleanElement(string caption, bool value) : base(caption, value)
        {           
        }
        
        public BooleanElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public BooleanElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }

        public override void Execute()
        {
            this.Value = !this.Value;
        }
    }
    
    public class CheckboxElement : Element<bool>
    {
        public CheckboxElement(string caption) : base(caption)
        {
        }
        
        public CheckboxElement(string caption, bool value) : base(caption, value)
        {           
        }
        
        public CheckboxElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public CheckboxElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }

        public override void Execute()
        {
            this.Value = !this.Value;
        }
    }
      
    public interface IInputElement
    {
    }
      
    public class TextInputElement : Element<string>, IInputElement
    {
        private string placeholder;
        private UIKeyboardType keyboardType;
        
        public TextInputElement(string caption) : base(caption)
        {
            this.placeholder = string.Empty;
        }
        
        public TextInputElement(string caption, string value) : base(caption, value)
        {
            this.placeholder = string.Empty;
        }
        
        public TextInputElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public TextInputElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
        
        public string Placeholder
        {
            get
            {
                return this.placeholder;
            }
            
            set
            {
                if (!string.Equals(this.placeholder, value, StringComparison.CurrentCulture))
                {
                    this.placeholder = value;
                    this.OnPropertyChanged("Placeholder");
                }   
            }
        }
        
        public UIKeyboardType KeyboardType
        {
            get
            {
                return this.keyboardType;
            }
            
            set
            {
                if (value != this.keyboardType)
                {
                    this.keyboardType = value;
                    this.OnPropertyChanged("KeyboardType");
                }
            }
        }
    }
        
    public class PasswordInputElement : Element<string>, IInputElement
    {
        public PasswordInputElement(string caption) : base(caption)
        {    
        }
        
        public PasswordInputElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public PasswordInputElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
      
    public class DateInputElement : Element<DateTime>, IInputElement
    {
        public DateInputElement(string caption) : base(caption)
        {
        }
        
        public DateInputElement(string caption, DateTime value) : base(caption, value)
        {
        }
        
        public DateInputElement(object data, Binding binding) : base(data, binding)
        {           
        }
        
        public DateInputElement(object data, Binding binding, Binding valueBinding) : base(data, binding, valueBinding)
        {           
        }
    }
}
