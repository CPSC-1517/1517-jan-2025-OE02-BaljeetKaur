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
//pretend main as my WebApp 
// pretend that you want to consume this service

List<Regions> regionData = Region_GetList();

// Linqpad has a method to display collections: Dump()

regionData.Dump();

// pretend there are some controls on your webApp
// one field on the WebApp is passing input as regionID

int regionarg = 11;
 Regions results= Region_GetByID(regionarg);
 results.Dump();
 
}

// You can define other methods, fields, classes and namespaces here
// pretend that this area is imy class library BLL folder
// write my service metods

public List<Regions> Region_GetList()
{
IEnumerable<Regions> info = Regions.OrderBy(r=> r.RegionDescription);
return info.ToList();
}


//lookup the specific region  record for specified region ID

public Regions Region_GetByID( int regionID)
{

Regions info = Regions.Where(r=> r.RegionID == regionID).FirstOrDefault();

return info;
}