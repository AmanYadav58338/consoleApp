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
using Microsoft.Xrm.Sdk.Query;
using DamManagementConsole;


namespace DamManagementConsoleApp
{
    internal class DamManagement
    {
        public void CalculateTotalItemPrice(Entity itemEntity, Object Service, Context context)

        {
            IOrganizationService service = Service as IOrganizationService;
            Guid callingUserID = context.InitiatingUserId;

            /*try
            {
                EntityReference ProductRef = itemEntity.GetAttributeValue<EntityReference>(Item.product);
                Entity ProductRecord = service.Retrieve(Catalogue.cataloguetable, ProductRef.Id, new ColumnSet(Catalogue.perunitcost));
                decimal total = ((Money)ProductRecord.[Catalogue.perunitcost]).Value * Item.quantity;
                itemEntity [Item.totalcost] = new Money(total);
                service.Update(itemEntity);

            }*/
             try
            {
                EntityReference productRef = itemEntity.GetAttributeValue<EntityReference>(Item.product);
                Entity productRecord = service.Retrieve(Catalogue.cataloguetable, productRef.Id, new ColumnSet(Catalogue.perunitcost));
                Money perUnitCost = productRecord.GetAttributeValue<Money>(Catalogue.perunitcost);
                decimal quantity = itemEntity.GetAttributeValue<decimal>(Item.quantity);

                decimal total = perUnitCost.Value * quantity;

                itemEntity[Item.totalcost] = new Money(total);

                service.Update(itemEntity);
            }
            catch (Exception ex)
            {
                // tracingService.Trace($"Error: {ex.Message}");
             
                throw new InvalidPluginExecutionException($"Unexpected error: {ex.Message}"); ;
            }
        }

    }
}
