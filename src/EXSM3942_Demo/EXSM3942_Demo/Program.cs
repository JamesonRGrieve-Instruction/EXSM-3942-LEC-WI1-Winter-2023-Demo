/*
Main Parts of the Project:

Models: Classes that "map" onto database tables.
Context: Class that describes how to connect to the database.
Application: Everything else that uses the Context and Models in order to serve database data to the user.
*/
/*
0. Ensure MariaDB is running so that when we go to connect to it, it is there to answer.
1. Ensure packages are installed (See Slide 6).
2. Generate the files for the Context and the Models. Folder structure is up to you, organize it in a way that you can find files as needed. Ensure the classes are public.
3. Inherit the context from DbContext.
4. Declare a default constructor and one that accepts DbContextOptions.
5. Declare virtual DbSets of our model types.
6. Override OnConfiguring and connect to the database.
7. Specify OnModelCreating instructions for setting up models.
*/

using EXSM3942_Demo.Data;
using EXSM3942_Demo.Data.Models;

namespace EXSM3942_Demo
{
    internal class Program
    {
        public static void CreateProduct(string name, string description, int categoryID)
        {
            using(GroceryStoreContext context = new GroceryStoreContext())
            {
                context.Products.Add(new Product() { Name = name, Description = description, CategoryID = categoryID });
                context.SaveChanges();
            }
        }
        public static void UpdateProduct(int id, string name, string description, int categoryID)
        {
            using (GroceryStoreContext context = new GroceryStoreContext())
            {
                Product toUpdate = context.Products.Where(x => x.ID == id).Single();
                toUpdate.Name = name;
                toUpdate.Description = description;
                toUpdate.CategoryID = categoryID;
                context.SaveChanges();
            }
        }
        public static void DeleteProduct(int id)
        {
            using (GroceryStoreContext context = new GroceryStoreContext())
            {
                Product toDelete = context.Products.Where(x => x.ID == id).Single();
                context.Products.Remove(toDelete);
                context.SaveChanges();
            }
        }
        public static List<Product> GetProducts()
        {
            List<Product> products;
            using (GroceryStoreContext context = new GroceryStoreContext())
            {
                products = context.Products.ToList();
            }
            return products;
        }
        public static int GetCategoryIDByName(string name)
        {
            int categoryID;
            using (GroceryStoreContext context = new GroceryStoreContext())
            {
                categoryID = context.ProductCategories.Where(x=>x.Name == name).Single().ID;
            }
            return categoryID;
        }
        public static int GetProductIDByName(string name)
        {
            int categoryID;
            using (GroceryStoreContext context = new GroceryStoreContext())
            {
                categoryID = context.Products.Where(x => x.Name == name).Single().ID;
            }
            return categoryID;
        }
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Welcome to the Grocery Store!\n1. Create Product\n2. List Products\n3. Update Product\n4. Delete Product\n0. Exit");
                Console.Write("\tPlease make a selection: ");
                input = Console.ReadLine().Trim();
                if (input == "1")
                {
                    string catName, prodName, prodDesc;
                    int catID;
                    Console.Write("Please enter a product name: ");
                    prodName = Console.ReadLine().Trim();
                    Console.Write("Please enter a product description: ");
                    prodDesc = Console.ReadLine().Trim();
                    Console.Write("Please enter a category name: ");
                    catName = Console.ReadLine().Trim();
                    catID = GetCategoryIDByName(catName);
                    CreateProduct(prodName, prodDesc, catID);
                }
                else if (input == "2")
                {
                    foreach(Product product in GetProducts())
                    {
                        Console.WriteLine($"{product.ID} - {product.Name}, {product.Description}");
                    }
                }
                else if (input == "3")
                {
                    string targetName, catName, prodName, prodDesc;
                    int catID, targetID;
                    Console.Write("Please enter a current product name: ");
                    targetName = Console.ReadLine().Trim();
                    targetID = GetProductIDByName(targetName);

                    Console.Write("Please enter the updated product name: ");
                    prodName = Console.ReadLine().Trim();
                    Console.Write("Please enter the updated product description: ");
                    prodDesc = Console.ReadLine().Trim();
                    Console.Write("Please enter the updated category name: ");
                    catName = Console.ReadLine().Trim();
                    catID = GetCategoryIDByName(catName);
                    UpdateProduct(targetID, prodName, prodDesc, catID);
                }
                else if (input == "4")
                {
                    string targetName;
                    int targetID;
                    Console.Write("Please enter a current product name: ");
                    targetName = Console.ReadLine().Trim();
                    targetID = GetProductIDByName(targetName);
                    DeleteProduct(targetID);
                }
                else if (input != "0")
                {
                    Console.WriteLine("Error, please make a valid selection.");
                }
                Console.WriteLine();
            } while (input != "0");
        }
    }
}