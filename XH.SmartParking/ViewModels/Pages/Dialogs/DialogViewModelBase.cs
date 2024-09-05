using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.ViewModels.Pages.Dialogs
{
    public class DialogViewModelBase : BindableBase, IDialogAware
    {
        public string Title { get; set; }

        public virtual event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public virtual void OnDialogOpened(IDialogParameters parameters) { }
        public DelegateCommand SaveCommand { get; set; }
        public DialogViewModelBase()
        {
            SaveCommand = new DelegateCommand(DoSave);
        }
        public virtual void DoSave()
        {
            this.RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}
