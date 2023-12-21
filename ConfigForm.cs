using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSupport_v2
{
    public partial class ConfigForm : DevExpress.XtraEditors.XtraForm
    {
        private System.Configuration.Configuration _configFile;
        private System.ComponentModel.BindingList<HospitalSetting> _Hospitals = new System.ComponentModel.BindingList<HospitalSetting>();
        public IList<HospitalSetting> Hospitals => (IList<HospitalSetting>)this._Hospitals;
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this._configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (this._configFile.GetSection("HospitalSettings") is HospitalSettings section)
            {
                foreach (HospitalSetting hospital in (ConfigurationElementCollection)section.Hospitals)
                {
                    this._Hospitals.Add(hospital);
                }
            }
            this._Hospitals.AllowNew = true;
            this._Hospitals.AllowEdit = true;
            gridControl1.DataSource = _Hospitals;
            gridView1.Columns["GROUP"].Group(); 
            gridView1.Columns["BENHVIEN_ID"].Visible= false;
            gridView1.Columns["BENHVIEN_ID"].Group();
        }
        public void SaveConfig()
        {
            if (!(this._configFile.GetSection("HospitalSettings") is HospitalSettings section))
                return;
            section.Hospitals.Clear();
            foreach (HospitalSetting hospital in (IEnumerable<HospitalSetting>)this.Hospitals)
                section.Hospitals.Add(hospital);
            this._configFile.Save();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveConfig();
            //AlertInfo aInfo = new AlertInfo("Thông báo", "Lưu thành công");
            //alertControl2.FormLocation = AlertFormLocation.TopRight;
            //alertControl2.AutoFormDelay = 1000;
            //alertControl2.Show(this, aInfo);
        }
    }
    public class HospitalSetting : ConfigurationElement
    {
        [ConfigurationProperty("KEY", IsRequired = true)]
        public string KEY
        {
            get => (string)this[nameof(KEY)];
            set => this[nameof(KEY)] = (object)value;
        }
        [ConfigurationProperty("VALUE", IsRequired = true)]
        public string VALUE
        {
            get => (string)this[nameof(VALUE)];
            set => this[nameof(VALUE)] = (object)value;
        }
        [ConfigurationProperty("BENHVIEN_ID", IsRequired = true)]
        public string BENHVIEN_ID
        {
            get => (string)this[nameof(BENHVIEN_ID)];
            set => this[nameof(BENHVIEN_ID)] = (object)value;
        }

        [ConfigurationProperty("GROUP", IsRequired = true)]
        public string GROUP
        {
            get => (string)this[nameof(GROUP)];
            set => this[nameof(GROUP)] = (object)value;
        }
        [ConfigurationProperty("TEXT", IsRequired = true)]
        public string TEXT
        {
            get => (string)this[nameof(TEXT)];
            set => this[nameof(TEXT)] = (object)value;
        }
    }
    public class HospitalSettings : ConfigurationSection
    {
        [ConfigurationProperty("Hospitals", IsDefaultCollection = false)]
        public HospitalsCollection Hospitals => (HospitalsCollection)this[nameof(Hospitals)];
    }
    public class HospitalsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement() => (ConfigurationElement)new HospitalSetting();

        protected override object GetElementKey(ConfigurationElement element) => (object)((HospitalSetting)element).KEY;

        public override bool IsReadOnly() => false;

        public void Add(HospitalSetting element) => this.BaseAdd((ConfigurationElement)element);

        public void Clear() => this.BaseClear();

        public int IndexOf(HospitalSetting element) => this.BaseIndexOf((ConfigurationElement)element);

        public void Remove(HospitalSetting element)
        {
            if (this.BaseIndexOf((ConfigurationElement)element) < 0)
                return;
            this.BaseRemove((object)element.BENHVIEN_ID);
        }

        public void RemoveAt(int index) => this.BaseRemoveAt(index);



        public HospitalSetting Getvalue(object key) => (HospitalSetting)BaseGet(key);

        public HospitalSetting this[int index]
        {
            get => (HospitalSetting)this.BaseGet(index);
            set
            {
                if (this.BaseGet(index) != null)
                    this.BaseRemoveAt(index);
                this.BaseAdd(index, (ConfigurationElement)value);
            }
        }
    } 
}