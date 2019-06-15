using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using RadioButtonTesting.Adapter;
using System.Collections.Generic;
using Android.Views;

namespace RadioButtonTesting
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ListView GetListView;
        public View PopUpView;
       public List<DepartmentDto> list = new List<DepartmentDto>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource


            PopUpView = this.LayoutInflater.Inflate(Resource.Layout.DepartmentPopUp, null);
            GetListView = PopUpView.FindViewById<ListView>(Resource.Id.Departmentlistview);
            
          
        SetContentView(Resource.Layout.activity_main);
         EditText Departmentpicker=   FindViewById<EditText>(Resource.Id.departmentPicker);
            Departmentpicker.Click += Departmentpicker_Click;
         //   ListView listView = FindViewById<ListView>(Resource.Id.Departmentlistview);

        
            for (int i = 0; i < 10; i++)
            {
                list.Add(new DepartmentDto { Checked = false, Afdeling_Txt = "item" + i });
            }

            DepartmentListAdapter arrayAdapter = new DepartmentListAdapter(this, list);
            GetListView.Adapter = arrayAdapter;
        }

        private void Departmentpicker_Click(object sender, System.EventArgs e)
        {
          
            GetListView.ChoiceMode = ListView.ChoiceModeSingle;
            GetListView.Adapter = new DepartmentListAdapter(this, list);

            bool focusable = true;
            int width = 350;//LinearLayout.LayoutParams.WrapContent;
            int height = 450;//LinearLayout.LayoutParams.WrapContent;
                             // listView = _PopUpView.FindViewById<ListView>(Resource.Id.Departmentlistview);
            PopupWindow popupWindow = new PopupWindow(PopUpView, width, height, focusable);
            popupWindow.ContentView = PopUpView;
            popupWindow.ShowAtLocation(PopUpView, GravityFlags.CenterVertical, 0, 0);
            popupWindow.Focusable = false;
            popupWindow.Touchable = true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}