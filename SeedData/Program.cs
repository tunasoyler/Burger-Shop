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
                new Menu {  Name = "BBQ Burger", Price = 80, Image = ReadFile("Resources/bbq.png"), Description="180 gr. dana burger köftesi, kıtır soğan, sotelenmiş mantar, dana bacon, cheddar peyniri, BBQ sos, patates kızartması.", MenuCategory="etmenu" ,State=true},
                new Menu {  Name = "Double Burger", Price = 90, Image = ReadFile("Resources/bigmac.png"), Description="İki katmanlı özel hamburger ekmeği arasında közde marine edilmiş sığır eti köftesi, çedar peyniri, turşu, soğan, turşulu mayonez ve marul ile servis edilir.", MenuCategory="etmenu" ,State=true},
                new Menu {  Name = "Sakura 2'li Burger", Price = 100, Image = ReadFile("Resources/ikiliSakura.png"), Description="İki adet köftesiyle özel bir lezzet sunan burger. Dana köftesi, hardal, soya sosu, teriyaki sos, cheddar peyniri, marul, domates ve turşu eşliğinde servis edilir." , MenuCategory="etmenu",State=true},
                new Menu {  Name = "Sakura 3'lü Burger", Price = 120, Image = ReadFile("Resources/ucluSakura.png"), Description="Üç adet köftesiyle özel bir lezzet sunan burger. Dana köftesi, hardal, soya sosu, teriyaki sos, cheddar peyniri, marul, domates ve turşu eşliğinde servis edilir." , MenuCategory="etmenu",State=true},
                new Menu {  Name = "Doktor Burger", Price = 100, Image = ReadFile("Resources/doktor.png"), Description="Dana burger köftesi, mantar, hardal, ketchup, cheddar peyniri, marul, domates, turşu, tursu suyu ve ketçaplı özel sos ile servis edilir.", MenuCategory="etmenu",State=true },
                new Menu {  Name = "Cheese Burger", Price = 70, Image = ReadFile("Resources/cheese.png"), Description="Dana burger köftesi, cheddar peyniri, marul, domates, turşu ve klasik burger sosu ile servis edilir.", MenuCategory="etmenu" ,State=true},
                new Menu {  Name = "Doyamıyorum Menüsü", Price = 150, Image = ReadFile("Resources/doyamiyorum.png"), Description="Açlığınızı sonlandırmak için en ideal seçenek. 2 adet BBQ Burger, 2 adet tavuk kanadı, patates kızartması ve 2 adet içecek ile servis edilir.", MenuCategory="etmenu",State=true },
                new Menu {  Name = "Toplu Menü", Price = 140, Image = ReadFile("Resources/toplu.png"), Description="3 adet Cheese Burger, 3 adet tavuk kanadı, büyük boy patates kızartması ve 1 litrelik içecek ile servis edilir.", MenuCategory="etmenu",State=true },
                new Menu {  Name = "Klasik Menü", Price = 100, Image = ReadFile("Resources/klasik.png"), Description="Dana burger köftesi, marul, domates, turşu, klasik burger sosu ve patates kızartması ile servis edilir.", MenuCategory="etmenu",State=true },

                new Menu {  Name = "Fish Burger", Price = 80, Image = ReadFile("Resources/fishMenu.png"), Description="Lezzetli balık filetosu, marul, domates, turşu ve tartar sos ile servis edilir.", MenuCategory="balikmenu" ,State=true},
                new Menu {  Name = "Double Fish Burger", Price = 100, Image = ReadFile("Resources/doubleFish.png"), Description="İki katmanlı lezzetli balık filetosu, marul, domates, turşu ve tartar sos ile servis edilir", MenuCategory="balikmenu" ,State=true},

                new Menu {  Name = "Tavuk Burger", Price = 70, Image = ReadFile("Resources/tavuk.png"), Description="Tavuk göğsü, cheddar peyniri, marul, domates, turşu ve mayonez ile servis edilir.", MenuCategory="tavukmenu",State=true },
                new Menu {  Name = "Izgara Tavuk Burger", Price = 100, Image = ReadFile("Resources/izgaraTavuk.png"), Description="Izgara tavuk göğsü, cheddar peyniri, marul, domates, turşu ve baharatlı sos ile servis edilir.", MenuCategory="tavukmenu",State=true },

                new Menu {  Name = "Vegan Burger", Price = 70, Image = ReadFile("Resources/vegan.png"), Description="Vegan burger köftesi, vegan cheddar peyniri, marul, domates, turşu ve vegan mayonez ile servis edilir.", MenuCategory="veganmenu",State=true }};

            List<Extra> extras = new List<Extra>()
            {
                new Extra {  Name = "Kola",Image = ReadFile("Resources/coke.png"), Price=20, ExtraCategoryId=1,State=true},
                new Extra {  Name = "Sprite",Image = ReadFile("Resources/sprite.png"), Price=20, ExtraCategoryId=1,State=true},
                new Extra {  Name = "Fanta",Image = ReadFile("Resources/fanta.png"), Price=20, ExtraCategoryId=1,State=true},

                new Extra {  Name = "Patates Kızartması",Image = ReadFile("Resources/patates.png"),  Price=25, ExtraCategoryId=2,State=true},
                new Extra {  Name = "Tavuk",Image = ReadFile("Resources/chicken.png"),  Price=40, ExtraCategoryId=2,State=true},
                new Extra {  Name = "Soğan Halkası",Image = ReadFile("Resources/onion.png"),  Price=30, ExtraCategoryId=2,State=true},

                new Extra {  Name = "Ketçap",Image = ReadFile("Resources/ketchup.png"),  Price=5,ExtraCategoryId=3,State=true},
                new Extra {  Name = "Mayonez",Image = ReadFile("Resources/mayonnaise.png"),  Price=5,ExtraCategoryId=3,State=true},
                new Extra {  Name = "Ranch Sos",Image = ReadFile("Resources/ranch.png"),  Price=5,ExtraCategoryId=3,State=true},
                new Extra {  Name = "BBQ Sos",Image = ReadFile("Resources/bbqsauce.png"),  Price=5,ExtraCategoryId=3,State=true}
            };


            Console.WriteLine(menus.Count + " items will be added.");

            foreach (var item in menus)
            {
                MenuManager menuManager = new MenuManager(new EfMenuDal());
                menuManager.MenuAdd(item);
                Console.WriteLine("process...");
            }
            Console.WriteLine("All Menus are added.");
            foreach (var item in extras)
            {
                ExtraManager extraManager = new ExtraManager(new EfExtraDal());
                extraManager.ExtraAdd(item);
                Console.WriteLine("process...");
            }
            Console.WriteLine("All Extras are added.");


            Console.WriteLine("ALL DONE");
            Console.ReadKey();
        }
    }
}