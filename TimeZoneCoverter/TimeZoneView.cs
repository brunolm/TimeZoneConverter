using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneCoverter
{
    public class TimeZoneView
    {
        private string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = String.Join("", value.Where(c => char.IsUpper(c)));
            }
        }
        public string DisplayName { get; set; }
        public DateTime Time { get; set; }

        public TimeZoneView(TimeZoneInfo info, DateTime local)
        {
            ID = info.Id;
            DisplayName = info.DisplayName;
            Time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(local, info.Id);
        }
    }
}
