using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Models
{
    public class PassRecordItemModel
    {
        public DelegateCommand RecordItemCommand { get; set; } = new DelegateCommand(() =>
        {

        });
        public DelegateCommand MenuItemCommand { get; set; }
        public string PassDate { get; set; }
        public string Passageway { get; set; }
        public string TollCollector { get; set; }
        public string LiftingState { get; set; }
        public double DisCount { get; set; }
        public string State { get; set; }
    }
}
