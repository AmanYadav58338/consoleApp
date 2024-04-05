using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.PluginTelemetry;
using Microsoft.Xrm;
using Newtonsoft.Json.Linq;
using DamApplicationConsoleApp;
using Microsoft.Xrm.Tooling.Connector;
using DamManagementConsoleApp;

namespace DamManagementConsole
{
    public class PROGRAM
    {

        public static string dynamicUrl = "https://orge7433814.api.crm8.dynamics.com/api/data/v9.2/";
        public static string clientId = "ec77d0e2-8bfd-4cad-b1c4-dcfea7198e91";
        public static string clientSecretId = "yUg8Q~AnwL5w2fvMiV~bV8Dne6rkPJKkPlMg8bq4";

        public static void Main(string[] args)
        {
            DamManagement Damplugin = new DamManagement();

            IOrganizationService serviceClient = GetOrganizationServiceClient(clientId, clientSecretId, dynamicUrl);

            Context obj = new Context();
            obj.MessageName = "Update";
            obj.InitiatingUserId = new Guid("d1727398-9de8-ee11-a203-6045bdac2c24");
            Entity Item = GetItemRecordFromDynamics();
            Damplugin.CalculateTotalItemPrice(Item,serviceClient, obj);


        }
        public static IOrganizationService GetOrganizationServiceClient(string clientID, string clientSecretID, string dynamicapiURL)
        {
            try
            {
                var connection = new CrmServiceClient($@"AuthType=ClientSecret;url={dynamicapiURL};ClientId={clientID};ClientSecret={clientSecretID}");
                return connection.OrganizationWebProxyClient != null ? connection.OrganizationWebProxyClient : (IOrganizationService)connection.OrganizationServiceProxy;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while connecting to CRM " + ex.Message);
                Console.ReadKey();
                return null;
            }
        }

        public static Entity GetItemRecordFromDynamics()
        {
            Entity ItemRecord = new Entity();
            ItemRecord.LogicalName = Item.itemtable;
            Guid guid = Guid.Parse("abbd4e19-7ef1-ee11-a1fd-7c1e52061e92");
            ItemRecord.Id = guid;

            // ItemRecord.Attributes[Item.itemtable] = "wms_item";
           // decimal Quan = 2000;
            ItemRecord.Attributes[Item.quantity] = Item.quantity;
            //   ItemRecord.Attributes[Item.totalcost] = "wms_totalcost";
            EntityReference agreementRef = new EntityReference("wms_agreement", new Guid("44a54dbf-9ff1-ee11-a1fd-7c1e52061e92"));
            ItemRecord.Attributes[Item.agreement] = agreementRef;
            EntityReference productRef = new EntityReference("wms_damproducts", new Guid("b9a788dd-22ec-ee11-a203-7c1e5205b943"));
            ItemRecord.Attributes[Item.product] = productRef;

            return ItemRecord;
        }


        /*public static Entity GetCatalogueFromDynamic()
        {
            Entity CatalogueRecord = new Entity();
            CatalogueRecord.LogicalName = Catalogue.cataloguetable;
            Guid guid = Guid.Parse("5f22c8b8-0f79-4456-916b-105e40a52c28");
            CatalogueRecord.Id = guid;

            CatalogueRecord.Attributes[Catalogue.cataloguetable] = "wms_cateloge";
            CatalogueRecord.Attributes[Catalogue.servicename] = "wms_name";
            CatalogueRecord.Attributes[Catalogue.measuringunit] = "wms_measuringunit";
            CatalogueRecord.Attributes[Catalogue.perunitcost] = "wms_perunitcost";
            return CatalogueRecord;
        }*/

        /*public static Entity GetFrieghtRateFromDynamic()
        {
            Entity FrieghtRateRecord = new Entity();
            FrieghtRateRecord.LogicalName = FrieghtRate.frieghtraterecord;
            Guid guid = Guid.Parse("5f22c8b8-0f79-4456-916b-105e40a52c28");
            FrieghtRateRecord.Id = guid;

            FrieghtRateRecord.Attributes[FrieghtRate.frieghtraterecord] = "wms_freightrate";
            FrieghtRateRecord.Attributes[FrieghtRate.mediumoftransport] = "wms_name";
            FrieghtRateRecord.Attributes[FrieghtRate.fixedpricelength] = "wms_ffxedpricelength";
            FrieghtRateRecord.Attributes[FrieghtRate.fixedpricerate] = "wms_fixedprice";
            FrieghtRateRecord.Attributes[FrieghtRate.addoncost] = "wms_addoncost";
            return FrieghtRateRecord;
        }*/


        /*public static Entity GetTaxRecordFromDynamics()
        {
            Entity taxRecord = new Entity();
            taxRecord.LogicalName = Tax.taxtable;
            Guid guid = Guid.Parse("5f22c8b8-0f79-4456-916b-105e40a52c28");
            taxRecord.Id = guid;

            taxRecord.Attributes[Tax.taxtable] = "cra3f_tax";
            taxRecord.Attributes[Tax.name] = "wms_name";
            taxRecord.Attributes[Tax.cgst] = "wms_cgst";
            taxRecord.Attributes[Tax.sgst] = "wms_sgst";
            taxRecord.Attributes[Tax.igst] = "wms_igst";
            return taxRecord;
        }*/

        
    }
    public class Context
    {
        public string MessageName { get; set; }

        public Guid InitiatingUserId { get; set; }
    }

}