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
    
    public partial class EquipmentWarehouseMaster
    {
        public int ID { get; set; }
        public Nullable<int> EquipmentWarehouseID { get; set; }
        public Nullable<int> MasterID { get; set; }
    
        public virtual EquipmentWarehouse EquipmentWarehouse { get; set; }
        public virtual Logins Logins { get; set; }
    }
}
