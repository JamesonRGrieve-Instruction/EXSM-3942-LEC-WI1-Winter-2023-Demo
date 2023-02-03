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
        static void Main(string[] args)
        {

        }
    }
}