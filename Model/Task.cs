//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Equipment_Accounting.Resource.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.TaskEquipment = new HashSet<TaskEquipment>();
            this.TaskTMC = new HashSet<TaskTMC>();
        }
        public string getID()
        {
            if (TypeID == 2) return $"ТТ-{IDofType}";
            else if (TypeID == 3) return $"ЗМС-{IDofType}";
            else return $"А-{IDofType}";
        }
        public string FullID => getID();
        public int DaysEnd => (int)((TimeSpan)(DateStart - DateEnt)).TotalDays;

        public int ID { get; set; }
        public int IDofType { get; set; }
        public string Contract { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnt { get; set; }
        public string Creator { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> MasterID { get; set; }
        public Nullable<int> StatusTaskID { get; set; }
        public string Addres { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> PortID { get; set; }
        public string Note { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Logins Logins { get; set; }
        public virtual StatusTask StatusTask { get; set; }
        public virtual TypeTask TypeTask { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskEquipment> TaskEquipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskTMC> TaskTMC { get; set; }
    }
}
