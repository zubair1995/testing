using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Widget.CompoundButton;

namespace RadioButtonTesting.Adapter
{

    public class DepartmentDto
    {
        public string Afdeling_Txt { set; get; }

        public bool Checked { set; get; }
    }

    public class DepartmentListAdapter : BaseAdapter<DepartmentDto>, IOnCheckedChangeListener
    {
        private Activity activity;
        List<DepartmentDto> Departments;
        int selectedIndex = -1;

        public DepartmentListAdapter(Activity activity, List<DepartmentDto> Departments)
        {
            this.activity = activity;
            this.Departments = Departments;
        }

        public override DepartmentDto this[int position] => Departments[position];

        public override int Count => Departments.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DepartmentPopUpListViewRow, parent, false);
            // var DepartmentpopUp = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DepartmentPopUpListViewRow, parent, false);

            var btnRadio = view.FindViewById<RadioButton>(Resource.Id.SelectedDepartment);
            btnRadio.SetOnCheckedChangeListener(null);
            btnRadio.Tag = position;
            btnRadio.Checked = Departments[position].Checked;
            btnRadio.SetOnCheckedChangeListener(this);
            return view;
        }

        private void BtnRadio_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            int position = (int)buttonView.Tag;
            if (isChecked)
            {
                foreach (DepartmentDto model in Departments)
                {
                    if (model != Departments[position])
                    {
                        model.Checked = false;
                    }
                    else
                    {
                        model.Checked = true;
                    }
                }
                NotifyDataSetChanged();
            }
        }
    }
}
