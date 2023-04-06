using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using MVC.Models.Context;

namespace SeedData
{
    public class Program
    {
        private readonly BurgerContext context;

        public Program(BurgerContext context)
        {
            this.context = context;
        }

        static void Main(string[] args)
        {


            static byte[] ReadFile(string sPath)
            {
                //Initialize byte array with a null value initially.
                byte[] data = null;

                //Use FileInfo object to get file size.
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes
                //to read from file.
                //In this case we want to read entire file. 
                //So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);
                fStream.Close();
                br.Close();
                return data;
            }




            List<Menu> menus = new List<Menu>() {
                new Menu {  Name = "BBQ Burger", Price = 80, Image = ReadFile("Resources/bbq.png"), Description="", MenuCategory="etmenu" },
                new Menu {  Name = "Big Mac", Price = 90, Image = ReadFile("Resources/bigmac.png"), Description="", MenuCategory="etmenu" },
                new Menu {  Name = "Sakura 2'li Burger", Price = 100, Image = ReadFile("Resources/ikiliSakura.png"), Description="" , MenuCategory="etmenu"},
                new Menu {  Name = "Sakura 3'lü Burger", Price = 120, Image = ReadFile("Resources/ucluSakura.png"), Description="" , MenuCategory="etmenu"},
                new Menu {  Name = "Doktor Burger", Price = 100, Image = ReadFile("Resources/doktor.png"), Description="", MenuCategory="etmenu" },

                new Menu {  Name = "Cheese Burger", Price = 70, Image = ReadFile("Resources/cheese.png"), Description="", MenuCategory="etmenu" },
                new Menu {  Name = "Fish Burger", Price = 80, Image = ReadFile("Resources/fishMenu.png"), Description="", MenuCategory="balikmenu" },
                new Menu {  Name = "Double Fish Burger", Price = 100, Image = ReadFile("Resources/doubleFish.png"), Description="", MenuCategory="balikmenu" },
                new Menu {  Name = "Doyamıyorum Menüsü", Price = 150, Image = ReadFile("Resources/doyamiyorum.png"), Description="", MenuCategory="etmenu" },
                new Menu {  Name = "Tavuk Burger", Price = 70, Image = ReadFile("Resources/tavuk.png"), Description="", MenuCategory="tavukmenu" },                
                new Menu {  Name = "Izgara Tavuk Burger", Price = 100, Image = ReadFile("Resources/izgaraTavuk.png"), Description="", MenuCategory="tavukmenu" },
                new Menu {  Name = "Toplu Menü", Price = 140, Image = ReadFile("Resources/toplu.png"), Description="", MenuCategory="etmenu" },
                new Menu {  Name = "Klasik Menü", Price = 100, Image = ReadFile("Resources/klasik.png"), Description="", MenuCategory="etmenu" },

                new Menu {  Name = "Vegan Burger", Price = 70, Image = ReadFile("Resources/vegan.png"), Description="", MenuCategory="veganmenu" }};




            Console.WriteLine(menus.Count + "items will be added.");
            foreach (var item in menus)
            {
                MenuManager menuManager = new MenuManager(new EfMenuDal());
                menuManager.MenuAdd(item);
                Console.WriteLine("process...");

            }
            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}