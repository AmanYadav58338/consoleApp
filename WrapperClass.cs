using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamApplicationConsoleApp
{
    internal class Item
    {
        public static string itemtable = "wms_item";
        public static string quantity = "wms_quantity";
        public static string totalcost = "wms_totalcost";
        public static string order = "wms_order";
        public static string agreement = "wms_agreementitem";
        public static string product = "wms_itemname";
        public static string supplayNumberOfWeek = "wms_supplydeliverycycleweeks";
        public static string supplaychoice= "wms_supplydeliverycycle";
    }
    internal class Catalogue
    {
        public static string cataloguetable = "wms_cateloge";
        public static string servicename = "wms_name";
        public static string measuringunit = "wms_measuringunit";
        public static string perunitcost = "wms_perunitcost";
    }
    internal class FrieghtRate
    {
        public static string frieghtraterecord = "wms_freightrate";
        public static string mediumoftransport = "wms_name";
        public static string fixedpricelength = "wms_ffxedpricelength";
        public static string fixedpricerate = "wms_fixedprice";
        public static string addoncost = "wms_addoncost";
    }
    internal class Tax
    {
        public static string taxtable = "wms_tax";
        public static string name = "wms_name";
        public static string cgst = "wms_cgst";
        public static string sgst = "wms_sgst";
        public static string igst = "wms_igst";
    }
}
