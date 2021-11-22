using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace assets_management_system {
    public static class DeviceConst
    {
        public static string TABLE_NAME = "";
        public static string COLUMN_ID = "";
        public static string COLUMN_NAME = "";
        public static string COLUMN_CONTRACT = "";
        public static string COLUMN_DIVISION = "";

        public static string COLUMN_UNIT = "";
        public static string COLUMN_TYPE = "";
        public static string COLUMN_STATUS = "";
        public static string COLUMN_SPECS = "";
        public static string COLUMN_PRODUCTION_YEAR = "";
        public static string COLUMN_IMPLEMENT_YEAR = "";
        public static string COLUMN_ANUAL_VALUE_LOST = "";

    }
    class Device {
        int id;
        string Name;
        int Contract;
        int Division;

        int Unit;
        int Type;
        string Status;
        string Specification;
        
        int ProductionYear;

        int ImplementYear;

        float AnualValueLost;


        public Device(int id)
        {
            DataTable QueriedDataTable = ExecuteQuery.SqlDataTableFromQuery("SELECT * from "+ DeviceConst.TABLE_NAME + " WHERE " + DeviceConst.COLUMN_ID + " = " + id);
        }

    }


}