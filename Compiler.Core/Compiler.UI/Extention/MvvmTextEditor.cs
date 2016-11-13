using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ICSharpCode.AvalonEdit;

namespace Compiler.UI.Extention {
    public class MvvmTextEditor : TextEditor, INotifyPropertyChanged {
        public static DependencyProperty DocumentTextProperty =
            DependencyProperty.Register("DocumentText",
                                        typeof(string), typeof(MvvmTextEditor),
            new PropertyMetadata((obj, args) => {
                MvvmTextEditor target = (MvvmTextEditor)obj;
                target.DocumentText = (string)args.NewValue;
            })
        );

        public string DocumentText {
            get { return base.Text; }
            set { base.Text = value; }
        }

        protected override void OnTextChanged(EventArgs e) {
            SetCurrentValue(DocumentTextProperty, base.Text);
            base.OnTextChanged(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
