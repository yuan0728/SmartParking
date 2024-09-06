using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.IService;

namespace XH.SmartParking.Models
{
    public class UserModel : BindableBase, INotifyDataErrorInfo
    {
        public UserModel() { }

        IUserService _userService;
        public UserModel(IUserService userService)
        {
            _userService = userService;
        }

        public int Index { get; set; }

        public int UserId { get; set; }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;

                _errors.Remove("UserName");
                Task.Run(() =>
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        _errors.Add("UserName", new List<string> { "用户名不能为空" });
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("UserName"));
                    }
                    else if (_userService != null && _userService.CheckUserName(value))
                    {
                        _errors.Add("UserName", new List<string> { "用户名已被占用" });
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("UserName"));
                    }
                });
            }
        }

        public string RealName { get; set; }
        private string _userIcon;

        public string UserIcon
        {
            get { return _userIcon; }
            set { SetProperty<string>(ref _userIcon, value); }
        }

        private int? _age;

        public int? Age
        {
            get { return _age; }
            set
            {
                _age = value;
                _errors.Remove("Age");
                if (value > 200 || value < 0)
                {
                    _errors.Add("Age", new List<string> { "用户年龄必须在0-200之间" });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Age"));
                }
            }
        }

        private int? _gender;
        public int? Gender
        {
            get { return _gender; }
            set { SetProperty<int?>(ref _gender, value); }
        }

        public string Address { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private int? _status;

        public int? Status
        {
            get { return _status; }
            set { SetProperty<int?>(ref _status, value); }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty<bool>(ref _isSelected, value); }
        }


        public List<RoleModel> Roles { get; set; }


        Dictionary<string, IList<string>> _errors = new Dictionary<string, IList<string>>();
        //Dictionary<string, IList<string>> _errors = new Dictionary<string, IList<string>>();
        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return null;
        }
    }
}
