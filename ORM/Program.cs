


using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM;
using System.Data;
using System.Net.Http.Headers;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);


//var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("Sawyer's New Department");

//var departments = departmentRepo.GetAllDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//}

var productRepo = new DapperProductRepository(conn);

Console.WriteLine("What is the name of your new product?");
var productName = Console.ReadLine();

Console.WriteLine("What is the price?");
var productPrice = double.Parse(Console.ReadLine());

Console.WriteLine("What is the category ID?");
var productID = int.Parse(Console.ReadLine());

productRepo.CreateProduct(productName, productPrice, productID);

var products = productRepo.GetAllProducts();

foreach (var item in products)
{
    Console.WriteLine(item.ProductID);
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Price);
    Console.WriteLine(item.CategoryID);
    Console.WriteLine(item.OnSale);
    Console.WriteLine(item.StockLevel);
    Console.WriteLine();
}