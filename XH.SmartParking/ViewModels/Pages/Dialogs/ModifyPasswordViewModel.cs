using Prism.Services.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XH.SmartParking.Entities;
using XH.SmartParking.IService;
using XH.SmartParking.Models;

namespace XH.SmartParking.ViewModels.Pages.Dialogs
{
    public class ModifyPasswordViewModel : DialogViewModelBase, INotifyDataErrorInfo
    {
        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.Title = "修改密码";
            User = parameters.GetValue<UserModel>("user");
            //OldPassword = User.Password;
            OldPassword = "";
            NewPassword = "";
            ConfirmPassword = "";
            base.OnDialogOpened(parameters);
        }

        private string _oldPassword;

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _errors.Remove("OldPassword");
                _errors.Remove("NewPassword");
                if (string.IsNullOrEmpty(value))
                {
                    _errors.Add("OldPassword", new List<string> { "旧密码不能为空" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("OldPassword"));
                }
                else if (User.Password != value)
                {
                    _errors.Add("OldPassword", new List<string> { "旧密码不正确" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("OldPassword"));
                }
                if (NewPassword == value)
                {
                    _errors.Add("NewPassword", new List<string> { "不能和旧密码相同" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("NewPassword"));
                }

                SetProperty<string>(ref _oldPassword, value);
            }
        }

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _errors.Remove("NewPassword");
                _errors.Remove("ConfirmPassword");
                if (OldPassword == value)
                {
                    _errors.Add("NewPassword", new List<string> { "不能和旧密码相同" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("NewPassword"));
                }
                else if (string.IsNullOrEmpty(value))
                {
                    _errors.Add("NewPassword", new List<string> { "新密码不能为空" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("NewPassword"));
                }
                else if (value != ConfirmPassword)
                {
                    _errors.Add("ConfirmPassword", new List<string> { "两次密码不相同" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("ConfirmPassword"));
                }
                SetProperty<string>(ref _newPassword, value);
            }
        }

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _errors.Remove("ConfirmPassword");
                if (value != NewPassword)
                {
                    _errors.Add("ConfirmPassword", new List<string> { "两次密码不相同" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("ConfirmPassword"));
                }
                SetProperty<string>(ref _confirmPassword, value);
            }
        }


        public UserModel User { get; set; }
        Dictionary<string, IList<string>> _errors = new Dictionary<string, IList<string>>();

        public bool HasErrors => _errors.Count > 0;

        private readonly IUserService _userService;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public ModifyPasswordViewModel(IUserService userService)
        {
            _userService = userService;
        }

        public override void DoSave()
        {
            try
            {
                if (HasErrors) return;

                var user = _userService.Find<SysUser>(User.UserId);
                if (user == null || user.Password != OldPassword) return;

                user.Password = NewPassword;
                _userService.Update(user);

                base.DoSave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return null;
        }
    }
}
