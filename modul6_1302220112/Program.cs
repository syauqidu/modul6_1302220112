namespace modul6_1302220112
{
    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string username;

        public SayaTubeUser(string username)
        {
            if (username == null || username.Length > 100)
            {
                throw new ArgumentException("Username maksimal 100 karakter atau NULL. ");
            }
            Random random = new Random();
            id = random.Next(10000, 99999);
            this.username = username;
            uploadedVideos = new List<SayaTubeVideo>();
        }

        public int getTotalVideoPlayCount()
        {
            int jumlah = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                jumlah = jumlah + uploadedVideos[i].getPlayCount();
            }
            return jumlah;
        }

        public void addVideo(SayaTubeVideo video)
        {
            if (video  == null)
            {
                throw new ArgumentNullException("Video tidak boleh NULL!");
            }
            uploadedVideos.Add(video);
        }

        public void printAllVideoPlayCount()
        {
            Console.WriteLine("User : " + username);
            for (int i = 0;i < uploadedVideos.Count;i++)
            {
                Console.WriteLine("Video " + (i+1) + " judul: " + uploadedVideos[i].getTitle());
            }
            Console.WriteLine("Total PlayCount: " + getTotalVideoPlayCount());
        }
    }

    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (title == null || title.Length > 200)
            {
                throw new ArgumentException("Judul video maksimal 200 karakter dan tidak boleh null. ");
            }
            this.title = title;
            Random random = new Random();
            id = random.Next(10000, 99999);
            playCount = 0;
        }

        public int getPlayCount()
        {
            return playCount;
        }

        public string getTitle()
        {
            return title;
        }
        public void increasePlayCount(int play)
        {
            if (play > 25000000 || play < 0)
            {
                throw new ArgumentOutOfRangeException("Jumlah harus diantara 0 sampai 25.000.000");
            }
            try
            {
                checked
                {
                    playCount = playCount + play;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("OverFlow Execption: " + ex.Message);
            }
        }
        
        public void printVideoDetails()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("ID Video : " + id);
            Console.WriteLine("Tittle   : " + title);
            Console.WriteLine("Pemutaran: " +  playCount);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SayaTubeUser user = new SayaTubeUser("Syauqi Dhiya Ulhaq");
                SayaTubeVideo video1 = new SayaTubeVideo("Review Film CARS 2 oleh Syauqi");
                SayaTubeVideo video2 = new SayaTubeVideo("Review Film BEARNARD BEAR oleh Syauqi");
                SayaTubeVideo video3 = new SayaTubeVideo("Review Film FINDING NEMO oleh Syauqi");
                SayaTubeVideo video4 = new SayaTubeVideo("Review Film FINDING DORI oleh Syauqi");
                SayaTubeVideo video5 = new SayaTubeVideo("Review Film AVANGER oleh Syauqi");
                SayaTubeVideo video6 = new SayaTubeVideo("Review Film JOMBI oleh Syauqi");
                SayaTubeVideo video7 = new SayaTubeVideo("Review Film JAMALISM oleh Syauqi");
                SayaTubeVideo video8 = new SayaTubeVideo("Review Film KIBLAT oleh Syauqi");
                SayaTubeVideo video9 = new SayaTubeVideo("Review Film BOLT oleh Syauqi");
                SayaTubeVideo video10 = new SayaTubeVideo("Review Film RIO 2 oleh Syauqi");

                user.addVideo(video1);
                user.addVideo(video2);
                user.addVideo(video3);
                user.addVideo(video4);
                user.addVideo(video5);
                user.addVideo(video6);
                user.addVideo(video7);
                user.addVideo(video8);
                user.addVideo(video9);
                user.addVideo(video10);

                video1.increasePlayCount(100);
                video2.increasePlayCount(120);
                video3.increasePlayCount(100);
                video4.increasePlayCount(103);
                video5.increasePlayCount(125);
                video6.increasePlayCount(100);
                video7.increasePlayCount(105);
                video8.increasePlayCount(110);
                video9.increasePlayCount(130);
                video10.increasePlayCount(120);

                video1.printVideoDetails();
                video2.printVideoDetails();
                video3.printVideoDetails();
                video4.printVideoDetails();
                video5.printVideoDetails();
                video6.printVideoDetails();
                video7.printVideoDetails();
                video8.printVideoDetails();
                video9.printVideoDetails();
                video10.printVideoDetails();

                Console.WriteLine(" ");
                user.printAllVideoPlayCount();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument Exception: " + ex.Message);
            }
           
        }
    }
}
