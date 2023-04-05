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
                new Menu {  Name = "Whooper", Price = 50, Image = ReadFile("~/Resources/bigmac.png"), Description="Whooper sevenlere özel." },
                new Menu {  Name = "Big Mac", Price = 70, Image = ReadFile("~/Resources/bigmac.png"), Description="Big Mac sevenlere özel." },
                new Menu {  Name = "Sakura Special", Price = 80, Image = ReadFile("~/Resources/bigmac.png"), Description="Sakura sevenlere özel." },
                new Menu {  Name = "Doktor Burger", Price = 100, Image = ReadFile("~/Resources/bigmac.png"), Description="Doktor sevenlere özel." } };


            Console.WriteLine(menus.Count);
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