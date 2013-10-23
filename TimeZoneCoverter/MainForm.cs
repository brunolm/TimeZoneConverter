using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace TimeZoneCoverter
{
    public partial class MainForm : Form
    {
        private readonly ReadOnlyCollection<TimeZoneInfo> timezones = TimeZoneInfo.GetSystemTimeZones();
        private List<TimeZoneView> timezoneViews;

        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadTimeZones()
        {
            timezoneViews = new List<TimeZoneView>();

            foreach (var item in timezones)
            {
                var tzv = new TimeZoneView(item, dtpTime.Value);

                if (String.IsNullOrWhiteSpace(txtSearch.Text)
                    || tzv.ID.IndexOf(txtSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    timezoneViews.Add(tzv);
                }
            }

            dgvTimes.DataSource = timezoneViews;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTimeZones();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            LoadTimeZones();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTimeZones();
        }


    }
}
