<Query Kind="Program">
  <Connection>
    <ID>a65a8412-9b66-4ee6-bd48-a56183c4f94c</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>.\SQLEXPRESS</Server>
    <Database>WestWind</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
// WEB APP
DateTime yearmontharg= DateTime.Parse("2018-01-01");
List<Shipments> info = Shipment_GetByYearMonth(yearmontharg);

//info.Dump();

List<Shippers> shipperinfo = Shippter_ShipperShipmentList();
shipperinfo.Dump();


	
}

// You can define other methods, fields, classes and namespaces here

// Application Library

//ShipmentServices
// PoC -methods of Service


public List<Shipments> Shipment_GetByYearMonth(DateTime yearmontharg)
{
	IEnumerable<Shipments> info = Shipments.Where(s=>s.ShippedDate.Year== yearmontharg.Year 
									&& s.ShippedDate.Month== yearmontharg.Month);
	
	return info.ToList();
}



public List<Shippers> Shippter_ShipperShipmentList()
{
	IEnumerable<Shippers> shipperinfo = Shippers.Where(x => x.ShipViaShipments.Any(y => x.ShipperID== y.ShipVia))
										.Distinct().OrderBy(x => x.CompanyName);
	return shipperinfo.ToList();
}